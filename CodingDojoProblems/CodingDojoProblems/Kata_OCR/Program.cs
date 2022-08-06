namespace Ocr;

public class OCR
{
    public const int nLines = 3;
    public const int nChars = 27;
    public const int size = 3;

    public static void Main()
    {
        string[,] matrix = ReadFile();
        string[] accountCode = new string[9];
        bool invalidCharFound = false;

        ParallelLoopResult x = Parallel.For(1, 10, i =>
        {
            if (CheckForOnes(i, matrix))
            {
                accountCode[i - 1] = "1";
                return;
            }

            if (CheckForTwos(i, matrix))
            {
                accountCode[i - 1] = "2";
                return;
            }

            if (CheckForThrees(i, matrix))
            {
                accountCode[i - 1] = "3";
                return;
            }

            if (CheckForFours(i, matrix))
            {
                accountCode[i - 1] = "4";
                return;
            }

            if (CheckForFives(i, matrix))
            {
                accountCode[i - 1] = "5";
                return;
            }

            if (CheckForSixs(i, matrix))
            {
                accountCode[i - 1] = "6";
                return;
            }

            if (CheckForSevens(i, matrix))
            {
                accountCode[i - 1] = "7";
                return;
            }

            if (CheckForEights(i, matrix))
            {
                accountCode[i - 1] = "8";
                return;
            }

            if (CheckForNines(i, matrix))
            {
                accountCode[i - 1] = "9";
                return;
            }

            if (CheckForZeros(i, matrix))
            {
                accountCode[i - 1] = "0";
                return;
            }

            accountCode[i - 1] = "?";
            invalidCharFound = true;
            return;
        });

        if (invalidCharFound)
        {
            accountCode.ToList().ForEach(n => Console.Write(n));
            Console.Write(" ILL");
        }
        else if (CheckSumCalculator(accountCode))
        {
            accountCode.ToList().ForEach(n => Console.Write(n));
        }
        else
        {
            CheckSolutionsERR(accountCode);
        }

        Console.WriteLine();
    }

    private static bool CheckForZeros(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        if (!matrix[1, when].ToString().Equals(" ") &&
            matrix[1, when + 1].ToString().Equals(" ") &&
           !matrix[2, when].ToString().Equals(" ") &&
           !matrix[1, till].ToString().Equals(" ") &&
           !matrix[2, till].ToString().Equals(" ")
           )
        {
            return true;
        }

        return false;
    }

