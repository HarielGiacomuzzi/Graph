using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Vertex
    {
        public Node node = null;
        public int weight = 0;

        public Vertex(Node v, int w) {
            this.node = v;
            this.weight = w;
        }

    }
}
