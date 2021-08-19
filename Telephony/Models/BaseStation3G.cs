namespace Telephony.Models
{
  public class BaseStation3G : BaseStation
  {
    public override void Register(Phone phone)
    {
      base.Register(phone);
      if (phone is Phone3G phone3G)
        phone3G.InternetConnecting += this.PhoneInternetConnecting;
    }

    public override void Unregister(Phone phone)
    {
      if (phone is Phone3G phone3G)
        phone3G.InternetConnecting -= this.PhoneInternetConnecting;
      base.Unregister(phone);
    }

    private void PhoneInternetConnecting(object sender, System.EventArgs e)
    {
      
    }

    public BaseStation3G()
      : base()
    {

    }
  }
}
