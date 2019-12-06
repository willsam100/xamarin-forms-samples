namespace Notes

open System
open System.IO
open Xamarin.Forms

type App() as this =
    inherit Application()
    let mutable _folderpath = Unchecked.defaultof<string>

    do
        _folderpath <- Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData))
        base.MainPage <- new NavigationPage(new NotesPage(this))

    member this.FolderPath
        with get () = _folderpath
        and set value = _folderpath <- value

    override this.OnStart() = ()
    override this.OnSleep() = ()
    override this.OnResume() = ()

    interface IFolderPath with 
        member this.FolderPath with get() = this.FolderPath