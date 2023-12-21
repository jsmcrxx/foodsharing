
// В данной модели указываются параматры для элемента коллекции

namespace foodsharing.Models
{
	public class Post
	{
        public string Id { get; set; }
        public string PostName { get; set; }
        public string Adress { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }
        public string PhoneNumder { get; set; }
        public string Description { get; set; }
    }
}

