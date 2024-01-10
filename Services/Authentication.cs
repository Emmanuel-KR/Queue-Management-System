using Npgsql;
using Microsoft.Extensions.Configuration;
//using Queue_Management_System_Assignment.Models;

namespace Queue_Management_System_Assignment.Services
{
    public class Authentication : IAuthentication
    {
        private readonly string _connectionString;

        public Authentication(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public ServiceProvider GetServiceProviderByUsername(string username)
        {

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM ServiceProvider WHERE Username = @Username";
                    command.Parameters.AddWithValue("@Username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var serviceProvider = new ServiceProvider
                            {
                                Id = Convert.ToInt32(reader["ServiceProviderId"]),
                                Username = reader["Username"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                ServicePointId = Convert.ToInt32(reader["ServicePointId"]),
                                Role = reader["Role"].ToString()

                            };

                            return serviceProvider;
                        }
                    }
                }
            }

            return null;
        }

        public bool AuthenticateServiceProvider(string username, string providedPassword)
        {
            var serviceProvider = GetServiceProviderByUsername(username);

            if (serviceProvider != null)
            {

                return string.Equals(serviceProvider.PasswordHash, providedPassword, StringComparison.Ordinal);
            }

            return false;
        }
    }
}
