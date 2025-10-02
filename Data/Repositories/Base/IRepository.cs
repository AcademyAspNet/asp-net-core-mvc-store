namespace Asp_Net_Core_Mvc_Store.Data.Repositories.Base
{
    public interface IRepository<E>
    {
        IList<E> GetAll();
        E? GetById(int id);
    }
}
