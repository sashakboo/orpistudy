using System;

namespace Telephony.Models
{
  public class Phone3G : Phone
  {
    internal event EventHandler InternetConnecting;

    public void OpenInternetConnection()
    {
      this.InternetConnecting?.Invoke(this, null);
    }

    public override void Call(Contact contact)
    {
      base.Call(contact);
    }

    public override void Call(PhoneNumber number)
    {
      base.Call(number);
    }
    public Phone3G(string imei, PhoneNumber number) 
      : base(imei, number)
    {
    }
  }
}
