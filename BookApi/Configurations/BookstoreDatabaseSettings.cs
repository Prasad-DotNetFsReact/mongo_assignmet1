using MongoDB.Driver;

namespace BookApi.Configurations
{
    public class BookstoreDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string BooksCollectionName { get; set; }
    }
}
