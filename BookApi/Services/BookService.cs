using BookApi.Configurations;
using BookApi.Models;
using MongoDB.Driver;

namespace BookApi.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(BookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public async Task<List<Book>> GetAsync() =>
            await _books.Find(book => true).ToListAsync();

        public async Task<Book> GetAsync(string id) =>
            await _books.Find<Book>(book => book.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Book book) =>
            await _books.InsertOneAsync(book);

        public async Task UpdateAsync(string id, Book bookIn) =>
            await _books.ReplaceOneAsync(book => book.Id == id, bookIn);

        public async Task RemoveAsync(string id) =>
            await _books.DeleteOneAsync(book => book.Id == id);
    }
}





