using System;

namespace TeamHGSAzureFunctions.Models
{
    public class ReturnObject
    {
        public ReturnObject()
        {
            Result = false;
            ResultStatus = 0;
            ResultValue = "Email2 Blank";
            LastUpdated = DateTime.UtcNow.ToString("g");
        }

        public bool Result { get; set; }
        public string LastUpdated { get; }
        public int ResultStatus { get; set; }
        public string ResultValue { get; set; }
    }
}
