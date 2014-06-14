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
        int[,] relateTo;
        int count = 0;

        public Graph(int size) {
            relateTo = new int[size, size];
        }

        public void addNode(string label, int data)
        {
            Node n = new Node(data, count,label);
            count++;
            nodes.AddLast(n);
        }

        public void addNode(string label)
        {
            Node n = new Node(0, count, label);
            count++;
            nodes.AddLast(n);
        }
                
        private void addNonDirectedVertex(int u, int v) {
            relateTo[u, v] = 1;
            relateTo[v, u] = 1;
        }

        public void addNonDirectedVertex(string u, string v)
        {
            int posU = 0;
            int posV = 0;
            Node x=null,y=null;
            foreach (Node a in nodes)
            {
                if (a.label.Equals(u))
                {
                    posU = a.pos;
                    x = a;
                }
                if (a.label.Equals(v))
                {
                    posV = a.pos;
                    y = a;
                }
            }
            if (x == null || y == null) {
                return;
            }
            x.vizinhos.AddLast(y);
            y.vizinhos.AddLast(x);
            addNonDirectedVertex(posU, posV);
        }

        private void addDirectedVertex(int u, int v) {
            relateTo[u, v] = 1;
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
            foreach (Node a in x.vizinhos) {
                result.Append(" "+a.label);
            }
            return result.ToString();
        }

        public void addDirectedVertex(string u, string v)
        {
            int posU = 0;
            int posV = 0;
            Node x = null, y = null;
            foreach (Node a in nodes)
            {
                if (a.label.Equals(u))
                {
                    posU = a.pos;
                    x = a;
                }
                if (a.label.Equals(v))
                {
                    posV = a.pos;
                    y = a;
                }
            }
            if (x == null || y == null)
            {
                return;
            }
            x.vizinhos.AddLast(y);
            addDirectedVertex(posU, posV);
        }

        public bool hasConection(string u, string v)
        {
            int posU=0;
            int posV=0;
            foreach (Node a in nodes) {
                if (a.label.Equals(u))
                {
                    posU = a.pos;
                }
                if (a.label.Equals(v)) {
                    posV = a.pos;
                }
            }
            return hasConection(posU, posV);
        }

        private bool hasConection(int u, int v){
            if (relateTo[u,v] != 0){
                return true;
            }
            return false;
        }

        public void CreateGraphVizFile(string where, bool directed)
        {
            StreamWriter writer = new StreamWriter(where, false);

            if (directed)
            {
                writer.WriteLine("digraph MyGraph {\nrankdir = TB;\nnode [\nshape = ellipse,\nstyle = filled,\ncolor = \"#000000\",\nfillcolor = \"#FFFFFF\"];\n");
                foreach (Node a in nodes)
                {
                    writer.WriteLine(a.label + "[label=\"Node: " + a.label + "\\nValor: " + a.data + "\"]");
                    foreach (Node b in a.vizinhos)
                    {
                        writer.WriteLine(a.label + " -> " + b.label);
                    }
                }

                writer.WriteLine("}");
                writer.Close();
            }

            else {
              writer.WriteLine("graph MyGraph {\nrankdir = TB;\nnode [\nshape = ellipse,\nstyle = filled,\ncolor = \"#000000\",\nfillcolor = \"#FFFFFF\"];\n");
                foreach (Node a in nodes)
                {
                    writer.WriteLine(a.label + "[label=\"Node: " + a.label + "\\nValor: " + a.data + "\"]");
                    foreach (Node b in a.vizinhos)
                    {
                        if (!b.printMark)
                        {
                            writer.WriteLine(a.label + " -- " + b.label);
                        }
                    }
                    a.printMark = true;
                }

                writer.WriteLine("}");
                writer.Close();           
            }
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
                    foreach (Node b in a.vizinhos)
                    {
                        writer.WriteLine(a.label + " -> " + b.label);
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
                    foreach (Node b in a.vizinhos)
                    {
                        if (!b.printMark)
                        {
                            writer.WriteLine(a.label + " -- " + b.label);
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
