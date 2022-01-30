using System.Threading.Tasks;

namespace BrickHandler.Model.Contract
{
    public interface IBrickRepository
    {
        Task SaveAsync(IBrick brick);

    }
}
