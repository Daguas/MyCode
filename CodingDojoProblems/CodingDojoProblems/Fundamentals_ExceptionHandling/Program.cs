namespace ExceptionHandling;

public class ExceptionHandling
{
    public static void Main()
    {
        
        string erroBase = Console.ReadLine();

        try
        {
            GenerateParseException(erroBase);
            Console.WriteLine("Nothing bad happen");
        }
        catch // If any number is found exception is ignored
        {
            Console.WriteLine("Something bad happen");
        }
    }

    public static int? GenerateParseException(string value)
    {
        var result = 0; 
        try
        {
            Console.WriteLine("Start!");
            result = int.Parse(value);
        }
        catch(FormatException ex) when (ValidateFormatException(value, ex))
        {
            Console.WriteLine("FormatException!");
            return null;
        }
        catch (Exception ex) 
        {
            // Code to handle the exception goes here.
            // Only catch exceptions that you know how to handle.
            // Never catch base class System.Exception without
            // rethrowing it at the end of the catch block.

            Console.WriteLine("Exception!");
            LogException(ex);
            throw;
        }
        finally
        {
            // Code to execute after the try (and possibly catch) blocks
            // goes here.
            Console.WriteLine("Final!");
        }

        return result;
    }

    private static bool ValidateFormatException(string value, Exception e)
    {
        int x1 = 0;
        var validNumbers = value.ToList().Where(x => int.TryParse(x.ToString(),out x1));

        if(validNumbers.Count() > 0)
        {
            Console.WriteLine("Found issues but also numbers: ");
            validNumbers.ToList().ForEach(x => Console.Write(x.ToString() + " "));
            Console.WriteLine("");
            return true;
        }

        return false;
    }

    private static void LogException(Exception e)
    {
        Console.WriteLine($"\tIn the log routine. Caught {e.GetType()}");
        Console.WriteLine($"\tMessage: {e.Message}");
    }
}