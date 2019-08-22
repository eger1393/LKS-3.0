using LKS.Data.Models;

namespace LKS.Data.Repositories
{
    public interface ISummerSboryRepository
    {
        SummerSbory GetItem();
        bool UpdateItem(SummerSbory item);
    }
}
