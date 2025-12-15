public interface IEmailQueue
{
    void Enqueue(string email, string password);
    bool TryDequeue(out (string Email, string Password) job);
}
