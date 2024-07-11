namespace SkateparkManagement
{
    public static class PinValidator
    {
        public static bool ValidatePin(string userName, string pin)
        {
            var user = Database.Users.Find(u => u.Name == userName);
            return user != null && user.Pin == pin;
        }
    }
}
