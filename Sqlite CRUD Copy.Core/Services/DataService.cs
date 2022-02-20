using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sqlite_CRUD_Copy.Core.Context;
using Sqlite_CRUD_Copy.Core.Contracts.Services;
using Sqlite_CRUD_Copy.Core.Models;

namespace Sqlite_CRUD_Copy.Core.Services
{
    public class DataService : ISampleDataService
    {
        public DataService()
        {
        }


        public async Task<IEnumerable<UserDto>> GetContentGridDataAsync()
        {
            IEnumerable<UserDto> Users;
            using (AppDbContext db = new AppDbContext())
            {
                Users = await db.Users.Where(s=>true).ToListAsync();
            }
            return Users;
        }
    }
}
