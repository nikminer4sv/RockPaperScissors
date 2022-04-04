using System;

namespace RockPaperScissors {

    internal class Program {

        static void Main(string[] args) {

            Validate(args);

            StartGame(args);

        }

        public static void PrintMenu(string[] moves, string HMAC)
        {
            Console.WriteLine($"HMAC:\n{HMAC}");
            Console.WriteLine("Available moves:");
            for (int i = 0; i < moves.Length; i++)
                Console.WriteLine($"{i + 1} - {moves[i]}");
            Console.WriteLine("0 - exit\n? - help");
            Console.Write("Enter your move: ");
        }

        public static void StartGame(string[] moves) {

            int computerChoice = new Random().Next(0, moves.Length);

            string key = Encryptor.GenerateRandomKey();
            string HMAC = Encryptor.GenerateHMAC(moves[computerChoice], key);

            PrintMenu(moves, HMAC);

            string userChoiceStr = Console.ReadLine();
            int userChoice = 0;
            if (userChoiceStr.Length == 1) {
                
                if (userChoiceStr == "?") {
                    
                    HelpTable table = new HelpTable(moves);
                    Console.WriteLine(table.ToString());
                    Environment.Exit(0);

                } else if (char.IsNumber(userChoiceStr[0])) {

                    if (int.Parse(userChoiceStr) >= 0 && int.Parse(userChoiceStr) <= moves.Length) {

                        if (int.Parse(userChoiceStr) == 0) {
                            Environment.Exit(0);
                        } else {
                            userChoice = int.Parse(userChoiceStr);
                        }
                        
                    }

                }

            }


            Console.WriteLine($"Your move: {moves[userChoice - 1]}");
            Console.WriteLine($"Computer move: {moves[computerChoice]}");

            int BattleResult = Rules.GetBattleResult(moves, userChoice - 1, computerChoice);

            if (BattleResult == 1)
                Console.WriteLine("You win!");
            else if (BattleResult == -1) 
                Console.WriteLine("You lose!");
            else
                Console.WriteLine("Dead heat...");
                
            Console.WriteLine($"HMAC key:\n{key}");
            

        }

        static void Validate(string[] args) {

            if (args.Length < 3) {
                Console.WriteLine("Number of actions must be more or equal to 3.");
                Environment.Exit(0);
            }
            if (args.Length % 2 == 0) {
                Console.WriteLine("Number of actions must be odd.");
                Environment.Exit(0);
            }

            for (int i = 0; i < args.Length; i++) {
                for (int j = i + 1; j < args.Length; j++) {
                    if (args[i].ToLower() == args[j].ToLower()) {
                        Console.WriteLine("Elements must be different.");
                        Environment.Exit(0);
                    }
                }
            }

        }

    }

}