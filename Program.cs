using System;
using System.Timers;
using System.Diagnostics;

namespace TimerExit
{
    class Program
    {
        private static string RespPID { get; set; }

        static void Main(string[] args)
        {
            Console.Title = "Creado por Ilusir                                                                                   TimerExit";
            
            Console.Write("Pon el PID: "); RespPID = Console.ReadLine();
            Console.Clear();
            Console.Write("Pon segundos: "); string respSeg = Console.ReadLine();
            Console.Clear();

            double.TryParse(respSeg, out double result);
            
            Timer timer = new Timer
            {
                AutoReset = false,
                Enabled = true,
                Interval = 1000 * result
            }; 

            timer.Elapsed += TimerFunction;
            timer.Start();
            Console.WriteLine("Para cancelar esto, presiona cualquier tecla.");
            Console.ReadKey();
            timer.Stop();
        }

        static void TimerFunction(object source, ElapsedEventArgs e)
        {
            string strCommand = "/c taskkill /pid " + RespPID + " /f";
            Process.Start("CMD.exe", strCommand);
        }
    }
}
