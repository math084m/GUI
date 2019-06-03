using System;

namespace ASPNET_SmartCity_MathiasThomassen_201706287.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}