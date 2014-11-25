using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewProjectChess
{
    public class Game
    {
        public Pieces pieceList;
        private Player Wplayer;
        private Player Bplayer;

        public Game()
        {
           pieceList = new Pieces();
            Wplayer = new Player("White",pieceList.GetPieceList());
            Bplayer = new Player("Black", pieceList.GetPieceList());

        }

        public void StartGame()
        {
            
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
            foreach (var chessPiece in pieceList.GetPieceList())
            {
                chessPiece.canMove = false;
                chessPiece.canKill = false;
                chessPiece.MovePositions.Clear();
            }
        }
    }
}
