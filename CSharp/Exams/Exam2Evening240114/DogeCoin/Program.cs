using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace DogeCoin
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//        }
//    }
//}


//using System;
//using System.Collections.Generic;

class PathsInLabyrinth
{
    static char[,] lab;/*= 
    {
        {' ', ' ', ' ', '*', ' ', ' ', ' '},
        {'*', '*', ' ', '*', ' ', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', '*', '*', '*', '*', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
    };*/

    static List<Tuple<int, int>> path = new List<Tuple<int, int>>();
    static int[,] coins;
    static int maxSumCoins = 0;
    static int pathCount = 0;
    static int currSum = 0;
    static bool InRange(int row, int col)
    {
        bool rowInRange = row >= 0 && row < lab.GetLength(0);
        bool colInRange = col >= 0 && col < lab.GetLength(1);
        return rowInRange && colInRange;
    }

    static void FindPathToExit(int row, int col)
    {
        if (!InRange(row, col))
        {
            // We are out of the labyrinth -> can't find a path
            return;
        }

        // Check if we have found the exit
        if (lab[row, col] == 'e')
        {
            // PrintPath(row, col);
            if (currSum > maxSumCoins)
            {
                maxSumCoins = currSum;
            }
            // pathCount++;
        }

        if (lab[row, col] != '\0')
        {
            // The current cell is not free -> can't find a path
            return;
        }

        // Temporary mark the current cell as visited to avoid cycles
        lab[row, col] = 's';
        path.Add(new Tuple<int, int>(row, col));
        currSum += coins[row, col];

        // Invoke recursion the explore all possible directions
        //FindPathToExit(row, col - 1); // left
        //FindPathToExit(row - 1, col); // up
        FindPathToExit(row, col + 1); // right
        FindPathToExit(row + 1, col); // down

        // Mark back the current cell as free
        // Comment the below line to visit each cell at most once
        lab[row, col] = '\0';
        path.RemoveAt(path.Count - 1);
        currSum -= coins[row, col];
    }

    //private static void PrintPath(int finalRow, int finalCol)
    //{
    //    Console.Write("Found the exit: ");
    //    foreach (var cell in path)
    //    {
    //        Console.Write("({0},{1}) -> ", cell.Item1, cell.Item2);
    //    }
    //    Console.WriteLine("({0},{1})", finalRow, finalCol);
    //    Console.WriteLine();
    //}
    private static int CountCoins(int finalRow, int finalCol, int[,] coins)
    {
        int sum = 0;
        foreach (var cell in path)
        {
            sum += coins[cell.Item1, cell.Item2];
        }
        return sum;
    }
    private static void Input(ref char[,] lab)
    {
        int[] size = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(item => int.Parse(item)).ToArray();
        lab = new char[size[0], size[1]];
        lab[size[0] - 1, size[1] - 1] = 'e';

        int coinsCount = int.Parse(Console.ReadLine());
        coins = new int[size[0], size[1]];
        for (int i = 0; i < coinsCount; i++)
        {
            int[] coinsCoord = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(item => int.Parse(item)).ToArray();
            coins[coinsCoord[0], coinsCoord[1]]++;
        }


    }
    static void Main()
    {
        Input(ref lab);
        FindPathToExit(0, 0);
        Console.WriteLine(maxSumCoins);
        // Console.WriteLine(pathCount);
    }
}

