using System;
using WongaLibrary.Components;

namespace ConsoleUIA
{
    public class Application : IApplication
    {
        IMessageHelper _messageHelper;
        IMessageLifeCycle _messageLifeCycle;

        public Application(IMessageHelper messageHelper, IMessageLifeCycle messageLifeCycle)
        {
            _messageHelper = messageHelper;
            _messageLifeCycle = messageLifeCycle;
        }

        public void Run()
        {
            Console.WriteLine(_messageHelper.GetQuestion());
            string userResponse = Console.ReadLine();
            Console.WriteLine(_messageHelper.FormatUserResponse(userResponse));

            _messageLifeCycle.OutgoingMessageLifeCycle(userResponse, "ConsoleB");
        }
    }
}
