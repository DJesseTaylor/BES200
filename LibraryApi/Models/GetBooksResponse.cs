using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Models
{
    public class GetBooksResponse : HttpCollection<BookSummaryItem>
    {
        public string Genre { get; set; }
    }

    public class BookSummaryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
