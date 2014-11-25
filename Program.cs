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


            Game game = new Game();
            //DoMove doMove = new DoMove();
            // bool whiteTurn = true;

            while (true)
            {
                //List<ChessPiece> whiteList = new List<ChessPiece>();
                //List<ChessPiece> blackList = new List<ChessPiece>();                   
                Console.Clear();
                board.Board(game.pieceList.GetPieceList());
                Console.ReadKey();
                game.WhiteTurn();
                Console.Clear();
                board.Board(game.pieceList.GetPieceList());
                Console.ReadKey();
                game.BlackTurn();
                Console.Clear();
                board.Board(game.pieceList.GetPieceList());
                Console.Clear();
                board.Board(game.pieceList.GetPieceList());

                //piece.GetPositionX = doMove.GetBestMove(moves.PossibleMoves(piece)).x;
                //piece.GetPositionY = doMove.GetBestMove(moves.PossibleMoves(piece)).y;



            }
        }
    }
}

