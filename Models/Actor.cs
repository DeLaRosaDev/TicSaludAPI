using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicSaludAPI.Models
{
    public class Actor
    {
        public int actor_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime last_update { get; set; }
        
    }
}
