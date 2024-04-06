using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalculadoraDescuentos
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] comprasClientes = {
                {150, 200, 300, 400, 500},
                {600, 700, 800, 900, 1000},
                {1200, 1300, 1400, 1500, 1600},
                {50, 75, 90, 110, 130},
                {950, 975, 990, 1010, 1030}
            };

            AplicarDescuentos(comprasClientes);
        }

        static void AplicarDescuentos(int[,] comprasClientes)
        {
            for (int i = 0; i < comprasClientes.GetLength(0); i++)
            {
                int totalCompra = 0;
                for (int j = 0; j < comprasClientes.GetLength(1); j++)
                {
                    totalCompra += comprasClientes[i, j];
                }


                double descuento = 0;
                if (totalCompra >= 100 && totalCompra <= 1000)
                {
                    descuento = 0.1; 
                }
                else if (totalCompra > 1000)
                {
                    descuento = 0.2; 
                }

                double totalAPagar = totalCompra - (totalCompra * descuento);

                Console.WriteLine("Cliente " + (i + 1) + ":");
                Console.WriteLine("Total de compras: $" + totalCompra);
                Console.WriteLine("Descuento aplicado: " + (descuento * 100) + "%");
                Console.WriteLine("Total a pagar: $" + totalAPagar);
                Console.ReadLine();
            }
        }
    }
}
