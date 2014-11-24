using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectChess
{
    class DoMove
    {
        private Pieces pieces;
        private Move moves;
        public DoMove()
        {
            pieces = new Pieces();
            moves = new Move(pieces.GetPieceList());
        }

        public Position GetBestMove(List<Values> values)
        {
            List<Position>positions = new List<Position>();
            foreach (var value in values)
            {
                for (int i = 10; i >= 0; i--)
                {
                    if (value.key == i)
                    {
                        positions.Add(new Position(value.position.x,value.position.y));
                    }
                }
            }
            return new Position(positions[0].x,positions[0].y);
        }

    }
}
