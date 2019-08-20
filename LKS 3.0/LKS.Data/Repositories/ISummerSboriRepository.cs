using LKS.Data.Models;

namespace LKS.Data.Repositories
{
    public interface ISummerSboriRepository
    {
        SummerSbori GetItem();
        bool UpdateItem(SummerSbori item);
    }
}
