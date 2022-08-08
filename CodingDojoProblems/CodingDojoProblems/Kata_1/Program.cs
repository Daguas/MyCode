namespace GameOfLife;

public class GameOfLife
{
    public static void Main()
    {
        var matrix = ReadFile();

        matrix = CheckNextGen(matrix);

        PrintMatrix(matrix);
    }

    private static void PrintMatrix(char[,] matrix)
    {
        var nRows = matrix.GetLength(0);
        var nCols = matrix.GetLength(1);

        for (int r = 0; r < nRows; r++)
        {
            for (int c = 0; c < nCols; c++)
            {
                Console.Write(matrix[r, c]);
            }
            Console.WriteLine();
        }
    }

    private static char[,] CheckNextGen(char[,] matrix)
    {
        var nRows = matrix.GetLength(0);
        var nCols = matrix.GetLength(1);

        var newGen = new char[nRows, nCols];

        for (int r = 0; r < nRows; r++)
        {
            for (int c = 0; c < nCols; c++)
            {
                int liveCells = 0;

                // compare bellow
                if (r < nRows-1)
                {
                    if(isAlive(matrix[r+1, c]))
                    {
                        liveCells++;
                    }

                    // compare left
                    if (c > 0)
                    {
                        if (isAlive(matrix[r+1, c - 1]))
                        {
                            liveCells++;
                        }
                    }

                    // compare right
                    if (c < nCols-1)
                    {
                        if (isAlive(matrix[r+1, c + 1]))
                        {
                            liveCells++;
                        }
                    }
                }

                // compare left
                if(c>0)
                {
                    if (isAlive(matrix[r, c-1]))
                    {
                        liveCells++;
                    }
                }

                // compare right
                if (c < nCols-1)
                {
                    if (isAlive(matrix[r, c + 1]))
                    {
                        liveCells++;
                    }
                }

                // compare above
                if (r > 0)
                {
                    if (isAlive(matrix[r-1, c]))
                    {
                        liveCells++;
                    }

                    // compare left
                    if (c > 0)
                    {
                        if (isAlive(matrix[r-1, c - 1]))
                        {
                            liveCells++;
                        }
                    }

                    // compare right
                    if (c < nCols-1)
                    {
                        if (isAlive(matrix[r-1, c + 1]))
                        {
                            liveCells++;
                        }
                    }
                }

                newGen[r, c] = MyStatus(matrix[r,c], liveCells);
            }
        }

        return newGen;
    }

    private static char MyStatus(char v, int liveCells)
    {
        if (isAlive(v) && (liveCells < 2 || liveCells > 3))
        {
            return '.';
        }
        else if(!isAlive(v) && liveCells == 3)
        {
            return '*';
        }

        return v;
    }

    private static bool isAlive(char v)
    {
       return v.ToString().Equals("*");
    }

    private static char[,] ReadFile()
    {
        try
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Daniel\Repos\CodingDojoProblems\CodingDojoProblems\Kata_1\TextFile1.txt");

            var matrix = new char[int.Parse(lines[0].ElementAt(0).ToString()), int.Parse(lines[0].ElementAt(2).ToString())];

            for (var i = 1; i < lines.Length; i++)
            {
                for(var c = 0; c < lines[i].Length; c++)
                {
                    int v = i - 1;
                    
                    matrix[v, c] = lines[i].ElementAt(c);
                }
            }

            return matrix;
        }
        catch
        {
            Console.WriteLine("Error: Coudnt read file.");

            return null;
        }
    }
}
