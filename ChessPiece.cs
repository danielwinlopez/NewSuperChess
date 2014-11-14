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
//public int CurrentPosition
//{
//    get
//    {
//        throw new System.NotImplementedException();
//    }
//    set
//    {
//    }
//}
//public void ChangePosition()
//{
//    // This method will have to get activated after the NewPosition() has calculated the best move "new position".
//    //And then move the piece, change the Currentposition property to the new position.
//}
//public void NewPostion()
//{
//    throw new System.NotImplementedException();
//}