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

        public Graph() { }

        public void addNode(string label, int data)
        {
            Node n = new Node(data,label);
            nodes.AddLast(n);
        }

        public void addNode(string label)
        {
            Node n = new Node(0, label);
            nodes.AddLast(n);
        }
                
        public void addNonDirectedVertex(string u, string v)
        {
            Node x=null,y=null;
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
            if (x == null || y == null) {
                return;
            }
            x.vizinhos.AddLast(new vertex(y,0));
            y.vizinhos.AddLast(new vertex(x,0));
        }

        public String vizinhos(string u) {
            Node x = null;
            StringBuilder result = new StringBuilder();
            foreach (Node a in nodes) {
                if (a.label.Equals(u)) {
                    x = a;
                    break;
                }            
            }
            foreach (vertex a in x.vizinhos) {
                result.Append(" "+a.node.label);
            }
            return result.ToString();
        }

        public void addDirectedVertex(string u, string v)
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
            x.vizinhos.AddLast(new vertex(y,0));
        }

        public bool hasConnection(string u, string v) {
            if (hasDirectConection(u, v)) return true;
            foreach (Node a in nodes) {
                if (a.label.Equals(u)) { 
                    foreach(vertex b in a.vizinhos){
                        if (hasDirectConection(b.node.label, v)) return true;
                    }
                    break;
                }
            }

            return true;
        }


        private bool hasDirectConection(string u, string v)
        {
            Node x = null, y = null;
            foreach (Node a in nodes) {
                if (a.label.Equals(u))
                {
                    foreach (vertex b in a.vizinhos) {
                        if (b.node.label.Equals(v)) {
                            return true;                    
                        }
                    }
                    break;
                }
            }
            return false;
        }

        public void CreateGraphVizFile(string where, bool directed)
        {
            CreateGraphVizFile(where, directed, "MyGraph");
        }

        public void CreateGraphVizFile(string where, bool directed, string name)
        {
            StreamWriter writer = new StreamWriter(where, false);

            if (directed)
            {
                writer.WriteLine("digraph "+name+" {\nrankdir = TB;\nnode [\nshape = ellipse,\nstyle = filled,\ncolor = \"#000000\",\nfillcolor = \"#FFFFFF\"];\n");
                foreach (Node a in nodes)
                {
                    writer.WriteLine(a.label + "[label=\"Node: " + a.label + "\\nValor: " + a.data + "\"]");
                    foreach (vertex b in a.vizinhos)
                    {
                        writer.WriteLine(a.label + " -> " + b.node.label);
                    }
                }

                writer.WriteLine("}");
                writer.Close();
            }

            else
            {
                writer.WriteLine("graph "+name+" {\nrankdir = TB;\nnode [\nshape = ellipse,\nstyle = filled,\ncolor = \"#000000\",\nfillcolor = \"#FFFFFF\"];\n");
                foreach (Node a in nodes)
                {
                    writer.WriteLine(a.label + "[label=\"Node: " + a.label + "\\nValor: " + a.data + "\"]");
                    foreach (vertex b in a.vizinhos)
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
