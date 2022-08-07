namespace Kata_RomanNumerals;

// https://codingdojo.org/kata/RomanNumerals/
public class RomanNumerals
{
    public static void Main()
    {
        int value = int.Parse(Console.ReadLine());

        string romanValue = ConvertToRoman(value);

        Console.WriteLine(romanValue);
    }

    private static string ConvertToRoman(int value)
    {
        string result = "";

        int size = value.ToString().Length - 1;

        Parallel.For(i)


        for (int i = 0; i <= size; i++)
        {
            int house = int.Parse(value.ToString()[i].ToString());

        }
    }
    private static string CheckFives(int i, int value)
    {
        string result = "";

        switch (i)
        {
            case 3:
                for (int j = 0; j < value; j++)
                {
                    result += "M";
                }
                break;
            case 2:
                if (value >= 5 && value < 9)
                {
                    result += "D";

                    for (int j = 0; j < value - 5; j++)
                    {
                        result += "C";
                    }
                }
                break;
            case 1:
                if (value >= 5 && value < 9)
                {
                    result += "L";

                    for (int j = 0; j < value - 5; j++)
                    {
                        result += "X";
                    }
                }
                break;
            case 0:
                if (value >= 5 && value < 9)
                {
                    result += "V";
                    for (int j = 0; j < value - 5; j++)
                    {
                        result += "I";
                    }
                }
                break;
        }

        return result;
    }

    private static string CheckNines(int i, int value)
    {
        string result = "";

        switch (i)
        {
            case 2:
                if (value == 9)
                {
                    result += "CM";
                }
                break;
            case 1:
                if (value == 9)
                {
                    result += "XC";
                }
                break;
            case 0:
                if (value == 9)
                {
                    result += "IX";
                }
                break;
            default:
                break;
        }

        return result;
    }

    private static string CheckFours(int i, int value)
    {
        string result = "";

        switch (i)
        {
            case 2:
                if (value == 4)
                {
                    result += "CD";
                }
                break;
            case 1:
                if (value == 4)
                {
                    result += "XL";
                }
                break;
            case 0:
                if (value == 4)
                {
                    result += "IV";
                }
                break;
            default:
                break;
        }

        return result;
    }

    private static string CheckExtra(int i, int value)
    {
        string result = "";

        switch (i)
        {
            case 2:
                for (int j = 0; j < value; j++)
                {
                    result += "C";
                }
                break;
            case 1:
                for (int j = 0; j < value; j++)
                {
                    result += "X";
                }
                break;
            case 0:
                for (int j = 0; j < value; j++)
                {
                    result += "I";
                }
                break;
            default:
                break;
        }

        return result;
    }
}