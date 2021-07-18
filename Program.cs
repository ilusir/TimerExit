using System;
using System.Timers;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace TimerExit
{
    class Program
    {
        private static string RespPID { get; set; }
        private static string RespNombreVentana { get; set; }
        private static string RespNombreProceso { get; set; }

        static void Main()
        {
            Console.Title = "Creado por Ilusir                                                                                   TimerExit";

            Inicio1: 
            Console.WriteLine("Elige de qué forma elegirás el proceso");
            Console.WriteLine("\t1 = PID\n\t2 = Título de la ventana\n\t3 = Nombre del proceso\n\t4 = Procesos sin Respuestas\n");
            Console.Write("Introduce un número: "); string respNum = Console.ReadLine();
            switch (respNum)
            {
                case "1":
                    OptionPID();
                    break;
                case "2":
                    OptionTitle();
                    break;
                case "3":
                    OptionProceso();
                    break;
                case "4":
                    OptionEstado();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Introduce un número válido.\n");
                    goto Inicio1;
            }
        }

        private static void TiempoSeg(out Timer timer)
        {
            Console.Clear();
            Console.Write("Pon los segundos: "); string respSeg = Console.ReadLine();
            Console.Clear();

            double.TryParse(respSeg, out double result);

            timer = new Timer
            {
                AutoReset = false,
                Enabled = true,
                Interval = 1000 * result
            };
        }

        private static void TiempoMin(out Timer timer)
        {
            Console.Clear();
            Console.Write("Pon los minutos: "); string respSeg = Console.ReadLine();
            Console.Clear();

            double.TryParse(respSeg, out double result);

            timer = new Timer
            {
                AutoReset = false,
                Enabled = true,
                Interval = 1000 * 60 * result
            };
        }

        private static void TiempoHors(out Timer timer)
        {
            Console.Clear();
            Console.Write("Pon las horas: "); string respSeg = Console.ReadLine();
            Console.Clear();

            double.TryParse(respSeg, out double result);

            timer = new Timer
            {
                AutoReset = false,
                Enabled = true,
                Interval = 1000 * 60 * 60 * result
            };
        }

        private static void OptionPID()
        {
            Inicio2: 
            Console.Clear();
            Console.WriteLine("Elige de qué forma elegirás el tiempo");
            Console.WriteLine("\t1 = Segundos\n\t2 = Minutos\n\t3 = Horas\n");
            Console.Write("Introduce un número: "); string respNum = Console.ReadLine();
            switch (respNum)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Introduce el PID del proceso;: "); RespPID = Console.ReadLine();
                    TiempoSeg(out Timer timer1);
                    timer1.Elapsed += TimerFunctionPID;
                    timer1.Start();
                    Console.WriteLine("Para cancelar esto, presiona cualquier tecla.\n");
                    Console.ReadKey();
                    timer1.Stop();
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("Introduce el PID del proceso: "); RespPID = Console.ReadLine();
                    TiempoMin(out Timer timer2);
                    timer2.Elapsed += TimerFunctionPID;
                    timer2.Start();
                    Console.WriteLine("Para cancelar esto, presiona cualquier tecla.\n");
                    Console.ReadKey();
                    timer2.Stop();
                    break;
                case "3":
                    Console.Clear();
                    Console.Write("Introduce el PID del proceso: "); RespPID = Console.ReadLine();
                    TiempoHors(out Timer timer3);
                    timer3.Elapsed += TimerFunctionPID;
                    timer3.Start();
                    Console.WriteLine("Para cancelar esto, presiona cualquier tecla.\n");
                    Console.ReadKey();
                    timer3.Stop();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Introduce un número válido.\n");
                    goto Inicio2;
            }
            Console.Clear();
        }

        private static void TimerFunctionPID(object source, ElapsedEventArgs e)
        {
            string strCommand = $"/c taskkill /PID {RespPID} /F";
            Process.Start("CMD.exe", strCommand);
        }

        private static void OptionTitle()
        {
        Inicio3:
            Console.Clear();
            Console.WriteLine("Elige de qué forma elegirás el tiempo");
            Console.WriteLine("\t1 = Segundos\n\t2 = Minutos\n\t3 = Horas\n");
            Console.Write("Introduce un número: "); string respNum = Console.ReadLine();
            switch (respNum)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Introduce el Título de la ventana: "); RespNombreVentana = Console.ReadLine();
                    TiempoSeg(out Timer timer1);
                    timer1.Elapsed += TimerFunctionVentan;
                    timer1.Start();
                    Console.WriteLine("Para cancelar esto, presiona cualquier tecla.\n");
                    Console.ReadKey();
                    timer1.Stop();
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("Introduce el Título de la ventana: "); RespNombreVentana = Console.ReadLine();
                    TiempoMin(out Timer timer2);
                    timer2.Elapsed += TimerFunctionVentan;
                    timer2.Start();
                    Console.WriteLine("Para cancelar esto, presiona cualquier tecla.\n");
                    Console.ReadKey();
                    timer2.Stop();
                    break;
                case "3":
                    Console.Clear();
                    Console.Write("Introduce el Título de la ventana: "); RespNombreVentana = Console.ReadLine();
                    TiempoHors(out Timer timer3);
                    timer3.Elapsed += TimerFunctionVentan;
                    timer3.Start();
                    Console.WriteLine("Para cancelar esto, presiona cualquier tecla.\n");
                    Console.ReadKey();
                    timer3.Stop();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Introduce un número válido.\n");
                    goto Inicio3;
            }
            Console.Clear();
        }

        private static void TimerFunctionVentan(object source, ElapsedEventArgs e)
        {
            string strCommand = $"/c taskkill /F /FI \"WINDOWTITLE eq {RespNombreVentana}\"";
            Process.Start("CMD.exe", strCommand);
        }

        private static void OptionProceso()
        {
        Inicio4:
            Console.Clear();
            Console.WriteLine("Elige de qué forma elegirás el tiempo");
            Console.WriteLine("\t1 = Segundos\n\t2 = Minutos\n\t3 = Horas\n");
            Console.Write("Introduce un número: "); string respNum = Console.ReadLine();
            switch (respNum)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Introduce el Nombre del Proceso: "); RespNombreProceso = Console.ReadLine();
                    TiempoSeg(out Timer timer1);
                    timer1.Elapsed += TimerFunctionProceso;
                    timer1.Start();
                    Console.WriteLine("Para cancelar esto, presiona cualquier tecla.\n");
                    Console.ReadKey();
                    timer1.Stop();
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("Introduce el Nombre del Proceso: "); RespNombreProceso = Console.ReadLine();
                    TiempoMin(out Timer timer2);
                    timer2.Elapsed += TimerFunctionProceso;
                    timer2.Start();
                    Console.WriteLine("Para cancelar esto, presiona cualquier tecla.\n");
                    Console.ReadKey();
                    timer2.Stop();
                    break;
                case "3":
                    Console.Clear();
                    Console.Write("Introduce el Nombre del Proceso: "); RespNombreProceso = Console.ReadLine();
                    TiempoHors(out Timer timer3);
                    timer3.Elapsed += TimerFunctionProceso;
                    timer3.Start();
                    Console.WriteLine("Para cancelar esto, presiona cualquier tecla.\n");
                    Console.ReadKey();
                    timer3.Stop();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Introduce un número válido.\n");
                    goto Inicio4;
            }
            Console.Clear();
        }

        private static void TimerFunctionProceso(object source, ElapsedEventArgs e)
        {
            string strCommand = $"/c taskkill /F /IM {RespNombreProceso} /T";
            Process.Start("CMD.exe", strCommand);
        }

        private static void OptionEstado()
        {
        Inicio5:
            Console.Clear();
            Console.WriteLine("A continuación se detendrán los procesos que no respondan.\n");
            Console.WriteLine("Elige de qué forma elegirás el tiempo");
            Console.WriteLine("\t1 = Segundos\n\t2 = Minutos\n\t3 = Horas\n");
            Console.Write("Introduce un número: "); string respNum = Console.ReadLine();
            switch (respNum)
            {
                case "1":
                    Console.Clear();
                    TiempoSeg(out Timer timer1);
                    timer1.Elapsed += TimerFunctionEstado;
                    timer1.Start();
                    Console.WriteLine("Para cancelar esto, presiona cualquier tecla.\n");
                    Console.ReadKey();
                    timer1.Stop();
                    break;
                case "2":
                    Console.Clear();
                    TiempoMin(out Timer timer2);
                    timer2.Elapsed += TimerFunctionEstado;
                    timer2.Start();
                    Console.WriteLine("Para cancelar esto, presiona cualquier tecla.\n");
                    Console.ReadKey();
                    timer2.Stop();
                    break;
                case "3":
                    Console.Clear();
                    TiempoHors(out Timer timer3);
                    timer3.Elapsed += TimerFunctionEstado;
                    timer3.Start();
                    Console.WriteLine("Para cancelar esto, presiona cualquier tecla.\n");
                    Console.ReadKey();
                    timer3.Stop();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Introduce un número válido.\n");
                    goto Inicio5;
            }
            Console.Clear();
        }

        private static void TimerFunctionEstado(object source, ElapsedEventArgs e)
        {
            string strCommand = "/c taskkill /F /FI \"STATUS eq NOT RESPONDING\" /T";
            Process.Start("CMD.exe", strCommand);
        }
    }
}
