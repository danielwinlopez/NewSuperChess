using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewProjectChess
{
    public class Pieces
    {
        private List<ChessPiece> pieceList = null;
        public Move PossibleMoves { get; set; }

        public Pieces()
        {


            pieceList = new List<ChessPiece>
            {
                //Vita Pjäser
                new Pawn(0, 1 ,"White"),
                new Pawn(1, 1 ,"White"),
                new Pawn(2, 1 ,"White"),
                new Pawn(3, 1 ,"White"),
                new Pawn(4, 1 ,"White"),
                new Pawn(5, 1 ,"White"),
                new Pawn(6, 1 ,"White"),
                new Pawn(7, 1 ,"White"),
                new Knight(6, 0, "White"),
                new Knight(1, 0, "White"),
                new Bishop(2, 0, "White"),
                new Bishop(5, 0, "White"),
                new Rook(7, 0, "White"),
                new Rook(0, 0, "White"),
                new Queen(4, 0, "White"),
                new King(3, 0, "White"),         

                //Svarta Pjäser
                new Pawn(0, 6 ,"Black"),
                new Pawn(1, 6 ,"Black"),
                new Pawn(2, 6 ,"Black"),
                new Pawn(3, 6 ,"Black"),
                new Pawn(4, 6 ,"Black"),
                new Pawn(5, 6 ,"Black"),
                new Pawn(6, 6 ,"Black"),
                new Pawn(7, 6 ,"Black"),
                new Knight(6, 7, "Black"),
                new Knight(1, 7, "Black"),
                new Bishop(2, 7, "Black"),
                new Bishop(5, 7, "Black"),
                new Rook(7, 7, "Black"),
                new Rook(0, 7, "Black"),
                new Queen(3, 7, "Black"),
                new King(4, 7, "Black")

    
            };
            
        }

        public List<ChessPiece> GetPieceList() // Metod som kallas när man vill ha ut listan
        {
            return pieceList;
        }

        public void setPieceList(List<ChessPiece> pl) // metod som kallas när listan ska uppdateras
        {
            pieceList = pl;
        }

    }
}
