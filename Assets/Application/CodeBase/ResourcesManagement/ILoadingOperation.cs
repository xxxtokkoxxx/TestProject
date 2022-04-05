using System.Threading.Tasks;

namespace Application.CodeBase.ResourcesManagement
{
    public interface ILoadingOperation
    {
        Task Load();
    }
}