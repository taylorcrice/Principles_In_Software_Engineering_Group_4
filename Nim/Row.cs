using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class Row
    {
        public int maxRowSize;
        public int numberOfPieces {get; set;}

        public Row(int numberOfPieces)
        {
            maxRowSize = numberOfPieces;
            this.numberOfPieces = numberOfPieces;
        }
    }
}
