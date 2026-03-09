using System;

class PrimeNumberPrinter
{
    static void Main()
    {
        try
        {
            int lowerLimit = GetNumberInput("请输入下限整数：");
            int upperLimit = GetNumberInput("请输入上限整数：");
            if (lowerLimit > upperLimit)
            {
                int temp = lowerLimit;
                lowerLimit = upperLimit;
                upperLimit = temp;
                Console.WriteLine($"已自动交换上下限，当前区间：{lowerLimit} ~ {upperLimit}");
            }
            List<int> primes = new List<int>();
            for (int num = lowerLimit; num <= upperLimit; num++)
            {
                if (IsPrime(num))
                {
                    primes.Add(num);
                }
            }
            Console.WriteLine($"\n{lowerLimit} 到 {upperLimit} 之间的素数：");
            if (primes.Count == 0)
            {
                Console.WriteLine("该区间内无素数！");
            }
            else
            {
                for (int i = 0; i < primes.Count; i++)
                {
                    Console.Write($"{primes[i],5}");
                    if ((i + 1) % 10 == 0)
                    {
                        Console.WriteLine();
                    }
                }
                if (primes.Count % 10 != 0)
                {
                    Console.WriteLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"程序运行出错：{ex.Message}");
        }
    }

    static int GetNumberInput(string prompt)
    {
        int num;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().Trim();
            if (int.TryParse(input, out num))
            {
                break;
            }
            else
            {
                Console.WriteLine("输入错误！请输入有效的整数（如 5、20、100）。");
            }
        }
        return num;
    }

    static bool IsPrime(int num)
    {
        if (num < 2) return false;
        if (num == 2) return true;
        if (num % 2 == 0) return false;
        for (int i = 3; i <= Math.Sqrt(num); i += 2)
        {
            if (num % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}