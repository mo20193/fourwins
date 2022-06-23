using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourwins
{
    public class Player
    {
        public string Name { get; set; }
        public int Y { get; set; }
        public int X { get; set; }
        public int Value { get; set; }

        public Player(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
