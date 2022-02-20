using Sqlite_CRUD_Copy.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Sqlite_CRUD_Copy.Core.Contracts.Services
{
    public interface ISampleDataService
    {
        Task<IEnumerable<UserDto>> GetContentGridDataAsync();
    }
}
