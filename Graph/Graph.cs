using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Graph
{
    public class Graph
    {
        LinkedList<Node> nodes = new LinkedList<Node>();
        
        /**
         * <summary>Initializes a Graph without any element on it.</summary>
         * **/
        public Graph() { }

        /**
         * <summary>
         * Add a new Node in the Graph without any connection to it.
         * </summary>
         * 
         * <param name="label">Node label</param>
         * <param name="data">Node data</param>
         * **/
        public void addNode(string label, int data)
        {
            nodes.AddLast(new Node(data,label));
        }
        /**
         * <summary>Add a new Node in the Graph without any connection to it and with node data equals 0.</summary>
         * <param name="label">Node Label</param>         * 
         * **/
        public void addNode(string label)
        {
            addNode(label,0);
        }
        /**
         * <summary>Create a new NON directed vertex from node u to v with weight 0</summary>
         * <param name="u">Node name</param>
         * <param name="v">Node name</param>
         * **/
        public void addNonDirectedVertex(string u, string v)
        {
            addNonDirectedVertex(u, v, 0);
        }
        /**
         * <summary>Create a new NON directed vertex from node u to v with the specified weight</summary>
         * <param name="u">Node name</param>
         * <param name="v">Node name</param>
         * <param name="weigth">Weight of the vertex</param>
         * **/
        public void addNonDirectedVertex(string u, string v,int weigth)
        {
            Node x = null, y = null;
            foreach (Node a in nodes)
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
            x.neighbors.AddLast(new Vertex(y, weigth));
            y.neighbors.AddLast(new Vertex(x, weigth));
        }
        /**
         * <summary>Returns a string with the neihbors of a node u</summary>
         * <returns>String with all neighbors of the Node u</returns>
         * <param name="u">Node name</param>
         * **/
        public String neighbors(string u)
        {
            StringBuilder result = new StringBuilder();
            foreach (Node a in nodes) {
                if (a.label.Equals(u)) {
                    foreach (Vertex b in a.neighbors)
                    {
                        result.Append(" " + b.node.label);
                    }
                    return result.ToString();
                }            
            }            
            return result.ToString();
        }
        /**
         * <summary>
         * Creates a new Directed vertex from node u to node v.
         * </summary>
         * 
         * <param name="u">Node Name from</param>
         * <param name="v">Node Name to</param>
         **/
        public void addDirectedVertex(string u, string v)
        {
            addDirectedVertex(u, v, 0);
        }
        /**
         * <summary>Create a new directed vertex from node u to node v with the specified vertex</summary>
         * <param name="u">Node name from</param>
         * <param name="v">Node name to</param>
         * <param name="weigth">Weight of the vertex</param>
         * **/
        public void addDirectedVertex(string u, string v,int weigth)
        {
            Node x = null, y = null;
            foreach (Node a in nodes)
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
            x.neighbors.AddLast(new Vertex(y, weigth));
        }
        /**
         * <summary>Check if there's a way of going from node u to node v</summary>
         * <param name="u">Node name</param>
         * <param name="v">Node name</param>
         * **/
        public bool hasConnection(string u, string v) {
            if (hasDirectConection(u, v)) return true;
            foreach (Node a in nodes) {
                if (a.label.Equals(u)) {
                    foreach (Vertex b in a.neighbors)
                    {
                        if (hasDirectConection(b.node.label, v)) return true;
                    }
                    break;
                }
            }

            return true;
        }

        /**
         * Clear all the marks from all nodes in the graph
         * **/
        private void clearAllMarks(){
    	     foreach (Node a in nodes){
    		     a.mark = 0;
    	    }    	 
        }
        // start all the values for the Dijkstra Algorithm and also for the Algorithm of Bellman-Ford
        private void initializePathFinder(Node start) {
            foreach (Node a in nodes) { 
                if (a == start){
                    a.distanceToMe = 0;
                    a.Father = null;
                }
                a.Father = null;
                a.distanceToMe = 999999999;
            }
        }

        //Returns the lowest distance node in the list.
        private Node Lowest(LinkedList<Node> l) {
            int lowest = 999999999;
            Node lower = null;
            foreach (Node a in l) {
                if (a.distanceToMe < lowest) { lower = null; }
            }
            return lower;
        }

        //relaxes a vertex btween Nodes u & v
        private void relax(Node u, Node v, int weight) {
            if (v.distanceToMe > u.distanceToMe + weight) {
                v.distanceToMe = u.distanceToMe + weight;
                v.Father = u;
            }
        }

        public String Dijkstra(String u, String v) {
            initializePathFinder(getNodeByName(u));
            LinkedList<Node> list = nodes;
            while (list.Count != 0) {
                Node x = Lowest(list);
                foreach (Vertex a in x.neighbors) {
                    relax(x, a.node,a.weight);
                }
            }

            Node Finish = getNodeByName(v);
            Node Start = getNodeByName(u);
            //TODO:finish this code to ereturn the path btween U & v with the less weight using the Father atribute.
            return u;
        }
        /**
         * <summary>Return a string with the result of a Depth-first search (DFS). Return a empty string if the starting Node is invalid.</summary>
         * <param name="u">Starting node name</param>
         * **/
        public String DFSWalk(String u)
        {
            clearAllMarks();
            Node start = getNodeByName(u);
            if (start == null)
            {
                return "";
            }
            return DFSWalk(start, new StringBuilder()).ToString();
        }

        // Return a stringBuilder with the result of a Depth-first search (DFS).
        private StringBuilder DFSWalk(Node u, StringBuilder aux)
        {
    	    aux.Append(u.label);
    	    u.mark = 1;
    	    foreach(Vertex a in u.neighbors){
    		 if(a.node.mark == 0){
    			 aux = (DFSWalk(a.node, aux));
    		 }
    	    }    	 
    	 return aux;
        }
        /**
         * <summary>Return a string with the result of a breadth-first search (BFS). Return a empty string if the starting node is invalid.</summary>
         * <param name="u">Starting node name</param>
         * **/
        public String BFSWalk(String u){
    	    clearAllMarks();
    	 // setting up some things
    	    StringBuilder aux = new StringBuilder();    	 
    	    LinkedList<Node> list = new LinkedList<Node>();
    	    Node start = getNodeByName(u);
    	    // checking if the node isn't null
    	    if (start == null ){
    		    return "";
    	    }
    	 //start the walking
    	    aux.Append(start.label);
    	    start.mark = 1;
    	    list.AddLast(start);
    	    while(list.Count != 0){
                Node v = list.First();
                list.RemoveFirst();
    		    foreach(Vertex a in v.neighbors){
    			    if (a.node.mark == 0){
    				    aux.Append(" "+a.node.label);
    				    a.node.mark = 1;
    				    list.AddLast(a.node);
    			    }    			 
    		    }
    	    }
    	     return aux.ToString();
         }     

        /**
         * Returns a reference to a node bey seacrh for it's label.
         * **/
        private Node getNodeByName(String u){
    	    foreach(Node a in nodes){
        		if (a.label.Equals(u)){
    			    return a;
    		    } 
    	    }
    	    return null;
        }    

        /**
         * check if the node v is neighbor of node u.
         * **/
        private bool hasDirectConection(string u, string v)
        {
            foreach (Node a in nodes) {
                if (a.label.Equals(u))
                {
                    foreach (Vertex b in a.neighbors)
                    {
                        if (b.node.label.Equals(v)) {
                            return true;                    
                        }
                    }
                    break;
                }
            }
            return false;
        }
        /**
         * <summary>Creates a text file for use in GraphViz</summary>
         * <param name="directed">Is this a directed Graph ?</param>
         * <param name="where">Path to save the file</param>
         * **/
        public void CreateGraphVizFile(string where, bool directed)
        {
            CreateGraphVizFile(where, directed, "MyGraph");
        }
        /**
         * <summary>Creates a text file for use in GraphViz</summary>
         * <param name="directed">Is this a directed Graph ?</param>
         * <param name="where">Path to save the file</param>
         * <param name="name">The Graph name</param>
         * **/
        public void CreateGraphVizFile(string where, bool directed, string name)
        {
            StreamWriter writer = new StreamWriter(where, false);

            if (directed)
            {
                writer.WriteLine("digraph "+name+" {\nrankdir = LR;\nnode [\nshape = ellipse,\nstyle = filled,\ncolor = \"#000000\",\nfillcolor = \"#FFFFFF\"];\n");
                foreach (Node a in nodes)
                {
                    writer.WriteLine(a.label + "[label=\"Node: " + a.label + "\\nValor: " + a.data + "\"]");
                    foreach (Vertex b in a.neighbors)
                    {
                        writer.WriteLine(a.label + " -> " + b.node.label);
                    }
                }

                writer.WriteLine("}");
                writer.Close();
            }

            else
            {
                writer.WriteLine("graph "+name+" {\nrankdir = LR;\nnode [\nshape = ellipse,\nstyle = filled,\ncolor = \"#000000\",\nfillcolor = \"#FFFFFF\"];\n");
                foreach (Node a in nodes)
                {
                    writer.WriteLine(a.label + "[label=\"Node: " + a.label + "\\nValor: " + a.data + "\"]");
                    foreach (Vertex b in a.neighbors)
                    {
                        if (!b.node.printMark)
                        {
                            writer.WriteLine(a.label + " -- " + b.node.label);
                        }
                    }
                    a.printMark = true;
                }

                writer.WriteLine("}");
                writer.Close();
            }
        }

    }
}
