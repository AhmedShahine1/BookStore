namespace library.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string description { get; set; }

        public string imageUrl { get; set; }

        public Author Author { get; set; }
    }
}
