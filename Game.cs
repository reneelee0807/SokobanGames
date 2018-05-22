using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;

namespace GameNS
{
    public class Game : IGame
    {
        IFiler Filer;
        private string[] Level { get; set; } //this is for load to create a map!.
        private Map Map; //creates an instance of the Map! 
        private List<Direction> PlayerMoves = new List<Direction>();
        private int MoveCount = 0;
        private List<bool> BoxMoved = new List<bool>();

        public Game(IFiler filer)
        {
            Filer = filer;
        }

        public Map GetMap()
        {
            return Map;
        }

        public MapItem FindPlayer()
        {
            return (from x in Map.Items where (x.Sign == (char)Parts.Player || x.Sign == (char)Parts.PlayerOnGoal) select x).FirstOrDefault();
            //to find the players position in the map.
            //update for to move if player on goal as well! 
        }

        public int GetColumnCount()
        {
            return Level.Length;
            //for creating array and for displaying in View Later
        }

        public int GetRowCount()
        {
            return Level[0].Length;
            //for creating array and for displaying in View Later
        }

        public int GetMoveCount()
        {
            return MoveCount;
            //to get the player moves (for display later)
        }

        public string GetMoveHistory()
        {
            string MoveHistory = "";
            int length = PlayerMoves.Count();
            if (length <= 5)
            {
                MoveHistory = string.Join(",", PlayerMoves.ToArray());
            }
            else
            {

                MoveHistory = string.Join(",", PlayerMoves.GetRange(length - 5, 5).ToArray());
            }

            return MoveHistory;
        }

        public bool IsFinished() //checks whether the game is finished or not.
                                 //should check the amount 
        {
            int boxOnGoalCount = Map.Items.Where(x => x.Sign.Equals('*')).Count();
            int GoalsCount = Map.Items.Where(x => x.Sign.Equals('.')).Count();
            int PlayerOnGoalCount = Map.Items.Where(x => x.Sign.Equals('+')).Count();

            return boxOnGoalCount >= 1 && GoalsCount == 0 && PlayerOnGoalCount == 0;
        }

        public void Load(string newLevel) //loads the level from either Filer or LevelDesigner
        {
            //if (newLevel.Contains('@') || newLevel.Contains('+'))
            //{
            //    Level = newLevel.Split(',');
            //}
            Level = Filer.Load(newLevel).Split(',');
        }

        public void Save(string fileName, GameNS.Game mockObject)
        {
            Filer.Save(fileName, mockObject);
        }

        public void Move(Direction moveDirection) //moves player
        {
            var player = this.FindPlayer();
            var x = player.CordX;
            var y = player.CordY;
            int toX = 0; //player destination
            int pastToX = 0; // other box etcs destination
            int toY = 0; //player destination
            int pastToY = 0; // other box etcs destination

            switch (moveDirection)
            {
                case Direction.Up:
                    toX = x - 1;
                    pastToX = x - 2;
                    toY = y;
                    pastToY = y;
                    break;
                case Direction.Down:
                    toX = x + 1;
                    pastToX = x + 2;
                    toY = y;
                    pastToY = y;
                    break;
                case Direction.Right:
                    toX = x;
                    pastToX = x;
                    toY = y + 1;
                    pastToY = y + 2;
                    break;
                case Direction.Left:
                    toX = x;
                    pastToX = x;
                    toY = y - 1;
                    pastToY = y - 2;
                    break;
                default:
                    break;
            }
            this.MovePlayer(player, toX, pastToX, toY, pastToY);
            this.PlayerMoves.Add(moveDirection);



        }

