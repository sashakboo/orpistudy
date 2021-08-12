namespace Telephony.Models
{
  class Phone3G : Phone
  {
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
