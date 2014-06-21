using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;

namespace Graph_main
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph.Graph g = new Graph.Graph();

            g.addNode("1 1", 3);
            g.addNode("1 2", 6);
            g.addNode("1 3", 5);
            g.addNode("1 4", 8);
            g.addNode("1 5", 3);
            g.addNode("2 1", 4);
            g.addNode("2 2", 1);
            g.addNode("2 3", 9);
            g.addNode("2 4", 4);
            g.addNode("2 5", 7);
            g.addNode("1", 1);
            g.addNode("8", 8);
            g.addNode("3", 3);
            g.addNode("1", 1);
            g.addNode("2", 2);
            g.addNode("2", 2);
            g.addNode("2", 2);
            g.addNode("9", 9);
            g.addNode("3", 3);
            g.addNode("8", 8);
            g.addNode("8", 4);
            g.addNode("7", 4);
            g.addNode("9", 4);
            g.addNode("2", 4);
            g.addNode("6", 4);
            g.addNode("6", 5);
            g.addNode("4", 5);
            g.addNode("5", 5);
            g.addNode("6", 5);
            g.addNode("4", 5);


            g.addDirectedVertex("a", "b");
            g.addDirectedVertex("a", "d");
            g.addDirectedVertex("a", "c");
            g.addDirectedVertex("d", "b");
            g.addDirectedVertex("c", "b");
            g.addDirectedVertex("c", "f");
            g.addDirectedVertex("c", "g");
            g.addDirectedVertex("b", "f");
            g.addDirectedVertex("g", "h");
            g.addDirectedVertex("e", "h");
            g.addDirectedVertex("f", "h");
            g.addDirectedVertex("f", "e");
            g.addDirectedVertex("b", "e");
            g.addDirectedVertex("d", "e");

            Console.WriteLine(g.vizinhos("a"));
            Console.WriteLine(g.vizinhos("c"));
            Console.WriteLine(g.vizinhos("b"));

            g.CreateGraphVizFile(@"D:\output.txt",true);


            Console.ReadKey();

            

        }
    }
}
