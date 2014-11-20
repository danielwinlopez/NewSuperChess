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
            Logik logic = new Logik();
            int i = 0;
            while (true)
            {
                foreach (var piece in pieces.GetPieceList())
                {

                    Console.Write(moves.CheckPosition(piece.GetPositionX, piece.GetPositionY, piece));                 
                    Console.WriteLine("="+i++);//Console.WriteLine(moves.CanMove(piece));
                }
                
            pieces.setPieceList(pieces.GetPieceList());
            board.Board(pieces.GetPieceList());
            
            Thread.Sleep(50000);
            Console.Clear();
            }
        }
    }
}
//object possibleMoves;
            //    return List < Position > possibleMoves;