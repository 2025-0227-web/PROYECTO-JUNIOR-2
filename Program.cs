using System;

namespace PROYECTO_GIT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Instanciamos el auto con la clase original
            Automovil carro = new Automovil("Ferrari Classic");
            carro.encender();

            // Variables para controlar las luces y la marcha
            bool lucesAlternas = false;
            string estadoMarcha = "ESTACIONADO";

            while (true)
            {
                // Limpieza total de pantalla para evitar el rastro fantasma al dar reversa
                Console.Clear();

                // --- PANEL DE CONTROL ---
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("======================================================================");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                🏎️  FERRARI CLASSIC SIMULATOR v3.0 🏎️            ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("======================================================================");
                Console.ResetColor();

                Console.WriteLine("\n>> CONTROLES:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("   [ESPACIO / ARRIBA] -> Avanzar frente");
                Console.WriteLine("   [FLECHA ABAJO]     -> Dar Reversa");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("   [ESC]              -> Apagar auto\n");
                Console.ResetColor();

                // Conectamos con la matemática del archivo
                string kmsTexto = carro.getKilometroRecorridos().ToString();
                int kms = 0;
                int.TryParse(kmsTexto, out kms);

                // Evitamos números negativos en los espacios para que no se rompa la consola
                int posicionVisual = Math.Clamp(kms, 0, 55);
                string avance = new string(' ', posicionVisual);

                // --- DASHBOARD ---
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"  MARCHA: ");

                if (estadoMarcha == "AVANZANDO ↑") Console.ForegroundColor = ConsoleColor.Green;
                else if (estadoMarcha == "REVERSA ↓") Console.ForegroundColor = ConsoleColor.Magenta;
                else Console.ForegroundColor = ConsoleColor.White;

                Console.Write($"{estadoMarcha,-15}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"KILÓMETROS: {kmsTexto} km");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("----------------------------------------------------------------------\n");

                // --- EL PRIMER DISEÑO (ESTRUCTURA ORIGINAL CON LETRAS FERRARI) ---

                // Fila 1: Techo original
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(avance + "  ______");

                // Fila 2: Parabrisas y capó + Destello intermitente al frente
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(avance + " /|_||_\\`.__");
                Console.ForegroundColor = lucesAlternas ? ConsoleColor.Yellow : ConsoleColor.DarkGray;
                Console.WriteLine(lucesAlternas ? " *" : ""); // Luz parpadeante al frente del capó

                // Fila 3: Chasis original modificado con la palabra FERRARI exacta
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(avance + "(  FERRARI  \\");

                // Fila 4: Neumáticos y escape originales intactos
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(avance + "=`-(_)--(_)-'");
                Console.ResetColor();

                // Carretera
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n======================================================================");
                Console.ResetColor();

                // Captura de teclas en tiempo real
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                lucesAlternas = !lucesAlternas; // Hace que el asterisco de la luz prenda y apague en cada paso

                if (tecla.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (tecla.Key == ConsoleKey.Spacebar || tecla.Key == ConsoleKey.UpArrow)
                {
                    carro.acelerar(120, 15); // Suma kilómetros 
                    estadoMarcha = "AVANZANDO ↑";
                }
                else if (tecla.Key == ConsoleKey.DownArrow)
                {
                    carro.acelerar(-120, 15); // Resta kilómetros  (Reversa)
                    estadoMarcha = "REVERSA ↓";
                }
                else
                {
                    estadoMarcha = "NEUTRO •";
                }
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[!] Auto apagado de forma segura. ¡Proyecto listo para entregar!");
            Console.ResetColor();
        }
    }
}