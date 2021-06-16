using System;
using System.Collections.Generic;
using System.Text;
using WongaLibrary;
using WongaLibrary.Components;
using WongaLibrary.Utilities;

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
            //string outgoingMessage = _messageHelper.FormatUserResponse(userResponse);
            Console.WriteLine(_messageHelper.FormatUserResponse(userResponse));

            _messageLifeCycle.OutgoingMessageLifeCycle(userResponse, "ConsoleB");


            ////MessageModel model = new MessageModel() 
            ////{
            ////    Message = _messageHelper.FormatUserResponse(Console.ReadLine()),
            ////    Queue = "ConsoleB"
            ////};
            ////_messagerService.SendMessage(model);

            //Console.WriteLine(_message.GetQuestion());

            //_message.Response = Console.ReadLine();
            //string initialMessage = _message.GetInitialMessage();
            //Console.WriteLine(initialMessage);

            //_message.SendMessage(initialMessage, "ConsoleB");
        }
    }
}
