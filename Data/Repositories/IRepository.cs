namespace Asp_Net_Core_Mvc_Store.Data.Repositories
{
    public interface IRepository<E>
    {
        IList<E> GetAll();
    }
}
