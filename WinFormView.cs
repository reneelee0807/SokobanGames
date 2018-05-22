using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameNS;

namespace SokobanExampleSolution
{
    class WinFormView : IView
    {
        protected GameForm GameForm;
       
        public void SetParent(GameForm Form)
        {
            GameForm = Form;
        }

        public void UpdateMap(List<MapItem> Map)
        {
            GameForm.UpdateMap(Map);
        }
        public void MakeTable(int col, int row, List<MapItem> theMap)
        {
            GameForm.MakeTable(col, row, theMap);
        }
        public void GetGameStats(int num, string moveHistory)
        {
            GameForm.AddMoveCount(num.ToString());
            GameForm.AddMoveHistory(moveHistory);
        }

        //public void WinCondition()
        //{
        //    MessageBox.Show("You won! "); ;
        //}


        //public void Out(string message)
        //{
        //    throw new NotImplementedException();
        //}
        //public string GetIn(string prompt)
        //{
        //    return prompt; 
        //}


    }
}
