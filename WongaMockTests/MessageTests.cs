using Autofac.Extras.Moq;
using Moq;
using WongaLibrary.Components;
using WongaLibrary.Utilities;
using Xunit;

namespace WongaUnitTests
{
    public class MessageTests
    {
        [Fact]
        public void SendMessage_SingleMessageSent()
        {
            using (var mock = AutoMock.GetLoose())
            {
                string message = "Test";
                string queue = "ConsoleB";

                mock.Mock<IMessagerService>()
                    .Setup(x => x.SendMessage(message, queue));

                var consoleAApplication = mock.Create<MessageLifeCycle>();

                consoleAApplication.OutgoingMessageLifeCycle(message, queue);

                mock.Mock<IMessagerService>()
                    .Verify(x => x.SendMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));
            }
        }

        [Fact]
        public void GetMessage_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                string message = "Test";
                string queue = "ConsoleB";

                mock.Mock<IMessagerService>()
                    .Setup(x => x.GetMessage(queue))
                    .Returns(message);

                mock.Mock<IMessageHelper>()
                    .Setup(x => x.RemoveFormatFromMessage(message))
                    .Returns(message);

                mock.Mock<IMessageHelper>()
                    .Setup(x => x.ValidateUserResponse(message))
                    .Returns(true);

                var ConsoleAApplication = mock.Create<MessageLifeCycle>();
                var expected = message;

                var actual = ConsoleAApplication.IncomingMessageLifeCycle(queue);

                Assert.True(actual != null);
                Assert.Equal(expected, actual);
            }
        }
    }
}
