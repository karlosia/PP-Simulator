using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;
using Simulator;
public class IndexModel : PageModel
{
    public int Turn { get; private set; } = 0; // Aktualna tura symulacji
    public SimulationTurnLog CurrentLog { get; private set; } // Log bie¿¹cej tury
    public int SizeX { get; } = 8; // Rozmiar mapy w osi X
    public int SizeY { get; } = 6; // Rozmiar mapy w osi Y
    public string Moves { get; set; } = string.Empty; // Przechowuje ruchy u¿ytkownika

    public Simulation Simulation { get; private set; } // Obiekt symulacji
    public SimulationHistory SimHistory { get; private set; } // Historia symulacji

    // Inicjalizuje symulacjê z domyœlnymi wartoœciami
    public void InitializeSimulation()
    {
        string moves = HttpContext.Session.GetString("Moves") ?? "ddddddddd";  // Domyœlna wartoœæ, jeœli brak danych w sesji

        // Tworzenie mapy toroidalnej
        var map = new SmallTorusMap(SizeX, SizeY);

        // Lista istot na mapie
        var creatures = new List<IMappable>
    {
        new Orc("Gorbag"), // Ork o imieniu Gorbag
        new Elf("Elandor"), // Elf o imieniu Elandor
        new Animals("Rabbits", false), // Zwierzêta (króliki)
        new Birds("Eagles", true), // Ptaki (or³y, zdolne do latania)
        new Birds("Ostriches", false) // Ptaki (struœ, nielataj¹cy)
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

        // Tworzenie instancji symulacji i jej historii
        Simulation = new Simulation(map, creatures, points, moves);  // U¿ywamy ruchów z sesji
        SimHistory = new SimulationHistory(Simulation);

        // Ustawienie logu dla pierwszej tury
        CurrentLog = SimHistory.TurnLogs[Turn];
    }

    // Pobiera aktualn¹ turê z sesji u¿ytkownika
    private int GetTurnFromSession() => HttpContext.Session.GetInt32("Turn") ?? 0;

    // Zapisuje numer aktualnej tury w sesji u¿ytkownika
    private void SaveTurnToSession(int turn) => HttpContext.Session.SetInt32("Turn", turn);

    // Obs³uguje ¿¹danie GET. Inicjalizuje symulacjê, jeœli jest to konieczne
    public void OnGet()
    {
        Turn = GetTurnFromSession();
        if (Simulation == null || SimHistory == null)
        {
            InitializeSimulation();
        }
    }

    // Obs³uguje ¿¹danie POST do ustawienia ruchów
    public void OnPostSetMoves(string moves)
    {
        // Sprawdzamy, czy moves s¹ poprawne
        if (!string.IsNullOrEmpty(moves) && moves.All(c => "udlr".Contains(c)))
        {
            // Zaktualizowanie listy ruchów w symulacji
            HttpContext.Session.SetString("Moves", moves);  // Zapisujemy ruchy w sesji
            Turn = 0;  // Resetujemy turê
            SaveTurnToSession(Turn);  // Zapisujemy turê w sesji
            InitializeSimulation();  // Inicjalizujemy symulacjê z nowymi danymi
        }
        else
        {
            // Obs³uga b³êdów, jeœli ruchy s¹ niepoprawne
            ModelState.AddModelError("Moves", "Musisz podaæ co najmniej jeden ruch (u, d, l, r).");
        }
    }


    // Obs³uguje przejœcie do nastêpnej tury
    public void OnPostNextTurn(string moves)
    {
        Turn = GetTurnFromSession();

        // Jeœli ruchy zosta³y przekazane przez formularz, zaktualizuj je
        if (!string.IsNullOrEmpty(moves))
        {
            // Zaktualizuj ruchy w symulacji
            Simulation.Moves = moves;
        }

        if (SimHistory == null)
        {
            InitializeSimulation();
        }

        if (Turn < SimHistory.TurnLogs.Count - 1)
        {
            Turn++;
            SaveTurnToSession(Turn);
            CurrentLog = SimHistory.TurnLogs[Turn];
        }
    }


    // Obs³uguje powrót do poprzedniej tury
    public void OnPostPrevTurn()
    {
        Turn = GetTurnFromSession();
        if (SimHistory == null)
        {
            InitializeSimulation();
        }

        if (Turn > 0)
        {
            Turn--;
            SaveTurnToSession(Turn);
            CurrentLog = SimHistory.TurnLogs[Turn];
        }
    }
}
