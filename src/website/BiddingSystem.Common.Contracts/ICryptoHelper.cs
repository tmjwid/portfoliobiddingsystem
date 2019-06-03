namespace BiddingSystem.Common.Contracts
{
    public interface ICryptoHelper
    {
         string HashPassword(string password);
         bool VerifyHashedPassword(string hashedPassword, string password);
    }
}