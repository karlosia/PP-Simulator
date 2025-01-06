namespace Simulator;
internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();

    }
    public static void Lab5a()
    {

        Console.WriteLine("== Tworzenie prostokątów ==");

        Rectangle firstrec = new Rectangle(1, 4, 3, 8);
        Console.WriteLine("Pierwszy prostokąt: " + firstrec);

        Rectangle secrec = new Rectangle(9, 6, 1, 3);
        Console.WriteLine("Drugi prostokąt: " + secrec);


        Point p1 = new Point(2, 2);
        Point p2 = new Point(3, 3);
        Rectangle thirdrec = new Rectangle(p1, p2);
        Console.WriteLine("Trzeci prostokąt: " + thirdrec);

        try
        {
            Rectangle rect4 = new Rectangle(3, 3, 3, 6);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}

