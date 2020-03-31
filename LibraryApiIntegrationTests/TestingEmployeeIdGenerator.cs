using LibraryApi.Services;
using System;
using System.Collections.Generic;
using System.Text;
namespace LibraryApiIntegrationTests
{
    public class TestingEmployeeIdGenerator : IGenerateEmployeeIds
    {
        public Guid GetNewEmployeeId()
        {
            return new Guid();
        }
    }
}
