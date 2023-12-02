using System.Text.RegularExpressions;

var games = File.ReadAllLines("input.txt");

var result = 0;
foreach (var game in games)
{
    var gameMatch = Regex.Match(game, @"Game (\d+):");
    var gameId = int.Parse(gameMatch.Groups[1].Value);
    var sets = game.Split(':')[1].Replace(';', ',').Split(",");

    var reds = new List<int>();
    var greens = new List<int>();
    var blues = new List<int>();

    foreach (var set in sets)
    {
        var setMatch = Regex.Match(set, @"(\d+) (\w+)");
        var num = int.Parse(setMatch.Groups[1].Value);
        var color = setMatch.Groups[2].Value;
        if (color == "red") reds.Add(num);
        if (color == "green") greens.Add(num);
        if (color == "blue") blues.Add(num);
    }

    result += reds.Max() * greens.Max() * blues.Max();
}
Console.WriteLine(result);