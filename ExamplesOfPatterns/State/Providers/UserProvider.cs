using State.AdditionalStuff;

namespace State.Providers
{
    public static class UserProvider
    {
        public static User GetCurrentUser()
        {
            return new User { IsEditor = true, IsOwnerOfDocument = true };
        }
    }
}