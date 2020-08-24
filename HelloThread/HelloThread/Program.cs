using System;
using System.Threading;

namespace HelloThread
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 2; i++)
            {
                int threadNum = i +1;
                if(threadNum == 1)
                {
                    Thread thread = new Thread(() => Print(threadNum, "Mamas"));
                    thread.Start();
                }
                else
                {
                    Thread thread = new Thread(() => Print(threadNum, "Empire"));
                    thread.Start();
                }
                    
            }
            
        }

        public static void Print(int threadNum, string toPrint)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"thread: {threadNum} - {toPrint}");
            }
        }
    }
}
