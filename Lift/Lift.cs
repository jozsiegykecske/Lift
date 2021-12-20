using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{
  internal class Lift
  {
    public DateTime Idopont { get; set; }
    public int Sorszam { get; set; }
    public int InduloSzint { get; set; }
    public int CelSzint { get; set; }
    public Lift(string be)
    {
      string[] a = be.Split();
      Idopont = Convert.ToDateTime(a[0]);
      Sorszam = Convert.ToInt32(a[1]);
      InduloSzint = Convert.ToInt32(a[2]);
      CelSzint = Convert.ToInt32(a[3]);
    }
  }
}
