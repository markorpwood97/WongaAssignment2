using WongaLibrary.Utilities;

namespace WongaLibrary.Components
{
    public class MessageLifeCycle : IMessageLifeCycle
    {
        IMessageHelper _messageHelper;
        IMessagerService _messagerService;

        public MessageLifeCycle(IMessageHelper messageHelper, IMessagerService messagerService)
        {
            _messageHelper = messageHelper;
            _messagerService = messagerService;
        }

        public void OutgoingMessageLifeCycle(string userResponse, string queue)
        {
            string outgoingMessage = _messageHelper.FormatUserResponse(userResponse);
            _messagerService.SendMessage(outgoingMessage, queue);
        }

        public string IncomingMessageLifeCycle(string queue)
        {
            string incomingMessage = _messagerService.GetMessage(queue);
            string response = _messageHelper.RemoveFormatFromMessage(incomingMessage);

            if (!_messageHelper.ValidateUserResponse(response))
            {
                return "Please enter a valid name";
            }

            return response;
        }
    }
}
