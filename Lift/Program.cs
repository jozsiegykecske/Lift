using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lift
{
  internal class Program
  {
    static int beCel = 0;
    static int beKartya = 0;
    static List<Lift> liftek = new List<Lift>();
    static void Main(string[] args)
    {
      Beolvasas();
      HarmadikFeladat();
      NegyedikFeladat();
      OtodikFeladat();
      HatodikFeladat();
      HetedikFeladat();
      NyolcadikFeladat();
      Console.ReadKey();
    }

    private static void NyolcadikFeladat()
    {
      Dictionary<DateTime, int> stat = liftek.GroupBy(x => x.Idopont).Select(y => new { y.Key, Value = y.Count() }).ToDictionary(z => z.Key, z => z.Value);
      Console.WriteLine("8.feladat:");
      foreach (var s in stat)
      {
        Console.WriteLine($"\t{s.Key.ToShortDateString()} - {s.Value}x");
      }
    }

    private static void HetedikFeladat()
    {
      int szamlalo = 0;
      while (szamlalo<liftek.Count && !(liftek[szamlalo].CelSzint==beCel && liftek[szamlalo].Sorszam==beKartya))
      {
        szamlalo++;
      }
      if (szamlalo<liftek.Count)
      {
        Console.WriteLine($"7.feladat: A(z) {beCel}. kártyával utaztak a(z) {beKartya}. emeletre");
      }
      else
      {
        Console.WriteLine($"7.feladat: A(z) {beKartya}. kártyával nem utaztak a(z) {beCel}. emeletre");
      }
    }

    private static void HatodikFeladat()
    {
      Console.WriteLine($"6.feladat:");
      Console.Write($"\tKártya száma:");
      try
      {
        beCel = Convert.ToInt32(Console.ReadLine());
      }
      catch (Exception)
      {
        beCel = 5;
      }
      Console.Write($"\tCélszint száma:");
      try
      {
        beKartya = Convert.ToInt32(Console.ReadLine());
      }
      catch (Exception)
      {
        beKartya = 5;
      }
    }

    private static void OtodikFeladat()
    {
      Console.WriteLine($"5.feladat: A legnagyobb sorszámú célszint: {liftek.Max(x=> x.CelSzint)}");
    }

    private static void NegyedikFeladat()
    {
      Console.WriteLine($"4.feladat: A vizsgált időszak: {liftek.Min(x=>x.Idopont.ToShortDateString())} - {liftek.Max(x=> x.Idopont.ToShortDateString())}");
    }

    private static void HarmadikFeladat()
    {
      Console.WriteLine($"3.feladat: A liftet {liftek.Count} alkalommal használták");
    }

    private static void Beolvasas()
    {
      using (StreamReader be = new StreamReader("lift.txt"))
      {
        while (!be.EndOfStream)
        {
          liftek.Add(new Lift(be.ReadLine()));
        }
      }
    }
  }
}
