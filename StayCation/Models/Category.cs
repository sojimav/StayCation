namespace Hotel.Models
{
    public class Category
    {
        public Category(List<Property> mostPicks, List<Property> backyards, List<Property> livingRooms, List<Property> kitchenSets)
        {
            MostPicks = mostPicks;
            Backyards = backyards;
            LivingRooms = livingRooms;
            KitchenSets = kitchenSets;
        }

        public List<Property> MostPicks { get; set; }
        public List<Property> Backyards { get;  set; }
        public List<Property> LivingRooms { get; set; } 
        public List<Property> KitchenSets { get; set; }
    }
}
