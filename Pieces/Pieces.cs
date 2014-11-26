using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewProjectChess
{
    public class Pieces
    {
        private List<ChessPiece> pieceList = null;

        public Pieces()
        {

            pieceList = new List<ChessPiece>
            {
                //Vita Pjäser
                new Pawn(0, 1 ,"Black"),
                new Pawn(1, 1 ,"Black"),
                new Pawn(2, 1 ,"Black"),
                new Pawn(3, 1 ,"Black"),
                new Pawn(4, 1 ,"Black"),
                new Pawn(5, 1 ,"Black"),
                new Pawn(6, 1 ,"Black"),
                new Pawn(7, 1 ,"Black"),
                new Knight(6, 0, "Black"),
                new Knight(1, 0, "Black"),
                new Bishop(2, 0, "Black"),
                new Bishop(5, 0, "Black"),
                new Rook(0, 0, "Black"),
                new Rook(7, 0, "Black"),
                new Queen(4, 0, "Black"),
                new King(3, 0, "Black"),         

                ////Svarta Pjäser
                new Pawn(0, 6 ,"White"),
                new Pawn(1, 6 ,"White"),
                new Pawn(2, 6 ,"White"),
                new Pawn(3, 6 ,"White"),
                new Pawn(4, 6 ,"White"),
                new Pawn(5, 6 ,"White"),
                new Pawn(6, 6 ,"White"),
                new Pawn(7, 6 ,"White"),
                new Knight(6, 7, "White"),
                new Knight(1, 7, "White"),
                new Bishop(2, 7, "White"),
                new Bishop(5, 7, "White"),
                new Rook(7, 7, "White"),
                new Rook(0, 7, "White"),
                new Queen(3, 7, "White"),
                new King(4, 7, "White")
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
