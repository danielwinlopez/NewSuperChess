using System;
using System.Collections.Generic;
using System.Linq;
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

            int i = 0;
            while (true)
            {
                foreach (var piece in pieces.GetPieceList()) //TODO: vi måste automatisera x och y pos beroende på vilken pjäs vi skickar in så att det ökar efter pjäsens steg
                {
                    //Console.Write(moves.CheckPosition(piece.GetPositionX, 5, piece)); // här sätter vi positionerna vi vill kolla!
                    //Console.WriteLine("=" + i++);//Console.WriteLine(moves.CanMove(piece));

                    
                    piece.GetPositionX = doMove.GetBestMove(moves.PossibleMoves(piece)).x;
                    piece.GetPositionY = doMove.GetBestMove(moves.PossibleMoves(piece)).y;
                    
                    Console.ReadKey();
                    Console.Clear();
                    board.Board(pieces.GetPieceList());
                }
            
            
                
            }
        }
    }
}
