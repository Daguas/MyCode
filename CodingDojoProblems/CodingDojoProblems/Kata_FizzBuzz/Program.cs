namespace FizzBuzz;

public class FizzBuzz
{
    public static int size = 100;

    public static string[] array = new string[size];

    public static void Main()
    {
        Parallel.For(1, size, i =>
        {
            var stringResult = "";

            if (CheckForFizz(i))
            {
                stringResult = "Fizz";
            }

            if (CheckForBuzz(i))
            {
                stringResult += "Buzz";
            }

            if (stringResult.Length == 0)
            {
                stringResult = i.ToString();
            }

            array[i-1] = stringResult;
        });

        array.ToList().ForEach(x => Console.WriteLine(x));
    }

    private static bool CheckForBuzz(int i)
    {
        return (i % 5 == 0);
    }

    private static bool CheckForFizz(int i)
    {
        return (i % 3 == 0);
    }
}