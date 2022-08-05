namespace Ocr;

public class OCR
{
    public const int nLines = 3;
    public const int nChars = 27;

    public static void Main()
    {
        string[,] matrix = ReadFile();
        char[] accountCode = new char[9];

        Parallel.For(1, 10, i =>
        {
            if (CheckForOnes(i, matrix))
            {
                accountCode[i - 1] = '1';
                return;
            }

            if (CheckForTwos(i, matrix))
            {
                accountCode[i - 1] = '2';
                return;
            }

            if (CheckForSevens(i, matrix))
            {
                accountCode[i - 1] = '7';
                return;
            }

            accountCode[i - 1] = '0';
        });

        Console.WriteLine(accountCode);
    }

    private static bool CheckForSevens(int i, string[,] matrix)
    {
        int when = i * 3 - 3;

        if (!matrix[0, when + 1].ToString().Equals(" ") &&
           matrix[1, when + 1].ToString().Equals(" "))
        {
            return true;
        }

        return false;
    }

    private static bool CheckForTwos(int i, string[,] matrix)
    {
        int till = i * 3 - 1;
        int when = i * 3 - 3;

        if (!matrix[2, when].ToString().Equals(" ") &&
           matrix[2, till].ToString().Equals(" "))
        {
            return true;
        }

        return false;
    }

    private static bool CheckForOnes(int i, string[,] matrix)
    {
        int till = i * 3 - 1;
        int when = i * 3 - 3;

        for (int c = when; c < till; c++)
        {
            if (!matrix[0, c].ToString().Equals(" ") ||
               !matrix[1, c].ToString().Equals(" ") ||
               !matrix[2, c].ToString().Equals(" "))
            {
                return false;
            }
        }

        return true;
    }

    private static string[,] ReadFile()
    {
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Daniel\Repos\CodingDojoProblems\CodingDojoProblems\Kata_OCR\TextFile1.txt");

        var matrix = new string[nLines, nChars];

        for (var i = 0; i < nLines; i++)
        {
            for (var c = 0; c < nChars; c++)
            {
                matrix[i, c] = lines[i].ElementAt(c).ToString();
            }
        }

        return matrix;
    }
}