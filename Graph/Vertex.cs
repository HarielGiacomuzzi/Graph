using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Vertex
    {
        public Node node;
        public int value;

        public Vertex(Node n, int value) {
            this.node = n;
            this.value = value;
        }
    }
}
