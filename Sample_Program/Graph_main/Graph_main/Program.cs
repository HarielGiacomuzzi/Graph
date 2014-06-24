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

            Console.WriteLine(g.neighbors("a"));
            Console.WriteLine(g.neighbors("c"));
            Console.WriteLine(g.neighbors("b"));

            Console.WriteLine(g.BFSWalk("a"));
            Console.WriteLine(g.DFSWalk("a"));

            //g.CreateGraphVizFile(@"D:\output.txt",true);


            Console.ReadKey();

            

        }
    }
}
