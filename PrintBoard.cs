using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectChess
{
    class PrintBoard
    {
        public void Board(List<ChessPiece>piece )
        {
            var signBoard = FillBoard(piece);

            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 8; x++)
                {
                    if (signBoard[x,y] == null)
                    {
                        Console.Write("  ");
                    }   
                        Console.Write(signBoard[x,y]+"|");
                }
                Console.WriteLine();
            }
        }
        public string[,] FillBoard(List<ChessPiece> popPieces)
        {
            var board = new string[8,8];
            foreach (var piece in popPieces)
            {
                board[piece.GetPositionX, piece.GetPositionY] = piece.GetSign();
            }
            return board;
        }
    }
}
