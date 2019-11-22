namespace LocalDatabaseTutorial

open System
open System.IO
open Xamarin.Forms

type App() as this =
    inherit Application()
    static let mutable database = Unchecked.defaultof<Database>
    do base.MainPage <- new MainPage(this.Database)

    member this.Database =
        if database = Unchecked.defaultof<Database> then
            database <- new Database(Path.Combine
                                         (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                          "people.db3"))
        database

    override this.OnStart() = ()
    override this.OnSleep() = ()
    override this.OnResume() = ()