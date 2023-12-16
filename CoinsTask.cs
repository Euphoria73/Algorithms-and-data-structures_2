using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LabWork_2
{
    public static class CoinsTask
    {
        public static int[] GreedyAlg(int amount, int[] coins)
        {
            Array.Sort(coins);
            Array.Reverse(coins);
            List<int> result = new List<int>();

            foreach (var item in coins)
            {
                while (amount >= item)
                {
                    amount -= item;
                    result.Add(item);
                }
            }
            return result.ToArray();
        }

        public static int[] DynamicAlg(int[] coins, int amount)
        {            
            int[] dp = new int[amount + 1];
            dp[0] = 0;
            // Меняем каждую монету, сохраняя решение подзадачи для дальнейшего использования, то есть заполняем таблицу
            for (int coin = 1; coin <= amount; coin++)
            {
                // Когда монета с наименьшим значением используется для сдачи, количество требуемых монет является наибольшим
                int minCoins = coin;
                // просматриваем каждую монету достоинства, чтобы увидеть, можно ли ее использовать как одну из сдач
                for (int kind = 0; kind < coins.Length; kind++)
                {
                    // Если текущий номинал монеты меньше текущих монет, проходим по предыдущим значениям таблицы
                    if (coins[kind] <= coin)
                    {
                        int temp = dp[coin - coins[kind]] + 1;
                        if (temp < minCoins)
                        {
                            minCoins = temp;
                        }
                    }
                }
                // Сохраняем минимальное количество монет
                dp[coin] = minCoins;
            }
            return dp;
        }
    }
}