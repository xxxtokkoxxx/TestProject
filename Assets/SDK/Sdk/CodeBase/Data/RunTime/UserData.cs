using System;

namespace SDK.Sdk.CodeBase.Data.RunTime
{
    [Serializable]
    public class UserData
    {
        public string UserEmail { get; set; }
        public string CreditCard { get; set; }
        public string ExpirationDate { get; set; }

        public UserData(string email, string creditCard, string expirationDate)
        {
            UserEmail = email;
            CreditCard = creditCard;
            ExpirationDate = expirationDate;
        }
    }
}
