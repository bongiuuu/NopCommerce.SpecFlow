namespace NopCommerce.Constants
{
    public static class CompleteResultConstants
    {
        public enum UserAction
        {
            Register,
            Checkout
        }

        public static Dictionary<UserAction, List<string>> BodyMsgClassNames = new Dictionary<UserAction, List<string>>()
        {
            {UserAction.Register, new List<string> {"result", ""}},
            {UserAction.Checkout, new List<string> {"section order-completed", "//strong[1]"}}
        };
    }
}