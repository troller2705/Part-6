using System.Security.Cryptography;

namespace Part_6_Looping_Problems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string menu;
            bool done = false;

            while (!done)
            {
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1) Prompter");
                Console.WriteLine("2) Percent Passing");
                Console.WriteLine("3) Odd Sum");
                Console.WriteLine("4) Random Numbers");
                Console.WriteLine("5) Dice Game");
                Console.WriteLine("X) Exit");
                Console.Write("Enter a selection number to run it: ");
                menu = Console.ReadLine()!.ToLower();

                switch (menu)
                {
                    case "1":
                        Prompter();
                        break;
                    case "2":
                        PercentPassing();
                        break;
                    case "3":
                        OddSum();
                        break;
                    case "4":
                        RandomNumbers();
                        break;
                    case "5":
                        DiceGame();
                        break;
                    case "x":
                        done = true;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
        public static void Prompter()
        {
            int min;
            int max;
            int num;

            Console.Clear();
            Console.Write("Please enter a number for the min.: ");
            int.TryParse(Console.ReadLine(), out min);
            Console.Write("Please enter a number for the max.: ");
            int.TryParse(Console.ReadLine(), out max);

            if (min >= max)
            {
                Console.WriteLine("Min. can't be greater than or equal to max. please try again");
                Prompter();
            }

            Console.Write($"Please enter a number between {min} and {max}: ");
            int.TryParse(Console.ReadLine(), out num);

            if(num <= min || num >= max)
            {
                Console.Write($"Number must be between {min} and {max} please try again: ");
                int.TryParse(Console.ReadLine(), out num);
            }

            Console.WriteLine("Great Job! You can follow instructions.");
        }
        public static void PercentPassing()
        {
            double counter = 0;
            double passCounter = 0;
            bool done = false;
            string score;
            double percentScores;

            Console.Clear();
            while (!done)
            {
                Console.Write("Enter as many scores as you want then leave the input blank to get the percent of scores above 70%: ");
                score = Console.ReadLine();
                if (score!.Length > 0 && double.Parse(score) > 0)
                {
                    counter++;
                    if (double.Parse(score) >= 70)
                    {
                        passCounter++;
                    }
                }
                else
                {
                    done = true;
                }
            }

            //Console.WriteLine(counter); //debug
            //Console.WriteLine(passCounter); //debug
            percentScores = passCounter / counter * 100;
            Console.WriteLine("{0:0.##}",percentScores,"% of the scores entered were above a 70%");
            Thread.Sleep(2000);
        }
        public static void OddSum()
        {
            int max;
            int sum = 0;

            Console.Clear();
            Console.Write("Please enter a number: ");
            int.TryParse(Console.ReadLine(), out max);
            if(max <= 0)
            {
                Console.WriteLine("Number must be above 0");
                Thread.Sleep(2000);
                OddSum();
            }
            for (int i = 0; i <= max; i++)
            {
                if (i % 2 != 0)
                {
                    sum += i;
                } 
            }
            Console.WriteLine($"The sum of odd numbers from 0 to {max} is {sum}");
        }
        public static void RandomNumbers()
        {
            int min;
            int max;
            var rand = new Random();

            Console.Clear();
            Console.Write("Input a min. value:");
            int.TryParse(Console.ReadLine(), out min);
            Console.Write("Input a max value:");
            int.TryParse(Console.ReadLine(), out max);

            if (max < min)
            {
                Console.WriteLine("Max can't be below the min.");
                Console.Write("Input a max value:");
                int.TryParse(Console.ReadLine(), out max);
            }
            for (int ctr = 0; ctr <= 24; ctr++)
                Console.Write("{0,5:N0}", rand.Next(min, max + 1));
            Console.WriteLine();
            Thread.Sleep(2000);
        }
        public static void DiceGame()
        {
            var rand = new Random();
            decimal bank = 100.00m;
            bool done = false;
            string type;
            decimal bet;
            int roll1;
            int roll2;
            string[] die;

            Console.Clear();
            while (!done)
            {
                if (bank < 0)
                {
                    done = true;
                }
                Console.WriteLine("Current balance: {0:C}", bank);
                roll1 = rand.Next(1, 7);
                roll2 = rand.Next(1, 7);
                Console.Write("Please enter the desired bet type (Doubles, Not Doubles, Even Sum, Odd Sum): ");
                type = Console.ReadLine()!.ToLower();
                Console.Write("Please enter the desired bet amount: ");
                if (Decimal.TryParse(Console.ReadLine(), out bet) && bet > 0)
                {
                    die = SetDie(roll1);
                    Console.WriteLine("\n\n");
                    foreach (string line in die)
                        Console.WriteLine(line);
                    //Console.WriteLine(roll1); debug tool

                    die = SetDie(roll2);
                    Console.WriteLine("\n\n");
                    foreach (string line in die)
                        Console.WriteLine(line);
                    //Console.WriteLine(roll2); debug tool

                    switch (type)
                    {
                        case "doubles":
                            if (roll1 == roll2)
                            {
                                bank += bet * 2;
                                Console.WriteLine("You won! Gaining {0:C}", bet * 2);
                            }
                            else
                            {
                                bank -= bet;
                                Console.WriteLine("You lost! Losing {0:C}", bet);
                            }
                            break;
                        case "not doubles":
                            if (roll1 != roll2)
                            {
                                bank += bet / 2;
                                Console.WriteLine("You won! Gaining {0:C}", bet / 2);
                            }
                            else
                            {
                                bank -= bet;
                                Console.WriteLine("You lost! Losing {0:C}", bet);
                            }
                            break;
                        case "even sum":
                            if ((roll1 + roll2) % 2 == 0)
                            {
                                bank += bet;
                                Console.WriteLine("You won! Gaining {0:C}", bet);
                            }
                            else
                            {
                                bank -= bet;
                                Console.WriteLine("You lost! Losing {0:C}", bet);
                            }
                            break;
                        case "odd sum":
                            if ((roll1 + roll2) % 2 != 0)
                            {
                                bank += bet;
                                Console.WriteLine("You won! Gaining {0:C}", bet);
                            }
                            else
                            {
                                bank -= bet;
                                Console.WriteLine("You lost! Losing {0:C}", bet);
                            }
                            break;
                        default:
                            Console.WriteLine("Type invalid please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Bet invalid please try again.");
                }
                Console.Write("Do you wish to play again? (Yes/No): ");
                if (Console.ReadLine()!.ToLower() == "no")
                {
                    done = true;
                }
            }
        }
        public static string[] SetDie(int roll)
        {
            string[] die;

            if (roll == 1)
            {
                die = new string[]
                {
                    "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                    "⣿⣿⡏⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⢹⣿⣿",
                    "⣿⣿⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⣿⣿",
                    "⣿⣿⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⣿⣿",
                    "⣿⣿⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀       ⠀⣿⣿",
                    "⣿⣿⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀       ⠀⣿⣿",
                    "⣿⣿⠀⠀       ⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⣿⣿",
                    "⣿⣿⣇⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣸⣿⣿",
                    "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿"
                };
            }
            else if (roll == 2)
            {
                die = new string[]
                {
                    "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                    "⣿⣿⡏⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⢹⣿⣿",
                    "⣿⣿⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⣿⣿",
                    "⣿⣿⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⣿⣿",
                    "⣿⣿⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⣿⣿",
                    "⣿⣿⣇⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣸⣿⣿",
                    "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿"
                };
            }
            else if (roll == 3)
            {
                die = new string[]
                {
                    "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                    "⣿⣿⡏⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⢹⣿⣿",
                    "⣿⣿⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⣿⣿",
                    "⣿⣿⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⣿⣿",
                    "⣿⣿⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⣿⣿",
                    "⣿⣿⣇⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣸⣿⣿",
                    "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿"
                };
            }
            else if (roll == 4)
            {
                die = new string[]
                {
                    "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                    "⣿⣿⡏⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⢹⣿⣿",
                    "⣿⣿⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⣿⣿",
                    "⣿⣿⣇⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣸⣿⣿",
                    "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿"
                };
            }
            else if (roll == 5)
            {
                die = new string[]
                {
                    "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                    "⣿⣿⡏⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⢹⣿⣿",
                    "⣿⣿⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⣿⣿",
                    "⣿⣿⣇⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣸⣿⣿",
                    "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿"
                };
            }
            else
            {
                die = new string[]
                {
                    "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                    "⣿⣿⡏⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⢹⣿⣿",
                    "⣿⣿⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣷⣄  ⣿⣿",
                    "⣿⣿⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿  ⣿⣿",
                    "⣿⣿⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⡿⠋  ⣿⣿",
                    "⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣷⣄⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⠀⠀⣿⣿",
                    "⣿⣿⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⡿⠋⠀⠀⣿⣿",
                    "⣿⣿⣇⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣸⣿⣿",
                    "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿"
                };
            }

            return die;
        }
    }
}