        private void MovePlayer(MapItem player, int toX, int afterToX, int toY, int afterToY)
        {
            if (toX >= 0) //to stop player falling off map edge
            {
                if (this.WhatsAt(toX, toY) == Parts.Empty)
                {
                    if (player.Sign == '+')
                    {
                        this.Map.Update(player.CordX, player.CordY, (char)Parts.Goal);
                    }
                    else
                    {
                        this.Map.Update(player.CordX, player.CordY, (char)Parts.Empty);
                    }
                    this.Map.Update(toX, toY, (char)Parts.Player);
                    this.BoxMoved.Add(false);
                }
                else if ((WhatsAt(toX, toY) == Parts.Block || WhatsAt(toX, toY) == Parts.BlockOnGoal) && (afterToX >= 0)) // to move a box as well
                {
                    if (WhatsAt(afterToX, afterToY) == Parts.Empty) //can move box
                    {
                        if (WhatsAt(toX, toY) == Parts.BlockOnGoal)
                        {
                            this.Map.Update(toX, toY, (char)Parts.PlayerOnGoal);
                        }
                        else
                        {
                            this.Map.Update(toX, toY, player.Sign);
                        }//new playerpos
                        this.Map.Update(afterToX, afterToY, (char)Parts.Block); //new box pos
                        this.Map.Update(player.CordX, player.CordY, (char)Parts.Empty); //old playerpos now empty
                    }
                    else if (WhatsAt(afterToX, afterToY) == Parts.Goal) // move box on goal
                    {
                        if (WhatsAt(toX, toY) == Parts.BlockOnGoal)
                        {
                            this.Map.Update(toX, toY, (char)Parts.PlayerOnGoal);
                        }
                        else
                        {
                            this.Map.Update(toX, toY, player.Sign);
                        }
                        this.Map.Update(afterToX, afterToY, (char)Parts.BlockOnGoal);
                        this.Map.Update(player.CordX, player.CordY, (char)Parts.Empty);
                    }
                    this.BoxMoved.Add(true);
                }
                else if (WhatsAt(toX, toY) == Parts.Goal) // to move player onto goal
                {
                    this.Map.Update(toX, toY, (char)Parts.PlayerOnGoal);
                    this.Map.Update(player.CordX, player.CordY, (char)Parts.Empty);
                    this.BoxMoved.Add(false);
                }
                //else they dont move / no update 
                this.MoveCount++;
            }
        }

        public void Restart()
        {
            this.Map.ResetMap(Level);
            PlayerMoves = new List<Direction> { };
            BoxMoved = new List<bool> { };
            MoveCount = 0;
        }

        public void Undo() //similar to Move, but this time, reverse needs to pull a box with it etc
        {
            var player = this.FindPlayer();
            var x = player.CordX; //this should be in Player Move maybe? and return the co-ords?
            int y = player.CordY;
            int newPosX; //players old destination
            int inFrontOfX; // checks object currently in front of player
            int newPosY; //players old destination
            int inFrontOfY; //same as xxx

            if (PlayerMoves.Count >= 1)
            {
                Direction lastMove = PlayerMoves.Last(); // may change back to string
                if (lastMove == Direction.Up) //should move down then
                {
                    newPosX = x + 1;
                    inFrontOfX = x - 1;
                    newPosY = y;
                    inFrontOfY = y;
                    UndoMove(player, newPosX, newPosY, inFrontOfX, inFrontOfY);
                }
                else if (lastMove == Direction.Down) //should move up then
                {
                    newPosX = x - 1;
                    inFrontOfX = x + 1;
                    newPosY = y;
                    inFrontOfY = y;
                    UndoMove(player, newPosX, newPosY, inFrontOfX, inFrontOfY);
                }
                else if (lastMove == Direction.Left) //should move right
                {
                    newPosY = y + 1;
                    inFrontOfY = y - 1;
                    newPosX = x;
                    inFrontOfX = x;
                    UndoMove(player, newPosX, newPosY, inFrontOfX, inFrontOfY);
                }
                else
                {
                    newPosY = y - 1;
                    inFrontOfY = y + 1;
                    newPosX = x;
                    inFrontOfX = x;
                    UndoMove(player, newPosX, newPosY, inFrontOfX, inFrontOfY); //should move left
                }
                PlayerMoves.RemoveAt(PlayerMoves.Count - 1);
                BoxMoved.RemoveAt(BoxMoved.Count - 1);
                MoveCount -= 1; //to counteract the Move Direction Count
            }
        }

