using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminatorsModel.DAL;
using TerminatorsModel.DTO;

namespace terminatorsApp
{
    class Program
    {
        static TerminatorsDAL dal = new TerminatorsDAL();

        static void IngresarTerminator()
        {
            string nroSerie, objetivo;
            int prioridad, anioDestino;
            Tipo tipo;

            do
            {
                Console.WriteLine("Ingrese nro de serie");
                nroSerie = Console.ReadLine().Trim();
                if (nroSerie.Length != 7)
                {
                    Console.WriteLine("El nro de serie debe ser de largo 7");
                    nroSerie = String.Empty;
                }
                else if (dal.FindByNroSerie(nroSerie) != null)
                {
                    Console.WriteLine("Este terminator ya existe");
                    nroSerie = String.Empty;
                }

            } while (nroSerie == string.Empty);

            string resp;
            do
            {
                Console.WriteLine("Seleccione un tipo");
                Console.WriteLine("1-. T-1, 2.- T-800, 3.- T-1000, 4.- T-3000");
                resp = Console.ReadLine().Trim();
                switch (resp)
                {
                    case "1": tipo = Tipo.T1;
                        break;
                    case "2": tipo = Tipo.T800;
                        break;
                    case "3": tipo = Tipo.T1000;
                        break;
                    case "4": tipo = Tipo.T3000;
                        break;
                    default:
                        Console.WriteLine("Tipo incorrecto");
                        resp = string.Empty;
                        break;
                }
            } while (resp == string.Empty);

            do
            {
                Console.WriteLine("Ingrese objetivo");
                objetivo = Console.ReadLine().Trim();
            } while (objetivo == string.Empty);
            if (objetivo.ToLower() == "sarah connor")
            {
                prioridad = 999;
            }else
            {
                do
                {
                    Console.WriteLine("Ingrese una prioridad");
                    string prioridadString = Console.ReadLine().Trim();
                    if(!Int32.TryParse(prioridadString, out prioridad))
                    {
                        prioridad = -1;
                        Console.WriteLine("Vuelva a ingresar la prioridad");
                    }
                } while (prioridad < 0 || prioridad > 1999);
            }

            do
            {
                Console.WriteLine("Ingrese un año de destino");
                string anioDestinoString = Console.ReadLine().Trim();
                if (!Int32.TryParse(Console.ReadLine().Trim(), out anioDestino))
                {                   
                    anioDestino = -1;
                    Console.WriteLine("Vuelva a ingresar un año de destino");
                }
            } while (anioDestino < 1984 || anioDestino > 3000);

            Terminator t = new Terminator()
            {
                NroSerie = nroSerie,
                Objetivo = objetivo,
                AnioDestino = anioDestino,
                Prioridad = prioridad
            };

            dal.Save(t);
        }

        static void MostrarTerminators()
        {

        }

        static void BuscarTerminators()
        {

        }

        static Boolean Menu()
        {
            bool continuar = true;
            Console.WriteLine("Welcome To TerminatorsApp");
            Console.WriteLine("1.- Ingresar Terminator");
            Console.WriteLine("2.- Mostrar Terminator");
            Console.WriteLine("3.- Buscar Terminator");
            string opcion = Console.ReadLine().Trim();
            switch (opcion)
            {
                case "1":
                    IngresarTerminator();
                    break;
                case "2":
                    MostrarTerminators();
                    break;
                case "3":
                    BuscarTerminators();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Ingrese nuevamente");
                    break;
            }
            return continuar;
        }

        static void Main(string[] args)
        {
            while (Menu()) ; 
        }
    }
}
