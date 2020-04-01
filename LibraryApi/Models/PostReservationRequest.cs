using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Models
{
    public class PostReservationRequest
    {
        public string For { get; set; }
        public string[] Books { get; set; }
    }
}
