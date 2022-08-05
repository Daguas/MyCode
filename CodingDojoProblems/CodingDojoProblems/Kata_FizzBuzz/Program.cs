namespace FizzBuzz;

public class FizzBuzz
{
    public static void Main()
    {
        for (int i = 1; i < 100; i++)
        {
            var stringResult = "";

            var isWeirdN = false;

            if (CheckForFizz(i))
            {
                stringResult = "Fizz";
                isWeirdN = true;
            }

            if (CheckForBuzz(i))
            {
                stringResult += "Buzz";
                isWeirdN = true;
            }

            if (!isWeirdN)
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