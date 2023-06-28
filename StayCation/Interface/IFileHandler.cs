
using Hotel.Models;

namespace Hotel.Interface
{
    public interface IFileHandler
    {
        List<Property> ReadFromPropertyFile(string filepath);
        void WriteToFile(string filepath, User user);

	}
}
