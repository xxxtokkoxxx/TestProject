using System.Threading.Tasks;

namespace Sdk.CodeBase.ResourcesManagement
{
    public interface ILoadingOperation
    {
        Task Load();
    }
}