    private static bool CheckForOnes(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

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

    private static bool CheckForTwos(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        if (!matrix[2, when].ToString().Equals(" ") &&
           matrix[2, till].ToString().Equals(" "))
        {
            return true;
        }

        return false;
    }

    private static bool CheckForThrees(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        if (matrix[1, when].ToString().Equals(" ") &&
           matrix[2, when].ToString().Equals(" ") &&
           !matrix[1, when + 1].ToString().Equals(" ") &&
           !matrix[1, till].ToString().Equals(" ") &&
           !matrix[2, till].ToString().Equals(" ")
           )
        {
            return true;
        }

        return false;
    }

    private static bool CheckForFours(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        if (!matrix[1, when].ToString().Equals(" ") &&
           matrix[2, when].ToString().Equals(" ") &&
           matrix[2, till - 1].ToString().Equals(" ") &&
           !matrix[1, till].ToString().Equals(" ") &&
           !matrix[2, till].ToString().Equals(" ")
           )
        {
            return true;
        }

        return false;
    }

    private static bool CheckForFives(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        if (!matrix[1, when].ToString().Equals(" ") &&
           matrix[2, when].ToString().Equals(" ") &&
           matrix[1, till].ToString().Equals(" ") &&
           !matrix[2, till].ToString().Equals(" ")
           )
        {
            return true;
        }

        return false;
    }

    private static bool CheckForSixs(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        if (!matrix[1, when].ToString().Equals(" ") &&
           !matrix[2, when].ToString().Equals(" ") &&
           matrix[1, till].ToString().Equals(" ") &&
           !matrix[2, till].ToString().Equals(" ")
           )
        {
            return true;
        }

        return false;
    }

    private static bool CheckForSevens(int i, string[,] matrix)
    {
        int when = i * size - size;

        if (!matrix[0, when + 1].ToString().Equals(" ") &&
           matrix[1, when + 1].ToString().Equals(" ") &&
           matrix[2, when + 1].ToString().Equals(" "))
        {
            return true;
        }

        return false;
    }

    private static bool CheckForEights(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        if (!matrix[1, when].ToString().Equals(" ") &&
           !matrix[2, when].ToString().Equals(" ") &&
           !matrix[1, when + 1].ToString().Equals(" ") &&
           !matrix[1, till].ToString().Equals(" ") &&
           !matrix[2, till].ToString().Equals(" ")
           )
        {
            return true;
        }

        return false;
    }

    private static bool CheckForNines(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        if (!matrix[1, when].ToString().Equals(" ") &&
           matrix[2, when].ToString().Equals(" ") &&
           !matrix[1, till].ToString().Equals(" ") &&
           !matrix[2, till].ToString().Equals(" ")
           )
        {
            return true;
        }

        return false;
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

    private static bool CheckSumCalculator(string[] accountCode)
    {
        return SumCalculator(accountCode) % 11 == 0;
    }

    private static void CheckSolutionsERR(string[] accountCode)
    {
        int solutions = 0;
        List<string> good = new List<string>();
        string[] temp = accountCode;

        for (int i = 0; i < accountCode.Length; i++)
        {
            temp = accountCode.Select(x => x).ToArray();

            if (accountCode[i].ToString().Equals("0"))
            {
                temp[i] = "8";

                if (CheckSumCalculator(temp))
                {
                    good.Add(String.Concat(temp));
                    solutions++;
                }

                continue;
            }
            else if (accountCode[i].ToString().Equals("1"))
            {
                temp[i] = "7";

                if (CheckSumCalculator(temp))
                {
                    good.Add(String.Concat(temp));
                    solutions++;
                }

                continue;
            }
            else if (accountCode[i].ToString().Equals("3"))
            {
                temp[i] = "9";

                if (CheckSumCalculator(temp))
                {
                    good.Add(String.Concat(temp));
                    solutions++;
                }

                continue;
            }
            else if (accountCode[i].ToString().Equals("5"))
            {
                temp[i] = "9";

                if (CheckSumCalculator(temp))
                {
                    good.Add(String.Concat(temp));
                    solutions++;
                }

                temp[i] = "6";

                if (CheckSumCalculator(temp))
                {
                    good.Add(String.Concat(temp));
                    solutions++;
                }

                continue;
            }
            else if (accountCode[i].ToString().Equals("6"))
            {
                temp[i] = "5";

                if (CheckSumCalculator(temp))
                {
                    good.Add(String.Concat(temp));
                    solutions++;
                }

                temp[i] = "8";

                if (CheckSumCalculator(temp))
                {
                    good.Add(String.Concat(temp));
                    solutions++;
                }

                continue;
            }
            else if (accountCode[i].ToString().Equals("7"))
            {
                temp[i] = "1";

                if (CheckSumCalculator(temp))
                {
                    good.Add(String.Concat(temp));
                    solutions++;
                }

                continue;
            }
            else if (accountCode[i].ToString().Equals("8"))
            {
                temp[i] = "0";

                if (CheckSumCalculator(temp))
                {
                    good.Add(String.Concat(temp));
                    solutions++;
                }

                temp[i] = "6";

                if (CheckSumCalculator(temp))
                {
                    good.Add(String.Concat(temp));
                    solutions++;
                }

                temp[i] = "9";

                if (CheckSumCalculator(temp))
                {
                    good.Add(String.Concat(temp));
                    solutions++;
                }

                continue;
            }
            else if (accountCode[i].ToString().Equals("9"))
            {
                temp[i] = "8";

                if (CheckSumCalculator(temp))
                {
                    good.Add(String.Concat(temp));
                    solutions++;
                }

                temp[i] = "3";

                if (CheckSumCalculator(temp))
                {
                    good.Add(String.Concat(temp));
                    solutions++;
                }

                temp[i] = "5";

                if (CheckSumCalculator(temp))
                {
                    good.Add(String.Concat(temp));
                    solutions++;
                }

                continue;
            }
        }

        if (solutions == 0)
        {
            Console.Write(" ERR");
        }
        else if (solutions > 1)
        {
            accountCode.ToList().ForEach(n => Console.Write(n));

            Console.Write(" AMB [");
            for (int i = 0; i < good.Count; i++)
            {
                Console.Write("'" + good[i] + "'");
                if (good.Count - 1 == i)
                {
                    Console.Write("]");
                }else
                {
                    Console.Write(", ");
                }
            }
        }
        else if (solutions == 1)
        {
            good.ForEach(n => Console.Write(n));
        }
    }

    private static int SumCalculator(string[] accountCode)
    {
        var sum = 0;

        for (int i = accountCode.Length - 1; i >= 0; i--)
        {
            sum += int.Parse(accountCode[i].ToString()) * (accountCode.Length - i);
        }

        return sum;
    }
}