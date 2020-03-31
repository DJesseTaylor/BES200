using System;

namespace LibraryApi.Services
{
    public interface IGenerateEmployeeIds
    {
        Guid GetNewEmployeeId();
    }
}