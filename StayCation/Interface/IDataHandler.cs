namespace Hotel.Interface
{
	public interface IDataHandler<T>
	{
		List<T> ReadFromAnySqlTable(string query, Func<T> modelFactory);
	}
}
