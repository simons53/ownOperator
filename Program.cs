namespace ownOperator
{
    public class Valorant
    {
        public string Map { get; set; }
        public int? rounds { get; set; }
        public double Minutes { get; set; }
        public double TotalGames { get; set; }
        public double TotalMinutes { get; set; }

        public static Valorant operator ++(Valorant map)
        {

            map.TotalGames++;
            return map;

        }

        public static Valorant operator +(Valorant map, double time)
        {

            map.TotalMinutes += time;
            return map;

        }

        public static bool operator >(Valorant map1, Valorant map2)
        {

            bool result = false;
            if (map1.TotalMinutes > map2.TotalMinutes)
            {
                result = true;
            }
            return result;
        }


        public static bool operator <(Valorant map1, Valorant map2)
        {
            bool result = false;
            if (map1.TotalMinutes < map2.TotalMinutes)
            {
                result = true;
            }
            return result;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Valorant[] day1Games = new Valorant[15];
            Valorant[] day2Games = new Valorant[15];
            for (int i = 0; i < day1Games.Length; i++)
            {
                day1Games[i] = new Valorant();
                day2Games[i] = new Valorant();
            }
            bool more = true;
            int day1Counter = 0;

            Console.WriteLine("Map(s) played on Day 1");
            while (more)
            {
                day1Counter++;

                Console.WriteLine("Enter the map you played on: ");
                day1Games[day1Counter].Map = Console.ReadLine();

                Console.WriteLine("Number of rounds in the game?");
                day1Games[day1Counter].rounds = int.Parse(Console.ReadLine());

                Console.WriteLine("Minutes?");
                day1Games[day1Counter].Minutes = double.Parse(Console.ReadLine());
                day1Games[0]++;
                day1Games[0] += day1Games[day1Counter].Minutes;

                Console.WriteLine("Did you play any other maps? (any key for yes, N for no)");
                string moreMaps = Console.ReadLine();
                if (moreMaps.ToLower() == "n" || day1Counter >= 49)
                    more = false;
            }


            more = true;
            int day2Counter = 0;
            Console.WriteLine("Map(s) played on Day 2");
            while (more)
            {
                day2Counter++;
                Console.WriteLine("Enter the Map you played on: ");
                day2Games[day2Counter].Map = Console.ReadLine();

                Console.WriteLine("Number of rounds?");
                day2Games[day2Counter].rounds = int.Parse(Console.ReadLine());

                Console.WriteLine("Minutes?");
                day2Games[day2Counter].Minutes = double.Parse(Console.ReadLine());
                day2Games[0]++;
                day2Games[0] += day2Games[day2Counter].Minutes;

                Console.WriteLine("Did you play any other maps? (any key for yes, N for no)");
                string moreMaps = Console.ReadLine();
                if (moreMaps.ToLower() == "n" || day2Counter >= 49)
                    more = false;


            }

            Console.WriteLine("_______________________________");
            Console.WriteLine("Day 1 Valorant Game Information");
            Console.WriteLine($"Number of Games Played: {day1Games[0].TotalGames}");
            Console.WriteLine("_______________________________");
           
            foreach (var day1 in day1Games)
            {
                if (day1.Minutes != 0)
                {
                    Console.WriteLine($"Map: {day1.Map}");
                    Console.WriteLine($"Rounds: {day1.rounds}");
                    Console.WriteLine($"Minutes: {day1.Minutes}");

                }
            }

            Console.WriteLine();
            Console.WriteLine("_______________________________");
            Console.WriteLine("Day 2 Valorant Game Information");
            Console.WriteLine($"Number of Games Played: {day2Games[0].TotalGames}");
            Console.WriteLine("_______________________________");
           
            foreach (var day2 in day2Games)
            {
                if (day2.Minutes != 0)
                {
                    Console.WriteLine($"Map: {day2.Map}");
                    Console.WriteLine($"Rounds: {day2.rounds}");
                    Console.WriteLine($"Minutes: {day2.Minutes}");

                }

            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("_______________________________");
   
            if (day1Games[0] > day2Games[0])
            {
                double difference = day1Games[0].TotalMinutes - day2Games[0].TotalMinutes;
                Console.WriteLine($"Your game(s) lasted {difference} Minutes more yesterday than today");
            }
            else
            {
                double difference = day2Games[0].TotalMinutes - day1Games[0].TotalMinutes;
                Console.WriteLine($"Your game(s) lasted {difference} Minutes more today than yesterday");
            
            }
        }
    }
}
