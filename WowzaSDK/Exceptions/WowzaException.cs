using System;
namespace WowzaSDK.Exceptions
{
    public class WowzaException : Exception
    {
        public WowzaException()
        {
        }

        public WowzaException(int code, string wowzaErrorCode, string wowzaErrorMessage)
        {
            this.StatusCode = code;
            this.ErrorCode = wowzaErrorCode;
            this.ErrorMessage = wowzaErrorMessage;
        }

        public WowzaException(string message, Exception innerException) : base(message, innerException)
        {
            this.ErrorMessage = message;
        }

        public int StatusCode { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorTitle { get; set; } = "Wowza Exception from Request";
        public string ErrorMessage { get; set; }
        public string ErrrDescription { get; set; }
    }
}
