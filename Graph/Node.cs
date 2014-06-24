using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Node
    {
        public int data = 0;
        public short mark = 0;
        public bool printMark = false;
        public string label;
        public LinkedList<vertex> neighbors = new LinkedList<vertex>();

        public Node(int data, string label) {
            this.data = data;
            this.label = label;
        }

    }
}
