using System;
using Telephony.Models;

namespace Telephony
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var baseStation = new BaseStation();
      var baseStation3G = new BaseStation3G();

      var phone = new Phone("132456", new PhoneNumber("8", "2134567"));
      phone.Connect(baseStation);

      var phone2 = new Phone("54454", new PhoneNumber("8", "234568"));
      phone2.Connect(baseStation);

      phone.Call(new PhoneNumber("8", "234568"));

      var phone3G = new Phone3G("54544234", new PhoneNumber("8", "32132"));
      phone3G.Connect(baseStation3G);
      phone3G.OpenInternetConnection();


      Console.ReadKey();
    }
  }
}
