namespace A1P1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt").Trim();
            var lines = input.Split("\r\n");

            var result = 0;
            foreach (var line in lines)
            {
                var nums = line.Where(char.IsNumber).Select(char.GetNumericValue).ToArray();
                result += int.Parse($"{nums.First()}{nums.Last()}");
            }
            Console.WriteLine(result);
        }
    }
}