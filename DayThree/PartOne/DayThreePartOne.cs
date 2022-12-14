namespace AdventOfCode
{
    using System.IO;
    using System.Linq;

    class DayThreePartOne : Solution
    {
        private IList<char> _duplicateItems = new List<char>();
        private IEnumerable<int> _priorityMappings = new List<int>();

        public override T ResolvePuzzle<T>(string[] args)
        {
            IEnumerable<string> rucksacks = File.ReadAllLines(args[0]);
            

            foreach (string rucksack in rucksacks)
            {
                bool isMatchFound = false;

                int compartmentSplittingIndex = (rucksack.Length / 2);

                string compartmentA = rucksack.Substring(0, compartmentSplittingIndex);
                string compartmentB = rucksack.Substring(compartmentSplittingIndex);

                foreach (char itemInCompartmentA in compartmentA.ToArray())
                {
                    if (isMatchFound)
                        continue;

                    char duplicateItem = compartmentB.Where(itemInCompartmentB => itemInCompartmentB.Equals(itemInCompartmentA)).FirstOrDefault();
                    
                    if (duplicateItem > 0)
                    {
                        _duplicateItems.Add(duplicateItem);
                        isMatchFound = true;
                    }
                }
            }
            
            _priorityMappings = _duplicateItems.Select(item => Char.IsUpper(item) ? item % 32 + 26 : item % 32);
            
            int result = _priorityMappings.Sum();

            return (T)Convert.ChangeType(result, typeof(T));
        }
    }
}