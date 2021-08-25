using System;
using System.Collections.Generic;

namespace Telephony.Models
{
  public class Phone
  {
    private bool callInProgress;

    private BaseStation baseStation;

    public string IMEI { get; }

    public PhoneNumber Number { get; set; }

    public List<Contact> Contacts { get; } = new List<Contact>();

    internal event EventHandler<PhoneCallEventArgs> Calling;

    public Phone(string imei, PhoneNumber number)
    {
      this.IMEI = imei;
      this.Number = number;
    }

    public virtual void Connect(BaseStation station)
    {
      if (this.baseStation != null)
        this.baseStation.Unregister(this);

      station.Register(this);
      this.baseStation = station;
    }  

    public virtual void Call(PhoneNumber number)
    {
      if (this.baseStation == null)
        throw new Exception("Телефон не подключен к базовой станции");

      if (this.callInProgress)
        throw new Exception("Звонок уже запущен.");

      this.callInProgress = true;
      this.CheckNumberBeforeCall(number);
      this.Calling?.Invoke(this, new PhoneCallEventArgs(number));
    }

    public virtual void Call(Contact contact)
    {
      var number = contact.Number;
      this.Call(number);
    }

    public void ReceiveIncomingCall()
    {
      if (this.callInProgress)
        throw new Exception("Busy");

      this.callInProgress = true;
    }

    public void StopCall()
    {
      this.callInProgress = false;
    }

    protected virtual void CheckNumberBeforeCall(PhoneNumber number)
    {
      if (number == null)
        throw new ArgumentNullException(nameof(number));

      if (number.Equals(this.Number))
        throw new ArgumentOutOfRangeException(nameof(number), $"Невозможно выполнить вызов на свой номер {number.FullNumber}");
    }

    public override bool Equals(object obj)
    {
      if (obj is Phone phone)
        return this.IMEI.Equals(phone.IMEI, StringComparison.InvariantCultureIgnoreCase);

      return false;
    }

    public override int GetHashCode()
    {
      return this.IMEI.GetHashCode();
    }
  }
}
