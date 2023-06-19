using MauiBlazor.Entities;
using SQLite;

namespace MauiBlazor.Data
{
    internal class AppDatabase
    {
        private readonly string _dbPath = Path.Combine(FileSystem.AppDataDirectory, "app_db.db3");
        private SQLiteAsyncConnection _connection;

        public async Task InitAsync()
        {
            try
            {
                _connection ??= new(_dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
                await _connection.CreateTableAsync<RouteLocation>();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public SQLiteAsyncConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    InitAsync().Wait();
                }

                return _connection;
            }
        }
    }
}
