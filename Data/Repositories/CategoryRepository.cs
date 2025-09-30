using Asp_Net_Core_Mvc_Store.Data.Entities;
using Microsoft.Data.SqlClient;

namespace Asp_Net_Core_Mvc_Store.Data.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override IList<Category> GetAll()
        {
            IList<Category> categories = new List<Category>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT [Id], [Name], [Image] FROM [Categories]";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int idColumnIndex = reader.GetOrdinal("Id");
                    int nameColumnIndex = reader.GetOrdinal("Name");
                    int imageColumnIndex = reader.GetOrdinal("Image");

                    while (reader.Read())
                    {
                        Category category = new Category()
                        {
                            Id = reader.GetInt32(idColumnIndex),
                            Name = reader.GetString(nameColumnIndex),
                            Image = reader.GetString(imageColumnIndex)
                        };

                        categories.Add(category);
                    }
                }
            }

            return categories;
        }
    }
}
