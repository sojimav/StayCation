using System.Data.SqlClient;
using System.Data;
using Hotel.Interface;
using System.Reflection.Metadata.Ecma335;

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
								typeof(T).GetProperty(columnName)?.SetValue(model, columnValue);
							}

							result.Add(model);
						}
					}
				}
			}
				
		          return result;		
		}




		public void WriteToTable()
		{
			using(SqlConnection Tableconnection = new SqlConnection())
			{
				Tableconnection.Open();

				using(SqlCommand command= Tableconnection.CreateCommand())
				{
				  
				}
			}
		}

	} 
}
