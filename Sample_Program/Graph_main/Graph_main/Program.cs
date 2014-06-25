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

            g.addNode("a");
            g.addNode("b");
            g.addNode("c");
            g.addNode("d");
            g.addNode("e");
            g.addNode("f");
            g.addNode("g");
            g.addNode("h");


            g.addDirectedVertex("a", "b",10);
            g.addDirectedVertex("a", "d",17);
            g.addDirectedVertex("a", "c",3);
            g.addDirectedVertex("d", "b",2);
            g.addDirectedVertex("c", "b",13);
            g.addDirectedVertex("c", "f",8);
            g.addDirectedVertex("c", "g",9);
            g.addDirectedVertex("b", "f",7);
            g.addDirectedVertex("g", "h",5);
            g.addDirectedVertex("e", "h",6);
            g.addDirectedVertex("f", "h",11);
            g.addDirectedVertex("f", "e",7);
            g.addDirectedVertex("b", "e",15);
            g.addDirectedVertex("d", "e",14);
            g.addDirectedVertex("g", "b", 7);
            g.addDirectedVertex("f", "d", 2);
            g.addDirectedVertex("h", "a", 6);
            g.addDirectedVertex("e", "g", 1);

            Console.WriteLine(g.neighbors("a"));
            Console.WriteLine(g.neighbors("c"));
            Console.WriteLine(g.neighbors("b"));

            Console.WriteLine(g.BFSWalk("a"));
            Console.WriteLine(g.DFSWalk("a"));

            g.CreateGraphVizFile(@"D:\output.txt",true);

            Console.WriteLine(g.Dijkstra("a", "h"));

            Console.ReadKey();

            

        }
    }
}
