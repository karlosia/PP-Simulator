using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;
using Simulator;

namespace SimWeb.Pages
{
    public class IndexModel : PageModel
    {
        public int Turn { get; private set; } = 0; // Aktualna tura symulacji
        public SimulationTurnLog CurrentLog { get; private set; } // Log bie��cej tury
        public int SizeX { get; } = 8; // Rozmiar mapy w osi X
        public int SizeY { get; } = 6; // Rozmiar mapy w osi Y

        
        
        public Simulation Simulation { get; private set; } // Obiekt symulacji
        public SimulationHistory SimHistory { get; private set; } // Historia symulacji

        /// <summary>
        /// Inicjalizuje symulacj� z domy�lnymi warto�ciami.
        /// </summary>
        private void InitializeSimulation()
        {
            // Tworzenie mapy toroidalnej
            var map = new SmallTorusMap(SizeX, SizeY);

            // Lista istot na mapie
            var creatures = new List<IMappable>
            {
                new Orc("Gorbag"), // Ork o imieniu Gorbag
                new Elf("Elandor"), // Elf o imieniu Elandor
                new Animals("Rabbits", false), // Zwierz�ta (kr�liki)
                new Birds("Eagles", true), // Ptaki (or�y, zdolne do latania)
                new Birds("Ostriches", false) // Ptaki (stru�, nielataj�cy)
            };

            // Pozycje startowe istot na mapie
            var points = new List<Point>
            {
                new Point(1, 1),
                new Point(2, 2),
                new Point(3, 3),
                new Point(4, 4),
                new Point(5, 5)
            };

            // Ci�g ruch�w symulacji
            const string moves = "rrrrrrrrrrrr";

            // Tworzenie instancji symulacji i jej historii
            Simulation = new Simulation(map, creatures, points, moves);
            SimHistory = new SimulationHistory(Simulation);

            // Ustawienie logu dla pierwszej tury
            CurrentLog = SimHistory.TurnLogs[Turn];
        }

        /// <summary>
        /// Pobiera aktualn� tur� z sesji u�ytkownika.
        /// </summary>
        /// <returns>Numer aktualnej tury lub 0, je�li brak danych w sesji.</returns>
        private int GetTurnFromSession() => HttpContext.Session.GetInt32("Turn") ?? 0;

        /// <summary>
        /// Zapisuje numer aktualnej tury w sesji u�ytkownika.
        /// </summary>
        /// <param name="turn">Numer tury do zapisania.</param>
        private void SaveTurnToSession(int turn) => HttpContext.Session.SetInt32("Turn", turn);

        /// <summary>
        /// Obs�uguje ��danie GET. Inicjalizuje symulacj�, je�li jest to konieczne.
        /// </summary>
        public void OnGet()
        {
            // Pobranie tury z sesji
            Turn = GetTurnFromSession();

            // Inicjalizacja symulacji, je�li jeszcze nie zosta�a utworzona
            if (Simulation == null || SimHistory == null)
            {
                InitializeSimulation();
            }
        }

        /// <summary>
        /// Obs�uguje przej�cie do nast�pnej tury.
        /// </summary>
        public void OnPostNextTurn()
        {
            // Pobranie tury z sesji
            Turn = GetTurnFromSession();

            // Inicjalizacja symulacji, je�li jeszcze nie zosta�a utworzona
            if (SimHistory == null)
            {
                InitializeSimulation();
            }

            // Przej�cie do nast�pnej tury, je�li istnieje
            if (Turn < SimHistory.TurnLogs.Count - 1)
            {
                Turn++;
                SaveTurnToSession(Turn); // Zapisanie aktualnej tury w sesji
                CurrentLog = SimHistory.TurnLogs[Turn]; // Aktualizacja logu
            }
        }

        /// <summary>
        /// Obs�uguje powr�t do poprzedniej tury.
        /// </summary>
        public void OnPostPrevTurn()
        {
            // Pobranie tury z sesji
            Turn = GetTurnFromSession();

            // Inicjalizacja symulacji, je�li jeszcze nie zosta�a utworzona
            if (SimHistory == null)
            {
                InitializeSimulation();
            }

            // Powr�t do poprzedniej tury, je�li istnieje
            if (Turn > 0)
            {
                Turn--;
                SaveTurnToSession(Turn); // Zapisanie aktualnej tury w sesji
                CurrentLog = SimHistory.TurnLogs[Turn]; // Aktualizacja logu
            }
        }
    }
}