using System.Threading.Tasks;

namespace Sqlite_CRUD_Copy.Contracts.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle();

        Task HandleAsync();
    }
}
