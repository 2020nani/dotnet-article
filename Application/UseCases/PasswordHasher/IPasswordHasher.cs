namespace FirstApi.Application.UseCases.PasswordHasher
{
    public interface IPasswordHasher
    {
        public string Hash(string password);

        public bool Verify(string passwordHash, string password);
    }
}
