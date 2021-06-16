using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WongaLibrary.Components
{
    public class StarWarsMessageHelper : IMessageHelper
    {
        public string GetQuestion()
        {
            return "Please enter your name";
        }

        public string FormatUserResponse(string userResponse)
        {
            return $"Hello my name is, { userResponse }";
        }

        public string RemoveFormatFromMessage(string message)
        {
            return message.Replace("Hello my name is, ", "");
        }

        public string GetIconicLineFromResponse(string userResponse)
        {
            return $"Hello { userResponse }, I am your father";
        }

        public bool ValidateUserResponse(string userReponse)
        {
            return Regex.IsMatch(userReponse, "^[A-Z][a-zA-Z]*$");
        }
    }
}
