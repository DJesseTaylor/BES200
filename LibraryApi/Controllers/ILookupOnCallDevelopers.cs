using LibraryApi.Models;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public interface ILookupOnCallDevelopers
    {
        Task<OnCallDeveloperResponse> GetOnCallDeveloper();
    }
}