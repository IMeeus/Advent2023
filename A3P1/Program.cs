// 10:20

var lines = File.ReadAllLines("input.txt");

Dictionary<(int x, int y), string> parts = [];
List<(int x, int y)> symbols = [];
(int x, int y)? addingTo = null;

for (int y = 0; y < lines.Length; y++)
{
    for (int x = 0; x < lines[y].Length; x++)
    {
        char c = lines[y][x];

        if (addingTo.HasValue && !char.IsNumber(c))
        {
            addingTo = null;
        }

        if (c == '.') continue;

        if (char.IsNumber(c))
        {
            if (addingTo is null)
            {
                parts.Add((x, y), "" + c);
                addingTo = (x, y);
            }
            else
            {
                parts[addingTo.Value] += c;
            }
        }

        if (!char.IsLetterOrDigit(c))
        {
            symbols.Add((x, y));
        }
    }
}

var result = 0;
foreach (var part in parts.Keys)
{
    var valid = symbols.Any(symbol =>
        part.y >= symbol.y - 1 &&
        part.y <= symbol.y + 1 &&
        symbol.x >= part.x - 1 &&
        symbol.x <= part.x + parts[part].Length
    );

    if (valid)
    {
        result += int.Parse(parts[part]);
    }
}

Console.WriteLine(result);