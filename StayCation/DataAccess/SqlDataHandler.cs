using System.Data.SqlClient;
using System.Data;
using Hotel.Interface;
using System.Reflection.Metadata.Ecma335;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Helpers
{
	public class SqlDataHandler : IDataHandler 
	{
		public string Connection { get;  private set; }
		public SqlDataHandler(string connection)
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
			using (SqlConnection Tableconnection = new SqlConnection(Connection))
			{
				Tableconnection.Open();

				var properties = typeof(T).GetProperties();

				using (SqlCommand command = Tableconnection.CreateCommand())
				{
					command.CommandType = CommandType.StoredProcedure;
					command.CommandText = storedProcedure;

					foreach (var property in properties)
					{
						if (property.Name != "Id")  // Exclude the Id property
						{
							command.Parameters.AddWithValue("@" + property.Name, property.GetValue(model));
						}
					}

					command.ExecuteNonQuery();
				}

				Tableconnection.Close();
			}
		}


	}
}
