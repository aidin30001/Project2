using System;
using System.Threading;
using BarreirPro;

namespace BarrierPro
{
  public class Program 
  {
    static void WriteLine()
    {
      for (var i = 0; i < 1000; i++)
      {
        Console.WriteLine(new string(' ', 10) + "Hello world");
      }
    }
    public static void Main(string[] args)
    {
      int count = 0;
        
      // Барьер для 3 участников с post-phase действием
      Barrier barrier = new Barrier(2, (b) =>
      {
        Console.WriteLine($"Фаза {b.CurrentPhaseNumber} завершена. Общее значение count: {count}");
      });

      // Логика работы каждого потока
      Action action = () =>
      {
          // Фаза 0
        Interlocked.Increment(ref count);

        WriteLine();

        barrier.SignalAndWait();  // Ждем остальных

        // Фаза 1
        Interlocked.Increment(ref count);
        
        WriteLine2.Next();
        
        barrier.SignalAndWait();  // Ждем остальных
      };

      // Запуск 3 параллельных потоков
      Parallel.Invoke(action, action);

      // Освобождение ресурсов
      barrier.Dispose();

      Console.ReadKey();
    }
  }
}
