using System.Text.RegularExpressions;

var games = File.ReadAllLines("input.txt");

var maxR = 12;
var maxG = 13;
var maxB = 14;

var result = 0;
foreach (var game in games)
{
    var invalid = false;
    var gameMatch = Regex.Match(game, @"Game (\d+):");
    var gameId = int.Parse(gameMatch.Groups[1].Value);
    var sets = game.Split(':')[1].Replace(';', ',').Split(',');

    foreach (var set in sets)
    {
        var setMatch = Regex.Match(set, @"(\d+) (\w+)");
        var num = int.Parse(setMatch.Groups[1].Value);
        var color = setMatch.Groups[2].Value;
        if (color == "red" && num > maxR) invalid = true;
        if (color == "green" && num > maxG) invalid = true;
        if (color == "blue" && num > maxB) invalid = true;
        if (invalid) break;
    }

    if (invalid) continue;

    result += gameId;
}
Console.WriteLine(result);