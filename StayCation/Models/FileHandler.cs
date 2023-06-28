using Hotel.Interface;

namespace Hotel.Models
{
    public class FileHandler : IFileHandler
    {
        public  List<Property> ReadFromPropertyFile(string filepath)
        {
            var PropertyFile = new List<Property>();
            using (StreamReader reader = new StreamReader(filepath))
            {
                string? read;
                while ((read = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(read))
                    {
                        string[] lines = read.Split("|");

                        if (lines.Length >= 6)
                        {
                            string group = lines[1].Trim();
                            string image = lines[2].Trim();
                            string price = lines[3].Trim();
                            string NameofProp = lines[4].Trim();
                            string Location = lines[5].Trim();
                            string Popularity = lines[6].Trim();
                            Property property = new Property(group, image, price, NameofProp, Location, Popularity);
                            PropertyFile.Add(property);
                        }
                    }
                }
            }

            return PropertyFile;
        }



        public void WriteToFile(string filepath, User user)
        {
            using(StreamWriter writer = new StreamWriter(filepath))
            {
                writer.WriteLine($"{user.FullName} | {user.Email} | {user.Password}");

            }
        }
    }
}
