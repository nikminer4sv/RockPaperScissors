using System;

namespace RockPaperScissors {
    
    internal static class Rules {

        internal static int GetBattleResult(string[] moves, int playerChoice, int computerChoice) {

            if (playerChoice < computerChoice) {

                int leftSide = computerChoice - playerChoice;
                int rightSide = playerChoice + (moves.Length - computerChoice);

                return (leftSide > rightSide) ? 1 : -1;

            } else if (playerChoice > computerChoice) {

                int leftSide = computerChoice + (moves.Length - playerChoice);
                int rightSide = playerChoice - computerChoice;

                return (leftSide > rightSide) ? 1 : -1;

            } 

            return 0;

        }

        internal static int[] GetBeatList(int movesSize, int current) {

            int[] result = new int[movesSize / 2];

            int counter = 0;
            while (counter < movesSize / 2) {
                
                if (current - 1 - counter < 0)
                    result[counter] = movesSize + current - counter;
                else
                    result[counter] = current - counter;

                counter += 1;
            }

            return result;

        }

    }

}