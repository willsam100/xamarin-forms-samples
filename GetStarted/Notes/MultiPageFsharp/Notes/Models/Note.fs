namespace Notes.Models

open System

type Note() =
    member val Filename: string = Unchecked.defaultof<string> with get, set
    member val Text: string = Unchecked.defaultof<string> with get, set
    member val Date: DateTime = Unchecked.defaultof<DateTime> with get, set