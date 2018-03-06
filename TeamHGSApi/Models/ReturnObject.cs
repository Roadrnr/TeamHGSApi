using System;

namespace TeamHGSApi.Models
{
    public class ReturnObject
    {
        public bool Result { get; set; }
        public DateTime LastUpdated { get; } = DateTime.UtcNow;
        public int ResultStatus { get; set; }
        public string ResultValue { get; set; }
    }
}
