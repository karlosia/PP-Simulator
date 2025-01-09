using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator
{
    public class Simulation
    {
        public Map Map { get; }
        public List<Creature> Creatures { get; }
        public List<Point> Positions { get; }
        private int currentCreatureIndex = 0;
        public string Moves { get; }
        public bool Finished { get; set; } = false;

        /// <summary>
        /// Creature which will be moving current turn.
        /// </summary>
        public Creature CurrentCreature => Creatures[currentCreatureIndex];

        /// <summary>
        /// Lowercase name of direction which will be used in current turn.
        /// </summary>
        public string CurrentMoveName => Moves[currentCreatureIndex].ToString().ToLower();

        /// <summary>
        /// Simulation constructor.
        /// Throw errors:
        /// if creatures' list is empty,
        /// if number of creatures differs from 
        /// number of starting positions.
        /// </summary>
        public Simulation(Map map, List<Creature> creatures,
            List<Point> positions, string moves)
        {
            if (creatures.Count == 0)
                throw new ArgumentException("Lista stworów nie może być pusta.");

            if (creatures.Count != positions.Count)
                throw new ArgumentException("Liczba stworów musi odpowiadać liczbie początkowych pozycji.");

            Map = map;
            Creatures = creatures;
            Positions = positions;
            Moves = moves;

            for (int i = 0; i < creatures.Count; i++)
            {
                creatures[i].AssignToMap(map, positions[i]);
            }
        }

        public void Turn() {
            if (Finished)
                throw new InvalidOperationException("Symulacja została zakończona.");

            
            var directions = DirectionParser.Parse(CurrentMoveName);

            foreach (var direction in directions)
            {
                try
                {
                    
                    CurrentCreature.Go(direction);
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine($"Błąd ruchu dla {CurrentCreature.Name}: {ex.Message}");
                }
            }

            
            currentCreatureIndex++;

            
            if (currentCreatureIndex >= Creatures.Count)
            {
                currentCreatureIndex = 0;
            }
        }
    }
}
