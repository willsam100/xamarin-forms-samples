namespace WebServiceTutorial

open System
open Xamarin.Forms
open Xamarin.Forms.Xaml

type MainPage() =
    inherit ContentPage()
    let _ = base.LoadFromXaml typeof<MainPage>
    let cityEntry = base.FindByName<Entry> "cityEntry"
    let mutable _restService = Unchecked.defaultof<RestService>
    do _restService <- new RestService()
    
    member this.OnButtonClicked(sender: obj, e: EventArgs) =
        async {
            if not (String.IsNullOrWhiteSpace(cityEntry.Text)) then
                let! weatherData = _restService.GetWeatherDataAsync
                                       (this.GenerateRequestUri(Constants.OpenWeatherMapEndpoint)) |> Async.AwaitTask
                this.BindingContext <- weatherData
        }
        |> Async.StartImmediate

    member this.GenerateRequestUri(endpoint: string): string =
        let mutable requestUri = endpoint
        requestUri <- requestUri + sprintf "?q=%O" (cityEntry.Text)
        requestUri <- requestUri + "&units=imperial"
        requestUri <- requestUri + sprintf "&APPID=%O" (Constants.OpenWeatherMapAPIKey)
        requestUri