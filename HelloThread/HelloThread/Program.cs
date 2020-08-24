using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace HelloThread
{
    class Program
    {
        public static int counter = 0;
        public static object _locker = new Object();
        public static Dictionary<string, int> _dict = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            _dict["Mamas"] = 0;
            _dict["Empire"] = 0;

            for (int i = 0; i < 2; i++)
            {
                int threadNum = i +1;
                Thread thread = new Thread(() => Print(threadNum));
                //thread.IsBackground = true;
                thread.Start();
                //thread.Join();
            }
            Thread.Sleep(10000);
            Console.WriteLine($"Counter: {counter}");
            Console.WriteLine($"Mamas counter: {_dict["Mamas"]}");
            Console.WriteLine($"Empire counter: {_dict["Empire"]}");
        }

        public static void Print(int threadNum)
        {
            for (int i = 0; i < 10000; i++)
            {
                if (threadNum == 1)
                {
                    lock(_locker)
                    {
                        
                        if (counter % 2 == 0)
                        {
                            Console.WriteLine($"thread: {threadNum} - Mamas");
                            _dict["Mamas"]++;
                        }
                        if (counter < 10000)
                            counter++;
                    }
                }
                else
                {
                    lock(_locker)
                    {
                        
                        if (counter % 2 != 0)
                        {
                            Console.WriteLine($"thread: {threadNum} - Empire");
                            _dict["Empire"]++;
                        }
                        if (counter < 10000)
                            counter++;
                    }
                }
            }
        }

        public static void Print(int threadNum, string toPrint)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"thread: {threadNum} - {toPrint}");
                if(counter < 10000)
                    counter++;
                if(counter % 2 == 0)
                {

                }
            }
        }
    }
}
