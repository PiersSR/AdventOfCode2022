namespace AdventOfCode
{
    using System.IO;
    using System.Linq;

    class DayThreePartTwo : Solution
    {
        private IList<char> _badgeCharacters = new List<char>();
        private IEnumerable<int> _priorityMappings = new List<int>();

        public override T ResolvePuzzle<T>(string[] args)
        {
            IEnumerable<string> rucksacks = File.ReadAllLines(args[0]);
            
            char badgeCharacter;

            for (int i = 0; i < rucksacks.Count(); i += 3)
            {
                IEnumerable<string> elfGroup = new List<string>();
                int lastRucksackInGroup = i + 3;

                // Get the group of elf rucksacks by finding the next three rucksacks in the list.
                elfGroup = rucksacks.Where((rucksack, index) => index < lastRucksackInGroup && index >= i);
                badgeCharacter = CompareRucksacksInGroup(elfGroup);

                _badgeCharacters.Add(badgeCharacter);
            }

            _priorityMappings = _badgeCharacters.Select(item => Char.IsUpper(item) ? item % 32 + 26 : item % 32);
            
            int result = _priorityMappings.Sum();

            return (T)Convert.ChangeType(result, typeof(T));
        }

        private char CompareRucksacksInGroup(IEnumerable<string> rucksacks)
        {
            IList<char> matchingCharactersInGroup = new List<char>();

            foreach (string rucksack in rucksacks)
            {
                int compartmentSplittingIndex = (rucksack.Length / 2);

                string compartmentA = rucksack.Substring(0, compartmentSplittingIndex);
                string compartmentB = rucksack.Substring(compartmentSplittingIndex);
                matchingCharactersInGroup.Add(FindMatchesInRucksack(compartmentA, compartmentB));
            }
            
            string matchingCharactersToCompare = string.Join(string.Empty, matchingCharactersInGroup);
            foreach (char characterToFind in matchingCharactersToCompare)
            {
                char result = matchingCharactersInGroup.Where(matchingCharacters => matchingCharacters.ToString().Contains(characterToFind)).FirstOrDefault();
                
                if (!string.IsNullOrEmpty(result.ToString()))
                    return result;
            }

            return ' ';
        }

        private char FindMatchesInRucksack(string compartmentA, string compartmentB)
        {
            foreach (char itemInCompartmentA in compartmentA.ToArray())
            {
                char duplicateCharacter = compartmentB.Where(itemInCompartmentB => itemInCompartmentB.Equals(itemInCompartmentA)).FirstOrDefault();

                if (duplicateCharacter > 0)
                    return duplicateCharacter;
            }

            return ' ';
        }
    }
}