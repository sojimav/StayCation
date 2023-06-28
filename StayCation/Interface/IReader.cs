
using Hotel.Models;

namespace Hotel.Interface
{
    public interface IReader
    {
        List<Property> ReadFromPropertyFile(string filepath);
    }
}
