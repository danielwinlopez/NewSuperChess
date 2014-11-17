using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectChess
{
    class DoMove
    {

        public DoMove()
        {
            Pieces pieces = new Pieces();
            Move moves = new Move(pieces.GetPieceList());
        }
    }
}
