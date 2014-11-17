using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectChess
{
    public class Values
    {
        public int key { get; set; }
        public Position position { get; set; }

        public Values(int key, Position position)
        {
            this.key = key;
            this.position = position;
        }
    }
}
