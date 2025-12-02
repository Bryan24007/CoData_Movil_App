using SQLite;

public class UserRepository
{
    private readonly SQLiteAsyncConnection _db;

    public UserRepository()
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "appdb.db3");
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<User>().Wait();
    }

    public async Task<bool> ValidateUserAsync(string email, string password)
    {
        var user = await _db.Table<User>()
                            .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        return user != null;
    }

    public async Task<int> AddUserAsync(User user) => await _db.InsertAsync(user);
    public async Task<List<User>> GetUsersAsync() => await _db.Table<User>().ToListAsync();
    public async Task<int> UpdateUserAsync(User user) => await _db.UpdateAsync(user);
    public async Task<int> DeleteUserAsync(User user) => await _db.DeleteAsync(user);
}

public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [Unique]
    public string Email { get; set; }
    public string Password { get; set; }
    public string Nombre { get; set; }

}


