using library.Models;

namespace BookStore.ViewModels
{
    public class BookAuthorViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public List<Author> Author { get; set; }
    }
}
