namespace WongaLibrary.Components
{
    public interface IMessageHelper
    {
        string GetQuestion();
        string FormatUserResponse(string userResponse);
        string RemoveFormatFromMessage(string userResponse);
        string GetIconicLineFromResponse(string userResponse);
        bool ValidateUserResponse(string userResponse);
    }
}