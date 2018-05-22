using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNS;
using FilerNS;

namespace SokobanExampleSolution
{
    public class GameController
    {
        //public IView View;
        protected Game Game;
        protected IView View;
        protected string leveltext = "#########,#-------#,#---$---#,#---@---#,#---.---#,#-------#,#----$--#,#--.----#,#########";
        //protected string leveltext = "#####,#...#,#$$$#,#@--#,#####";
        //protected string leveltext = "#####,#...#,#$$$#,#@--#,#--##,----#,#-$$-,#..--";

        private List<MapItem> Map;

        public GameController(Game game, IView view)
        {
            Game = game;
            View = view;
        }

        public void MakeMap(string filename)
        {
            Game.Load(filename);
            Map = Game.MakeMap();
            int col = Game.GetColumnCount();
            int row = Game.GetRowCount();
            View.MakeTable(col, row, Map);
        }

        public void Reset()
        {
            Game.Restart();
            Map = Game.GetMap().Items;
            View.UpdateMap(Map);
            Game.GetMap().Updates = new List<MapItem>();
            View.GetGameStats(Game.GetMoveCount(), Game.GetMoveHistory());

        }

        public void Undo()
        {
            Game.Undo();
            Map = Game.GetMap().Updates;
            View.UpdateMap(Map);
            Game.GetMap().Updates = new List<MapItem>();
            View.GetGameStats(Game.GetMoveCount(), Game.GetMoveHistory());

        }

        public void Move(Direction move)
        {
            if (Game.IsFinished() == false)
            {
                Game.Move(move);
                Map = Game.GetMap().Updates;
                View.UpdateMap(Map);
                Game.GetMap().Updates = new List<MapItem>();
                View.GetGameStats(Game.GetMoveCount(), Game.GetMoveHistory());
            }
           
        }

        public bool GameIsFinish()
        {
            if (Game.IsFinished() == true)
            {
                return true;
            }
            else
            {
                return false;
            }  
        }

        //public void SaveGame(string filename, Game, callMeBackforDetails)
        //{
        //    Game.Save(filename, callMeBackforDetails);
        //}
        public void SaveFile(string fileName, IFileable callMeBackforDetails)
        {
            var mockObject = Game;
            Game.Save(fileName, mockObject);
        }

    }
}