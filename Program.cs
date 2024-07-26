using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_estadística
{
    internal class Program
    {
        static int cantidadNumeros = 1;
        static double resultado = 0;
        static List<double> listaNumero = new List<double>();
        static void MostrarMenu()
        {
            Console.WriteLine("Menú\n1. Ingresar n números\n2. Calcular y mostrar la media\n3. Calcular y mostar la mediana\n4. Mostrar la moda\n5. Mostrar la desviación estándar\n6. Ingresar nuevos números\n0. Salir\nSeleccione una opción...");
        }
        static void SolicitarListaNumeros()
        {
            Console.Clear();
            Console.WriteLine("¿Cuántos números desea ingresar?");
            cantidadNumeros = int.Parse(Console.ReadLine());
            if (cantidadNumeros > 1)
            {
                for (int i = 0; i < cantidadNumeros; i++)
                {
                    Console.WriteLine($"Numero {i + 1}:");
                    double numero = double.Parse(Console.ReadLine());
                    listaNumero.Add(numero);
                }
            }
            else
            {
                Console.WriteLine("Debe ingresar un número mayor a 1");
            }
        }
        static double CalcularMedia(List<double> lista)
        {
            double suma = 0;
            foreach (double numero in lista)
            {
                suma += numero;
            }
            return suma / lista.Count;
        }
        static void MostrarResultado()
        {
            Console.Clear();
            Console.WriteLine("El resultado es: " + resultado);
        }
        static double CalcularMediana(List<double> lista)
        {
            
        }
        static void Main(string[] args)
        {
            int opcionMenu = 1;
            do
            {
                try
                {
                    Console.Clear();
                    MostrarMenu();
                    opcionMenu = int.Parse(Console.ReadLine());
                    switch (opcionMenu)
                    {
                        case 1:
                            SolicitarListaNumeros();
                            Console.ReadKey();
                            break;
                        case 2:
                            resultado = CalcularMedia(listaNumero);
                            MostrarResultado();
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ha ingresado un caracter inválido, clic e intente de nuevo.");
                    Console.ReadKey();
                }
            } while (opcionMenu > 0);
        }
    }
}
