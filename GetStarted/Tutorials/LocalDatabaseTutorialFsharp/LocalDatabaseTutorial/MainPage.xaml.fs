namespace LocalDatabaseTutorial

open System
open Xamarin.Forms
open Xamarin.Forms.Xaml

type MainPage(db: IDatabase) =
    inherit ContentPage()
    let _ = base.LoadFromXaml typeof<MainPage>
    let ageEntry = base.FindByName<Entry> "ageEntry"
    let nameEntry = base.FindByName<Entry> "nameEntry"
    let listView = base.FindByName<ListView> "listView"

    override this.OnAppearing() =
        base.OnAppearing()
        async { let! peopleAsync = db.GetPeopleAsync() |> Async.AwaitTask
                listView.ItemsSource <- peopleAsync } |> Async.StartImmediate

    member this.OnButtonClicked(sender: obj, e: EventArgs) =
        async {
            if not (String.IsNullOrWhiteSpace(nameEntry.Text)) && not (String.IsNullOrWhiteSpace(ageEntry.Text)) then
                do! db.SavePersonAsync(new Person(Name = nameEntry.Text, Age = Int32.Parse(ageEntry.Text))) |> Async.AwaitTask |> Async.Ignore
                nameEntry.Text <- String.Empty
                ageEntry.Text <- String.Empty
                let! peopleAsync = db.GetPeopleAsync() |> Async.AwaitTask
                listView.ItemsSource <- peopleAsync
        }
        |> Async.StartImmediate