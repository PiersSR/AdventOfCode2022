namespace AdventOfCode
{
    public class AdventOfCode
    {
        static void Main(string[] args)
        {
            DayThreePartTwo puzzle = new DayThreePartTwo();
            var result = puzzle.ResolvePuzzle<int>(args);

            Console.WriteLine(result);
        }
    }

    public abstract class Solution
    {
        public abstract T ResolvePuzzle<T>(string[] args);
    }
}