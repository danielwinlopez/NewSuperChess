using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectChess
{
    class Pawn : ChessPiece
    {


        public Pawn(int x, int y, string color)
        {
            
            GetPositionX = x;
            GetPositionY = y;
            this.color = color;
            if (GetColor() == "Black")
            {
                movePattern.Add(new List<Position>
                {
                    new Position(0, 1)
                });
                movePattern.Add(new List<Position>
                {
                    new Position(0, 2)
                });
                movePattern.Add(new List<Position>
                {
                    new Position(-1, 1)
                });
                movePattern.Add(new List<Position>
                {
                    new Position(1, 1)
                });
            }
            else
            {
                movePattern.Add(new List<Position>
                {
                    new Position(0, -1)
                });
                movePattern.Add(new List<Position>
                {
                    new Position(0, -2)
                });
                movePattern.Add(new List<Position>
                {
                    new Position(-1, -1)
                });
                movePattern.Add(new List<Position>
                {
                    new Position(1, -1)
                });
            }

        }
        public override string Describe()
        {
            if (GetColor() == "White")
            {
                return "I am a White Pawn, at postion "
                  + GetPositionX + ", " + GetPositionY;
            }
            else
            {
                return "I am a Black Pawn, at postion "
                  + GetPositionX + ", " + GetPositionY;
            }

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
            {
                return "wP";
            }
            else
            {
                return "bP";
            }
        }
    }
}
