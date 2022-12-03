namespace AdventOfCode
{
    public class AdventOfCode
    {
        static void Main(string[] args)
        {
            PartTwo puzzle = new PartTwo();
            var result = puzzle.ResolvePuzzle<int>(args);

            Console.WriteLine(result);
        }
    }

    public abstract class Solution
    {
        public abstract T ResolvePuzzle<T>(string[] args);
    }
}