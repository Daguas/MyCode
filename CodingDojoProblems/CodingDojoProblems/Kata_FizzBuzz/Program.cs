namespace FizzBuzz;

public class FizzBuzz
{
    public static void Main()
    {
        for (int i = 1; i < 100; i++)
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

            Console.WriteLine(stringResult);
        }
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