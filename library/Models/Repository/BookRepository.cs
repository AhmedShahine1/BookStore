using library.Models;

namespace BookStore.Models.Repository
{
    public class BookRepository : IBookStoreRepositry<Book>
    {
        List<Book> books;
        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,Title="C# Programming", description="No Description", Author=new Author{Id=1}
                },
                new Book()
                {
                    Id=2,Title="C++ Programming", description="No Description",Author=new Author{Id=2}
                },
                new Book()
                {
                    Id=3,Title="Python Programming", description="No Description",Author = new Author{Id=3}
                },
                new Book()
                {
                    Id=4,Title="Java Programming", description="No Description",Author=new Author{Id=1}
                }
            };
        }

        public void Add(Book entity)
        {
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book=books.SingleOrDefault(x => x.Id == id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(books => books.Id == id);
            return book;
        }

        public IList<Book> List()
        {
            return books;
        }

        public void Update(Book entity, int id)
        {
            var book = Find(id);
            book.Title= entity.Title;
            book.description = entity.description;
            book.Author = entity.Author;
        }
    }
}
