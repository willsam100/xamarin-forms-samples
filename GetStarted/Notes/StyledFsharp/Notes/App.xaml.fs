namespace Notes

open System
open System.IO
open Xamarin.Forms
open Notes.Data
open Xamarin.Forms.Xaml

type App() =
    inherit Application()
    static let database = 
            new NoteDatabase(Path.Combine
                (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                  "Notes.db3"))

    do 
        let _ = base.LoadFromXaml typeof<App> // Load the app resources
        base.MainPage <- new NavigationPage(new NotesPage(database))

    override this.OnStart() = ()
    override this.OnSleep() = ()
    override this.OnResume() = ()