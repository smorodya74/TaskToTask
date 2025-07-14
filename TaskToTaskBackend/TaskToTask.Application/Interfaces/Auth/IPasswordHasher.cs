namespace TaskToTask.Application.Interfaces.Auth
{
    public interface IPasswordHasher
    {
        string GenerateHash(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}