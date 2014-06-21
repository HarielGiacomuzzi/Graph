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
            nodes.AddLast(new Node(data,label));
        }

        public void addNode(string label)
        {
            addNode(label,0);
        }
                
        public void addNonDirectedVertex(string u, string v)
        {
            addNonDirectedVertex(u, v, 0);
        }

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
            x.vizinhos.AddLast(new vertex(y, weigth));
            y.vizinhos.AddLast(new vertex(x, weigth));
        }

        public String vizinhos(string u) {
            StringBuilder result = new StringBuilder();
            foreach (Node a in nodes) {
                if (a.label.Equals(u)) {
                    foreach (vertex b in a.vizinhos)
                    {
                        result.Append(" " + b.node.label);
                    }
                    return result.ToString();
                }            
            }            
            return result.ToString();
        }

        public void addDirectedVertex(string u, string v)
        {
            addDirectedVertex(u, v, 0);
        }

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
            x.vizinhos.AddLast(new vertex(y, weigth));
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
