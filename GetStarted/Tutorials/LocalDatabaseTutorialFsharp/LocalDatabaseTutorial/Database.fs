namespace LocalDatabaseTutorial

open System.Collections.Generic
open System.Threading.Tasks
open SQLite

type IDatabase = 
    abstract member GetPeopleAsync: unit -> Task<List<Person>>
    abstract member SavePersonAsync: Person -> Task<int>

type Database(dbPath: string) =
    let mutable _database = Unchecked.defaultof<SQLiteAsyncConnection>

    do
        _database <- new SQLiteAsyncConnection(dbPath)
        _database.CreateTableAsync<Person>().Wait()

    interface IDatabase with 
        member this.GetPeopleAsync(): Task<List<Person>> = _database.Table<Person>().ToListAsync()
        member this.SavePersonAsync(person: Person): Task<int> = _database.InsertAsync(person)