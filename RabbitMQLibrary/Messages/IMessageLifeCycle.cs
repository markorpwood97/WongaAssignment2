namespace WongaLibrary.Components
{
    public interface IMessageLifeCycle
    {
        void OutgoingMessageLifeCycle(string outgoingMessage, string queue);
        string IncomingMessageLifeCycle(string queue);
    }
}