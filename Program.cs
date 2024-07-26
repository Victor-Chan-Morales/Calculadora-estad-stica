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
        static string tipoDeMedida = "";
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
            return suma / lista.Count; //Count cuenta el número de elementos de una lista
        }
        static double CalcularMediana(List<double> lista)
        {
            listaNumero.Sort(); // sort ordena (clasifica) del menor al mayor los elementos de una lista 
            cantidadNumeros = listaNumero.Count;
            if (cantidadNumeros%2==1)
            {
                return listaNumero[cantidadNumeros/ 2]; //Regresa el elemento con indice de cantidadNumeros/2
            }
            else
            {
                int mid1 = (cantidadNumeros / 2) - 1;
                int mid2 = cantidadNumeros / 2;
                return (listaNumero[mid1] + listaNumero[mid2]) / 2;
            }
        }
        static List<double> CalcularModa(List<double> lista)
        {
            List<double> noRepetidos = lista.Distinct().ToList(); //obtiene los numeros no repetidos y los agrega en una lista 
            List<int> repetidos = new List<int>();

            foreach (double numero in noRepetidos)
            {
                int cuenta = lista.Count(x => x == numero);
                repetidos.Add(cuenta);
            }

            int maxFrecuencia = repetidos.Max();
            List<double> modas = new List<double>();

            for (int i = 0; i < repetidos.Count; i++)
            {
                if (repetidos[i] == maxFrecuencia)
                {
                    modas.Add(noRepetidos[i]);
                }
            }
            return modas;
        }
        static double CalcularDesviacion(List<double>lista)
        {
            double media=lista.Average(); //función para calcular la media
            double sumaDesviacion = 0;
            foreach (double numero in lista)
            {
                sumaDesviacion += Math.Pow(numero-media,2);
            }
            double division=sumaDesviacion/lista.Count();
            return Math.Sqrt(division);
        }
        static void MostrarResultado()
        {
            Console.Clear();
            Console.WriteLine("De los números ingresados: ");
            string cadena = string.Join(" ", listaNumero);
            Console.WriteLine(cadena);
            Console.WriteLine("El resultado es: " + resultado);
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
                        case 3:
                            resultado= CalcularMediana(listaNumero);
                            MostrarResultado();
                            Console.ReadKey();
                            break;
                        case 4:
                            List<double> modas = CalcularModa(listaNumero);
                            Console.Clear();
                            Console.WriteLine("De los números ingresados: ");
                            Console.WriteLine(string.Join(" ", listaNumero));
                            Console.WriteLine("Las modas son: " + string.Join(", ", modas));
                            Console.ReadKey();
                            break;
                        case 5:
                            resultado=CalcularDesviacion(listaNumero);
                            MostrarResultado();
                            Console.ReadKey();
                            break;
                        case 6:
                            SolicitarListaNumeros();
                            break;
                        case 0:
                            Console.WriteLine("Saliendo del programa...");
                            return;
                        default:
                            Console.WriteLine("Esta opción no está disponible, seleccione una opción del menú");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ha ingresado un caracter inválido, clic e intente de nuevo.");
                    Console.ReadKey();
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("La lista está vacía, debe ingresar primero los números.");
                    Console.ReadKey();
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("No puede realizar esta operación, está intentando dividir un número entre cero, clic e intente de nuevo.");
                    Console.ReadKey();
                }
                catch(InvalidOperationException)
                {
                    Console.WriteLine("No puede realizar esta operación, no ha ingresado valores. Clic e intente de nuevo.");
                    Console.ReadKey();
                }
            } while (opcionMenu > 0);
        }
    }
}
