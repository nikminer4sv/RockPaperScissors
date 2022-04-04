using System;
using System.Text;

namespace RockPaperScissors {

    internal class HelpTable {

        private string[] moves;

        public HelpTable() {}
        public HelpTable(string[] moves) => this.moves = moves;

        public void SetMoves(string[] moves) => this.moves = moves;

        public override string ToString() {

            StringBuilder result = new StringBuilder("-----BEAT TABLE-----\n");
            //string result = "-----BEAT TABLE-----\n";

            for (int i = 0; i < moves.Length; i++) {

                result.Append($"{i + 1}. {moves[i]} beats ");
                int[] beatList = Rules.GetBeatList(moves.Length, i);
                foreach (int element in beatList)
                    result.Append(element.ToString() + ", ");

                result.Remove(result.Length - 2, 2);
                result.Append('\n');

            }

            return result.ToString();

        }

    }
    
}