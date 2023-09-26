using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketFlow.Models
{
    public class TicketModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Created { get; set; }
        public string Status { get; set; }


        public string[] Article { get; set; }
    }
}
