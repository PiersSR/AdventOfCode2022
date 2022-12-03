namespace AdventOfCode
{
    using System.IO;
    using System.Linq;

    class Dayone
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText(args[0]);

            // Separate input into a list of calories by elf.
            IEnumerable<string> caloriesByElf = input.Split("\r\n\r\n");
            IList<int> summedCalories = new List<int>();

            // Convert each string into the summed value of the elf's inventory.
            foreach (string caloriesHeldByElf in caloriesByElf)
            {
                // Convert the string of held calories into an array of integers, and sum it.
                int summedCaloriesForElf = caloriesHeldByElf.Split("\r\n").Sum(calories => Convert.ToInt32(calories));
                
                // Store the result in a list. We will end up with a list of total calories held by each elf.
                summedCalories.Add(summedCaloriesForElf);
            }

            // Sort the list by the total calories in each elf's inventory and return the first (highest) value.
            int highestCaloryElf = summedCalories.OrderByDescending(calories => calories).First();

            Console.WriteLine(highestCaloryElf);
        }
    }
}