using System;
using Telephony.Models;

namespace Telephony
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var baseStation = new BaseStation(10);
      var baseStation3G = new BaseStation3G(10);

      var phone = new Phone("132456", new PhoneNumber("8", "2134567"));
      phone.Connect(baseStation);

      var phone2 = new Phone("54454", new PhoneNumber("8", "234568"));
      phone2.Connect(baseStation);

      phone.Call(new PhoneNumber("8", "234568"));


      Console.ReadKey();
    }
  }
}
