using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewProjectChess
{
    public class ChessPiece
    {
        protected string color;
        public int GetPositionX { get; set; }
        public int GetPositionY { get; set; }
        public virtual string Describe()
        {
            return "I am at position " + GetPositionX + ", " + GetPositionY;
        }
        public virtual string GetChessType()
        {
            return "Chesspiece type should be written here.";
        }
        public virtual string GetColor()
        {
            return "Color should be written here.";
        }
        public virtual string GetSign()
        {
            return "chesstype sign";
        }
    }
}