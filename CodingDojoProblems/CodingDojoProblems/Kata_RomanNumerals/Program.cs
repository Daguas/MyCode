namespace Kata_RomanNumerals;

// https://codingdojo.org/kata/RomanNumerals/
public class RomanNumerals
{
    public static void Main()
    {
        int value = int.Parse(Console.ReadLine());

        string romanValue = ConvertToRoman(value);

        Console.WriteLine(romanValue);

        string normalValue = ConvertToNormal(romanValue);

        Console.WriteLine(normalValue);
    }

    public static string ConvertToNormal(string romanValue)
    {
        int thousands = 0;
        int hundreds = 0;
        int tens = 0;
        int zers = 0;
        for (int i = 0; i < romanValue.Length; i++)
        {
            if (hundreds == 0 && romanValue[i].ToString().Equals("M"))
            {
                thousands++;
                if (i != romanValue.Length - 1 && romanValue[i + 1].ToString().Equals(romanValue[i].ToString()))
                {
                    continue;
                }
                else if (i != romanValue.Length - 1 && romanValue[i + 1].ToString().Equals("C"))
                {
                    continue;
                }
            }
            else if (hundreds<9 && romanValue[i].ToString().Equals("C"))
            {
                hundreds++;if (i != romanValue.Length - 1 && romanValue[i + 1].ToString().Equals("M"))
                {
                    hundreds = 9;
                }
                else if (i != romanValue.Length - 1 && romanValue[i + 1].ToString().Equals("D"))
                {
                    hundreds = 4;
                }
            }
            else if (hundreds == 0 && romanValue[i].ToString().Equals("D"))
            {
                hundreds = 5;
            }
            else if (tens < 9 && romanValue[i].ToString().Equals("X"))
            {
                tens++;
                if (i != romanValue.Length - 1 && romanValue[i + 1].ToString().Equals("C"))
                {
                    tens = 9;
                }
                else if (i != romanValue.Length - 1 && romanValue[i + 1].ToString().Equals("L"))
                {
                    tens = 4;
                }
            }
            else if (tens == 0 && romanValue[i].ToString().Equals("L"))
            {
                tens = 5;
            }
            else if (romanValue[i].ToString().Equals("I"))
            {
                zers++;
                if (i != romanValue.Length - 1 && romanValue[i + 1].ToString().Equals("X"))
                {
                    zers = 9;
                    break;
                }
                else if (i != romanValue.Length - 1 && romanValue[i + 1].ToString().Equals("V"))
                {
                    zers = 4;
                    break;
                }
            }
            else if (zers == 0 && romanValue[i].ToString().Equals("V"))
            {
                zers = 5;
                break;
            }
        }
        return (thousands * 1000 + hundreds * 100 + tens * 10 + zers).ToString();
    }

    public static string ConvertToRoman(int num)
    {
        int size = num.ToString().Length - 1;

        string result = "";

        for (int i = 0; i <= size; i++)
        {
            int house = int.Parse(num.ToString()[i].ToString());

            result += CheckNines(size - i, house);
            result += CheckFives(size - i, house);
            result += CheckFours(size - i, house);
            result += CheckLowers(size - i, house);
        }

        return result;
    }

    private static string CheckNines(int i, int value)
    {
        string result = "";
        if (value == 9)
        {
            switch (i)
            {
                case 3:
                    for (int j = 0; j < value; j++)
                    {
                        result += "M";
                    }
                    break;
                case 2:
                    result += "CM";
                    break;
                case 1:
                    result += "XC";
                    break;
                case 0:
                    result += "IX";
                    break;
                default:
                    break;
            }
        }
        return result;
    }

    private static string CheckFives(int i, int value)
    {
        string result = "";
        if (value >= 5 && value < 9)
        {
            switch (i)
            {
                case 3:
                    for (int j = 0; j < value; j++)
                    {
                        result += "M";
                    }
                    break;
                case 2:
                    result += "D";
                    for (int j = 0; j < value - 5; j++)
                    {
                        result += "C";
                    }
                    break;
                case 1:
                    result += "L";
                    for (int j = 0; j < value - 5; j++)
                    {
                        result += "X";
                    }
                    break;
                case 0:
                    result += "V";
                    for (int j = 0; j < value - 5; j++)
                    {
                        result += "I";
                    }
                    break;
            }
        }
        return result;
    }

    private static string CheckFours(int i, int value)
    {
        string result = "";
        if (value == 4)
        {
            switch (i)
            {
                case 3:
                    for (int j = 0; j < value; j++)
                    {
                        result += "M";
                    }
                    break;
                case 2:
                    result += "CD";
                    break;
                case 1:
                    result += "XL";
                    break;
                case 0:
                    result += "IV";
                    break;
                default:
                    break;
            }
        }
        return result;
    }

    private static string CheckLowers(int i, int value)
    {
        string result = "";

        if (value < 4)
        {
            switch (i)
            {
                case 3:
                    for (int j = 0; j < value; j++)
                    {
                        result += "M";
                    }
                    break;
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
        }

        return result;
    }
}