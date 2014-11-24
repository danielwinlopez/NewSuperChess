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
        public int CheckPosition(int x, int y, ChessPiece piece) // kollar var alla pjäser står och returnerar värde på position
        {
            int value = 0;
            bool empty = true;
           
            bool friend = false;
           
            string type = null;

            foreach (var pieces in pieceList)
            {
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
            return value;
        }
        public Values MoveRook(ChessPiece piece) // Scannar RookMoves
        {
            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
            List<Values> sortedList = new List<Values>();
            var resultList = new List<Values>(); //dictionary lista 
            bool foundEnemy = false;


            for (int i = 1; i < 8; i++)
            {
                resultVal = CheckPosition(xpos, ypos + i, piece);
                if (!foundEnemy)
                {
                    if (ypos + i > 7) // begränsing så han inte går utanför boarden
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos, ypos + i)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos, ypos + i)));
                            foundEnemy = true;
                        }
                    }
                }
                resultVal = CheckPosition(xpos + i, ypos, piece);
                if (!foundEnemy)
                {
                    if (xpos + i > 7)
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos)));
                            foundEnemy = true;
                        }
                    }
                }
                resultVal = CheckPosition(xpos - i, ypos, piece);
                if (!foundEnemy)
                {
                    if (xpos - i < 0)
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos)));
                            foundEnemy = true;
                        }
                    }
                }
                resultVal = CheckPosition(xpos, ypos - i, piece);
                if (!foundEnemy)
                {
                    if (ypos - i < 0) // begränsing så han inte går utanför boarden
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos, ypos - i)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos, ypos - i)));
                            foundEnemy = true;
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
                        sortedList.Add(new Values(item.key,new Position(item.position.x,item.position.y)));
                    }
                }
            }
            return sortedList[0];
        }
        public Values MoveBishop(ChessPiece piece) // Scannar BishopMoves
        {
            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
            List<Values> sortedList = new List<Values>();
            var resultList = new List<Values>();
            bool foundEnemy = false;

            for (int i = 1; i < 8; i++)
            {
                resultVal = CheckPosition(xpos - i, ypos - i, piece);
                if (!foundEnemy)
                {
                    if (xpos - i < 0 && ypos - i < 0) // begränsing så han inte går utanför boarden
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - i)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - i)));
                            foundEnemy = true;
                        }
                    }
                }
                resultVal = CheckPosition(xpos + i, ypos - i, piece);
                if (!foundEnemy)
                {
                    if (xpos + i > 7 && ypos - i < 0) // begränsing så han inte går utanför boarden
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - i)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - i)));
                            foundEnemy = true;
                        }
                    }
                }
                resultVal = CheckPosition(xpos + i, ypos + i, piece);
                if (!foundEnemy)
                {
                    if (xpos + i > 7 && ypos + i > 7) // begränsing så han inte går utanför boarden
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + i)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + i)));
                            foundEnemy = true;
                        }
                    }
                }
                resultVal = CheckPosition(xpos - i, ypos - i, piece);
                if (!foundEnemy)
                {
                    if (xpos - i > 0 && ypos + i > 7) // begränsing så han inte går utanför boarden
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - i)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - i)));
                            foundEnemy = true;
                        }
                    }
                }
            }
            foreach (var item in resultList)
            {
                for (int i = 10; i > -1; i--)
                {
                    if (item.key == i)
                    {
                        sortedList.Add(new Values(item.key, new Position(item.position.x, item.position.y)));
                    }
                }
            }
            return sortedList[0];
        }
        public Values MoveQueen(ChessPiece piece) // Scannar QueenMoves
        {
            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
            List<Values> sortedList = new List<Values>();
            var resultList = new List<Values>(); //dictionary lista 
            bool foundEnemy = false;

            for (int i = 0; i < 8; i++)
            {
                resultVal = CheckPosition(xpos, ypos + i, piece);
                if (!foundEnemy)
                {
                    if (ypos + i > 7) // begränsing så han inte går utanför boarden
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos, ypos + i)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos, ypos + i)));
                            foundEnemy = true;
                        }
                    }
                }
                resultVal = CheckPosition(xpos + i, ypos, piece);
                if (!foundEnemy)
                {
                    if (xpos + i > 7)
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos)));
                            foundEnemy = true;
                        }
                    }
                }
                resultVal = CheckPosition(xpos - i, ypos, piece);
                if (!foundEnemy)
                {
                    if (xpos - i < 0)
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos)));
                            foundEnemy = true;
                        }
                    }
                }
                resultVal = CheckPosition(xpos, ypos - i, piece);
                if (!foundEnemy)
                {
                    if (ypos - i < 0) // begränsing så han inte går utanför boarden
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos, ypos - i)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos, ypos - i)));
                            foundEnemy = true;
                        }
                    }
                }
                resultVal = CheckPosition(xpos - i, ypos - i, piece);
                if (!foundEnemy)
                {
                    if (xpos - i < 0 && ypos - i < 0) // begränsing så han inte går utanför boarden
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - i)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - i)));
                            foundEnemy = true;
                        }
                    }
                }
                resultVal = CheckPosition(xpos + i, ypos - i, piece);
                if (!foundEnemy)
                {
                    if (xpos + i > 7 && ypos - i < 0) // begränsing så han inte går utanför boarden
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - i)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - i)));
                            foundEnemy = true;
                        }
                    }
                }
                resultVal = CheckPosition(xpos + i, ypos + i, piece);
                if (!foundEnemy)
                {
                    if (xpos + i > 7 && ypos + i > 7) // begränsing så han inte går utanför boarden
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + i)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + i)));
                            foundEnemy = true;
                        }
                    }
                }
                resultVal = CheckPosition(xpos - i, ypos + i, piece);
                if (!foundEnemy)
                {
<<<<<<< HEAD
                    if (xpos - i < 0 && ypos + i > 7) // begränsing så han inte går utanför boarden
=======
                    if (xpos - i > 0 && ypos - i < 0) // begränsing så han inte går utanför boarden
>>>>>>> origin/master
                    {
                        resultVal = -1;
                    }
                    if (resultVal != -1)
                    {
                        if (resultVal == 0)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos + i)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos + i)));
                            foundEnemy = true;
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
        public List<Position> MoveKnight(ChessPiece piece) // Scannar KnightMoves
        {
            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
            List<Position> sortedList = new List<Position>();
            var resultList = new List<Values>(); //dictionary lista 
            bool foundEnemy = false;
            
            for (int i = 0; i < 2; i += 2)
            {
                for (int j = 0; j < 2; j++)
                {
                    resultVal = CheckPosition(xpos + i, ypos + j, piece);
                    if (!foundEnemy)
                    {
                        if (xpos + i > 7 && ypos + j > 7) // begränsing så han inte går utanför boarden
                        {
                            resultVal =  -1;
                        }
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + j)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos +  j)));
                            foundEnemy = true;
                        }
                    }
                    resultVal = CheckPosition(xpos + i, ypos - j, piece);
                    if (!foundEnemy)
                    {
                        if (xpos + i > 7 && ypos - j < 0) // begränsing så han inte går utanför boarden
                        {
                            resultVal = -1;
                        }
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - j)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - j)));
                            foundEnemy = true;
                        }
                    }
                    resultVal = CheckPosition(xpos - i, ypos + j, piece);
                    if (!foundEnemy)
                    {
                        if (xpos - i < 0 && ypos + j > 7) // begränsing så han inte går utanför boarden
                        {
                            resultVal = -1;
                        }
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos + j)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos + j)));
                            foundEnemy = true;
                        }
                    }
                    resultVal = CheckPosition(xpos - i, ypos - j, piece);
                    if (!foundEnemy)
                    {
                        if (xpos - i < 0 && ypos - j < 0) // begränsing så han inte går utanför boarden
                        {
                            resultVal = -1;
                        }
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - j)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - j)));
                            foundEnemy = true;
                        }
                    }

                    resultVal = CheckPosition(xpos + i, ypos + j, piece);
                    if (!foundEnemy)
                    {
                        if (ypos + i > 7 && xpos + j > 7) // begränsing så han inte går utanför boarden
                        {
                            resultVal = -1;
                        }
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(ypos + i, xpos + j)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(ypos + i, xpos + j)));
                            foundEnemy = true;
                        }
                    }
                    resultVal = CheckPosition(ypos + i, xpos - j, piece);
                    if (!foundEnemy)
                    {
                        if (xpos + i > 7 && ypos - j < 0) // begränsing så han inte går utanför boarden
                        {
                            resultVal = -1;
                        }
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(ypos + i, xpos - j)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(ypos + i, xpos - j)));
                            foundEnemy = true;
                        }
                    }
                    resultVal = CheckPosition(ypos - i, xpos + j, piece);
                    if (!foundEnemy)
                    {
                        if (xpos - i < 0 && ypos + j > 7) // begränsing så han inte går utanför boarden
                        {
                            resultVal = -1;
                        }
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(ypos - i, xpos + j)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(ypos - i, xpos + j)));
                            foundEnemy = true;
                        }
                    }
                    resultVal = CheckPosition(ypos - i, xpos - j, piece);
                    if (!foundEnemy)
                    {
                        if (xpos - i < 0 && ypos - j < 0) // begränsing så han inte går utanför boarden
                        {
                            resultVal = -1;
                        }
                        if (resultVal != -1)
                        {
                            resultList.Add(new Values(resultVal, new Position(ypos - i, xpos - j)));
                        }
                        else
                        {
                            resultList.Add(new Values(resultVal, new Position(ypos - i, xpos - j)));
                            foundEnemy = true;
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

            for (int i = 1; i < 2; i++)
            {
                resultVal = CheckPosition(xpos,ypos + i, piece);
                if (ypos + i > 7) // begränsing så han inte går utanför boarden
                {
                    resultVal = -1;
                }
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos, ypos + i)));
                }

                resultVal = CheckPosition(xpos+i, ypos, piece);
                if (xpos + i > 7) // begränsing så han inte går utanför boarden
                {
                    resultVal = -1;
                }
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos+i, ypos)));
                }
                resultVal = CheckPosition(xpos + i,ypos+ i, piece);
                if (xpos + i > 7 || ypos + i > 7) // begränsing så han inte går utanför boarden
                {
                    resultVal = -1;
                }
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + i)));
                }
                resultVal = CheckPosition(xpos-i, ypos+i, piece);
                if (xpos - i < 0 || ypos + i > 7) // begränsing så han inte går utanför boarden
                {
                    resultVal = -1;
                }
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos - i, ypos + i)));
                }
                resultVal = CheckPosition(xpos - i, ypos, piece);
                if (xpos - i < 0) // begränsing så han inte går utanför boarden
                {
                    resultVal = -1;
                }
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos - i, ypos)));
                }
                resultVal = CheckPosition(xpos, ypos -i, piece);
                if (ypos - i < 0) // begränsing så han inte går utanför boarden
                {
                    resultVal = -1;
                }
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos, ypos - i)));
                }
                resultVal = CheckPosition(xpos- i, ypos - i, piece);
                if (xpos - i < 0 || ypos - i < 0) // begränsing så han inte går utanför boarden
                {
                    resultVal = -1;
                }
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos -i, ypos - i)));
                }
                resultVal = CheckPosition(xpos - i, ypos - i, piece);
                if (xpos + i > 7 || ypos - i < 0) // begränsing så han inte går utanför boarden
                {
                    resultVal = -1;
                }
                if (resultVal != -1)
                {
                    resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - i)));
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
            if (piece.GetColor()=="White")
            {
                for (int i = 1; i < 2; ++i)
                {
                    resultVal = CheckPosition(xpos, ypos + i, piece);
                    if (resultVal > 0)
                    {
                        resultVal = -1;
                    }
                    if (resultVal == 0)
                    {
                        resultList.Add(new Values(resultVal, new Position(xpos, ypos + i)));
                    }

                    if (firstMove && resultVal == 0)
                    {
                        for (int j = 1; j < 3; j++)
                        {
                            resultVal = CheckPosition(xpos, ypos + j, piece);     //i en if-sats som kollar om det är första draget om första draget kontrollera om bonden kan ta två steg annars skit i denna kollen.
                            if (resultVal != -1)
                            {
                                resultList.Add(new Values(resultVal, new Position(xpos, ypos + j)));
                            }
                            firstMove = false;
                        }
                    }
                    foreach (var chessPiece in pieceList)
                    {
                        //finns de någon på denna positionen av motsatt färg
                        if (xpos + 1 == chessPiece.GetPositionX && ypos + 1 == chessPiece.GetPositionY && piece.GetColor() != chessPiece.GetColor())
                        {
                            resultVal = CheckPosition(xpos + i, ypos + i, piece);
                            if (resultVal != -1)
                            {
                                resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + i)));
                            }
                        }
                        //finns de någon på denna positionen av motsatt färg
                        if (xpos - 1 == chessPiece.GetPositionX && ypos + 1 == chessPiece.GetPositionY && piece.GetColor() != chessPiece.GetColor())
                        {
                            resultVal = CheckPosition(xpos - i, ypos + i, piece);
                            if (resultVal != -1)
                            {
                                resultList.Add(new Values(resultVal, new Position(xpos - i, ypos + i)));
                            }
                        }
                    }
                }
            }
            else // gäller för black pawn
            {
                for (int i = 1; i < 2; ++i)
                {
                    resultVal = CheckPosition(xpos, ypos - i, piece);
                    if (resultVal > 0)
                    {
                        resultVal = -1;
                    }
                    if (resultVal == 0)
                    {
                        resultList.Add(new Values(resultVal, new Position(xpos, ypos - i)));
                    }

                    if (firstMove && resultVal == 0)
                    {
                        for (int j = 1; j < 3; j++)
                        {
                            resultVal = CheckPosition(xpos, ypos - j, piece);     //i en if-sats som kollar om det är första draget om första draget kontrollera om bonden kan ta två steg annars skit i denna kollen.
                            if (resultVal != -1)
                            {
                                resultList.Add(new Values(resultVal, new Position(xpos, ypos - j)));
                            }
                            firstMove = false;
                        }
                    }
                    foreach (var chessPiece in pieceList)
                    {
                        //finns de någon på denna positionen av motsatt färg
                        if (xpos + 1 == chessPiece.GetPositionX && ypos - 1 == chessPiece.GetPositionY && piece.GetColor() != chessPiece.GetColor())
                        {
                            resultVal = CheckPosition(xpos + i, ypos - i, piece);
                            if (resultVal != -1)
                            {
                                resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - i)));
                            }
                        }
                        //finns de någon på denna positionen av motsatt färg
                        if (xpos - 1 == chessPiece.GetPositionX && ypos - 1 == chessPiece.GetPositionY && piece.GetColor() != chessPiece.GetColor())
                        {
                            resultVal = CheckPosition(xpos - i, ypos - i, piece);
                            if (resultVal != -1)
                            {
                                resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - i)));
                            }
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
    }
}
