using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectChess
{
    class Pawn : ChessPiece
    {
        public static List<List<Position>> Moves = new List<List<Position>>();

        public Pawn(int x, int y, string color)
        {
            GetPositionX = x;
            GetPositionY = y;
            this.color = color;

            Moves.Add(new List<Position>
            {
                new Position(0, 1)
            });       
            Moves.Add(new List<Position>
            {
                new Position(0, 2)
            });                            
            Moves.Add(new List<Position>
            {
                new Position(-1, 1)
            });                                   
            Moves.Add(new List<Position>
            {
                new Position(1, 1)
            });                                   


        }

        public override string Describe()
        {
            return "I am a Pawn, at postion "
                   + GetPositionX + ", " + GetPositionY;
        }

        public override string GetChessType()// kallar på denna när man vill ha ut typen
        {
            return "Pawn";
        }

        public override string GetColor()// när man vill ha ut color värdet på pjäsen kallas denna metod
        {
            return color;
        }
        public override string GetSign()
        {
            if (GetColor() == "White")
                return "wP";
            else
            {
                return "bP";
            }
        }
    }
}
