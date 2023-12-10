using Domain.Infrastructure.Abstract.InterfaceC;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Domain.RabbitUser.Model;
using Newtonsoft.Json;

namespace Domain.RabbitUser
{
    public class UserRabbit : IUserRabbit
    {
        private readonly IConfiguration _configuration;
        public UserRabbit(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<object> UserRabbitMQ(ClaimsIdentity identity)
        {
            int stateuser = 1;
            string Companyposition = "Costumer services";
            string rabbitMqApiUrl = "http://localhost:15672";
            string username = "guest";
            string password = "guest";
            int NumQueueallowed = 10;
            List<string> resulQueue = new List<string>();
            string ListResult="";
            List<ModelQueue> QueueData = new List<ModelQueue>();
            
            try
            {
                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;
                using (HttpClient client = new HttpClient())
                {
                    // Configurar credenciales para acceder a la API de RabbitMQ
                    var authHeader = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Basic",
                          Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{username}:{password}"))
                    );
                    client.DefaultRequestHeaders.Authorization = authHeader;

                    // Obtener la lista de conexiones
                    var connectionsResponse = await client.GetStringAsync($"{rabbitMqApiUrl}/api/queues");
                    IEnumerable<QueueData> result = JsonConvert.DeserializeObject<IEnumerable<QueueData>>(connectionsResponse);                    
                    foreach (QueueData data in result)
                    {
                        if (data.Name != null)
                        {
                            resulQueue.Add (data.Name);

                        }
                    }
                    string sqlDataSource = _configuration.GetConnectionString("BDSql");
                    SqlDataReader myReader;
                    string query = @"select [Seniority] FROM [Test].[dbo].[User] where [Identification] = @id";

                    // 
                    List<string> resultados = new List<string>();
                    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                    {
                        myCon.Open();

                        using (SqlCommand command = new SqlCommand(query, myCon))
                        {
                            command.Parameters.AddWithValue("@id", id);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        resultados.Add(reader["Seniority"].ToString());
                                        ListResult = resultados.ToString();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Any result with that Id.");
                                }
                            }
                        }
                    }

                    var factory = new ConnectionFactory { HostName = "localhost", Port = 5672 };
                    using var connection = factory.CreateConnection();
                    using var channel = connection.CreateModel();
                    foreach (var queue in resulQueue)
                    {
                        var queueDeclareResponse = channel.QueueDeclarePassive(queue);
                        var messageCount = queueDeclareResponse.MessageCount;
                        QueueData.Add(new ModelQueue{NameQueue= queue, NumQueue=Convert.ToInt32(messageCount) });
                    }
                    switch (ListResult)
                    {
                        case "Junior":
                            if (QueueData[0].NumQueue <= NumQueueallowed+ 0.4 && QueueData[1].NumQueue <= NumQueueallowed + 0.4)
                            {
                                return "There are many users, please try again later.";
                            }
                            else
                            {
                                if (QueueData[0].NumQueue <= QueueData[1].NumQueue)
                                {
                                    channel.BasicPublish(exchange: "",
                                                          routingKey: QueueData[0].NameQueue,
                                                          basicProperties: null,
                                                          body: Encoding.UTF8.GetBytes($"User in row'{id}'"));
                                }
                                else
                                {
                                    channel.BasicPublish(exchange: "",
                                                         routingKey: QueueData[0].NameQueue,
                                                         basicProperties: null,
                                                         body: Encoding.UTF8.GetBytes($"User in row'{id}'"));
                                }
                            }
                            break;

                        case "Senior":
                            if (QueueData[0].NumQueue <= NumQueueallowed + 0.8 && QueueData[1].NumQueue <= NumQueueallowed + 0.8)
                            {
                                return "There are many users, please try again later.";
                            }
                            else
                            {
                                if (QueueData[0].NumQueue <= QueueData[1].NumQueue)
                                {
                                    channel.BasicPublish(exchange: "",
                                                          routingKey: QueueData[0].NameQueue,
                                                          basicProperties: null,
                                                          body: Encoding.UTF8.GetBytes($"User in row'{id}'"));
                                }
                                else
                                {
                                    channel.BasicPublish(exchange: "",
                                                         routingKey: QueueData[0].NameQueue,
                                                         basicProperties: null,
                                                         body: Encoding.UTF8.GetBytes($"User in row'{id}'"));
                                }
                            }
                            break;
                        case "Mid-Level":
                            if (QueueData[0].NumQueue <= NumQueueallowed + 0.6 && QueueData[1].NumQueue <= NumQueueallowed + 0.6)
                            {
                                return "There are many users, please try again later.";
                            }
                            else
                            {
                                if (QueueData[0].NumQueue <= QueueData[1].NumQueue)
                                {
                                    channel.BasicPublish(exchange: "",
                                                          routingKey: QueueData[0].NameQueue,
                                                          basicProperties: null,
                                                          body: Encoding.UTF8.GetBytes($"User in row'{id}'"));
                                }
                                else
                                {
                                    channel.BasicPublish(exchange: "",
                                                         routingKey: QueueData[0].NameQueue,
                                                         basicProperties: null,
                                                         body: Encoding.UTF8.GetBytes($"User in row'{id}'"));
                                }
                            }
                            break;
                        case "Team Lead":
                            if (QueueData[0].NumQueue <= NumQueueallowed + 0.5 && QueueData[1].NumQueue <= NumQueueallowed + 0.5)
                            {
                                return "There are many users, please try again later.";
                            }
                            else
                            {
                                if (QueueData[0].NumQueue <= QueueData[1].NumQueue)
                                {
                                    channel.BasicPublish(exchange: "",
                                                          routingKey: QueueData[0].NameQueue,
                                                          basicProperties: null,
                                                          body: Encoding.UTF8.GetBytes($"User in row'{id}'"));
                                }
                                else
                                {
                                    channel.BasicPublish(exchange: "",
                                                         routingKey: QueueData[0].NameQueue,
                                                         basicProperties: null,
                                                         body: Encoding.UTF8.GetBytes($"User in row'{id}'"));
                                }
                            }
                            break;
                    }
                }             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
    }
}
