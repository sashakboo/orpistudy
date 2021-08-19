using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony.Models
{
  public class BaseStation
  {
    private readonly List<Phone> phones;

    public BaseStation()
    {
      this.phones = new List<Phone>();
    }

    public virtual void Register(Phone phone)
    {
      if (!this.IsRegistered(phone))
      {
        this.phones.Add(phone);
        phone.Calling += this.PhoneCalling;
      }
    }

    public virtual void Unregister(Phone phone)
    {
      if (this.IsRegistered(phone))
      {
        phone.Calling -= this.PhoneCalling;
        this.phones.Remove(phone);
      }
    }

    public bool IsRegistered(Phone phone)
    {
      return this.phones.IndexOf(phone) > -1;
    }

    protected virtual void RedirectCall(Phone initiator, Phone receiver)
    {
      receiver.ReceiveIncomingCall();
      receiver.StopCall();
      initiator.StopCall();
    }

    private void PhoneCalling(object sender, PhoneCallEventArgs e)
    {
      var initiator = sender as Phone;
      var receiverNumber = e.ReceiverNumber;

      if (initiator == null)
        throw new ArgumentNullException(nameof(initiator));

      if (receiverNumber == null)
        throw new ArgumentNullException(nameof(receiverNumber));

      var receiver = this.phones.FirstOrDefault(x => x.Number.Equals(receiverNumber));

      if (receiver == null)
        throw new Exception($"Number {receiverNumber.FullNumber} not found");

      this.RedirectCall(initiator, receiver);
    }
  }
}
