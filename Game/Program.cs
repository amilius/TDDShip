using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ship;


namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 15;//rozmiar planety
            Point max = new Point(m, m);
            List<Point> przeszkody = new List<Point>();
            Planet planeta = new Planet(max,przeszkody);
            int iloscPrzeszkod = 10;
            var rnd = new Random();
            Spaceship statek = new Spaceship(new Location(new Point(0, 0), Direction.NORTH)); ;
            while (iloscPrzeszkod != 0)
            {
                int namiar1 = rnd.Next(1,m);
                int namiar2  = rnd.Next(1,m);
                int index = przeszkody.FindIndex(x => x.X == namiar1 &&  x.Y == namiar2);
                if (index == -1)
                {
                    przeszkody.Add(new Point(namiar1, namiar2));
                    iloscPrzeszkod--;
                }
                
            }

            int indexStatku;
            do
            {
                int namiarStatkuX = rnd.Next(1,m);
                int namiarStatkuY = rnd.Next(1,m);
                indexStatku = przeszkody.FindIndex(x => x.X == namiarStatkuX && x.Y == namiarStatkuY);
                if (indexStatku == -1)
                {

                    statek = new Spaceship(new Location(new Point(namiarStatkuX, namiarStatkuY),Direction.NORTH ));
                }

            } while (indexStatku >= 0);

            foreach (var p in przeszkody)
            {
                Console.WriteLine($"x {p.X} y {p.Y}");
            }

            string instructions;
            do
            {
                PrintPlanet(max, przeszkody, statek);
                instructions = ReadInstructions();
                string result = statek.Command(instructions, max, przeszkody);
                Console.WriteLine(result);
                Console.WriteLine($"pozycja statku x:{statek.Location.X}, y:{statek.Location.Y}");
            } while (instructions != "q");

            Console.ReadKey();
        }

        public static void PrintPlanet(Point max, List<Point> przeszkody, Spaceship statek)
        {
            for (int j = 1; j < max.Y+1; j++)
            {
                for (int k = 1; k < max.X+1; k++)
                {
                    int index = przeszkody.FindIndex(x => x.X == k && x.Y == j);
                    
                    if (index >= 0)
                    {
                        Console.Write(" m");
                    }
                    else if (statek.Location.X == k && statek.Location.Y == j)
                    {
                        if(statek.GetDirection() == Direction.NORTH)
                            Console.Write(" ^");

                        if (statek.GetDirection() == Direction.EAST)
                            Console.Write(" >");

                        if (statek.GetDirection() == Direction.SOUTH)
                            Console.Write(" v");

                        if (statek.GetDirection() == Direction.WEST)
                            Console.Write(" <");


                    }
                    else
                    {
                        Console.Write(" ~");
                    }


                }
                Console.WriteLine("");
            }
        }

        public static string ReadInstructions()
        {
            Console.WriteLine("Instructions:");
            string instructions = Console.ReadLine();
            return instructions;
        }
    }
}
