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
                               
            Moves.Add(new List<Position>
            {
                new Position(1, 2)
            });                            
            Moves.Add(new List<Position>
            {
                new Position(1, -2)
            });                                   
            Moves.Add(new List<Position>
            {
                new Position(-1, 2)
            });                                   
            Moves.Add(new List<Position>
            {             
                new Position(-1, -2)
            });
            Moves.Add(new List<Position>
            {
                new Position(2, 1)
            });
            Moves.Add(new List<Position>
            {
                new Position(2, -1)
            });
            Moves.Add(new List<Position>
            {
                new Position(-2, 1)
            });
            Moves.Add(new List<Position>
            {
                new Position(-2, -1)
            });

        }

        public override string Describe()
        {
            return "I am a Knight, at postion "
                   + GetPositionX + ", " + GetPositionY;
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
