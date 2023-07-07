using Microsoft.Data.SqlClient;
using Hotel.Interface;


namespace Hotel.Helpers
{
	public class DataHandler : IDataHandler 
	{
		public string ConnectionString { get;  private set; }
		public DataHandler(string connectionString)
		{
			ConnectionString = connectionString;
		}

		
		public void ReadFromTable(string query)
		{
			using(SqlConnection Tableconnection = new SqlConnection(ConnectionString))
			{
				Tableconnection.Open();
				using(SqlCommand command = new SqlCommand(query, Tableconnection))
				{
					using(SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							/*reader.GetOrdinal()*/
						}
					}
				}
			}
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
