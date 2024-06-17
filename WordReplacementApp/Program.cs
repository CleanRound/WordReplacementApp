class WordReplacementApp
{
    static void Main()
    {
        Console.Write("Enter the path of the file: ");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        Console.Write("Enter the word to search for: ");
        string searchWord = Console.ReadLine();

        Console.Write("Enter the word to replace with: ");
        string replaceWord = Console.ReadLine();

        string fileContent = File.ReadAllText(filePath);
        int occurrences = CountOccurrences(fileContent, searchWord);

        string updatedContent = fileContent.Replace(searchWord, replaceWord);
        File.WriteAllText(filePath, updatedContent);

        Console.WriteLine("Word replacement complete.");
        Console.WriteLine($"Number of occurrences replaced: {occurrences}");
    }

    static int CountOccurrences(string text, string word)
    {
        int count = 0;
        int index = text.IndexOf(word, StringComparison.OrdinalIgnoreCase);
        while (index != -1)
        {
            count++;
            index = text.IndexOf(word, index + word.Length, StringComparison.OrdinalIgnoreCase);
        }
        return count;
    }
}
