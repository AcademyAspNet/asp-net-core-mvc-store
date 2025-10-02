using Asp_Net_Core_Mvc_Store.Data.Entities;
using Asp_Net_Core_Mvc_Store.Data.Repositories.Base;
using Microsoft.Data.SqlClient;

namespace Asp_Net_Core_Mvc_Store.Data.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override IList<Product> GetAll()
        {
            IList<Product> products = new List<Product>();

            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT [Id], [Name], [Description], [Image], [Price] FROM [Products]";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return products;

                    int idColumnIndex = reader.GetOrdinal("Id");
                    int nameColumnIndex = reader.GetOrdinal("Name");
                    int descriptionColumnIndex = reader.GetOrdinal("Description");
                    int imageColumnIndex = reader.GetOrdinal("Image");
                    int priceColumnIndex = reader.GetOrdinal("Price");

                    while (reader.Read())
                    {
                        Product product = new Product()
                        {
                            Id = reader.GetInt32(idColumnIndex),
                            Name = reader.GetString(nameColumnIndex),
                            Description = !reader.IsDBNull(descriptionColumnIndex) ? reader.GetString(descriptionColumnIndex) : null,
                            Image = !reader.IsDBNull(imageColumnIndex) ? reader.GetString(imageColumnIndex) : null,
                            Price = reader.GetDecimal(priceColumnIndex)
                        };

                        products.Add(product);
                    }
                }
            }

            return products;
        }

        public override Product? GetById(int id)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT [Id], [Name], [Description], [Image], [Price] FROM [Products] WHERE [Id] = @Id";
                command.Parameters.AddWithValue("@Id", id);

                Product product;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return null;

                    reader.Read();

                    int idColumnIndex = reader.GetOrdinal("Id");
                    int nameColumnIndex = reader.GetOrdinal("Name");
                    int descriptionColumnIndex = reader.GetOrdinal("Description");
                    int imageColumnIndex = reader.GetOrdinal("Image");
                    int priceColumnIndex = reader.GetOrdinal("Price");

                    product = new Product()
                    {
                        Id = reader.GetInt32(idColumnIndex),
                        Name = reader.GetString(nameColumnIndex),
                        Description = !reader.IsDBNull(descriptionColumnIndex) ? reader.GetString(descriptionColumnIndex) : null,
                        Image = !reader.IsDBNull(imageColumnIndex) ? reader.GetString(imageColumnIndex) : null,
                        Price = reader.GetDecimal(priceColumnIndex)
                    };
                }

                product.Categories = GetProductCategoryIds(connection, id);

                return product;
            }
        }

        public IList<Product> GetByCategoryId(int categoryId)
        {
            IList<Product> products = new List<Product>();

            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT [Id], [Name], [Description], [Image], [Price] " +
                                      "FROM [Products] " +
                                      "INNER JOIN [ProductCategories] ON [Products].[Id] = [ProductCategories].[ProductId] " +
                                      "WHERE [CategoryId] = @CategoryId";

                command.Parameters.AddWithValue("@CategoryId", categoryId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return products;

                    int idColumnIndex = reader.GetOrdinal("Id");
                    int nameColumnIndex = reader.GetOrdinal("Name");
                    int descriptionColumnIndex = reader.GetOrdinal("Description");
                    int imageColumnIndex = reader.GetOrdinal("Image");
                    int priceColumnIndex = reader.GetOrdinal("Price");

                    while (reader.Read())
                    {
                        Product product = new Product()
                        {
                            Id = reader.GetInt32(idColumnIndex),
                            Name = reader.GetString(nameColumnIndex),
                            Description = !reader.IsDBNull(descriptionColumnIndex) ? reader.GetString(descriptionColumnIndex) : null,
                            Image = !reader.IsDBNull(imageColumnIndex) ? reader.GetString(imageColumnIndex) : null,
                            Price = reader.GetDecimal(priceColumnIndex)
                        };

                        products.Add(product);
                    }
                }
            }

            return products;
        }

        private ISet<int> GetProductCategoryIds(SqlConnection connection, int productId)
        {
            ISet<int> categoryIds = new HashSet<int>();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT [CategoryId] FROM [ProductCategories] WHERE [ProductId] = @ProductId";
            command.Parameters.AddWithValue("@ProductId", productId);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.HasRows)
                    return categoryIds;

                while (reader.Read())
                {
                    int categoryId = reader.GetInt32(0);
                    categoryIds.Add(categoryId);
                }
            }

            return categoryIds;
        }
    }
}
