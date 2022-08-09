namespace Diamond;

public class Diamond
{
    private static readonly char[] alphabeth = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

    public static void Main()
    {
        string toFind = Console.ReadLine();

        int end = FindPosition(toFind.First());

        MathRight(0, end);

        MathLeft(end, 0);
    }

    private static int FindPosition(char v)
    {
         return alphabeth.ToList().FindIndex(x => x.ToString().ToLower().Equals(v.ToString().ToLower()));
    }

    private static void MathRight(int start, int stop)
    {
        for (int i = start; i <= stop; i++)
        {
            PrintLine(alphabeth[i], (i * 2 - 1), (stop- i));
        }
    }

    private static void MathLeft(int start, int stop)
    {
        for (int i = start - 1; i >= stop; i--)
        {
            PrintLine(alphabeth[i], (i * 2 - 1), (start - i));
        }
    }

    private static void PrintLine(char letter, int nSpaces, int nBeforeSpaces)
    {
        if (nBeforeSpaces > 0)
        {
            PrintWhiteSpaces(nBeforeSpaces);
        }

        Console.Write(letter);

        if (nSpaces > 0)
        {
            PrintWhiteSpaces(nSpaces);

            Console.Write(letter);
        }

        Console.WriteLine();
    }

    private static void PrintWhiteSpaces(int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {
            Console.Write(' ');
        }
    }
}
