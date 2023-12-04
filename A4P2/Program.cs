using System.Text.RegularExpressions;

var lines = File.ReadAllLines("input.txt");

int[] counts = new int[lines.Length];
for (int i = 0; i < lines.Length; i++)
{
    var line = lines[i];
    var match = Regex.Match(line, @"(\d+): (.*) [|] (.*)");
    var winners = match.Groups[2].Value.Split().Where(x => x != "");
    var nums = match.Groups[3].Value.Split().Where(x => x != "");
    var winCount = nums.Count(x => winners.Contains(x));

    for (int j = 0; j < counts[i] + 1; j++)
    {
        for (int k = 0; k < winCount; k++)
        {
            counts[i + k + 1]++;
        }
    }
}

var result = lines.Length + counts.Sum();

Console.WriteLine(result);