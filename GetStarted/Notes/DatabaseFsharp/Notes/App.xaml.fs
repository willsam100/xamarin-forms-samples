namespace Notes

open System
open System.IO
open Xamarin.Forms
open Notes.Data

type App() =
    inherit Application()

    let database =
        new NoteDatabase(Path.Combine
                             (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                              "Notes.db3"))
    do 
        base.MainPage <- new NavigationPage(new NotesPage(database))

                              
    override this.OnStart() = ()
    override this.OnSleep() = ()
    override this.OnResume() = ()