using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectChess
{
    public class PrintBoard
    {
        public void Board(List<ChessPiece>piece )
        {
            string[,] signBoard = FillBoard(piece);

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
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
            string [,] board = new string[8,8];
            foreach (var piece in popPieces)
            {
                board[piece.GetPositionX, piece.GetPositionY] = piece.GetSign();
            }
            return board;
        }
    }
}
