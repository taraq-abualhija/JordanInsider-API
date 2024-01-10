using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Core.DTO
{
    public class SendEmailDTO
    {
        public string To { get; set; } = string.Empty;
        public string PlainText { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
    }
}
