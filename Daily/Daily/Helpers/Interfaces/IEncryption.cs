namespace Daily.Helpers.Interfaces
{
    public interface IEncryption
    {
        byte[] CreateKey(string InputKey, byte[] saltBytes);
        string DecryptString(string input, byte[] key, byte[] IV);
        string EncryptString(string input, byte[] key, byte[] IV);
        byte[] GenerateIV();
        byte[] GenerateSalt();
    }
}