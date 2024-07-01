/* requirements:
 * 1. game must take place on a 3x3 board - done
 * 2. must alternate between 2 players each turn - done
 * 3. must accept input of only 'X' and 'O' depending on the prompt - in progress
 * 4. option to exit or loop the game - done
 * 5. doesn't generate a new board each turn - done 
 * 6. 3 outcomes - win, draw or loss, horizontal, vertical or diagonal - done
 * 7. keep a scoreline for the restart loops - in progress
 */
class Program
{
    static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // this is the array which the board will rely on and the player choices
    static int player = 1; // player 1 is the default
    static int choice; // set as the player's choice of X or O
    static int flag = 0; // this will be used to check what the outcome is, win lose or draw. 1 = win, -1 = draw, 0 = ongoing

    static void Main(string[] args)
    {
        while (true)
        {
            do
            {
                Console.Clear();// this runs the game on the same board each turn
                Console.WriteLine("Player 1: X and Player 2: O");
                Console.WriteLine("\n");

                if (player % 2 != 0) // player is initialised to 1. the remainder of 1/2 is not 0, hence this would be player 1's turn and will alternate each turn
                {
                    Console.WriteLine("player 1's turn");
                }
                else
                {
                    Console.WriteLine("player 2's turn");
                }
                Console.WriteLine("\n");
                Board();// calling the board Function

                bool isValidInput = false; // to only accept 'X' or 'O'

                while (!isValidInput)
                {
                    Console.WriteLine("enter your choice: ");

                }

                choice = int.Parse(Console.ReadLine());

                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 != 0) // using the above logic
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("place {0} already taken by {1}", choice, arr[choice]); // if the array space is already occupied, there will be a 2s pause before continuing the game
                    Console.WriteLine("pls wait");
                    Thread.Sleep(2000);
                }
                flag = CheckWin(); // self explanatory 
            }
            while (flag != 1 && flag != -1);

            Console.Clear();
            Board();
            if (flag == 1)
            {
                Console.WriteLine("player {0} has won", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("draw");
            }

            Console.WriteLine("press e to exit or any key to restart");
            if (Console.ReadLine() == "e")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                ResetBoard();
            }
        }
        
        
        static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }

        static int CheckWin()
        {
            #region horizontal win
            // win for first row
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            // win for second row
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            // win for third row
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion
            #region vertical win
            // win for first column
            if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //win for second column
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            // win for third column
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion
            #region diagonal win
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion
            #region draw
            else if (IsBoardFull()) return -1;
            else return 0;
            #endregion
        }

       

        static bool IsBoardFull()
        {
            for (int i = 1; i <= 9; i++)
            {
                if (arr[i] == i.ToString()[0]);
                return false;
            }
            return true;
        }

        static void ResetBoard()
        {
            for (int i = 1; i <= 9; i++)
            {
                arr[i] = i.ToString()[0];
            }
            player = 1;
            flag = 0;
        }


    }
}