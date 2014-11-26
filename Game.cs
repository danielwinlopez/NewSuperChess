using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewProjectChess
{
    public class Game
    {
        public Pieces PieceList;
        private Player Wplayer;
        private Player Bplayer;
        private PrintBoard printBoard;

        public Game()
        {
            printBoard = new PrintBoard();
           PieceList = new Pieces();
            Wplayer = new Player("White",PieceList.GetPieceList());
            Bplayer = new Player("Black", PieceList.GetPieceList());

        }

        public void StartGame()
        {
            while (true)
            {
                printBoard.Board(PieceList.GetPieceList());
                Console.ReadKey();
                WhiteTurn();
                printBoard.Board(PieceList.GetPieceList());
                Console.ReadKey();
                BlackTurn();
                printBoard.Board(PieceList.GetPieceList());
            }
        }

        public void BlackTurn()
        {
            Bplayer.move.AnalyzePieces();
            Bplayer.GetMove();
            clearAll();
            
        }

        public void WhiteTurn()
        {
            Wplayer.move.AnalyzePieces();
            Wplayer.GetMove();
            clearAll();
        }

        public void clearAll()
        {
            foreach (var chessPiece in PieceList.GetPieceList())
            {
                chessPiece.canMove = false;
                chessPiece.canKill = false;
                chessPiece.MovePositions.Clear();
            }
        }
    }
}
