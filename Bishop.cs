using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectChess
{
    class Bishop :ChessPiece
    {
        public static List<List<Position>> Moves = new List<List<Position>>();
        public Bishop(int x, int y, string color)
        {
            GetPositionX = x;
            GetPositionY = y;
            this.color = color;

            movePattern.Add(new List<Position>
            {
                new Position(1, 1),
                new Position(2, 2),
                new Position(3, 3),
                new Position(4, 4),
                new Position(5, 5),
                new Position(6, 6),
                new Position(7, 7)
            });

            movePattern.Add(new List<Position>
            {
                new Position(1, -1),
                new Position(2, -2),
                new Position(3, -3),
                new Position(4, -4),
                new Position(5, -5),
                new Position(6, -6),
                new Position(7, -7)
            });

            movePattern.Add(new List<Position>
            {
                new Position(-1, 1),
                new Position(-2, 2),
                new Position(-3, 3),
                new Position(-4, 4),
                new Position(-5, 5),
                new Position(-6, 6),
                new Position(-7, 7)
            });

            movePattern.Add(new List<Position>
            {
                new Position(-1, -1),
                new Position(-2, -2),
                new Position(-3, -3),
                new Position(-4, -4),
                new Position(-5, -5),
                new Position(-6, -6),
                new Position(-7, -7)
            });

        }
        public override string Describe()
        {
            if (GetColor() == "White")
            {
                return "I am a White Bishop, at postion "
                  + GetPositionX + ", " + GetPositionY;
            }
            else
            {
                return "I am a Black Bishop, at postion "
                  + GetPositionX + ", " + GetPositionY;
            }
        }
        public override string GetChessType()// kallar på denna när man vill ha ut typen
        {
            return "Bishop";
        }
        public override string GetColor()// när man vill ha ut color värdet på pjäsen kallas denna metod
        {
            return color;
        }
        public override string GetSign()
        {
            if(GetColor()== "White")
                return "wB";
            else
            {
                return "bB";
            }
        }
    }
}
