using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameNS
{
    public enum Direction { Up, Down, Left, Right };

    public interface IGame
    {
        void Move(Direction moveDirection);
        int GetMoveCount();
        void Undo();
        void Restart();
        bool IsFinished();
        void Load(string newLevel);
    }
}
