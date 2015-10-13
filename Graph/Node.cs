using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Node<T>
    {
        /// <summary>
        /// Data of node
        /// </summary>
        public int data = 0;

        /// <summary>
        /// Mark of node
        /// </summary>
        public short mark = 0;

        /// <summary>
        /// PrintMark of node
        /// </summary>
        public bool printMark = false;
        
        /// <summary>
        /// Parent node if it has
        /// </summary>
        public Node<T> Father = null;

        /// <summary>
        /// Value for set distance to this node from another node
        /// </summary>
        public int distanceToMe = 0;

        /// <summary>
        /// Label for this node using as object for node
        /// </summary>
        public T label;

        /// <summary>
        /// ListOf Neighbors of this node
        /// </summary>
        public LinkedList<Vertex<T>> neighbors = new LinkedList<Vertex<T>>();

        /// <summary>
        /// Inicializa un nodo con los valores especificados
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nodeObjectGeneric"></param>
        public Node(int data, T nodeObjectGeneric) {
            this.data = data;
            this.label = nodeObjectGeneric;
        }

    }
}
