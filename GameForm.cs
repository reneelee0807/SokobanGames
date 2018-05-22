using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameNS;
using FilerNS;

namespace SokobanExampleSolution
{
    public partial class GameForm : Form
    {
        protected GameController GameController;
        
        protected IView View;
        protected IFileable callMeBackforDetails;

        public GameForm()
        {
            InitializeComponent();
        }

        public GameForm(IView view, GameController gameController)
        {
            GameController = gameController;
            View = view;
            InitializeComponent();
            View.SetParent(this);
        }

        private void Load_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                string filename = openFileDialog1.FileName;
                //FilerControl.LoadFile(filename);
                //MessageBox.Show("You Selected " + openFileDialog1.FileName);
                //fileContent.Text = FilerControl.LoadFile(filename);


                GameController.MakeMap(filename);
                Load_btn.Enabled = false;
                //Rest_btn.Enabled = false;
                //Load_btn.Enabled = false;
                //Undo_btn.Enabled = false;
                //Start_btn.Enabled = true;
            }
           // GameController.MakeMap();
            Rest_btn.Enabled = false;
            
            Undo_btn.Enabled = false;
            Start_btn.Enabled = true;

            //GameDisplay.ColumnCount = col;

        }
        
        public void MakeTable(int col, int row, List<MapItem> theMap)
        {
            GameDisplay.ColumnCount = col;
            GameDisplay.RowCount = row;
            GameDisplay.AutoSize = true;

            foreach (MapItem m in theMap)
            {
                GameDisplay.Controls.Add(AddPic(m), m.CordY, m.CordX);
            }
        }

        private Bitmap GetImgPosition(char sign)
        {
            switch (sign)
            {
                case '#':
                    return Properties.Resources.brickwall;
                case '$':
                    return Properties.Resources.box;
                case '+':
                    return Properties.Resources.playerOnGoal;

                case '@':
                    return Properties.Resources.player;

                case ' ':
                    return Properties.Resources.background;

                case '.':
                    return Properties.Resources.goal;

                case '*':
                    return Properties.Resources.blockOnGoal;

                default:
                    return Properties.Resources.background;
            }
        }
        private PictureBox AddPic(MapItem m)
        {
            PictureBox picture = new PictureBox()
            {
                Name = "Icon" + m.CordX.ToString() + m.CordY.ToString(),
                Size = new System.Drawing.Size(40, 40),
                Image = GetImgPosition(m.Sign),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            return picture;
        }
        
        
        public void AddMoveCount(string message)
        {
            count_output.Text = message;
        }

        public void AddMoveHistory(string moveHistory)
        {
            MoveHistoryOutput.Text = moveHistory;
        }
        private void GameForm_Load(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                control.PreviewKeyDown += new PreviewKeyDownEventHandler(Control_PreviewKeyDown);
            }
        }

        private void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            Direction Move = Direction.Up;
            if (Start_btn.Enabled == false)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        Move = Direction.Up;
                        break;
                    case Keys.Down:
                        Move = Direction.Down;
                        break;
                    case Keys.Right:
                        Move = Direction.Right;
                        break;
                    case Keys.Left:
                        Move = Direction.Left;
                        break;
                }
                GameController.Move(Move);
                GameIsFinish();
            }
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {            
            Rest_btn.Enabled = true;
            count_output.Enabled = false;           
            MoveHistoryOutput.Enabled = false;
            Start_btn.Enabled = false;
            Undo_btn.Enabled = true;
            save_btn.Enabled = true;
            ActiveControl = GameDisplay;
        }
        public void UpdateMap(List<MapItem> Map)
        {
            if (Map != null)
            {
                foreach (var obj in Map)
                {
                    var test = GameDisplay.GetControlFromPosition(obj.CordY, obj.CordX);
                    GameDisplay.Controls.Remove(test);
                    GameDisplay.Controls.Add(AddPic(obj), obj.CordY, obj.CordX);
                }
                
            }

        }
        private void Undo_btn_Click(object sender, EventArgs e)
        {
            GameController.Undo();
        }
        private void Rest_btn_Click(object sender, EventArgs e)
        {
            GameController.Reset();
            Rest_btn.Enabled = false;
            Start_btn.Enabled = true;
        }

        private void GameIsFinish()
        {
            if (GameController.GameIsFinish() == true)
            {
                MessageBox.Show("You won! with " + count_output.Text + "moves" );
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                GameController.SaveFile(filename, callMeBackforDetails);
                MessageBox.Show("You file is save as " + saveFileDialog1.FileName);

            }
        }
    }
}
