var map = new Dictionary<string, int>()
{
    { "one", 1 },
    { "two", 2 },
    { "three", 3 },
    { "four", 4 },
    { "five", 5 },
    { "six", 6 },
    { "seven", 7 },
    { "eight", 8 },
    { "nine", 9 },
};

int? TryGetNumber(char c, string buffer)
{
    if (char.IsNumber(c))
        return (int)char.GetNumericValue(c);

    var match = map.Keys.SingleOrDefault(x => buffer.Contains(x));
    if (match is not null)
        return map[match];

    return null;
}

var lines = File.ReadAllLines("input.txt");
var sum = 0;
foreach (var line in lines)
{
    var cal = "";

    for (int i = 0; i < line.Length; i++)
    {
        var c = line[i];
        var buffer = line[..(i + 1)];

        var num = TryGetNumber(c, buffer);
        if (num is null) continue;
        cal += num; break;
    }

    for (int i = line.Length - 1; i >= 0; i--)
    {
        var c = line[i];
        var buffer = line[i..];

        var num = TryGetNumber(c, buffer);
        if (num is null) continue;
        cal += num; break;
    }

    sum += int.Parse(cal);
}

Console.WriteLine(sum);