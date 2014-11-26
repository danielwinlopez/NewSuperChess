using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectChess
{
    class Knight : ChessPiece
    {
        public static List<List<Position>> Moves = new List<List<Position>>();

        public Knight(int x, int y, string color)
        {
            GetPositionX = x;
            GetPositionY = y;
            this.color = color;

            movePattern.Add(new List<Position>
            {
                new Position(1, 2)
            });
            movePattern.Add(new List<Position>
            {
                new Position(1, -2)
            });
            movePattern.Add(new List<Position>
            {
                new Position(-1, 2)
            });
            movePattern.Add(new List<Position>
            {             
                new Position(-1, -2)
            });
            movePattern.Add(new List<Position>
            {
                new Position(2, 1)
            });
            movePattern.Add(new List<Position>
            {
                new Position(2, -1)
            });
            movePattern.Add(new List<Position>
            {
                new Position(-2, 1)
            });
            movePattern.Add(new List<Position>
            {
                new Position(-2, -1)
            });

        }
        public override string Describe()
        {
            if (GetColor() == "White")
            {
                return "I am a White Knight, at postion "
                  + GetPositionX + ", " + GetPositionY;
            }
            else
            {
                return "I am a Black Knight, at postion "
                  + GetPositionX + ", " + GetPositionY;
            }
        }
        public override string GetChessType() // kallar på denna när man vill ha ut typen
        {
            return "Knight";
        }
        public override string GetColor()// när man vill ha ut color värdet på pjäsen kallas denna metod
        {
            return color;
        }
        public override string GetSign()
        {
            if (GetColor() == "White")
                return "wk";
            else
            {
                return "bk";
            }
        }
    }
}
