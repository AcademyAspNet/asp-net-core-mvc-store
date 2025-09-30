namespace Asp_Net_Core_Mvc_Store.Data.Repositories
{
    public abstract class Repository<E> : IRepository<E>
    {
        protected readonly string _connectionString;

        protected Repository(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Default");

            if (string.IsNullOrEmpty(connectionString))
                throw new MissingFieldException("Failed to get 'Default' connection string");

            _connectionString = connectionString;
        }

        public abstract IList<E> GetAll();
    }
}
