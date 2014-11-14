using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectChess
{
    public class Values
    {
        private int key;
        private Position position;

        public Values(int key, Position position)
        {
            this.key = key;
            this.position = position;
        }
    }
}
