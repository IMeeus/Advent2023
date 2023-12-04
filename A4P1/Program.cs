var lines = File.ReadAllLines("input.txt");

var result = 0;

foreach (var line in lines)
{
    var split = line.Split(':')[1].Split('|');
    var winning = split[0].Split(' ').Where(x => x != "").Select(int.Parse);
    var mine = split[1].Split(' ').Where(x => x != "").Select(int.Parse);

    mine = mine.Where(x => winning.Contains(x));
    if (mine.Any())
    {
        result += (int)Math.Pow(2, mine.Count() - 1);
    }
}
Console.WriteLine(result);