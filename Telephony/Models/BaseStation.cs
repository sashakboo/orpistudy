using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony.Models
{
  public class BaseStation
  {
    private readonly List<Phone> phones;

    public virtual void Register(Phone phone)
    {
      if (!this.IsRegistered(phone))
        this.phones.Add(phone);
    }

    public virtual void Unregister(Phone phone)
    {
      if (this.IsRegistered(phone))
        this.phones.Remove(phone);
    }

    public bool IsRegistered(Phone phone)
    {
      return this.phones.IndexOf(phone) > -1;
    }

    public virtual void ReceiveCall(Phone initiator, string number)
    {
      if (!this.IsRegistered(initiator))
        throw new Exception("Initiator is not registered");

      var receiver = this.phones.FirstOrDefault(x => x.Number.FullNumber.Equals(number, StringComparison.InvariantCultureIgnoreCase));
      if (receiver == null)
        throw new Exception($"Number {number} not found");

      receiver.ReceiveIncomingCall();
      receiver.StopCall();
    }

    public BaseStation(int initialSize)
    {
      if (initialSize <= 0)
        throw new ArgumentOutOfRangeException(nameof(initialSize), "Size must be greater then 0");

      this.phones = new List<Phone>(initialSize);
    }
  }
}
