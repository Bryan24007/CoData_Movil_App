using SQLite;

public class ReporteRepository
{
    private readonly SQLiteAsyncConnection _db;

    public ReporteRepository()
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "appdb.db3");
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<Reporte>().Wait();
    }

    public async Task<int> AddReporteAsync(Reporte reporte) => await _db.InsertAsync(reporte);
    public async Task<List<Reporte>> GetReportesAsync() => await _db.Table<Reporte>().ToListAsync();
    public async Task<int> UpdateReporteAsync(Reporte reporte) => await _db.UpdateAsync(reporte);
    public async Task<int> DeleteReporteAsync(Reporte reporte) => await _db.DeleteAsync(reporte);

    


}
