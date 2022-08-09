namespace KataTennis;

public class Tennis
{
    public static void Main()
    {
        int player1Score = -1;
        int player2Score = -2;
        do
        {
            try
            {
                Console.WriteLine("P1 Score:");
                player1Score = int.Parse(Console.ReadLine());

                Console.WriteLine("P2 Score:");
                player2Score = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Player Score (must be a number:");
            }
        } while (player1Score < 0 || player2Score < 0);   



        if (CheckPlayerDeuce(player1Score, player2Score))
        {
            Console.WriteLine("Deuce");
        }
        else if (CheckPlayerAdv(player2Score, player1Score))
        {
            Console.WriteLine("Player 1: 40 - Player 2: Adv");
        }
        else if (CheckPlayerAdv(player1Score, player2Score))
        {
            Console.WriteLine("Player 1: Adv - Player 2: 40");
        }
        else if (CheckPlayerWin(player1Score, player2Score))
        {
            Console.WriteLine("(WIN) Player 1: " + CheckPlayerLove(player1Score) + " - Player 2: " + CheckPlayerLove(player2Score));
        }
        else if (CheckPlayerWin(player2Score, player1Score))
        {
            Console.WriteLine("Player 1: " + CheckPlayerLove(player1Score) + " - (WIN) Player 2: " + CheckPlayerLove(player2Score));
        }
        else
        {
            Console.WriteLine("Game in progress:");
            Console.WriteLine("Player 1: " + CheckPlayerLove(player1Score) + " - Player 2: " + CheckPlayerLove(player2Score));
        }
    }

    private static string CheckPlayerLove(int i)
    {
        if (i == 0)
        {
            return "Love";
        }
        else if (i == 1)
        {
            return "15";
        }
        else if (i == 2)
        {
            return "30";
        }
        else if (i == 3)
        {
            return "40";
        }
        else if (i > 3)
        {
            return "45";
        }

        return "";
    }

    private static bool CheckPlayerDeuce(int i, int j)
    {
        if (i == 3 && j == 3)
        {
            return true;
        }

        return false;
    }

    private static bool CheckPlayerAdv(int i, int j)
    {
        if (i == j + 1 && j >= 3)
        {
            return true;
        }

        return false;
    }

    private static bool CheckPlayerWin(int i, int j)
    {
        if ((i == 4 && j < 3) || (i >= j + 2 && j >= 3))
        {
            return true;
        }

        return false;
    }

}