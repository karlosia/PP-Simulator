using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int turn = 1;
            Console.OutputEncoding = Encoding.UTF8;


            SmallSquareMap map = new(5);
            List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
            List<Point> points = [new(2, 2), new(3, 1)];
            string moves = "dlrludl";
            Simulation simulation = new(map, creatures, points, moves);
            MapVisualizer mapVisualizer = new(simulation.Map);

            mapVisualizer.Draw();

            while (!simulation.Finished)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();  // Czekaj na naciśnięcie klawisza

                // Wyświetl turę
                Console.WriteLine($"\nTurn: {turn}");
                Console.WriteLine($"{simulation.CurrentCreature} {simulation.CurrentCreature.CurrentPosition} goes {simulation.CurrentMoveName}:");

                // Wykonaj turę
                simulation.Turn();

                // Wyświetl stan mapy po ruchu
                mapVisualizer.Draw();

                // Zwiększ numer tury
                turn++;

            }
        }
    }
}
