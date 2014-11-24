using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectChess
{
    internal class King : ChessPiece
    {
        public static List<List<Position>> Moves = new List<List<Position>>();

        public King(int x, int y, string color)
        {
            GetPositionX = x;
            GetPositionY = y;
            this.color = color;
            //Uppåt
            Moves.Add(new List<Position>
            {
                new Position(0, 1),

            }); //Neråt
            Moves.Add(new List<Position>
            {
                new Position(0, -1),

            }); //vänster
            Moves.Add(new List<Position>
            {
                new Position(-1, 0),

            }); //höger
            Moves.Add(new List<Position>
            {
                new Position(1, 0),

            });
            Moves.Add(new List<Position>
            {
                new Position(1, 1),

            });
            Moves.Add(new List<Position>
            {
                new Position(1, -1),

            });
            Moves.Add(new List<Position>
            {
                new Position(-1, 1),

            });
            Moves.Add(new List<Position>
            {
                new Position(-1, -1),

            });

        }
        public override string Describe()
        {
            if (GetColor() == "White")
            {
                return "I am a White King, at postion "
                  + GetPositionX + ", " + GetPositionY;
            }
            else
            {
                return "I am a Black King, at postion "
                  + GetPositionX + ", " + GetPositionY;
            }
        }
        public override string GetChessType() // kallar på denna när man vill ha ut typen
        {
            return "King";
        }
        public override string GetColor() // när man vill ha ut color värdet på pjäsen kallas denna metod
        {
            return color;
        }
        public override string GetSign()
        {
            if (GetColor() == "White")
                return "wK";
            else
            {
                return "bK";
            }
        }
    }
}
