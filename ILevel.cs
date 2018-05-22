using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;
using System.Drawing;

namespace LevelDesignNS
{
    public interface ILevel
    {
        void CreateLevel(int width, int height);
        int GetLevelWidth();
        int GetLevelHeight();
        void AddBlock(int gridX, int gridY);
        void AddPlayer(int gridX, int gridY);
        void AddWall(int gridX, int gridY);
        void AddGoal(int gridX, int gridY);
        void AddEmpty(int gridX, int gridY);
        void AddBlockOnGoal(int gridX, int gridY);
        void AddPlayerOnGoal(int gridX, int gridY);
        Parts GetPartAtIndex(int gridX, int gridY);
        void SaveMe();
        bool CheckValid();
    }
}
