﻿using Npgsql;
using Queue_Management_System_Assignment.Models;

namespace Queue_Management_System_Assignment.Repository
{
    public class ApplicationDAL
    {
        private readonly DBConnectionsHelper _connection;


        public ApplicationDAL(DBConnectionsHelper connectionFactory)
        {
            _connection = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public async Task<List<ServiceTypeM>> GetAvailableServicesAsync()
        {
            var serviceTypes = new List<ServiceTypeM>();

            try
            {
                // Open a connection using the connection factory
                using var connection = _connection.CreateConnection();
                await connection.OpenAsync();

                var query = "SELECT Id, Name, Description FROM ServiceTypes";

                using var cmd = new NpgsqlCommand(query, connection);
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var serviceType = new ServiceTypeM
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.IsDBNull(2) ? null : reader.GetString(2)
                    };

                    serviceTypes.Add(serviceType);
                }
            }
            catch (Exception ex)
            {
                // Handle exception or log the error
                Console.WriteLine($"Error fetching services: {ex.Message}");
            }

            return serviceTypes;
        }

        public async Task<bool> SaveSelectedService(string ticketNumber, string serviceName, string customerName)
        {
            try
            {
                using var connection = _connection.CreateConnection();
                await connection.OpenAsync();

                // Construct the SQL query to insert the selected service into the QueueEntry table
                var query = "INSERT INTO QueueEntry (TicketNumber, ServicePoint, CustomerName, CheckinTime) " +
                            "VALUES (@ticketNumber, @servicePoint, @customerName, @checkinTime)";

                using var cmd = new NpgsqlCommand(query, connection);
                cmd.Parameters.AddWithValue("ticketNumber", ticketNumber);
                cmd.Parameters.AddWithValue("servicePoint", serviceName);
                cmd.Parameters.AddWithValue("customerName", customerName);
                cmd.Parameters.AddWithValue("checkinTime", DateTime.Now);

                // Execute the SQL command to insert the selected service into the table
                var rowsAffected = await cmd.ExecuteNonQueryAsync();

                // Return true if the insertion was successful (at least one row affected)
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Handle exception or log the error
                Console.WriteLine($"Error saving selected service: {ex.Message}");
                return false;
            }
        }

        public async Task<WaitingPageM> GetTopQueueEntryAsync()
        {
            WaitingPageM waiting = null;

            try
            {
                using var connection = _connection.CreateConnection();
                await connection.OpenAsync();

                var query = "SELECT id, ticketnumber, servicepoint, customername, checkintime " +
                            "FROM public.queueentry " +
                            "ORDER BY id DESC " +
                            "LIMIT 1";

                using var cmd = new NpgsqlCommand(query, connection);
                using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var ticketNumber = reader.GetString(1);
                    var servicePoint = reader.GetString(2);
                    var customerName = reader.GetString(3);
                    var checkinTime = reader.GetDateTime(4);

                    waiting = new WaitingPageM(ticketNumber, servicePoint, customerName, checkinTime);
                }

            }
            catch (Exception ex)
            {
                // Handle exception or log the error
                Console.WriteLine($"Error fetching top queue entry: {ex.Message}");
            }

            return waiting;
        }

        public async Task<ServiceProviderM> LoginAsync(string usernameOrEmail, string password)
        {
            ServiceProviderM serviceProvider = null;

            try
            {
                using var connection = _connection.CreateConnection();
                await connection.OpenAsync();

                var query = "SELECT Id, Username, Email, Phone, PasswordHash, RegistrationDate, ServicePoint, ServiceTypeId " +
                            "FROM serviceProviders " +
                            "WHERE (Username = @UsernameOrEmail OR Email = @UsernameOrEmail) " +
                            "AND PasswordHash = @Password";

                using var cmd = new NpgsqlCommand(query, connection);
                cmd.Parameters.AddWithValue("UsernameOrEmail", usernameOrEmail);
                cmd.Parameters.AddWithValue("Password", password);

                using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    serviceProvider = new ServiceProviderM
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Email = reader.GetString(2),
                        Phone = reader.GetString(3),
                        PasswordHash = reader.GetString(4),
                        RegistrationDate = reader.GetDateTime(5),
                        ServicePoint = reader.GetString(6),
                        ServiceTypeId = reader.GetInt32(7)
                    };
                }
            }
            catch (Exception ex)
            {
                // Handle exception or log the 
                Console.WriteLine($"Error during login: {ex.Message}");
            }

            return serviceProvider;
        }

        public async Task<Queue> GetLatestQueueEntryAsync()
        {
            Queue latestEntry = null;

            try
            {
                using var connection = new Npgsql.NpgsqlConnection(_connectionString);
                await connection.OpenAsync();

                var query = "SELECT id, ticketnumber, servicepoint, customername, checkintime " +
                            "FROM public.queueentry " +
                            "ORDER BY id DESC " +
                            "LIMIT 1";

                using var cmd = new NpgsqlCommand(query, connection);
                using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    latestEntry = new Queue
                    {
                        Id = reader.GetInt32(0),
                        TicketNumber = reader.GetString(1),
                        ServicePoint = reader.GetString(2),
                        CustomerName = reader.GetString(3),
                        CheckinTime = reader.GetDateTime(4)
                    };
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error retrieving latest queue entry: {ex.Message}");
            }

            return latestEntry;
        }
    }
}
