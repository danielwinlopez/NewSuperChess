using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectChess
{
    public class Logik
    {
        //public Move GetCheckPosition { get; set; }

        //public List<Position> MoveRook(ChessPiece piece) // Scannar RookMoves
        //{
        //    int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
        //    int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
        //    int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
        //    List<Position> sortedList = new List<Position>();
        //    var resultList = new Dictionary<int, Position>(); //dictionary lista 

        //    for (int i = 0; i < 8; i++)
        //    {
        //        resultVal = GetCheckPosition.CheckPosition(xpos, i, piece);
        //        if (resultVal != -1) //dictionaryListan( key-värdet = resultval och 
        //        {
        //            //värdet = positionen med (xpos som x och i som y). 
        //            resultList.Add(resultVal, new Position(xpos, i));
        //            //i värdet ökar för att kolla alla y värden där x är samma
        //        }
        //        resultVal = GetCheckPosition.CheckPosition(i, ypos, piece);
        //        if (resultVal != -1) //dictionaryListan( key-värdet = resultval och 
        //        {
        //            //värdet = positionen med (x som i och y som ypos). 
        //            resultList.Add(resultVal, new Position(i, ypos));
        //            //i värdet ökar för att kolla alla x värden där y är samma
        //        }
        //        resultVal = GetCheckPosition.CheckPosition(-i, ypos, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(-i, ypos));
        //        }
        //        resultVal = GetCheckPosition.CheckPosition(xpos, -i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(xpos, -i));
        //        }
        //    }

        //    for (int i = 10; i >= 0; i--) // i är 10 eftersom 10(tidigare 300) är just nu kungens värde 
        //    {
        //        //och den ska sortera ner från högsta pjäsvärde till lägsta
        //        Position positionCoor = null;
        //        if (resultList.TryGetValue(i, out positionCoor)) // en out parameter == motsatsen till en in parameter. 
        //        {
        //            //värde sätts innanför istället för utanför metoden (kolla msdn, bra förklaring)
        //            sortedList.Add(positionCoor);
        //        }
        //    }
        //    return sortedList;
        //}

        //public List<Position> MoveBishop(ChessPiece piece) // Scannar BishopMoves
        //{
        //    int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
        //    int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
        //    int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
        //    List<Position> sortedList = new List<Position>();
        //    var resultList = new Dictionary<int, Position>();


        //    for (int i = 0; i < 8; i++)
        //    {
        //        resultVal = GetCheckPosition.CheckPosition(i, i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(i, i));
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(-i, i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(-i, i));
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(- i, - i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(-i, -i));
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(i, -i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(i, -i));
        //        }
        //    }

        //    for (int i = 10; i >= 0; i--) // i är 10 eftersom 10(tidigare 300) är just nu kungens värde 
        //    {
        //        //och den ska sortera ner från högsta pjäsvärde till lägsta
        //        Position positionCoor = null;
        //        if (resultList.TryGetValue(i, out positionCoor)) // en out parameter == motsatsen till en in parameter. 
        //        {
        //            //värde sätts innanför istället för utanför metoden (kolla msdn, bra förklaring)
        //            sortedList.Add(positionCoor);
        //        }
        //    }
        //    return sortedList;
        //}

        //public List<Position> MoveQueen(ChessPiece piece) // Scannar QueenMoves
        //{
        //    int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
        //    int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
        //    int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
        //    List<Position> sortedList = new List<Position>();
        //    var resultList = new Dictionary<int, Position>(); //dictionary lista 

        //    for (int i = 0; i < 8; i++)
        //    {
        //        resultVal = GetCheckPosition.CheckPosition(xpos, i, piece);
        //        if (resultVal != -1)  
        //        {                 
        //            resultList.Add(resultVal, new Position(xpos, i));                
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(i, ypos, piece);
        //        if (resultVal != -1) 
        //        {                 
        //            resultList.Add(resultVal, new Position(i, ypos));            
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(-i, ypos, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(-i, ypos));
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(xpos, -i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(xpos, -i));
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(i, i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(i, i));
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(-i, i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(-i, i));
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(-i, -i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(-i, -i));
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(i, -i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(i, -i));
        //        }
        //    }

        //    for (int i = 10; i >= 0; i--) // i är 10 eftersom 10(tidigare 300) är just nu kungens värde 
        //    {
        //        //och den ska sortera ner från högsta pjäsvärde till lägsta
        //        Position positionCoor = null;
        //        if (resultList.TryGetValue(i, out positionCoor)) // en out parameter == motsatsen till en in parameter. 
        //        {
        //            //värde sätts innanför istället för utanför metoden (kolla msdn, bra förklaring)
        //            sortedList.Add(positionCoor);
        //        }
        //    }
        //    return sortedList;
        //}

        //public List<Position> MoveKnight(ChessPiece piece) // Scannar KnightMoves
        //{
        //    int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
        //    int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
        //    int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
        //    List<Position> sortedList = new List<Position>();
        //    var resultList = new Dictionary<int, Position>(); //dictionary lista 

        //    for (int i = 0; i < 2; i++)
        //    {
        //        for (int j = 0; j < 2; j++)
        //        {
        //            for (int k = 0; k < 3; k++)
        //            {
        //                resultVal = GetCheckPosition.CheckPosition(k, j, piece);
        //                if (resultVal != -1)
        //                {
        //                    resultList.Add(resultVal, new Position(k, j));
        //                }
        //                resultVal = GetCheckPosition.CheckPosition(-k, j, piece);
        //                if (resultVal != -1)
        //                {
        //                    resultList.Add(resultVal, new Position(-k, j));
        //                }
        //                resultVal = GetCheckPosition.CheckPosition(k, -j, piece);
        //                if (resultVal != -1)
        //                {
        //                    resultList.Add(resultVal, new Position(k, -j));
        //                }
        //                resultVal = GetCheckPosition.CheckPosition(-k, -j, piece);
        //                if (resultVal != -1)
        //                {
        //                    resultList.Add(resultVal, new Position(-k, -j));
        //                }
        //            }
        //        }
        //        for (int j = 0; j < 3; j++)
        //        {
        //            for (int k = 0; k < 2; k++)
        //            {
        //                resultVal = GetCheckPosition.CheckPosition(k, j, piece);
        //                if (resultVal != -1)
        //                {
        //                    resultList.Add(resultVal, new Position(k, j));
        //                }
        //                resultVal = GetCheckPosition.CheckPosition(-k, j, piece);
        //                if (resultVal != -1)
        //                {
        //                    resultList.Add(resultVal, new Position(-k, j));
        //                }
        //                resultVal = GetCheckPosition.CheckPosition(k, -j, piece);
        //                if (resultVal != -1)
        //                {
        //                    resultList.Add(resultVal, new Position(k, -j));
        //                }
        //                resultVal = GetCheckPosition.CheckPosition(-k, -j, piece);
        //                if (resultVal != -1)
        //                {
        //                    resultList.Add(resultVal, new Position(-k, -j));
        //                }
        //            }
        //        }
        //    }
        //    for (int i = 10; i >= 0; i--) // i är 10 eftersom 10(tidigare 300) är just nu kungens värde 
        //    {
        //        //och den ska sortera ner från högsta pjäsvärde till lägsta
        //        Position positionCoor = null;
        //        if (resultList.TryGetValue(i, out positionCoor))
        //            // en out parameter == motsatsen till en in parameter. 
        //        {
        //            //värde sätts innanför istället för utanför metoden (kolla msdn, bra förklaring)
        //            sortedList.Add(positionCoor);
        //        }
        //    }
        //    return sortedList;
        //}
       
        //public List<Position> MoveKing(ChessPiece piece) // Scannar KingMoves
        //{
        //    int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
        //    int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
        //    int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
        //    List<Position> sortedList = new List<Position>();
        //    var resultList = new Dictionary<int, Position>(); //dictionary lista 

        //    for (int i = 0; i < 2; i++)
        //    {
        //        resultVal = GetCheckPosition.CheckPosition(xpos, i, piece);
        //        if (resultVal != -1) 
        //        {
        //            resultList.Add(resultVal, new Position(xpos, i));      
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(i, ypos, piece);
        //        if (resultVal != -1) 
        //        {                    
        //            resultList.Add(resultVal, new Position(i, ypos));                 
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(-i, ypos, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(-i, ypos));
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(xpos, -i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(xpos, -i));
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(i, i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(i, i));
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(-i, i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(-i, i));
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(-i, -i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(-i, -i));
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(i, -i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(i, -i));
        //        }
        //    }

        //    for (int i = 10; i >= 0; i--) // i är 10 eftersom 10(tidigare 300) är just nu kungens värde 
        //    {
        //        //och den ska sortera ner från högsta pjäsvärde till lägsta
        //        Position positionCoor = null;
        //        if (resultList.TryGetValue(i, out positionCoor)) // en out parameter == motsatsen till en in parameter. 
        //        {
        //            //värde sätts innanför istället för utanför metoden (kolla msdn, bra förklaring)
        //            sortedList.Add(positionCoor);
        //        }
        //    }
        //    return sortedList;
        //}

        //public List<Position> MovePawn(ChessPiece piece) // Scannar PawnMoves
        //{
        //    int xpos = piece.GetPositionX; //sätter pjäsens x värde till xpos
        //    int ypos = piece.GetPositionY; //sätter pjäsens y värde till ypos
        //    int resultVal = -1; // står för om en pjäs med samma färg står på positionen så man inte kan gå dit
        //    List<Position> sortedList = new List<Position>();
        //    var resultList = new Dictionary<int, Position>(); //dictionary lista 

        //    for (int i = 0; i < 2; i++)
        //    {
        //        resultVal = GetCheckPosition.CheckPosition(xpos, i, piece);
        //        if (resultVal != -1) //dictionaryListan( key-värdet = resultval och 
        //        {                     
        //            resultList.Add(resultVal, new Position(xpos, i));
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(xpos, i + 1, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(xpos, i + 1));
        //        }
 
        //        resultVal = GetCheckPosition.CheckPosition(i, i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(i, i));
        //        }

        //        resultVal = GetCheckPosition.CheckPosition(-i, i, piece);
        //        if (resultVal != -1)
        //        {
        //            resultList.Add(resultVal, new Position(-i, i));
        //        }
        //    }
        //    for (int i = 10; i >= 0; i--) // i är 10 eftersom 10(tidigare 300) är just nu kungens värde 
        //    {
        //        //och den ska sortera ner från högsta pjäsvärde till lägsta
        //        Position positionCoor = null;
        //        if (resultList.TryGetValue(i, out positionCoor)) // en out parameter == motsatsen till en in parameter. 
        //        {
        //            //värde sätts innanför istället för utanför metoden (kolla msdn, bra förklaring)
        //            sortedList.Add(positionCoor);
        //        }
        //    }
        //    return sortedList;
        //}
    }
}