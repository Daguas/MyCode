namespace Ocr;

public class OCR
{
    public const int nLines = 3;
    public const int nChars = 27;
    public const int size = 3;
    public static bool invalidCharFound = false;

    public static void Main()
    {
        string[,] matrix = ReadFile();
        string[] accountCode = new string[9];

        Parallel.For(1, 10, i =>
        {
            accountCode[i - 1] = CheckNumbers(i, matrix);
            return;
        });

        if (invalidCharFound)
        {
            CheckSolutionsILL(accountCode, matrix);
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

    private static string CheckNumbers(int i, string[,] matrix)
    {
        if (CheckForOnes(i, matrix))
        {
            return "1";
            ;
        }

        if (CheckForTwos(i, matrix))
        {
            return "2";
        }

        if (CheckForThrees(i, matrix))
        {
            return "3";
        }

        if (CheckForFours(i, matrix))
        {
            return "4";
        }

        if (CheckForFives(i, matrix))
        {
            return "5";
        }

        if (CheckForSixs(i, matrix))
        {
            return "6";

        }

        if (CheckForSevens(i, matrix))
        {
            return "7";
        }

        if (CheckForEights(i, matrix))
        {
            return "8";
        }

        if (CheckForNines(i, matrix))
        {
            return "9";
        }

        if (CheckForZeros(i, matrix))
        {
            return "0";
        }

        invalidCharFound = true;
        return "?";
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
        var sum = 0;

        for (int i = accountCode.Length - 1; i >= 0; i--)
        {
            sum += int.Parse(accountCode[i].ToString()) * (accountCode.Length - i);
        }

        return sum % 11 == 0;
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
                }
                else
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

    private static void CheckSolutionsILL(string[] accountCode, string[,] matrix)
    {
        int invalids = accountCode.Where(x => x.Equals("?")).Count();

        if (invalids > 1)
        {
            accountCode.ToList().ForEach(n => Console.Write(n));
            Console.Write(" ILL");
        }
        else
        {
            int i = accountCode.ToList().FindIndex(x => x.Equals("?"));
            CheckBlanksILL(accountCode, i, matrix);
        }
    }

    private static void CheckBlanksILL(string[] accountCode, int i, string[,] matrix)
    {
        List<string> good = new List<string>();
        int solutions = 0;
        int startC = i * size;
        int endC = i * size + size;
        string[,] copy = new string[nLines, nChars];

        for (int l = 0; l < 3; l++)
        {
            for (int j = startC; j < endC; j++)
            {
                copy = (string[,])matrix.Clone();

                if (matrix[l, j].ToString().Equals(" "))
                {
                    copy[l, j] = "_";
                }
                else
                {
                    copy[l, j] = " ";
                }

                var result = CheckNumbers(i + 1, copy);

                if (!result.Equals("?"))
                {
                    var temp = (string[]) accountCode.Clone();
                    temp[i] = result;

                    if (CheckSumCalculator(temp))
                    {
                        good.Add(String.Concat(temp));
                        solutions++;
                    }                  
                }
            }
        }

        if (solutions == 0)
        {
            accountCode.ToList().ForEach(n => Console.Write(n));

            Console.Write(" ILL");
        }
        else if (solutions > 1)
        {
            accountCode.ToList().ForEach(n => Console.Write(n));

            Console.Write(" AMB [");

            for (int g = 0; i < good.Count; g++)
            {
                Console.Write("'" + good[g] + "'");
                if (good.Count - 1 == i)
                {
                    Console.Write("]");
                }
                else
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

    #region Check Numbers
    // Fixed
    private static bool CheckForZeros(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        for (int c = when; c <= till; c++)
        {
            for (int l = 0; l < 3; l++)
            {
                if (((c == till || c == when) && (l == 1 || l == 2)) || (c == when + 1) && (l == 0 || l == 2))
                {
                    if (matrix[l, c].ToString().Equals(" "))
                    {
                        return false;
                    }
                }
                else if (!matrix[l, c].ToString().Equals(" "))
                {
                    return false;
                }
            }
        }

        return true;
    }

    // Fixed
    private static bool CheckForOnes(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        for (int c = when; c <= till; c++)
        {
            for (int l = 0; l < 3; l++)
            {
                if (c == till && (l == 1 || l == 2))
                {
                    if (matrix[l, c].ToString().Equals(" "))
                    {
                        return false;
                    }
                }
                else if (!matrix[l, c].ToString().Equals(" "))
                {
                    return false;
                }
            }
        }

        return true;
    }

    // Fixed
    private static bool CheckForTwos(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        for (int c = when; c <= till; c++)
        {
            for (int l = 0; l < 3; l++)
            {
                if ((c == till && l == 1) || (c == when + 1) || (c == when && l == 2))
                {
                    if (matrix[l, c].ToString().Equals(" "))
                    {
                        return false;
                    }
                }
                else if (!matrix[l, c].ToString().Equals(" "))
                {
                    return false;
                }
            }
        }

        return true;
    }

    // Fixed
    private static bool CheckForThrees(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        for (int c = when; c <= till; c++)
        {
            for (int l = 0; l < 3; l++)
            {
                if (((c == till && (l == 1 || l == 2)) || c == when + 1))
                {
                    if (matrix[l, c].ToString().Equals(" "))
                    {
                        return false;
                    }
                }
                else if (!matrix[l, c].ToString().Equals(" "))
                {
                    return false;
                }
            }
        }

        return true;
    }

    // Fixed
    private static bool CheckForFours(int i, string[,] matrix)
    {
        int end = i * size - 1;
        int start = i * size - size;

        for (int c = start; c <= end; c++)
        {
            for (int l = 0; l < 3; l++)
            {
                if (((c == end && (l == 1 || l == 2)) || c == start + 1 && l == 1) || c == start && l == 1)
                {
                    if (matrix[l, c].ToString().Equals(" "))
                    {
                        return false;
                    }
                }
                else if (!matrix[l, c].ToString().Equals(" "))
                {
                    return false;
                }
            }
        }

        return true;
    }

    // Fixed
    private static bool CheckForFives(int i, string[,] matrix)
    {
        int end = i * size - 1;
        int start = i * size - size;

        for (int c = start; c <= end; c++)
        {
            for (int l = 0; l < 3; l++)
            {
                if ((c == start && l == 1 ) || (c == start + 1) || (c == end && l == 2))
                {
                    if (matrix[l, c].ToString().Equals(" "))
                    {
                        return false;
                    }
                }
                else if (!matrix[l, c].ToString().Equals(" "))
                {
                    return false;
                }
            }
        }

        return true;
    }

    // Fixed
    private static bool CheckForSixs(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        for (int c = when; c <= till; c++)
        {
            for (int l = 0; l < 3; l++)
            {
                if ((c == when && (l == 1 || l == 2)) || (c == when + 1) || (c == till && l == 2))
                {
                    if (matrix[l, c].ToString().Equals(" "))
                    {
                        return false;
                    }
                }
                else if (!matrix[l, c].ToString().Equals(" "))
                {
                    return false;
                }
            }
        }

        return true;
    }
    
    // Fixed
    private static bool CheckForSevens(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        for (int c = when; c <= till; c++)
        {
            for (int l = 0; l < 3; l++)
            {
                if ((c == till && (l == 1 || l == 2)) || (c == when +1 && l == 0))
                {
                    if (matrix[l, c].ToString().Equals(" "))
                    {
                        return false;
                    }
                }
                else if (!matrix[l, c].ToString().Equals(" "))
                {
                    return false;
                }
            }
        }

        return true;
    }

    // Fixed
    private static bool CheckForEights(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        for (int c = when; c <= till; c++)
        {
            for (int l = 0; l < 3; l++)
            {
                if (((c == till || c == when) && (l == 1 || l == 2)) || (c == when + 1))
                {
                    if (matrix[l, c].ToString().Equals(" "))
                    {
                        return false;
                    }
                }
                else if (!matrix[l, c].ToString().Equals(" "))
                {
                    return false;
                }
            }
        }

        return true;
    }

    // Fixed
    private static bool CheckForNines(int i, string[,] matrix)
    {
        int till = i * size - 1;
        int when = i * size - size;

        for (int c = when; c <= till; c++)
        {
            for (int l = 0; l < 3; l++)
            {
                if (l == 1 || (c == when + 1) || (c == till && l == 2))
                {
                    if (matrix[l, c].ToString().Equals(" "))
                    {
                        return false;
                    }
                }
                else if (!matrix[l, c].ToString().Equals(" "))
                {
                    return false;
                }
            }
        }

        return true;
    }

    #endregion

}