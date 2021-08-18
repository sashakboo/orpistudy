using System;
using System.Collections.Generic;

namespace Telephony.Models
{
  public class Phone
  {
    private bool callInProgress = false;

    private readonly string imei;

    private BaseStation baseStation;

    public string IMEI => this.imei;

    public PhoneNumber Number { get; set; }

    public IList<Contact> Contacts { get; set; }

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

      this.CheckNumberBeforeCall(number);
      this.baseStation.ReceiveCall(this, number.FullNumber);
    }

    public virtual void Call(Contact contact)
    {
      PhoneNumber number = contact.Number;
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

    public Phone(string imei, PhoneNumber number)
    {
      this.imei = imei;
      this.Number = number;
    }
  }
}
