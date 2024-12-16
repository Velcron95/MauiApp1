using SQLite;
using MauiApp1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiApp1.Data;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _database;

    public DatabaseService(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<ToDoList>().Wait();
    }
    public Task<ToDoList> GetItemAsync(int id)
    {
        
        return _database.Table<ToDoList>().Where(item => item.Id == id).FirstOrDefaultAsync();
    }

    public Task<List<ToDoList>> GetItemsAsync()
    {
        return _database.Table<ToDoList>().ToListAsync();
    }

    public Task<int> SaveItemAsync(ToDoList item)
    {
        return _database.InsertAsync(item);
    }

    public Task<int> DeleteItemAsync(ToDoList item)
    {
        return _database.DeleteAsync(item);
    }
    public async Task ClearTableAsync()
    {
        await _database.ExecuteAsync("DELETE FROM ToDoList");
    }
    public async Task UpdateAsync(ToDoList item)
    {
        if (item.Id != 0) 
        {
            
            await _database.UpdateAsync(item);  
        }
        else
        {
            
            await _database.InsertAsync(item);  
        }
    }

}
