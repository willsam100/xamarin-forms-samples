namespace Notes.Data

open System.Collections.Generic
open System.Threading.Tasks
open SQLite
open Notes.Models

type INoteDatabase = 
    abstract member GetNotesAsync:unit -> Task<List<Note>>
    abstract member GetNoteAsync: int -> Task<Note>
    abstract member SaveNoteAsync: Note -> Task<int>
    abstract member DeleteNoteAsync: Note -> Task<int>

type NoteDatabase(dbPath: string) =
    let mutable _database = Unchecked.defaultof<SQLiteAsyncConnection>

    do
        _database <- new SQLiteAsyncConnection(dbPath)
        _database.CreateTableAsync<Note>().Wait()

    interface INoteDatabase with 
        member this.GetNotesAsync(): Task<List<Note>> = _database.Table<Note>().ToListAsync()
        member this.GetNoteAsync(id: int): Task<Note> =
            _database.Table<Note>().Where(fun i -> i.ID = id).FirstOrDefaultAsync()

        member this.SaveNoteAsync(note: Note): Task<int> =
            if note.ID <> 0 then _database.UpdateAsync(note)
            else _database.InsertAsync(note)
    
        member this.DeleteNoteAsync(note: Note): Task<int> = _database.DeleteAsync(note)