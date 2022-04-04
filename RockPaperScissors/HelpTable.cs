using System;
using System.Text;

namespace RockPaperScissors {

    internal class HelpTable {
	
		public static void Print(string[] moves) {
		
			foreach (var move in moves) 
				Console.Write("{0, 15}", move);
			Console.WriteLine();
		
			int counter = 0;
			foreach (var move in moves) {
				Console.Write("{0, -11}", move);
				for (int i = 0; i < moves.Length; i++) {
					int result = Rules.GetBattleResult(moves, i, counter);
					if (result == 1)
						Console.Write("{0, -15}", "Win");
					else if (result == -1)
						Console.Write("{0, -15}", "Lose");
					else
						Console.Write("{0, -15}", "Dead heat...");
				}
					
				counter += 1;
				Console.WriteLine();
			}

		}

    }
    
}