        private void UndoMove(MapItem player, int newX, int newY, int inFrontX, int inFrontY)
        {

            if (((BoxMoved[BoxMoved.Count() - 1] == false) && (this.WhatsAt(inFrontX, inFrontY) == Parts.Block || WhatsAt(inFrontX, inFrontY) == Parts.BlockOnGoal)) || this.WhatsAt(inFrontX, inFrontY) == Parts.Empty || this.WhatsAt(inFrontX, inFrontY) == Parts.Wall) //if no object infront of player, just move player back
            {
                if (WhatsAt(newX, newY) == Parts.Goal) //for where player is moving
                {
                    Map.Update(newX, newY, (char)Parts.PlayerOnGoal); // to keep player sign same

                }
                else
                {
                    this.Map.Update(newX, newY, (char)Parts.Player); // update to normal player sign
                }
                this.Map.Update(player.CordX, player.CordY, (char)Parts.Empty); // replace players 'old position' to empty
            }
            else if ((WhatsAt(inFrontX, inFrontY) == Parts.Block || WhatsAt(inFrontX, inFrontY) == Parts.BlockOnGoal) && (BoxMoved[BoxMoved.Count() - 1] == true)) // to move a box back as well (if not on goal currently)
            {
                if (WhatsAt(player.CordX, player.CordY) == Parts.PlayerOnGoal) //can move box onto Goal
                {
                    //check player destination type
                    if (WhatsAt(newX, newY) == Parts.Goal) //for where player is moving
                    {
                        this.Map.Update(newX, newY, player.Sign); // to keep player sign same
                    }
                    else
                    {
                        this.Map.Update(newX, newY, (char)Parts.Player); // update to normal player sign
                    }
                    if (WhatsAt(inFrontX, inFrontY) == Parts.Block)
                    {
                        this.Map.Update(inFrontX, inFrontY, (char)Parts.Empty); //where box was, now empty
                    }
                    else
                    {
                        this.Map.Update(inFrontX, inFrontY, (char)Parts.Goal);
                    }
                    this.Map.Update(player.CordX, player.CordY, (char)Parts.BlockOnGoal); //old playerongoal now  boxongoal
                }
                else //it must be an empty space
                {
                    if (WhatsAt(newX, newY) == Parts.Goal) //for where player is moving
                    {
                        this.Map.Update(newX, newY, player.Sign); // to keep player sign same
                    }
                    else
                    {
                        this.Map.Update(newX, newY, (char)Parts.Player); // update to normal player sign
                    }
                    if (WhatsAt(inFrontX, inFrontY) == Parts.Block)
                    {
                        this.Map.Update(inFrontX, inFrontY, (char)Parts.Empty); //where box was, now empty
                    }
                    else
                    {
                        this.Map.Update(inFrontX, inFrontY, (char)Parts.Goal);
                    }
                    this.Map.Update(player.CordX, player.CordY, (char)Parts.Block); //old playerongoal now  boxongoal

                }

            }
            else if (WhatsAt(inFrontX, inFrontY) == Parts.Goal) // so goal doesnt move
            {
                if (WhatsAt(player.CordX, player.CordY) == Parts.PlayerOnGoal) //can move box onto Goal
                {
                    //check player destination type

                    this.Map.Update(player.CordX, player.CordY, (char)Parts.Goal); //old player pos now Goal

                }
                else //it must be an empty space
                {
                    this.Map.Update(player.CordX, player.CordY, (char)Parts.Empty); //old player pos now empty
                }

                if (WhatsAt(newX, newY) == Parts.Goal) //for where player is moving
                {
                    this.Map.Update(newX, newY, (char)Parts.PlayerOnGoal); // to keep player sign same
                }
                else
                {
                    this.Map.Update(newX, newY, (char)Parts.Player); // update to normal player sign //same
                }
            }

        }

        public Parts WhatsAt(int row, int column)  //returns the part from the Map
        {
            int colCount = GetColumnCount();
            var item = Map.Items[row * colCount + column];
            switch (item.Sign)
            {
                case '#':
                    return Parts.Wall;

                case '$':
                    return Parts.Block;

                case '+':
                    return Parts.PlayerOnGoal;

                case '@':
                    return Parts.Player;

                case ' ':
                    return Parts.Empty;

                case '.':
                    return Parts.Goal;

                case '*':
                    return Parts.BlockOnGoal;

                default:
                    return Parts.Empty;
            }

        }

        public List<MapItem> MakeMap() //dont need for now..
        {

            this.Map = new Map(Level);
            return Map.Items;
        }
    }
}




