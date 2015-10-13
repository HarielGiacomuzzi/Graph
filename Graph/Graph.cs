using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Graph
{
    public class Graph<T>
    {
        /// <summary>
        /// Objeto que almacena a todos los nodos
        /// </summary>
        LinkedList<Node<T>> nodes = new LinkedList<Node<T>>();

        /// <summary>
        /// Inicializa el grafo sin ningun elemento | Initialize the graph without any element
        /// </summary>
        public Graph() { }

        /// <summary>
        /// Añade un nuevo nodo en el grafo sin ningun vertice | Add a new Node in the Graph without any connection to it.
        /// </summary>
        /// <param name="label">Node label</param>
        /// <param name="data">Node data</param>
        public void addNode(T label, int data)
        {
            nodes.AddLast(new Node<T>(data, label));
        }

        /// <summary>
        /// Añade un nuevo Nodo en el grafo sin ningun vertice y con un valor de nodo igual a 0
        /// Add a new Node in the Graph without any connection to it and with node data equals 0
        /// </summary>
        /// <param name="label">Nodo object [Generics] | Element T [Generics] </param>
        public void addNode(T label)
        {
            addNode(label, 0);
        }

        /// <summary>
        /// Crea un nuevo vertice sin direccion entre el nodo u y el nodo v con un costo de 0
        /// Create a new NON directed vertex from node u to v with weight 0
        /// </summary>
        /// <param name="u">Node object [Generic]</param>
        /// <param name="v">Node object [Generic]</param>
        public void addNonDirectedVertex(T u, T v)
        {
            addNonDirectedVertex(u, v, 0);
        }

        /// <summary>
        /// Crea un nuevo vertice sin direccion entre el nodo u y el nodo v con un costo especificado
        /// Create a new NON directed vertex from node u to v with the specified cost
        /// </summary>
        /// <param name="u">Node object [Generic]</param>
        /// <param name="v">Node object [Generic]</param>
        /// <param name="cost"></param>
        public void addNonDirectedVertex(T u, T v, int cost)
        {
            Node<T> x = null, y = null;
            foreach (Node<T> a in nodes)
            {
                if (a.label.Equals(u))
                {
                    x = a;
                }
                if (a.label.Equals(v))
                {
                    y = a;
                }
            }
            if (x == null || y == null)
            {
                return;
            }
            x.neighbors.AddLast(new Vertex<T>(y, cost));
            y.neighbors.AddLast(new Vertex<T>(x, cost));
        }

        /// <summary>
        /// Regresa un string con los vecinos de un objet node [Generic]
        /// Returns a string with the neihbors of a node u [Generic]
        /// </summary>
        /// <param name="u">Object node [Generic]</param>
        /// <returns>string</returns>
        public string neighbors(T u)
        {
            StringBuilder result = new StringBuilder();
            foreach (Node<T> a in nodes)
            {
                if (a.label.Equals(u))
                {
                    foreach (Vertex<T> b in a.neighbors)
                    {
                        result.Append(" " + b.node.label.ToString());
                    }
                    return result.ToString();
                }
            }
            return result.ToString();
        }

        /*
         * <summary>
         * Creates a new Directed vertex from node u to node v.
         * </summary>
         * 
         * <param name="u">Node Name from</param>
         * <param name="v">Node Name to</param>
         */

        /// <summary>
        /// Crea un nuevo vertice con direccion del nodo u al nodo v
        /// Creates a new Directed vertex from node u to node v.
        /// </summary>
        /// <param name="u">Node Object [Generic] From</param>
        /// <param name="v">Node Object [Generic] To</param>
        public void addDirectedVertex(T u, T v)
        {
            addDirectedVertex(u, v, 0);
        }

        /*
         * <summary>Create a new directed vertex from node u to node v with the specified vertex</summary>
         * <param name="u">Node name from</param>
         * <param name="v">Node name to</param>
         * <param name="weigth">Weight of the vertex</param>
         */

        /// <summary>
        /// Crea un nuevo vertice con direccion del nodo u al nodo v con el costo especifico de nodo a nodo
        /// Create a new directed vertex from node u to node v with the specified vertex cost
        /// </summary>
        /// <param name="u">Node Object [Generic] From</param>
        /// <param name="v">Node Object [Generic] To</param>
        /// <param name="cost">Cost of path</param>
        public void addDirectedVertex(T u, T v, int weigth)
        {
            Node<T> x = null, y = null;
            foreach (Node<T> a in nodes)
            {
                if (a.label.Equals(u))
                {
                    x = a;
                }
                if (a.label.Equals(v))
                {
                    y = a;
                }
            }
            if (x == null || y == null)
            {
                return;
            }
            x.neighbors.AddLast(new Vertex<T>(y, weigth));
        }

        /*
         * <summary>Check if there's a way of going from node u to node v</summary>
         * <param name="u">Node name</param>
         * <param name="v">Node name</param>
         */

        /// <summary>
        /// Checa si hay un camido de el objeto nodo u al objeto nodo v
        /// Check if there's a way of going from node u to node v
        /// </summary>
        /// <param name="u">Node object [Generic]</param>
        /// <param name="v">Node object [Generic]</param>
        /// <returns></returns>
        public bool hasConnection(T u, T v)
        {
            if (hasDirectConection(u, v)) return true;
            foreach (Node<T> a in nodes)
            {
                if (a.label.Equals(u))
                {
                    foreach (Vertex<T> b in a.neighbors)
                    {
                        if (hasDirectConection(b.node.label, v)) return true;
                    }
                    break;
                }
            }

            return true;
        }

        /*
         * Clear all the marks from all nodes in the graph
         */

        /// <summary>
        /// Limpiar todas las marcas de los nodos del grafo
        /// Clear all the marks from all nodes in the graph
        /// </summary>
        private void clearAllMarks()
        {
            foreach (Node<T> a in nodes)
            {
                a.mark = 0;
            }
        }
        /*
         * <summary>Returns the Count of Components in a Graph </summary>
         */
        
        /// <summary>
        /// Regresa el numero de elementos en el grafo
        /// </summary>
        /// <returns>Int count</returns>
        public int Count()
        {
            clearAllMarks();
            int count = 0;
            foreach (Node<T> a in nodes)
            {
                if (a.mark == 0)
                {
                    DFSWalk(a.label);
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Regresa una lista de todos los nodos que pueden ser buscados desde u a v
        /// Returns a list of all nodes who can be reached from u and v
        /// </summary>
        /// <param name="u">Node object [Generic]</param>
        /// <param name="v">Node object [Generic]</param>
        /// <returns></returns>
        public List<Node<T>> CanReach(T u, T v)
        {
            List<Node<T>> list = new List<Node<T>>();
            Node<T> a = getNodeByName(u);
            Node<T> b = getNodeByName(v);
            string result = "";

            if (a != null && b != null)
            {
                clearAllMarks();
                LinkedList<T> ReahcA = CanIReach(a, new LinkedList<T>());
                clearAllMarks();
                LinkedList<T> ReahcB = CanIReach(b, new LinkedList<T>());
                foreach (T x in ReahcA)
                {
                    foreach (T y in ReahcB)
                    {
                        if (x.Equals(y))
                        {
                            list.Add(new Node<T>(0,y));
                            result = result + y.ToString();
                        }
                    }
                }
                return list;
            }
            return null;
        }

        /// <summary>
        /// Regresa una lista con los T [Generic] objects de todos los nodos que pueden ser buscados desde u
        /// </summary>
        /// <param name="u"></param>
        /// <param name="reach"></param>
        /// <returns></returns>
        private LinkedList<T> CanIReach(Node<T> u, LinkedList<T> reach)
        {
            u.mark = 1;
            reach.AddLast(u.label);
            foreach (Vertex<T> a in u.neighbors)
            {
                if (a.node.mark == 0)
                {
                    CanIReach(a.node, reach);
                }
            }
            return reach;
        }
        
        /// <summary>
        /// Inicia todos los valores para el aloritmo de dijkstra y tambien para el algoritmo de bellmanford
        /// Start all the values for the Dijkstra Algorithm and also for the Algorithm of Bellman-Ford
        /// </summary>
        /// <param name="start">Nodo de partida</param>
        private void initializePathFinder(Node<T> start)
        {
            foreach (Node<T> a in nodes)
            {
                if (a == start)
                {
                    a.distanceToMe = 0;
                }
                else
                {
                    a.distanceToMe = int.MaxValue;
                }
                a.Father = null;
                a.mark = 0;
            }
        }

        /// <summary>
        /// Returns the lowest distance node in the list.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        private Node<T> Lowest(LinkedList<Node<T>> l)
        {
            int lowest = int.MaxValue;
            Node<T> lower = null;
            foreach (Node<T> a in l)
            {
                if (a.distanceToMe < lowest && a.mark == 0) { lower = a; }
            }
            return lower;
        }

        /// <summary>
        /// relaxes a vertex btween Nodes u & v
        /// </summary>
        /// <param name="u">Node u</param>
        /// <param name="v">Node v</param>
        /// <param name="weight">Cost</param>
        /// <returns>bool</returns>
        private bool relax(Node<T> u, Node<T> v, int weight)
        {
            if (v.distanceToMe > u.distanceToMe + weight)
            {
                v.distanceToMe = u.distanceToMe + weight;
                v.Father = u;
                return true;
            }
            return false;
        }

        /*
         * <summary> Returns a string with the less weight path from a node u to a node v using the djikstra algorithm
         * <param name="u">Node name from</param>
         * <param name="v">Node name to</param>
         */

        /// <summary>
        /// Regresa una lista de Nodos T con el menor costo del camino del nodo u al nodo v usando el algoritmo dijkstra
        /// </summary>
        /// <param name="u">Node object [Generic]</param>
        /// <param name="v">Node object [Generic]</param>
        /// <returns>lista de nodos</returns>
        public List<Node<T>> DijkstraList(T u, T v)
        {
            List<Node<T>> nodeway = new List<Node<T>>();
            // sets the distance from all nodes to "infinite" and the distance of the starting node to 0
            initializePathFinder(getNodeByName(u));
            Node<T> x = null;
            while (true)
            {
                // get's the node with the lower distance and without a processing mark.
                x = Lowest(nodes);
                if (x == null)
                {
                    break;
                }
                x.mark = 1;
                foreach (Vertex<T> a in x.neighbors)
                {
                    // check if the actual distance to the node is higher than the distance of this node + the vertex btween them.
                    relax(x, a.node, a.cost);
                }
            }

            // at this point the paths are already calculated now just creating the string to the user.
            Node<T> Finish = getNodeByName(v);
            Node<T> Start = getNodeByName(u);
            if (Start == null)
            {
                throw new Exception("Node Start not exists | El nodo de inicio no existe\nObject u: " + u.ToString());
            }

            if (Finish == null)
            {
                throw new Exception("Node Finish not exists | El nodo de destino no existe\nObject v: " + v.ToString());
            }

            String aux = "";
            int path = Finish.distanceToMe;
            int total = Finish.distanceToMe;
            while (Finish != null)
            {
                nodeway.Add(Finish);
                aux = " -> " + Finish.label + aux;
                // by using the father parameter of the nodes we can rebuild the path until we get the starting node
                Finish = Finish.Father;
            }

            IEnumerable<Node<T>> reverse = nodeway.Reverse<Node<T>>();
            nodeway = reverse.ToList<Node<T>>();
            return nodeway;
        }

        /// <summary>
        /// Regresa un string con la ruta del nodo u al nodo v con menor costo
        /// </summary>
        /// <param name="u">Node object [Generic]</param>
        /// <param name="v">Node object [Generic]</param>
        /// <returns></returns>
        public string DijkstraString(T u, T v)
        {
            List<Node<T>> nodeway = DijkstraList(u, v);
            // at this point the paths are already calculated now just creating the string to the user.
            Node<T> Finish = getNodeByName(v);
            Node<T> Start = getNodeByName(u);
            string aux = "";
            int path = Finish.distanceToMe;
            int total = Finish.distanceToMe;
            while (Finish != null)
            {
                aux = " -> " + Finish.label.ToString() + aux;
                // by using the father parameter of the nodes we can rebuild the path until we get the starting node
                Finish = Finish.Father;
            }
            return aux + " Total Distance: " + path;
        }

        /// <summary>
        /// Return a string with the result of a Depth-first search (DFS). Return a empty string if the starting Node is invalid.
        /// </summary>
        /// <param name="u">Starting node name</param>
        /// <returns></returns>
        public string DFSWalk(T u)
        {
            clearAllMarks();
            Node<T> start = getNodeByName(u);
            if (start == null)
            {
                return "";
            }
            return DFSWalk(start, "");
        }

        /// <summary>
        /// Return a stringBuilder with the result of a Depth-first search (DFS).
        /// </summary>
        /// <param name="u">Starting node name</param>
        /// <param name="aux"></param>
        /// <returns></returns>
        private string DFSWalk(Node<T> u, string aux)
        {
            aux = aux + " " + u.label.ToString();
            u.mark = 1;
            foreach (Vertex<T> a in u.neighbors)
            {
                if (a.node.mark == 0)
                {
                    aux = (DFSWalk(a.node, aux));
                }
            }
            return aux;
        }


        /// <summary>
        /// Return a string with the result of a breadth-first search (BFS). Return a empty string if the starting node is invalid.
        /// </summary>
        /// <param name="u">Starting node name</param>
        /// <returns></returns>
        public List<Node<T>> BFSWalk(T u)
        {
            clearAllMarks();
            // setting up some things
            //String aux;
            LinkedList<Node<T>> list = new LinkedList<Node<T>>();
            List<Node<T>> nodeway = new List<Node<T>>();
            Node<T> start = getNodeByName(u);
            // checking if the node isn't null
            if (start == null)
            {
                return null;
            }
            //start the walking
            //aux = start.label;
            start.mark = 1;
            list.AddLast(start);
            while (list.Count != 0)
            {
                Node<T> v = list.First();
                list.RemoveFirst();
                foreach (Vertex<T> a in v.neighbors)
                {
                    if (a.node.mark == 0)
                    {
                        //aux = aux + " " + a.node.label;
                        a.node.mark = 1;
                        list.AddLast(a.node);
                        nodeway.Add(a.node);
                    }
                }
            }
            return nodeway;
        }

        public List<Node<T>> BFSWalkList(T u)
        {
            clearAllMarks();
            // setting up some things
            //T aux;
            LinkedList<Node<T>> list = new LinkedList<Node<T>>();
            List<Node<T>> nodeway = new List<Node<T>>();
            Node<T> start = getNodeByName(u);
            // checking if the node isn't null
            if (start == null)
            {
                return null;
            }
            //start the walking
            //aux = start.label;
            start.mark = 1;
            list.AddLast(start);
            nodeway.Add(start);
            while (list.Count != 0)
            {
                Node<T> v = list.First();
                list.RemoveFirst();
                foreach (Vertex<T> a in v.neighbors)
                {
                    if (a.node.mark == 0)
                    {
                        //aux = aux + " " + a.node.label;
                        a.node.mark = 1;
                        list.AddLast(a.node);
                        nodeway.Add(a.node);
                    }
                }
            }
            return nodeway;
        }

        /// <summary>
        /// Returns a reference to a node bey seacrh for it's label.
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        private Node<T> getNodeByName(T u)
        {
            foreach (Node<T> a in nodes)
            {
                if (a.label.Equals(u))
                {
                    return a;
                }
            }
            return null;
        }

        /// <summary>
        /// Check if the node v is neighbor of node u.
        /// </summary>
        /// <param name="u">Node starting</param>
        /// <param name="v">Node to finish</param>
        /// <returns></returns>
        private bool hasDirectConection(T u, T v)
        {
            foreach (Node<T> a in nodes)
            {
                if (a.label.Equals(u))
                {
                    foreach (Vertex<T> b in a.neighbors)
                    {
                        if (b.node.label.Equals(v))
                        {
                            return true;
                        }
                    }
                    break;
                }
            }
            return false;
        }
        
        /*
        /// <summary>
        /// Creates a text file for use in GraphViz
        /// </summary>
        /// <param name = "directed" > Is this a directed Graph?</param>
        /// <param name = "where" > Path to save the file</param>
        public void CreateGraphVizFile(string where, bool directed)
        {
            CreateGraphVizFile(where, directed, "MyGraph");
        }
        */

        /*
        public void CreateGraphVizFile(T where, bool directed, T name)
        {
            StreamWriter writer = new StreamWriter(where, false);

            if (directed)
            {
                writer.WriteLine("digraph " + name + " {\nrankdir = LR;\nnode [\nshape = ellipse,\nstyle = filled,\ncolor = \"#000000\",\nfillcolor = \"#FFFFFF\"];\n");
                foreach (Node a in nodes)
                {
                    writer.WriteLine(a.label + "[label=\"Node: " + a.label + "\\nValor: " + a.data + "\"]");
                    foreach (Vertex b in a.neighbors)
                    {
                        writer.WriteLine(a.label + " -> " + b.node.label + " [label=\"" + b.weight + "\"];");
                    }
                }

                writer.WriteLine("}");
                writer.Close();
            }

            else
            {
                writer.WriteLine("graph " + name + " {\nrankdir = LR;\nnode [\nshape = ellipse,\nstyle = filled,\ncolor = \"#000000\",\nfillcolor = \"#FFFFFF\"];\n");
                foreach (Node<T> a in nodes)
                {
                    writer.WriteLine(a.label + "[label=\"Node: " + a.label + "\\nValor: " + a.data + "\"]");
                    foreach (Vertex<T> b in a.neighbors)
                    {
                        if (!b.node.printMark)
                        {
                            writer.WriteLine(a.label + " -- " + b.node.label + " [label=\"" + b.weight + "\"];");
                        }
                    }
                    a.printMark = true;
                }

                writer.WriteLine("}");
                writer.Close();
            }
        }
        */
    }
}