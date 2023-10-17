using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zammad_Lib.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public int Ticket_id { get; set; }
        public string Body { get; set; }
    }
}
