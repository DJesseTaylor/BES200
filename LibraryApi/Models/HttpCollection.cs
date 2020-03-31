using System.Collections.Generic;

namespace LibraryApi.Models
{
    public class HttpCollection<T>
    {
        public List<T> Data { get; set; }
    }
}
