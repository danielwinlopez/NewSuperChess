using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectChess
{
    public class DoMove
    {
        

        public DoMove()
        {
            
        }

        public Position SetPosition(List<List<Position>> positionList)
        {
            List<Position>list = new List<Position>();
            foreach (var positions in positionList)
            {
                Console.WriteLine(positions[0].x +" "+ positions[0].y);
                list.Add(new Position(positions[0].x,positions[0].y));
                Console.ReadKey();
            }
            return list[0];
        }




    }
}
