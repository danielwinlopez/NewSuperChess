using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace NewProjectChess
{   
    public class Move
    {
        public Logik logic { get; set; }
        private List<ChessPiece> pieceList;
        public Values value { get; set; }
        public Move(List<ChessPiece> pl)
        {
            pieceList = pl;
        }
        public bool CanMove(ChessPiece piece) // metod som avgör vilket "Move" som ska tas beroende vilken pjäs den tar in
        {
            switch (piece.GetChessType())
            {
                case "Rook":
                    MoveRook(piece);
                    break;
                case "Bishop":
                    MoveBishop(piece);
                    break;
                case "Knight":
                    MoveKnight(piece);
                    break;
                case "Queen":
                    MoveQueen(piece);
                    break;
                case "King":
                    MoveKing(piece);
                    break;
                case "Pawn":
                    MovePawn(piece);
                    break;
                default:
                    Console.WriteLine("Unknown piece type!"); // körs när något går riktigt fel
                    break;
            }
            return false;
        }

        //private List<Position> MoveRook(ChessPiece piece) // logik för rookmove
        //{
        //    int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
        //    int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
        //    int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
        //    List<Position> sortedList = new List<Position>();
        //    var resultList = new List<Values>();(); //dictionary lista 

        //    for (int i = 0; i < 8; i++)
        //    {
        //        resultVal = CheckPosition(xpos, i, piece);
        //        if (resultVal != -1)                                  //dictionaryListan( key-värdet = resultval och 
        //        {                                                     //värdet = positionen med (xpos som x och i som y). 
        //            resultList.Add(new Values(resultVal, new Position(xpos, i)); //i värdet ökar för att kolla alla y värden där x är samma
        //        }
        //        resultVal = CheckPosition(i, ypos, piece);
        //        if (resultVal != -1)                                  //dictionaryListan( key-värdet = resultval och 
        //        {                                                     //värdet = positionen med (x som i och y som ypos). 
        //            resultList.Add(new Values(resultVal, new Position(i, ypos)); //i värdet ökar för att kolla alla x värden där y är samma
        //        }                                                    
        //    }
        //    for (int i = 0; i > -8; i--)
        //    {
        //        resultVal = CheckPosition(xpos, i, piece);
        //        if (resultVal != -1)                                  //dictionaryListan( key-värdet = resultval och 
        //        {                                                     //värdet = positionen med (xpos som x och i som y). 
        //            resultList.Add(new Values(resultVal, new Position(xpos, i)); //i värdet ökar för att kolla alla y värden där x är samma
        //        }
        //        resultVal = CheckPosition(i, ypos, piece);
        //        if (resultVal != -1)                                  //dictionaryListan( key-värdet = resultval och 
        //        {                                                     //värdet = positionen med (x som i och y som ypos). 
        //            resultList.Add(new Values(resultVal, new Position(i, ypos)); //i värdet ökar för att kolla alla x värden där y är samma
        //        }
        //    }                                              
        //    for (int i = 10; i >= 0; i--)    // i är 10 eftersom 10(tidigare 300) är just nu kungens värde 
        //    {                                //och den ska sortera ner från högsta pjäsvärde till lägsta
        //        Position positionCoor = null;
        //        if (resultList.TryGetValue(i, out positionCoor)) // en out parameter == motsatsen till en in parameter. 
        //        {                                                //värde sätts innanför istället för utanför metoden (kolla msdn, bra förklaring)
        //            sortedList.Add(positionCoor);
        //        }
        //    }
        //    return sortedList;
        //}

        public int CheckPosition(int x, int y, ChessPiece piece) 
        {
           int Value = -1;
            foreach (var pieces in pieceList)
            {
                if (x != pieces.GetPositionX && 
                    y != pieces.GetPositionY)
                {
                     Value = 0; //ledig plats
                }
                else if (x == pieces.GetPositionX &&
                         y != pieces.GetPositionY)
                {
                    Value = 0; //ledig plats
                }
                else if (x != pieces.GetPositionX &&
                         y == pieces.GetPositionY)
                {
                    Value = 0; //ledig plats
                }
                else if (x == pieces.GetPositionX && // upptagen plats av samma färg
                         y == pieces.GetPositionY && 
                         piece.GetColor() == pieces.GetColor())
                {
                     Value = -1; //kan inte gå på egen färg
                }
                else if (x == pieces.GetPositionX && // upptagen plats av annan färg
                         y == pieces.GetPositionY &&
                         piece.GetColor() != pieces.GetColor())
                {
                    switch (pieces.GetChessType()) //värde på fienden
                    {
                        case "Pawn":
                            Value = 1;
                            break;
                        case "Bishop":
                            Value = 2;
                            break;
                        case "Rook":
                            Value = 3;
                            break;
                        case "Knight":
                            Value = 4;
                            break;
                        case "Queen":
                            Value = 6;
                            break;
                        case "King":
                            Value = 10;
                            break;
                        default:
                            Console.WriteLine("Unkown piece type!");
                                // körs när något går riktigt fel                   
                            break;
                    }
                }
            }
            return Value;
        }
        public List<Position> MovePawn(ChessPiece piece) // Scannar PawnMoves
        {
            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
            List<Position> sortedList = new List<Position>();
            var resultList = new List<Values>(); //dictionary lista 

            for (int i = 0; i < 2; ++i)
            {
                resultVal = CheckPosition(xpos, i, piece);
                if (resultVal != -1) //dictionaryListan( key-värdet = resultval och 
                {
                    resultList.Add(new Values(resultVal, new Position(xpos, i)));
                }

                resultVal = CheckPosition(xpos, i + 1, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos, i + 1)));
                }

                resultVal = CheckPosition(i, i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(i, i)));
                }

                resultVal = CheckPosition(-i, i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(-i, i)));
                }
            }

            foreach (var item in resultList)
            {
                for (int i = 10; i >= 0; i--)
                {
                    if (item.key == i)
                    {
                        sortedList.Add(item.position);
                    }
                }
            }
            return sortedList;
        }
        public List<Position> MoveKnight(ChessPiece piece) // Scannar KnightMoves
        {
            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
            List<Position> sortedList = new List<Position>();
            var resultList = new List<Values>(); //dictionary lista 

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        resultVal = CheckPosition(k, j, piece);
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(k, j)));
                        }
                        resultVal = CheckPosition(-k, j, piece);
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(-k, j)));
                        }
                        resultVal = CheckPosition(k, -j, piece);
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(k, -j)));
                        }
                        resultVal = CheckPosition(-k, -j, piece);
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(-k, -j)));
                        }
                    }
                }
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        resultVal = CheckPosition(k, j, piece);
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(k, j)));
                        }
                        resultVal = CheckPosition(-k, j, piece);
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(-k, j)));
                        }
                        resultVal = CheckPosition(k, -j, piece);
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(k, -j)));
                        }
                        resultVal = CheckPosition(-k, -j, piece);
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(-k, -j)));
                        }
                    }
                }
            }
            foreach (var item in resultList)
            {
                for (int i = 10; i >= 0; i--)
                {
                    if (item.key == i)
                    {
                        sortedList.Add(item.position);
                    }
                }
            }
            return sortedList;
        }
        public List<Position> MoveBishop(ChessPiece piece) // Scannar BishopMoves
        {
            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
            List<Position> sortedList = new List<Position>();
            var resultList = new List<Values>();

            for (int i = 1; i < 8; i++)
            {
                resultVal = CheckPosition(i, i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(i, i)));
                }

                resultVal = CheckPosition(-i, i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(-i, i)));
                }

                resultVal = CheckPosition(-i, -i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(-i, -i)));
                }

                resultVal = CheckPosition(i, -i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(i, -i)));
                }
            }

            foreach (var item in resultList)
            {
                for (int i = 10; i > -1; i--)
                {
                    if (item.key == i)
                    {
                        sortedList.Add(item.position);
                    }
                }
            }
            return sortedList;
        }
        public List<Position> MoveRook(ChessPiece piece) // Scannar RookMoves
        {
            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
            List<Position> sortedList = new List<Position>();
            var resultList = new List<Values>(); //dictionary lista 

            for (int i = 0; i < 8; i++)
            {
                resultVal = CheckPosition(xpos, i, piece);
                if (resultVal != -1) 
                {                   
                    resultList.Add(new Values(resultVal, new Position(xpos, i)));                   
                }

                resultVal = CheckPosition(i, ypos, piece);
                if (resultVal != -1) 
                {                  
                    resultList.Add(new Values(resultVal, new Position(i, ypos)));                 
                }

                resultVal = CheckPosition(-i, ypos, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(-i, ypos)));
                }
                resultVal = CheckPosition(xpos, -i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos, -i)));
                }
            }

            foreach (var item in resultList)
            {
                for (int i = 10; i >= 0; i--)
                {
                    if (item.key == i)
                    {
                        sortedList.Add(item.position);
                    }
                }
            }
            return sortedList;
        }
        public List<Position> MoveQueen(ChessPiece piece) // Scannar QueenMoves
        {
            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
            List<Position> sortedList = new List<Position>();
            var resultList = new List<Values>(); //dictionary lista 

            for (int i = 0; i < 8; i++)
            {
                resultVal = CheckPosition(xpos, i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos, i)));
                }

                resultVal = CheckPosition(i, ypos, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(i, ypos)));
                }

                resultVal = CheckPosition(-i, ypos, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(-i, ypos)));
                }

                resultVal = CheckPosition(xpos, -i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos, -i)));
                }

                resultVal = CheckPosition(i, i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(i, i)));
                }

                resultVal = CheckPosition(-i, i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(-i, i)));
                }

                resultVal = CheckPosition(-i, -i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(-i, -i)));
                }

                resultVal = CheckPosition(i, -i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(i, -i)));
                }
            }

            foreach (var item in resultList)
            {
                for (int i = 10; i >= 0; i--)
                {
                    if (item.key == i)
                    {
                        sortedList.Add(item.position);
                    }
                }
            }
            return sortedList;
        }
        public List<Position> MoveKing(ChessPiece piece) // Scannar KingMoves
        {
            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
            List<Position> sortedList = new List<Position>();
            var resultList = new List<Values>(); //dictionary lista 

            for (int i = 0; i < 2; i++)
            {
                resultVal = CheckPosition(xpos, i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos, i)));
                }

                resultVal = CheckPosition(i, ypos, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(i, ypos)));
                }

                resultVal = CheckPosition(-i, ypos, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(-i, ypos)));
                }

                resultVal = CheckPosition(xpos, -i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos, -i)));
                }

                resultVal = CheckPosition(i, i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(i, i)));
                }

                resultVal = CheckPosition(-i, i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(-i, i)));
                }

                resultVal = CheckPosition(-i, -i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(-i, -i)));
                }

                resultVal = CheckPosition(i, -i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(i, -i)));
                }
            }

            foreach (var item in resultList)
            {
                for (int i = 10; i >= 0; i--)
                {
                    if (item.key == i)
                    {
                        sortedList.Add(item.position);
                    }
                }
            }
            return sortedList;
        }
    }
}
