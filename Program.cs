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
            Game game = new Game();
            game.StartGame();          
        }
    }
}



// Belongs to the old code
//PrintBoard board = new PrintBoard();
//DoMove doMove = new DoMove();
//Pieces pieceList = new Pieces();
//while (true)
//{                                            

//foreach (var piece in pieceList.GetPieceList())
//{
//    //piece.GetPositionX = doMove.GetBestMove(moves.PossibleMoves(piece)).x;
//    //piece.GetPositionY = doMove.GetBestMove(moves.PossibleMoves(piece)).y;
//    //Console.ReadKey();
//}

//}

