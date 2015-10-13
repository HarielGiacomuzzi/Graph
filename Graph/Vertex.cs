using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Vertex<T>
    {
        /// <summary>
        /// Nodo del vertice
        /// </summary>
        public Node<T> node = null;

        /// <summary>
        /// Costo del vertice
        /// </summary>
        public int cost = 0;

        /// <summary>
        /// Inicializa un vertice de algun nodo asignando el costo
        /// </summary>
        /// <param name="node"></param>
        /// <param name="cost"></param>
        public Vertex(Node<T> node, int cost) {
            this.node = node;
            this.cost = cost;
        }

    }
}
