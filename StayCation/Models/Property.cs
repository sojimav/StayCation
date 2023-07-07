namespace Hotel.Models
{
	public class Property
	{
		public Property(string group, string image, string price, string nameOfProp, string location, string popularity)
		{
			Group = group;
			Image = image;
			Price = price;
			NameOfProp = nameOfProp;
			Location = location;
			Popularity = popularity;
		}

        //public Property()
        //{
            
        //}

        public string Group { get; set; }
		public string  Image  { get; set; }
		public string Price { get; set; }
		public string NameOfProp { get; set; }
		public string Location { get; set; }
		public string Popularity { get; set; }

	}
}
