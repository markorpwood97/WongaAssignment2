using System;
using System.Collections.Generic;
using System.Text;
using WongaLibrary;
using WongaLibrary.Components;
using WongaLibrary.Utilities;

namespace ConsoleUIB
{
    public class Application : IApplication
    {
        //IMessageComponent _messageComponent;
        IMessageHelper _messageHelper;
        IMessagerService _messagerService;
        IMessageLifeCycle _messageLifeCycle;

        public Application(IMessageHelper messageHelper, IMessagerService messagerService, IMessageLifeCycle messageLifeCycle)
        {
            //_messageComponent = messageComponent;
            _messageHelper = messageHelper;
            _messagerService = messagerService;
            _messageLifeCycle = messageLifeCycle;
        }

        public void Run()
        {
            string response = _messageLifeCycle.IncomingMessageLifeCycle("ConsoleB");

            if (!_messageHelper.ValidateUserResponse(response))
            {
                Console.WriteLine("Please enter a valid name");
                return;
            }

            Console.WriteLine(_messageHelper.GetIconicLineFromResponse(response));
            Console.ReadLine();
        }
    }
}
