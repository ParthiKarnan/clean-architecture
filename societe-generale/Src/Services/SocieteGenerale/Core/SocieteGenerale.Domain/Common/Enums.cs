namespace SocieteGenerale.Domain.Common
{
    public static class Enums
    {
        public enum CardType
        {
            Credit = 1, Debit
        }
        public enum AccountType
        {
            Savings = 1, Current, Credit
        }
        public enum PaymentType
        {
            Immediate = 1, Credit
        }
    }
}