namespace CreditPaymentSystem.Domain.Common
{
    public static class ErrorMessage
    {
        public const string REQUIRED_PROPERTY_NAME = "{PropertyName} is required.";
        public const string VALIDATE_CORRECT_OUTSTANDING_AMOUNT = "{PropertyName} has been entered worngly. Please enter correct outstanding amount!";
        public const string VALIDATE_PROPERTY_DOESNOT_EXIST = "{PropertyName} does not exist!";
        public const string VALIDATE_CHECKPENDING_TRANSACTIONS_BY_CUSTOMERID = "Sorry, your previous transactions has been pending, Please clear your eariler outstanding credit!";
        public const string VALIDATE_LONGTERM_CUSTOMER_BY_ID = "We are sorry, you are not eligible to purchase from Credit Payment Option, As per our policy, Long-term customer can only purchase from Credit Payment Option. Since more than 24 months only consider as a Long-term customer!";
    }
}
