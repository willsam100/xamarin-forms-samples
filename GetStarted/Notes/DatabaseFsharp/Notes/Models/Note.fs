namespace Notes.Models

open System
open SQLite

type Note() =

    [<PrimaryKey; AutoIncrement>]
    member val ID: int = Unchecked.defaultof<int> with get, set
    
    member val Text: string = Unchecked.defaultof<string> with get, set
    member val Date: DateTime = Unchecked.defaultof<DateTime> with get, set