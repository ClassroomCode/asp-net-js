namespace LangDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int>() { 1, 2, 3, 4, 5 };

            var evens = nums.Where(i => i % 2 == 0);

            foreach (var n in evens) {
                Console.WriteLine(n);
            }

            Console.WriteLine("-------");

            nums.Add(6);
            foreach (var n in evens) {
                Console.WriteLine(n);
            }
        }
    }
}
