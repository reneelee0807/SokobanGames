using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerNS
{
    public interface IFiler
    {
        void Save(string filename, GameNS.Game callMeBackforDetails);
        string Load(string filename);
    }
}