using System;
using System.Collections.Generic;
using Simulator.Maps;

namespace Simulator
{
    public class Simulation
    {
        public Map Map { get; }
        public List<IMappable> Mappables { get; }
        public List<Point> Positions { get; }
        private int currentMappableIndex = 0;
        private int currentMoveIndex = 0;
        public string Moves { get; set; }
        public bool Finished { get; private set; } = false;

        /// <summary>
        /// Creature which will be moving current turn.
        /// </summary>
        public IMappable CurrentMappable => Mappables[currentMappableIndex];

        /// <summary>
        /// Lowercase name of direction which will be used in current turn.
        /// </summary>
        public string CurrentMoveName
        {
            get
            {
                // Sprawdzamy, czy Moves jest puste
                if (string.IsNullOrEmpty(Moves))
                {
                    throw new InvalidOperationException("Lista ruchów nie może być pusta.");
                }

                // Cyfliczne przechodzenie po Moves, aby uniknąć przekroczenia zakresu
                return Moves[currentMoveIndex % Moves.Length].ToString().ToLower();
            }
        }

        /// <summary>
        /// Konstruktor symulacji
        /// </summary>
        public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
        {
            if (mappables.Count == 0)
                throw new ArgumentException("Lista stworów nie może być pusta.");

            if (mappables.Count != positions.Count)
                throw new ArgumentException("Liczba stworów musi odpowiadać liczbie początkowych pozycji.");

            Map = map;
            Mappables = mappables;
            Positions = positions;

            // Upewnij się, że Moves nie jest puste, jeśli nie, ustaw domyślną wartość
            Moves = string.IsNullOrEmpty(moves) ? "rrrrrrrrr" : moves;

            for (int i = 0; i < mappables.Count; i++)
            {
                mappables[i].AssignToMap(map, positions[i]);
            }
        }

        public void Turn()
        {
            if (Finished)
                throw new InvalidOperationException("Symulacja została zakończona.");

            // Upewnij się, że indeks ruchu mieści się w zakresie
            IMappable creature = CurrentMappable;

            // Użyj operatora % aby cyklicznie powtarzać ruchy, jeśli ich liczba jest mniejsza niż liczba stworów
            Direction direction = DirectionParser.Parse(Moves)[currentMoveIndex % Moves.Length];

            // Wykonanie ruchu
            creature.Go(direction);

            // Zwiększenie indeksu dla ruchów
            currentMoveIndex++;

            // Sprawdzamy, czy symulacja się zakończyła
            if (currentMoveIndex >= Moves.Length)
            {
                Finished = true;
            }

            // Zwiększenie indeksu dla stworów
            currentMappableIndex++;
            if (currentMappableIndex >= Mappables.Count)
            {
                currentMappableIndex = 0;  // Resetujemy indeks stworów
            }
        }
    }
}