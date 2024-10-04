using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarreirPro
{
  public class WriteLine2
  {
    public static void Next()
    {
      for (var i = 0; i < 1000; i++)
      {
        Console.WriteLine(new string(' ', 20) + "Hello world2");
      }
    }
  }
}
