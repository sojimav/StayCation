namespace Hotel.Interface
{
	public interface IDataHandler
	{
		List<T> ReadFromAnySqlTable<T>(string query, Func<T> modelFactory) where T : class; 
	} 
}
