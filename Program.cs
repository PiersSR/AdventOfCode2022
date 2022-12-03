namespace AdventOfCode
{
    public class AdventOfCode
    {
        static void Main(string[] args)
        {
            DayTwoPartTwo puzzle = new DayTwoPartTwo();
            var result = puzzle.ResolvePuzzle<int>(args);

            Console.WriteLine(result);
        }
    }

    public abstract class Solution
    {
        public abstract T ResolvePuzzle<T>(string[] args);
    }
}