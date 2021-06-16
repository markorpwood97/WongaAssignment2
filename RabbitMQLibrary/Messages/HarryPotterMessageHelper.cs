using System.Text.RegularExpressions;

namespace WongaLibrary.Components
{
    public class HarryPotterMessageHelper : IMessageHelper
    {
        public string GetQuestion()
        {
            return "Please enter your name";
        }

        public string FormatUserResponse(string userResponse)
        {
            return $"Hagrid: Yer a wizard { userResponse }";
        }

        public string RemoveFormatFromMessage(string userResponse)
        {
            return userResponse.Replace("Hagrid: Yer a wizard ", "");
        }

        public string GetIconicLineFromResponse(string userResponse)
        {
            return $"{ userResponse }: I'm a what?";
        }

        public bool ValidateUserResponse(string userResponse)
        {
            return Regex.IsMatch(userResponse, "^[A-Z][a-zA-Z]*$");
        }
    }
}
