using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
class Program
{
    /// <summary>
    /// задача 1.вывод чисел от 1 до 10
    /// </summary>
    static void cnt()
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine("поток {0}: {1}", Thread.CurrentThread.ManagedThreadId, i);
            Thread.Sleep(100); 
        }
    }
    static void Main()
    {
        //№1
        Console.WriteLine("задача 1. реализовать 3 потока, каждый из которых выведет на экран числа от 1 до 10.");
        Thread a = new Thread(new ThreadStart(cnt));
        a.Start();
        a.Join();
        Thread b = new Thread(new ThreadStart(cnt));
        b.Start();
        b.Join();
        Thread c = new Thread(new ThreadStart(cnt));
        c.Start();
        c.Join();
        Console.WriteLine("потоки завершили работу");
        Console.ReadLine();
        //№2
        Console.WriteLine("задача 2. создать программу, которая будет вычислять факториал от введенного числа и квадрат от введенного числа\nвведите число и нажмите enter:");
        int f = int.Parse(Console.ReadLine());
        Task<long> factorial = Task.Run(() =>
        {
            Task.Delay(8000).Wait();
            long ff = 1;
            for (int i = 2; i <= f; i++)
            {
                ff *= i;
            }
            return ff;
        });
        long square = f * f;
        Console.WriteLine("квадрат числа: {0}", square);
        long fac = factorial.Result;
        Console.WriteLine("факториал числа: {1}", factorial);
        Console.ReadLine();
        //№3
        Type type = typeof(Refl);
        MethodInfo[] ms = type.GetMethods();
        foreach (MethodInfo m in ms)
        {
            Console.WriteLine(m.Name);
        }
    }
}
