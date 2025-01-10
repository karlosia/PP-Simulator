using Simulator;
using Simulator.Maps;

namespace SimConsole
{
    public class MapVisualizer
    {
        private readonly Map _map;

        public MapVisualizer(Map map)
        {
            _map = map;
        }

        public void Draw()
        {
            Console.Clear();
            int width = _map.SizeX;  // Używamy SizeX
            int height = _map.SizeY; // Używamy SizeY

            // Rysowanie górnej linii
            Console.Write(Box.TopLeft);
            for (int x = 0; x < width; x++) // Używamy SizeX
                Console.Write(Box.Horizontal);
            Console.WriteLine(Box.TopRight);

            // Rysowanie linii z mapą
            for (int y = 0; y < height; y++) // Używamy SizeY
            {
                Console.Write(Box.Vertical);

                for (int x = 0; x < width; x++) // Używamy SizeX
                {
                    Point point = new Point(x, y);
                    var creatures = _map.At(point); // At zwraca listę stworów w danym punkcie

                    if (creatures.Count == 1)
                    {
                        // Wizualizowanie stworów
                        var creature = creatures[0];

                        if (creature is Animals animal)
                        {
                            if (animal.CanFly)
                            {
                                // Ptaki latające
                                Console.Write("B");
                            }
                            else
                            {
                                // Nieloty
                                Console.Write("b");
                            }
                        }
                        else if (creature is Orc)
                        {
                            Console.Write("O");
                        }
                        else if (creature is Elf)
                        {
                            Console.Write("E");
                        }
                    }
                    else if (creatures.Count > 1)
                    {
                        // Więcej niż jedno stworzenie w tym samym miejscu
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine(Box.Vertical);
            }

            // Rysowanie dolnej linii
            Console.Write(Box.BottomLeft);
            for (int x = 0; x < width; x++) // Używamy SizeX
                Console.Write(Box.Horizontal);
            Console.WriteLine(Box.BottomRight);
        }

    }
}



