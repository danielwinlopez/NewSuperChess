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
        PrintBoard board = new PrintBoard();  
        private List<ChessPiece> pieceList;
        public Values value { get; set; }
        public Move(List<ChessPiece> pieceList)
        {
            this.pieceList = pieceList;        
        }
        public void CanMove(ChessPiece piece) // metod som avgör vilket "Move" som ska tas beroende vilken pjäs den tar in
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
            
        }


        public int CheckPosition(int x, int y, ChessPiece piece)
        {

            int value = 0;
            bool empty = true;
            //bool myPiece = false; // kan vi ta bort
            bool friend = false;
            //bool enemy = false; //kan vi ta bort
            string type = null;

            foreach (var pieces in pieceList)
            {

                //if (x == piece.GetPositionX && y == piece.GetPositionY && piece.GetColor() == pieces.GetColor()) // DEN HÄR DELEN FÖRSTÖRDE 
                //{                                                                                                //ALLT MEN NU E DET BRA!!!!
                //    myPiece = true;
                //    empty = false;
                //}

                if ( x == pieces.GetPositionX && y == pieces.GetPositionY && // kollar om det står en vän på platsen vi e på
                    piece.GetColor() == pieces.GetColor())
                {
                    friend = true;
                    empty = false;
                }
                if (x == pieces.GetPositionX && y == pieces.GetPositionY && // kollar om det står en fiende på platsen vi e på
                    piece.GetColor() != pieces.GetColor())
                {
                    friend = false;
                    empty = false;
                    type = pieces.GetChessType();
                }

            }
            if (empty)
            {
                value = 0;
            }
            else if (friend)                      
            {                                
                value = -1;
            }
            else if (!friend )
            {
                switch (type) //värde på fienden
                {
                    case "Pawn":
                        value = 1;
                        break;
                    case "Bishop":
                        value = 2;
                        break;
                    case "Rook":
                        value = 3;
                        break;
                    case "Knight":
                        value = 4;
                        break;
                    case "Queen":
                        value = 6;
                        break;
                    case "King":
                        value = 10;
                        break;
                    default:
                        Console.WriteLine("Unkown piece type!");
                        // körs när något går riktigt fel                   
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error");
            }

            return value;
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
                resultVal = CheckPosition(xpos +i, i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos +i, i)));
                }

                resultVal = CheckPosition(i, ypos + i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(i, ypos+i)));
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


                resultVal = CheckPosition(xpos + i, i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos + i, i)));
                }

                resultVal = CheckPosition(i, ypos + i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(i, ypos + i)));
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
                            resultList.Add(new Values(resultVal, new Position(xpos + k, j)));
                        }
                        resultVal = CheckPosition(-k, j, piece);
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(k, j + ypos)));
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

                resultVal = CheckPosition(i, i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos +i, i)));
                }

                resultVal = CheckPosition(-i, i, piece);
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(i, i+ypos)));
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

        public List<Position> MovePawn(ChessPiece piece) // Scannar PawnMoves
        {
            bool firstMove = true;
            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
            List<Position> sortedList = new List<Position>();
            var resultList = new List<Values>(); 

            for (int i = 0; i < 2; ++i)
            {
                resultVal = CheckPosition(xpos, i, piece);
                if (resultVal != -1) 
                {
                    resultList.Add(new Values(resultVal, new Position(xpos, i)));
                }

                if (firstMove)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        resultVal = CheckPosition(xpos, j, piece);     //i en if-sats som kollar om det är första draget om första draget kontrollera om bonden kan ta två steg annars skit i denna kollen.
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos, j)));
                        }
                        firstMove = false;
                    }       
                }
                foreach (var chessPiece in pieceList)
                {  
                    //finns de någon på denna positionen av motsatt färg
                    if (xpos + 1 == chessPiece.GetPositionX && ypos + 1 == chessPiece.GetPositionY && piece.GetColor() != chessPiece.GetColor())
                    {
                        resultVal = CheckPosition(i, i, piece);
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(i, i)));
                        }
                    }

                    //finns de någon på denna positionen av motsatt färg
                    if (xpos - 1 == chessPiece.GetPositionX && ypos + 1 == chessPiece.GetPositionY && piece.GetColor() != chessPiece.GetColor())
                    resultVal = CheckPosition(-i, i, piece);
                    if (resultVal != -1)
                    {
                        resultList.Add(new Values(resultVal, new Position(-i, i)));
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
    }
}
