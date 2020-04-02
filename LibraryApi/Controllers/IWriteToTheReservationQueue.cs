using LibraryApi.Domain;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public interface IWriteToTheReservationQueue
    {
        Task Write(Reservation reservation);
    }
}