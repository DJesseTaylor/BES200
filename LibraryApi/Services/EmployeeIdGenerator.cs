using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public class EmployeeIdGenerator : IGenerateEmployeeIds
    {
        public Guid GetNewEmployeeId()
        {
            return Guid.NewGuid();
        }
    }
}
