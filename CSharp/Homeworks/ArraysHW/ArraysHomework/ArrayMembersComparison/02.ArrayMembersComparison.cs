using System;

class ArrayMembersComparison
{
    static void Main(string[] args)
    {   
        //Members insertion
        Console.Write("Insert the number of the members in each array!");
        int membersCount = int.Parse(Console.ReadLine());
        dynamic[] firstArray = new dynamic[membersCount];
        dynamic[] secondArray = new dynamic[membersCount];

        int i = 0;
        Console.WriteLine("Insert the members of the first array!");
        while (i <= membersCount - 1)
        {
            firstArray[i]= Console.ReadLine();
            i++;
        }
        Console.WriteLine("Insert the members of the second array!");
        i = 0;
        while (i <= membersCount - 1)
        {
            secondArray[i]= Console.ReadLine();
            i++;
        }
        //Members comparison
        Console.WriteLine("{0,-20} | {1,-20} | {2,-6}", "firstArray", "secondArray", "Equal?");
        i = 0;
        while (i<=membersCount-1)
        {
            Console.WriteLine("{0,-20} | {1,-20} | {2,-6}", firstArray[i], secondArray[i], (firstArray[i]==secondArray[i]));
            i++;
        }
    }
}
