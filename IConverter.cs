using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FilerNS
{
    public interface IConverter
    {
        string Expanded { get; }
        string Compressed { get; }
        string Compress(string uncompressedLevel);
        string Expand(string uncompressedLevel);
    }
}
