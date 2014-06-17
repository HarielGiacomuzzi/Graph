using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class vertex
    {
        public Node node = null;
        public int weight = 0;

        public vertex(Node v, int w) {
            this.node = v;
            this.weight = w;
        }

    }
}
