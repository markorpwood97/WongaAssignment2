using System;
using WongaLibrary.Components;

namespace ConsoleUIB
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
            string response = _messageLifeCycle.IncomingMessageLifeCycle("ConsoleB");

            if (!_messageHelper.ValidateUserResponse(response))
            {
                Console.WriteLine("Please enter a valid name next time");
                Console.ReadLine();
                return;
            }

            Console.WriteLine(_messageHelper.GetIconicLineFromResponse(response));
            Console.ReadLine();
        }
    }
}
