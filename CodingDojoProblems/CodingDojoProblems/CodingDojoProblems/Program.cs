using System;

namespace Diamond;

public class Diamond
{
    private static readonly char[] alphabeth = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

    public static void Main()
    {
        int row = 0;
        int spaceCount = 0;
        for (int i = 0; i <alphabeth.Length; i++)
        {
            do
            {
                Console.Write(alphabeth[i]);

                if(row != 0 && row < alphabeth.Length)
                {
                    spaceCount = 0;
                    do
                    {
                        Console.Write(' ');
                        spaceCount++;
                    } while (spaceCount <= row);

                    Console.Write(alphabeth[i]);
                }
                Console.WriteLine();
            } while (i < row);
            row++;            
        }
    }
}
