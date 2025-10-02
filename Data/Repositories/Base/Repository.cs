using Microsoft.Data.SqlClient;

namespace Asp_Net_Core_Mvc_Store.Data.Repositories.Base
{
    public abstract class Repository<E> : IRepository<E>
    {
        private readonly string _connectionString;

        protected Repository(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Default");

            if (string.IsNullOrEmpty(connectionString))
                throw new MissingFieldException("Failed to get 'Default' connection string");

            _connectionString = connectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public abstract IList<E> GetAll();
        public abstract E? GetById(int id);
    }
}
