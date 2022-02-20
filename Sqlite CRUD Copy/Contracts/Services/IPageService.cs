using System;
using System.Windows.Controls;

namespace Sqlite_CRUD_Copy.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);

        Page GetPage(string key);
    }
}
