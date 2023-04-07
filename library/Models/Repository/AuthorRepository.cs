using library.Models;

namespace BookStore.Models.Repository
{
    public class AuthorRepository : IBookStoreRepositry<Author>
    {
        IList<Author> authors;
        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author()
                {
                    Id = 1, Name="Khaled"
                },
                new Author()
                {
                    Id=2, Name="Mohammed"
                },
                new Author()
                {
                    Id=3, Name="Seif"
                }
            };
        }
        public void Add(Author entity)
        {
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(x => x.Id == id);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public void Update(Author entity, int id)
        {
            var author = Find(id);
            author.Name = entity.Name;
        }
    }
}
