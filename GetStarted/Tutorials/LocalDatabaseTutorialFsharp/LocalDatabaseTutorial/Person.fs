namespace LocalDatabaseTutorial

open SQLite

type Person() =
    member val ID: int = Unchecked.defaultof<int> with get, set
    member val Name: string = Unchecked.defaultof<string> with get, set
    member val Age: int = Unchecked.defaultof<int> with get, set