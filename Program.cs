using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewProjectChess
{
    class Program
    {
        static void Main(string[] args)
        {
            
            PrintBoard board = new PrintBoard();
            Pieces pieces = new Pieces();
            Move moves = new Move(pieces.GetPieceList());
            DoMove doMove = new DoMove();
            bool whiteTurn = true;

            int i = 0;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                List<ChessPiece> whiteList = new List<ChessPiece>();
                List<ChessPiece> blackList = new List<ChessPiece>();
                foreach (var piece in pieces.GetPieceList()) //TODO: vi måste automatisera x och y pos beroende på vilken pjäs vi skickar in så att det ökar efter pjäsens steg
                {
                    Console.Clear();
                    board.Board(pieces.GetPieceList());
                    Console.WriteLine(piece.Describe());
                    
                    piece.GetPositionX = doMove.GetBestMove(moves.PossibleMoves(piece)).x;
                    piece.GetPositionY = doMove.GetBestMove(moves.PossibleMoves(piece)).y;


                    Console.WriteLine();
                    Console.ReadKey();
                    
                }
            pieces.setPieceList(pieces.GetPieceList());
            board.Board(pieces.GetPieceList());
            Console.ReadLine();
            }
        }
    }
}
