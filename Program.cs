using System;

class Program {
    static void Main(string[] args) {
        char[] board = {'1', '2', '3', '4', '5', '6', '7', '8', '9'}; 
        int player = 1;
        int count = 1;
        bool hasWin = false;
        
     do {
        PrintDescriptionGame(player);
        PrintBoard(board);
        int choice = UserInputChoice(player, board);
        if (IsPlayer2(player)) {
            board[choice - 1] = 'O';
            player++;
        } else {
            board[choice - 1] = 'X';
            player++;
        }
        count++;
        hasWin = CheckWin(board);
     } while(!hasWin && count != 9);

     PrintResult(hasWin, player, board);
    }

    static void PrintResult(bool hasWin, int player, char[] board) {
        Console.Clear();
        PrintBoard(board);
        if (hasWin) {
            Console.WriteLine("Player {0} won", (player % 2) + 1);
        }  else {
            Console.WriteLine("Draw!");
        }
    }

    static int UserInputChoice(int player, char[] board) {
        int input;
          while(true) {
            Console.Write(PrintPlayDescription(player));
            input = int.Parse(Console.ReadLine());

            if (CheckInValidInput(input, board)) {
                Console.Write("Please enter 1 - 9: "); 
            } else {
                break;
            }
        }

        return input;
    }

    static string PrintPlayDescription(int player) {
        return IsPlayer2(player) ? "Input O at: " : "Input X at: "; 
    }

    static void PrintDescriptionGame(int player) {
        Console.Clear();
        Console.WriteLine("Player 1: X and Player 2: O");
        Console.WriteLine("---------------------------");

        if (IsPlayer2(player)) {
            Console.WriteLine("Turn Player 2");
        } else {
            Console.WriteLine("Turn Player 1");
        }
    }

    static bool CheckWin(char[] board) {
        return IsWinFromHorizontalWinning(board) 
        || IsWinFromVerticalWinning(board) 
        || IsWinFromCrossWinning(board);
    }

    static bool IsWinFromHorizontalWinning(char[] board) {
        return ((board[0] == board[1]) && (board[1] == board[2]))
        || ((board[3] == board[4]) && (board[4] == board[5])) 
        || ((board[6] == board[7]) && (board[7] == board[8]));
    }

    static bool IsWinFromVerticalWinning(char[] board) {
         return ((board[0] == board[3]) && (board[3] == (board [6])))
         || ((board[1] == board[4]) && (board[4] == board[7])) 
         || ((board[2] == board[5]) && (board[5] == board[8]));
    }

    static bool IsWinFromCrossWinning(char[] board) {
        return ((board[0] == board[4]) && (board[4] == board[8])) 
        || ((board[2] == board[4] &&  (board[4] == board[6])));
    }

    static bool IsPlayer2(int player) {
        return player % 2 == 0;
    }

    static bool CheckInValidInput(int input, char[] board) {
        return ((input < 1 || input > 9) 
        || (board[input - 1] == 'X' || board[input - 1] == 'O'));
    }

    static void PrintBoard(char[] board) {
        Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}",
            board[0], board[1], board[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}",
            board[3], board[4], board[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}",
            board[6], board[7], board[8]);
            Console.WriteLine("     |     |      ");
    }
}