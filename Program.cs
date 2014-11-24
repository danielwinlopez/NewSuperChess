using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewProjectChess
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PrintBoard board = new PrintBoard();
            Pieces pieces = new Pieces();
            Move moves = new Move(pieces.GetPieceList());
            DoMove doMove = new DoMove();
            bool whiteTurn = true;
            int i = 0;
            while (true)
            {

                List<ChessPiece> whiteList = new List<ChessPiece>();
                List<ChessPiece> blackList = new List<ChessPiece>();
  
                foreach (var piece in pieces.GetPieceList())
                {     
                    Console.Clear();
                    board.Board(pieces.GetPieceList());
                    Console.WriteLine(piece.Describe());
                    
                    piece.GetPositionX = doMove.GetBestMove(moves.PossibleMoves(piece)).x;
                    piece.GetPositionY = doMove.GetBestMove(moves.PossibleMoves(piece)).y;

                    Console.ReadKey();        
                }

                
            }

        }
    }
}

