using System.Data.SqlClient;
using System.Data;
using Hotel.Interface;
using System.Reflection.Metadata.Ecma335;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Hotel.Helpers
{
	public class DataHandler : IDataHandler 
	{
		public string Connection { get;  private set; }
		public DataHandler(string connection)
		{
			Connection = connection;
		}

		
		public List<T> ReadFromAnySqlTable<T>(string storedProcedure, Func<T> modelFactory) where T : class
		{
			List<T> result = new List<T>();

			using(SqlConnection Tableconnection = new SqlConnection(Connection))
			{
				Tableconnection.Open();
				using(SqlCommand command = new SqlCommand(storedProcedure, Tableconnection))
				{
					command.CommandType = CommandType.StoredProcedure;
					using(SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							T model = modelFactory();
							for(int i = 0; i < reader.FieldCount; i++)
							{
								string columnName = reader.GetName(i);
								object columnValue = reader.GetValue(i);

								// Use reflection to set the property value on the model
								if(columnValue != DBNull.Value)
								{
									typeof(T).GetProperty(columnName)?.SetValue(model, columnValue);
								}
								else
								{
									typeof(T).GetProperty(columnName)?.SetValue(model, string.Empty);
								}
								
							}

							result.Add(model);
						}
					}
				}
			}
				
		          return result;		
		}




		public void WriteToTable<T>(string storedProcedure, T model) where T : class
		{
			using(SqlConnection Tableconnection = new SqlConnection(Connection))
			{
				
				Tableconnection.Open();

                // Get the properties of the model object
                var properties = typeof(T).GetProperties();

                using (SqlCommand command= Tableconnection.CreateCommand())
				{
				  command.CommandType = CommandType.StoredProcedure;
				  command.CommandText = storedProcedure;

                    foreach (var property in properties)
                    {
                        command.Parameters.AddWithValue("@" + property.Name, property.GetValue(model));
                    }

                    // Execute the INSERT statement
                    command.ExecuteNonQuery();
                }

                Tableconnection.Close();
            }
		}

	} 
}
