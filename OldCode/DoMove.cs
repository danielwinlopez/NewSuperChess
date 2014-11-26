using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectChess
{
    class DoMove
    {
        //private Pieces pieces;
        //private Move moves;
        //public DoMove()
        //public Values value { get; set; }


        //{
        //    pieces = new Pieces();
        //    moves = new Move(pieces.GetPieceList(),);
        //}

        //public Position GetBestMove(List<Values> values)
        //{
        //    List<Position>positions = new List<Position>();
        //    foreach (var value in values)
        //    {
        //        for (int i = 10; i >= 0; i--)
        //        {
        //            if (value.key == i)
        //            {
        //                positions.Add(new Position(value.position.x,value.position.y));
        //            }
                    
        //        }
        //    } return new Position(positions[0].x, positions[0].y);
            
        //}


        //        public List<Values> PossibleMoves(ChessPiece piece)
        //            // metod som avgör vilket "Move" som ska tas beroende vilken pjäs den tar in
        //        {
        //            List<Values> valueList = new List<Values>();
        //            switch (piece.GetChessType())
        //            {
        //                case "Rook":
        //                    valueList.Add(MoveRook(piece));
        //                    break;
        //                case "Bishop":
        //                    valueList.Add(MoveBishop(piece));
        //                    break;
        //                case "Knight":
        //                    valueList.Add(MoveKnight(piece));
        //                    break;
        //                case "Queen":
        //                    valueList.Add(MoveQueen(piece));
        //                    break;
        //                case "King":
        //                    valueList.Add(MoveKing(piece));
        //                    break;
        //                case "Pawn":
        //                    valueList.Add(MovePawn(piece));
        //                    break;
        //                default:
        //                    Console.WriteLine("Unknown piece type!"); // körs när något går riktigt fel
        //                    break;
        //            }
        //            return valueList;
        //        }
        //        public int CheckPosition(int x, int y, ChessPiece piece)
        //            // kollar var alla pjäser står och returnerar värde på position
        //        {
        //            int value = 0;
        //            bool empty = true;
        //            bool friend = false;
        //            string type = null;

        //            foreach (var pieces in pieceList)
        //            {
        //                if (x == pieces.GetPositionX && y == pieces.GetPositionY &&
        //                    // kollar om det står en vän på platsen vi e på
        //                    piece.GetColor() == pieces.GetColor())
        //                {
        //                    friend = true;
        //                    empty = false;
        //                }
        //                if (x == pieces.GetPositionX && y == pieces.GetPositionY &&
        //                    // kollar om det står en fiende på platsen vi e på
        //                    piece.GetColor() != pieces.GetColor())
        //                {
        //                    friend = false;
        //                    empty = false;
        //                    type = pieces.GetChessType();
        //                }
        //            }
        //            if (empty)
        //            {
        //                value = 0;
        //            }
        //            else if (friend)
        //            {
        //                value = -1;
        //            }
        //            else
        //            {
        //                switch (type) //värde på fienden
        //                {
        //                    case "Pawn":
        //                        value = 1;
        //                        break;
        //                    case "Bishop":
        //                        value = 2;
        //                        break;
        //                    case "Rook":
        //                        value = 3;
        //                        break;
        //                    case "Knight":
        //                        value = 4;
        //                        break;
        //                    case "Queen":
        //                        value = 6;
        //                        break;
        //                    case "King":
        //                        value = 10;
        //                        break;
        //                    default:
        //                        Console.WriteLine("Unkown piece type!");
        //                        // körs när något går riktigt fel                   
        //                        break;
        //                }
        //            }
        //            return value;
        //        }
        //        public Values MoveRook(ChessPiece piece) // Scannar RookMoves
        //        {
        //            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
        //            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
        //            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
        //            List<Values> sortedList = new List<Values>();
        //            var resultList = new List<Values>(); //dictionary lista 
        //            bool foundEnemy = false;

        //            for (int i = 1; i < 8; i++)
        //            {
        //                resultVal = CheckPosition(xpos, i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos > 7 || xpos < 0 || ypos > 7 || ypos < 0) // begränsing så han inte går utanför boarden
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos, i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos, i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //            }
        //            for (int r = 1; r < 8; r++)
        //                {
        //                    resultVal = CheckPosition(r, ypos, piece);
        //                    if (!foundEnemy)
        //                    {
        //                        if (xpos > 7 || xpos < 0 || ypos > 7 || ypos < 0)
        //                        {
        //                            resultVal = -1;
        //                        }
        //                        if (resultVal != -1)
        //                        {
        //                            if (resultVal == 0)
        //                            {
        //                                resultList.Add(new Values(resultVal, new Position(r, ypos)));
        //                            }
        //                            else
        //                            {
        //                                resultList.Add(new Values(resultVal, new Position(r, ypos)));
        //                                foundEnemy = true;
        //                            }
        //                        }
        //                    }
        //                }                   
        //            foreach (var item in resultList)
        //            {
        //                for (int i = 10; i >= 0; i--)
        //                {
        //                    if (item.key == i)
        //                    {
        //                        sortedList.Add(new Values(item.key, new Position(item.position.x, item.position.y)));
        //                    }
        //                }
        //            }
        //            Random rnd = new Random();
        //            return sortedList[rnd.Next(0, sortedList.Count)]; // TODO fixa till rookmoves så den rör sig rätt
        //        }
        //        public Values MoveBishop(ChessPiece piece) // Scannar BishopMoves
        //        {
        //            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
        //            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
        //            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
        //            List<Values> sortedList = new List<Values>();
        //            var resultList = new List<Values>();
        //            bool foundEnemy = false;

        //            for (int i = 1; i < 8; i++)
        //            {
        //                resultVal = CheckPosition(xpos - i, ypos - i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos - i < 0 || ypos - i < 0) // begränsing så han inte går utanför boarden
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //                resultVal = CheckPosition(xpos + i, ypos - i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos + i > 7 || ypos - i < 0) // begränsing så han inte går utanför boarden
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //                resultVal = CheckPosition(xpos + i, ypos + i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos + i > 7 || ypos + i > 7) // begränsing så han inte går utanför boarden
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //                resultVal = CheckPosition(xpos - i, ypos - i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos - i < 0 || ypos + i > 7) // begränsing så han inte går utanför boarden
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos + i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos + i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //            }
        //            foreach (var item in resultList)
        //            {
        //                for (int i = 10; i > -1; i--)
        //                {
        //                    if (item.key == i)
        //                    {
        //                        sortedList.Add(new Values(item.key, new Position(item.position.x, item.position.y)));
        //                    }
        //                }
        //            }
        //            Random rnd = new Random();
        //            return sortedList[rnd.Next(0, sortedList.Count)];
        //        }
        //        public Values MoveQueen(ChessPiece piece) // Scannar QueenMoves
        //        {
        //            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
        //            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
        //            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
        //            List<Values> sortedList = new List<Values>();
        //            var resultList = new List<Values>(); //dictionary lista 
        //            bool foundEnemy = false;
        //            for (int i = 1; i < 8; i++)
        //            {
        //                resultVal = CheckPosition(xpos, i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos > 7 || xpos < 0 || i > 7 || i < 0) // begränsing så han inte går utanför boarden
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos, i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos, i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //            }
        //            for (int r = 1; r < 8; r++)
        //            {
        //                resultVal = CheckPosition(r, ypos, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (r > 7 || r < 0 || ypos > 7 || ypos < 0)
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(r, ypos)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(r, ypos)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //            }
        //            for (int i = 1; i < 8; i++)
        //            {
        //                resultVal = CheckPosition(xpos - i, ypos - i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos - i < 0 || ypos - i < 0) // begränsing så han inte går utanför boarden
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //            }
        //            for (int i = 1; i < 8; i++)
        //            {
        //                resultVal = CheckPosition(xpos + i, ypos - i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos + i > 7 || ypos - i < 0) // begränsing så han inte går utanför boarden
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //            }
        //            for (int i = 1; i < 8; i++)
        //            {
        //                resultVal = CheckPosition(xpos + i, ypos + i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos + i > 7 || ypos + i > 7) // begränsing så han inte går utanför boarden
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //            }
        //            for (int i = 1; i < 8; i++)
        //            {
        //                resultVal = CheckPosition(xpos - i, ypos + i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos - i < 0 || ypos + i > 7) // begränsing så han inte går utanför boarden                  
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos + i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos + i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //            }       
        //    foreach (var item in resultList)
        //            {
        //                for (int i = 10; i >= 0; i--)
        //                {
        //                    if (item.key == i)
        //                    {
        //                        sortedList.Add(new Values(item.key, new Position(item.position.x, item.position.y)));
        //                    }
        //                }
        //            }
        //            Random rnd = new Random();
        //            return sortedList[rnd.Next(0, sortedList.Count)];
        //        }
        //        public Values MoveKnight(ChessPiece piece) // Scannar KnightMoves
        //        {
        //            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
        //            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
        //            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
        //            List<Values> sortedList = new List<Values>();
        //            var resultList = new List<Values>(); //dictionary lista 
        //            bool foundEnemy = false;
        //            for (int i = 2; i < 4; i += 2)
        //            {
        //                for (int j = 1; j < 2; j++)
        //                {
        //                    resultVal = CheckPosition(xpos + i, ypos + j, piece);
        //                    if (!foundEnemy)
        //                    {
        //                        if (xpos + i > 7 || ypos + j > 7) // begränsing så han inte går utanför boarden
        //                        {
        //                            resultVal = -1;
        //                        }
        //                        if (resultVal != -1)
        //                        {
        //                            if (resultVal == 0)
        //                            {
        //                                resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + j)));
        //                            }
        //                            else
        //                            {
        //                                resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + j)));
        //                                foundEnemy = true;
        //                            }
        //                        }
        //                    }
        //                    resultVal = CheckPosition(xpos + i, ypos - j, piece);
        //                    if (!foundEnemy)
        //                    {
        //                        if (xpos + i > 7 || ypos - j < 0) // begränsing så han inte går utanför boarden
        //                        {
        //                            resultVal = -1;
        //                        }
        //                        if (resultVal != -1)
        //                        {
        //                            if (resultVal == 0)
        //                            {
        //                                resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - j)));
        //                            }
        //                            else
        //                            {
        //                                resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - j)));
        //                                foundEnemy = true;
        //                            }
        //                        }
        //                    }
        //                    resultVal = CheckPosition(xpos - i, ypos + j, piece);
        //                    if (!foundEnemy)
        //                    {
        //                        if (xpos - i < 0 || ypos + j > 7) // begränsing så han inte går utanför boarden
        //                        {
        //                            resultVal = -1;
        //                        }
        //                        if (resultVal != -1)
        //                        {
        //                            if (resultVal == 0)
        //                            {
        //                                resultList.Add(new Values(resultVal, new Position(xpos - i, ypos + j)));
        //                            }
        //                            else
        //                            {
        //                                resultList.Add(new Values(resultVal, new Position(xpos - i, ypos + j)));
        //                                foundEnemy = true;
        //                            }
        //                        }
        //                    }
        //                    resultVal = CheckPosition(xpos - i, ypos - j, piece);
        //                    if (!foundEnemy)
        //                    {
        //                        if (xpos - i < 0 || ypos - j < 0) // begränsing så han inte går utanför boarden
        //                        {
        //                            resultVal = -1;
        //                        }
        //                        if (resultVal != -1)
        //                        {
        //                            if (resultVal == 0)
        //                            {
        //                                resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - j)));
        //                            }
        //                            else
        //                            {
        //                                resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - j)));
        //                                foundEnemy = true;
        //                            }
        //                        }
        //                    }
        //                    for (int l = 1; l < 2; l++)
        //                    {
        //                        for (int k = 2; k < 4; k += 2)
        //                        {
        //                            resultVal = CheckPosition(xpos + l, ypos + k, piece);
        //                            if (!foundEnemy)
        //                            {
        //                                if (xpos + l > 7 || ypos + k > 7) // begränsing så han inte går utanför boarden
        //                                {
        //                                    resultVal = -1;
        //                                }
        //                                if (resultVal != -1)
        //                                {
        //                                    if (resultVal == 0)
        //                                    {
        //                                        resultList.Add(new Values(resultVal, new Position(xpos + l, ypos + k)));
        //                                    }
        //                                    else
        //                                    {
        //                                        resultList.Add(new Values(resultVal, new Position(xpos + l, ypos + k)));
        //                                        foundEnemy = true;
        //                                    }
        //                                }
        //                            }
        //                            resultVal = CheckPosition(xpos + l, ypos - k, piece);
        //                            if (!foundEnemy)
        //                            {
        //                                if (xpos + l > 7 || ypos - k < 0) // begränsing så han inte går utanför boarden
        //                                {
        //                                    resultVal = -1;
        //                                }
        //                                if (resultVal != -1)
        //                                {
        //                                    if (resultVal == 0)
        //                                    {
        //                                        resultList.Add(new Values(resultVal, new Position(xpos + l, ypos - k)));
        //                                    }
        //                                    else
        //                                    {
        //                                        resultList.Add(new Values(resultVal, new Position(xpos + l, ypos - k)));
        //                                        foundEnemy = true;
        //                                    }
        //                                }
        //                            }
        //                            resultVal = CheckPosition(xpos - l, ypos + k, piece);
        //                            if (!foundEnemy)
        //                            {
        //                                if (xpos - l < 0 || ypos + k > 7) // begränsing så han inte går utanför boarden
        //                                {
        //                                    resultVal = -1;
        //                                }
        //                                if (resultVal != -1)
        //                                {
        //                                    if (resultVal == 0)
        //                                    {
        //                                        resultList.Add(new Values(resultVal, new Position(xpos - l, ypos + k)));
        //                                    }
        //                                    else
        //                                    {
        //                                        resultList.Add(new Values(resultVal, new Position(xpos - l, ypos + k)));
        //                                        foundEnemy = true;
        //                                    }
        //                                }
        //                            }
        //                            resultVal = CheckPosition(xpos - l, ypos - k, piece);
        //                            if (!foundEnemy)
        //                            {
        //                                if (xpos - l < 0 || ypos - k < 0) // begränsing så han inte går utanför boarden
        //                                {
        //                                    resultVal = -1;
        //                                }
        //                                if (resultVal != -1)
        //                                {
        //                                    if (resultVal == 0)
        //                                    {
        //                                        resultList.Add(new Values(resultVal, new Position(xpos - l, ypos - k)));
        //                                    }
        //                                    else
        //                                    {
        //                                        resultList.Add(new Values(resultVal, new Position(xpos - l, ypos - k)));
        //                                        foundEnemy = true;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            foreach (var item in resultList)
        //            {
        //                for (int i = 10; i >= 0; i--)
        //                {
        //                    if (item.key == i)
        //                    {
        //                        sortedList.Add(new Values(item.key, new Position(item.position.x, item.position.y)));
        //                    }
        //                }
        //            }
        //            return sortedList[0];
        //        }
        //        public Values MoveKing(ChessPiece piece) // Scannar KingMoves
        //        {
        //            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
        //            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
        //            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
        //            List<Values> sortedList = new List<Values>();
        //            var resultList = new List<Values>(); //dictionary lista 
        //            bool foundEnemy = false;

        //            for (int i = 1; i < 2; i++)
        //            {
        //                resultVal = CheckPosition(xpos, ypos + i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (ypos + i > 7) // begränsing så han inte går utanför boarden
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos, ypos + i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos, ypos + i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //                resultVal = CheckPosition(xpos + i, ypos, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos + i > 7)
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //                resultVal = CheckPosition(xpos - i, ypos, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos - i < 0)
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //                resultVal = CheckPosition(xpos, ypos - i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (ypos - i < 0) // begränsing så han inte går utanför boarden
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos, ypos - i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos, ypos - i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //                resultVal = CheckPosition(xpos - i, ypos - i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos - i < 0 || ypos - i < 0) // begränsing så han inte går utanför boarden
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //                resultVal = CheckPosition(xpos + i, ypos - i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos + i > 7 || ypos - i < 0) // begränsing så han inte går utanför boarden
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //                resultVal = CheckPosition(xpos + i, ypos + i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos + i > 7 || ypos + i > 7) // begränsing så han inte går utanför boarden
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //                resultVal = CheckPosition(xpos - i, ypos + i, piece);
        //                if (!foundEnemy)
        //                {
        //                    if (xpos - i < 0 || ypos + i > 7) // begränsing så han inte går utanför boarden                  
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal != -1)
        //                    {
        //                        if (resultVal == 0)
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos + i)));
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(new Values(resultVal, new Position(xpos - i, ypos + i)));
        //                            foundEnemy = true;
        //                        }
        //                    }
        //                }
        //            }
        //            foreach (var item in resultList)
        //            {
        //                for (int i = 10; i >= 0; i--)
        //                {
        //                    if (item.key == i)
        //                    {
        //                        sortedList.Add(new Values(item.key, new Position(item.position.x, item.position.y)));
        //                    }
        //                }
        //            }
        //            Random rnd = new Random();
        //            return sortedList[rnd.Next(0, sortedList.Count)];
        //        }
        //        public Values MovePawn(ChessPiece piece) // Scannar PawnMoves
        //        {
        //            bool firstMove = true;
        //            int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
        //            int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
        //            int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
        //            List<Values> sortedList = new List<Values>();
        //            var resultList = new List<Values>();
        //            bool foundEnemy = false;
        //            if (piece.GetColor() == "White")
        //            {
        //                for (int i = 0; i < 2; i++)
        //                {
        //                    resultVal = CheckPosition(xpos, ypos + i, piece);
        //                    if (resultVal > 0)
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal == 0)
        //                    {
        //                        resultList.Add(new Values(resultVal, new Position(xpos, ypos + i)));
        //                    }
        //                    //if (firstMove && resultVal == 0)
        //                    //{
        //                    //    for (int j = 2; j < 3; j++)
        //                    //    {
        //                    //        resultVal = CheckPosition(xpos, ypos + j, piece);
        //                    //        //i en if-sats som kollar om det är första draget om första draget kontrollera om bonden kan ta två steg annars skit i denna kollen.
        //                    //        if (resultVal != -1)
        //                    //        {
        //                    //            resultList.Add(new Values(resultVal, new Position(xpos, ypos + j)));
        //                    //        }
        //                    //        firstMove = false;
        //                    //    }
        //                    //}
        //                    //finns de någon på denna positionen av motsatt färg
        //                    resultVal = CheckPosition(xpos + i, ypos + i, piece);
        //                    if (resultVal > 0)
        //                    {
        //                        resultList.Add(new Values(resultVal, new Position(xpos + i, ypos + i)));                                       
        //                    }
        //                    //finns de någon på denna positionen av motsatt färg
        //                    resultVal = CheckPosition(xpos - i, ypos + i, piece);
        //                    if (resultVal > 0)
        //                    {
        //                        resultList.Add(new Values(resultVal, new Position(xpos - i, ypos + i)));                                              
        //                    }
        //                }
        //            }
        //            else // gäller för black pawn
        //            {
        //                for (int i = 1; i < 2; i++)
        //                {
        //                    resultVal = CheckPosition(xpos, ypos - i, piece);
        //                    if (resultVal > 0)
        //                    {
        //                        resultVal = -1;
        //                    }
        //                    if (resultVal == 0)
        //                    {
        //                        resultList.Add(new Values(resultVal, new Position(xpos, ypos - i)));
        //                    }
        //                    //if (firstMove && resultVal == 0) //kollar om det är första steget för bonden för att kunna ta 2 steg
        //                    //{
        //                    //    for (int j = 2; j < 3; j++)
        //                    //    {
        //                    //        resultVal = CheckPosition(xpos, ypos - j, piece);                           
        //                    //        if (resultVal != -1)
        //                    //        {
        //                    //            resultList.Add(new Values(resultVal, new Position(xpos, ypos - j)));
        //                    //        }
        //                    //        firstMove = false;
        //                    //    }
        //                    //}
        //                    //finns de någon på denna positionen av motsatt färg
        //                    resultVal = CheckPosition(xpos + i, ypos - i, piece);
        //                    if (resultVal > 0)
        //                    {
        //                        resultList.Add(new Values(resultVal, new Position(xpos + i, ypos - i)));
        //                    }
        //                    //finns de någon på denna positionen av motsatt färg
        //                    resultVal = CheckPosition(xpos - i, ypos - i, piece);
        //                    if (resultVal > 0)
        //                    {
        //                        resultList.Add(new Values(resultVal, new Position(xpos - i, ypos - i)));
        //                    }
        //                }
        //            }           
        //            foreach (var item in resultList)
        //            {
        //                for (int i = 10; i >= 0; i--)
        //                {
        //                    if (item.key == i)
        //                    {
        //                        sortedList.Add(new Values(item.key, new Position(item.position.x, item.position.y)));                       
        //                    }
        //                 }
        //            }
        //            Random rnd = new Random();           
        //            return sortedList[rnd.Next(0, sortedList.Count)];

        //        }
    }
}
