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
	
		public static int UserInputProcessing(int movesLength) {
			string? userInput = Console.ReadLine();
			
			int a;
	        bool flag = int.TryParse(userInput, out a);

			if (userInput == null || (flag == false && userInput != "?"))
				return -1;

			if (flag)
				if (a > movesLength || a < 0)
					return -2;
			
			if (userInput == "?")
				return -999;
			
			return int.Parse(userInput);
		}

        public static void StartGame(string[] moves) {

            int computerChoice = new Random().Next(0, moves.Length);
            string key = Encryptor.GenerateRandomKey();
            string HMAC = Encryptor.GenerateHMAC(moves[computerChoice], key);

            PrintMenu(moves, HMAC);
			
			int userChoice;
			do {
				userChoice = UserInputProcessing(moves.Length);
				if (userChoice == -1 || userChoice == -3)
					Console.WriteLine("Wrong input!");
				else if (userChoice == -2)
					Console.WriteLine("Option with this number does not exist!");
				else if (userChoice == -999)
					HelpTable.Print(moves);	
			} while(userChoice < 0);
			
			if (userChoice == 0)
				Environment.Exit(0);

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
