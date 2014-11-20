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
            //Pieces pieces= new Pieces();
            //Print.PrintOut(pieces.GetPieceList());
            //List<Position> pos = new List<Position>();
            //Console.WriteLine();

            PrintBoard board = new PrintBoard();
            Pieces pieces = new Pieces();
            Move moves = new Move(pieces.GetPieceList());
            int i = 0;
            while (true)
            {
                foreach (var piece in pieces.GetPieceList()) //TODO: vi måste automatisera x och y pos beroende på vilken pjäs vi skickar in så att det ökar efter pjäsens steg
                {                    
                        Console.Write(moves.CheckPosition(piece.GetPositionX, 7, piece)); // här sätter vi positionerna vi vill kolla!
                        Console.WriteLine("=" + i++);//Console.WriteLine(moves.CanMove(piece));                          
                }
            pieces.setPieceList(pieces.GetPieceList());
            board.Board(pieces.GetPieceList());
            Console.ReadLine();
            }
        }
    }
}
//object possibleMoves;
//    return List < Position > possibleMoves;