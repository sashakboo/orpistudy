using System;

namespace Telephony.Models
{
  public class PhoneCallEventArgs : EventArgs
  {
    public PhoneNumber ReceiverNumber { get; }

    public PhoneCallEventArgs(PhoneNumber phoneNumber)
    {
      this.ReceiverNumber = phoneNumber;
    }
  }
}
