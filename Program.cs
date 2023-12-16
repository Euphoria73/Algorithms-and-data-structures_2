using System;
using System.Linq;

namespace LabWork_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = { 1,3,4 }; //проверка на числе 6
            Console.WriteLine("Набор монет: ");
            PrintItems(coins);
            
            Console.WriteLine("\nВведите сумму которую хотите разменять:");
            int amount = Convert.ToInt32(Console.ReadLine());
           
            int[] greedyResult = CoinsTask.GreedyAlg(amount, coins);

            Console.WriteLine("Число монет в решении жадного алгоритма - " + greedyResult.Length);
            Console.WriteLine("Номиналами: ");
            PrintItems(greedyResult);

            int[] dynamicResult = CoinsTask.DynamicAlg(coins, amount);            
            Console.WriteLine("\nЧисло монет в решении динамическим программированием: " + dynamicResult[^1]);
            
            Console.ReadKey();           
        }
        static void PrintItems(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
        }
    }
}
