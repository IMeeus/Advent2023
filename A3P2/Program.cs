var lines = File.ReadAllLines("input.txt");

Dictionary<(int x, int y), string> parts = [];
Dictionary<(int x, int y), char> symbols = [];
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
            symbols.Add((x, y), c);
        }
    }
}

var result = 0;
foreach (var symbol in symbols.Keys)
{
    if (symbols[symbol] != '*') continue;

    var nearParts = parts.Keys.Where(part =>
        part.y >= symbol.y - 1 &&
        part.y <= symbol.y + 1 &&
        symbol.x >= part.x - 1 &&
        symbol.x <= part.x + parts[part].Length
    ).ToList();

    if (nearParts.Count() == 2)
    {
        result += int.Parse(parts[nearParts[0]]) * int.Parse(parts[nearParts[1]]);
    }
}

Console.WriteLine(result);