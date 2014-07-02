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


            g.addDirectedVertex("a", "b",-1);
            g.addDirectedVertex("a", "c",4);
            g.addDirectedVertex("b", "c",3);
            g.addDirectedVertex("b", "e",3);
            g.addDirectedVertex("b", "d",2);
            g.addDirectedVertex("d", "b",1);
            g.addDirectedVertex("e", "d", -3);
            g.addDirectedVertex("d", "c", 5);

            //Console.WriteLine(g.neighbors("a"));
            //Console.WriteLine(g.neighbors("c"));
            //Console.WriteLine(g.neighbors("b"));

            Console.WriteLine("-------- BFSWalk --------");
            Console.WriteLine(g.BFSWalk("a"));
            Console.WriteLine("-------- BFSWalk --------\n");
            Console.WriteLine("-------- DFSWalk --------");
            Console.WriteLine(g.DFSWalk("a"));
            Console.WriteLine("-------- DFSWalk --------");

            g.CreateGraphVizFile(@"H:\output.txt",true);

            Console.WriteLine("----- Can I Reach From u & v -----");
            Console.WriteLine(g.CanReach("b","e"));
            Console.WriteLine("----- Can I Reach From u & v -----");

            Console.WriteLine(g.Dijkstra("a", "d"));

            Console.ReadKey();      

        }
    }
}
