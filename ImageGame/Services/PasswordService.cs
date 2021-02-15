using BC = BCrypt.Net.BCrypt;

namespace ImageGame.Services
{
    public class PasswordService : IPasswordService
    {
        public string Hash(string password)
        {
            // TODO implements salt, maybe pepper
            string hashed = BC.HashPassword(password);
            return hashed;
        }

        public bool Verify(string password, string hash)
        {
            return BC.Verify(password, hash);
        }
    }
}
