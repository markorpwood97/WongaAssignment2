namespace WongaLibrary.Utilities
{
    public interface IMessagerService
    {
        void SendMessage(string message, string queue);
        string GetMessage(string queue);
    }
}
