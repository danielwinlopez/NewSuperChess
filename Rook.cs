using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewProjectChess
{
    public class Rook : ChessPiece{

        public static List<List<Position>> Moves = new List<List<Position>>();

        public Rook(int x, int y, string color)
        {
            GetPositionX = x;
            GetPositionY = y;
            this.color = color;
                                //Uppåt
            movePattern.Add(new List<Position>
            {
                new Position(0, 1),
                new Position(0, 2),
                new Position(0, 3),
                new Position(0, 4),
                new Position(0, 5),
                new Position(0, 6),
                new Position(0, 7)
            });
                                    //Neråt
            movePattern.Add(new List<Position>
            {
                new Position(0, -1),
                new Position(0, -2),
                new Position(0, -3),
                new Position(0, -4),
                new Position(0, -5),
                new Position(0, -6),
                new Position(0, -7)
            });
                                    //vänster
            movePattern.Add(new List<Position>
            {
                new Position(-1, 0),
                new Position(-2, 0),
                new Position(-3, 0),
                new Position(-4, 0),
                new Position(-5, 0),
                new Position(-6, 0),
                new Position(-7, 0)
            });
                                    //höger
            movePattern.Add(new List<Position>
            {
                new Position(1, 0),
                new Position(2, 0),
                new Position(3, 0),
                new Position(4, 0),
                new Position(5, 0),
                new Position(6, 0),
                new Position(7, 0)
            });

        }
        public override string Describe()
        {
            if (GetColor() == "White")
            {
                return "I am a White Rook, at postion "
                  + GetPositionX + ", " + GetPositionY;
            }
            else
            {
                return "I am a Black Rook, at postion "
                  + GetPositionX + ", " + GetPositionY;
            }
        }
        public override string GetChessType()// kallar på denna när man vill ha ut typen
        {
            return "Rook";
        }
        public override string GetColor()// när man vill ha ut color värdet på pjäsen kallas denna metod
        {
            return color;
        }
        public override string GetSign()
        {
            if (GetColor() == "White")
                return "wR";
            else
            {
                return "bR";
            }
        }
    }
}
