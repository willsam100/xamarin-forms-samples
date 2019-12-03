namespace WebServiceTutorial

open System
open System.Diagnostics
open System.Net.Http
open System.Threading.Tasks
open Newtonsoft.Json

type RestService() =
    let mutable _client = Unchecked.defaultof<HttpClient>
    do _client <- new HttpClient()
    member this.GetWeatherDataAsync(uri: string): Task<WeatherData> =
        async {
            let mutable weatherData = Unchecked.defaultof<WeatherData>
            try
                let! response = _client.GetAsync(uri) |> Async.AwaitTask
                if response.IsSuccessStatusCode then
                    let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
                    weatherData <- JsonConvert.DeserializeObject<WeatherData>(content)
            with :? Exception as ex -> Debug.WriteLine("	ERROR {0}", ex.Message)
            return weatherData
        }
        |> Async.StartAsTask