using Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<Estacion> g = new Graph<Estacion>();
            Estacion tacubaya = new Estacion { Nombre = "Tacubaya"};
            Estacion constituyentes = new Estacion { Nombre = "Constituyentes"};
            Estacion snpedro = new Estacion { Nombre = "Sn Pedro de los Pinos"};
            Estacion snantonio = new Estacion { Nombre = "Sn Antonio"};

            Estacion observatorio = new Estacion { Nombre = "Observatorio"};
            Estacion patriotismo = new Estacion { Nombre = "Patriotismo"};
            Estacion juanacatlan = new Estacion { Nombre = "Juanacatlan"};
            Estacion xD = new Estacion { Nombre = "xD" };

            g.addNode(tacubaya);
            g.addNode(constituyentes);
            g.addNode(snpedro);
            g.addNode(snantonio);
            g.addNode(observatorio);
            g.addNode(patriotismo);
            g.addNode(juanacatlan);


            g.addNonDirectedVertex(constituyentes, tacubaya, 1005);
            g.addNonDirectedVertex(tacubaya, snpedro, 1084);
            g.addNonDirectedVertex(snpedro, snantonio, 606);
            g.addNonDirectedVertex(tacubaya, observatorio, 1262);
            g.addNonDirectedVertex(tacubaya, patriotismo, 1133);
            g.addNonDirectedVertex(tacubaya, juanacatlan, 1158);

            

            try
            {
                List<Node<Estacion>> estaciones = g.DijkstraList(juanacatlan, xD);
                Console.WriteLine("Ruta desde " + xD.Nombre + " => " + patriotismo.Nombre);
                Console.WriteLine("");
                foreach (var item in estaciones)
                {
                    Console.WriteLine(item.label.Nombre);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
