using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Lib.Models
{
    public class BotDialog
    {
        public string Model { get; set; }
        public List<Message> Messages { get; set; }
    }
}
