using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM
{
    internal class Program
    {
        static int balance = 1000;
        static object lockObject = new object();
        static Random RNG = new Random();
        static void Main(string[] args)
        {
            Thread Hilo = new Thread(Obtener);
            Hilo.Start();

            Thread Hilo2 = new Thread(Obtener);
            Hilo2.Start();

            Console.ReadKey();
        }

        static void Obtener()
        {
            for (int i = 0; i <= 20; i++)
            {
                int Resultado = RNG.Next(10, 100);

                lock (lockObject)
                {
                    if (balance >= Resultado)
                    {
                        Console.WriteLine($"El hilo {Thread.CurrentThread.ManagedThreadId} va a retirar {Resultado}.");
                        balance -= Resultado;
                        Console.WriteLine($"Nuevo balance: {balance}. transacción exitosa.");
                    }
                    else
                    {
                        Console.WriteLine($"El hilo {Thread.CurrentThread.ManagedThreadId} Intentaste retirar {Resultado}. Transacción Fallida.");
                        Console.WriteLine($"Tu balance final es de: {balance}");
                        break;
                    }
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
