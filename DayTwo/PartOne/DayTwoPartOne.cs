namespace AdventOfCode
{
    using System.IO;
    using System.Linq;

    class DayTwoPartOne : Solution
    {
        private const char OPPONENT_ROCK = 'A';
        private const char OPPONENT_PAPER = 'B';
        private const char OPPONENT_SCISSORS = 'C';
        private const char ROCK = 'X';
        private const char PAPER = 'Y';
        private const char SCISSORS = 'Z';
        private const int ROCK_SCORE = 1;
        private const int PAPER_SCORE = 2;
        private const int SCISSORS_SCORE = 3;
        private const int DRAW_SCORE = 3;
        private const int WIN_SCORE = 6;
        private IList<int> _opponentScores = new List<int>();
        private IList<int> _myScores = new List<int>();

        public override T ResolvePuzzle<T>(string[] args)
        {
            IEnumerable<string> strategies = File.ReadAllLines(args[0]);
            int myScore;
            int opponentScore;

            foreach (string round in strategies)
            {
                // Split the strategy for the round into the opponents move and my move.
                string[] strategy = round.Split(' ');

                // Reset the scores for this round.
                myScore = 0; 
                opponentScore = 0;

                // Get the moves for each player.
                char opponentMove = strategy[0][0];
                char myMove = strategy[1][0];

                ResolveRound(opponentMove, myMove, ref myScore, ref opponentScore);
            }

            int result = _myScores.Sum();

            return (T)Convert.ChangeType(result, typeof(T));
        }

        private bool ResolveRound(char opponentMove, char myMove, ref int myScore, ref int opponentScore)
        {
            Results roundResult;

            switch (opponentMove)
            {
                case OPPONENT_ROCK:
                    opponentScore = ROCK_SCORE;
                    roundResult = ResolveRockMove(myMove, ref myScore, ref opponentScore);
                    break;
                case OPPONENT_PAPER:
                    opponentScore = PAPER_SCORE;
                    roundResult = ResolvePaperMove(myMove, ref myScore, ref opponentScore);
                    break;
                case OPPONENT_SCISSORS:
                    opponentScore = SCISSORS_SCORE;
                    roundResult = ResolveScissorsMove(myMove, ref myScore, ref opponentScore);
                    break;
                default:
                    throw new Exception($"Opponent move not recognised.");
            }

            CalculateScores(ref myScore, ref opponentScore, roundResult);
            
            return true;
        }

        private void CalculateScores(ref int myScore, ref int opponentScore, Results roundResult)
        {
            if (roundResult == Results.Win)
            {
                myScore += WIN_SCORE;
            }
            else if (roundResult == Results.Draw)
            {
                myScore += DRAW_SCORE;
                opponentScore += DRAW_SCORE;
            }
            else
            {
                opponentScore += WIN_SCORE;
            }

            _myScores.Add(myScore);
            _opponentScores.Add(opponentScore);
        }

        private Results ResolveRockMove(char myMove, ref int myScore, ref int opponentScore)
        {
            Results result = Results.Loss;

            if (myMove.Equals(PAPER))
            {
                myScore = PAPER_SCORE;
                result = Results.Win;
            }
            else if (myMove.Equals(ROCK))
            {
                myScore = ROCK_SCORE;
                result = Results.Draw;
            }
            else
            {
                myScore = SCISSORS_SCORE;
                result = Results.Loss;
            }

            return result;
        }

        private Results ResolvePaperMove(char myMove, ref int myScore, ref int opponentScore)
        {
            Results result = Results.Loss;

            if (myMove.Equals(SCISSORS))
            {
                myScore = SCISSORS_SCORE;
                result = Results.Win;
            }
            else if (myMove.Equals(PAPER))
            {
                myScore = PAPER_SCORE;
                result = Results.Draw;
            }
            else
            {
                myScore = ROCK_SCORE;
                result = Results.Loss;
            }

            return result;
        }

        private Results ResolveScissorsMove(char myMove, ref int myScore, ref int opponentScore)
        {
            Results result = Results.Loss;

            if (myMove.Equals(ROCK))
            {
                myScore = ROCK_SCORE;
                result = Results.Win;
            }
            else if (myMove.Equals(SCISSORS))
            {
                myScore = SCISSORS_SCORE;
                result = Results.Draw;
            }
            else
            {
                myScore = PAPER_SCORE;
                result = Results.Loss;
            }

            return result;
        }

        internal enum Results
        {
            Loss = 1,
            Draw = 2,
            Win = 3
        }
    }
}