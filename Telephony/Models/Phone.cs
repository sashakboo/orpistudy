using System;
using System.Collections.Generic;

namespace Telephony.Models
{
  class Phone
  {
    private bool callInProgress = false;

    private readonly string imei;

    private BaseStation baseStation;

    public string IMEI => imei;

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
      if (baseStation == null)
        throw new Exception("Телефон не подключен к базовой станции");

      this.CheckNumberBeforeCall(number);
      baseStation.ReceiveCall(this, number.FullNumber);
    }

    public virtual void Call(Contact contact)
    {
      PhoneNumber number = contact.Number;
      this.Call(number);
    }

    public void ReceiveIncomingCall()
    {
      if (callInProgress)
        throw new Exception("Busy");

      callInProgress = true;
    }

    public void StopCall()
    {
      callInProgress = false;
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
      Number = number;
    }
  }
}
