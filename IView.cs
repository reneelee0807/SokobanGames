using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameNS;

namespace SokobanExampleSolution
{
    public interface IView
    {
        void SetParent(GameForm Form);
        void UpdateMap(List<MapItem> Map);
        void MakeTable(int col, int row, List<MapItem> theMap);
        void GetGameStats(int num, string moveHistory);

        //void WinCondition();
    }
}
