using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewProjectChess
{
    public class Print
    {
        public static void PrintOut(List<ChessPiece> pieces )
        {
            foreach (var chessPiece in pieces)
            {
                Console.WriteLine(chessPiece.Describe());
            }
        }

    }
}
