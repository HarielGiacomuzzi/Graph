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
        public int pos = 0;
        public int mark = 0;
        public bool printMark = false;
        public string label;
        public LinkedList<Node> vizinhos = new LinkedList<Node>();

        public Node(int data, int pos, string label) {
            this.data = data;
            this.pos = pos;
            this.label = label;
        }

        public Node(int data, int pos) {
            this.data = data;
            this.pos = pos;
        }

    }
}
