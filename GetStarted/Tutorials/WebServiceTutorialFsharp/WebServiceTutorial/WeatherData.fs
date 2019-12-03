namespace WebServiceTutorial

open Newtonsoft.Json

type Main() =
    member val Temperature: double = Unchecked.defaultof<double> with get, set
    member val Humidity: int64 = Unchecked.defaultof<int64> with get, set

type Weather() =
    member val Visibility: string = Unchecked.defaultof<string> with get, set

type Wind() =
    member val Speed: double = Unchecked.defaultof<double> with get, set

type WeatherData() =
    member val Title: string = Unchecked.defaultof<string> with get, set
    member val Weather: Weather [] = Unchecked.defaultof<Weather []> with get, set
    member val Main: Main = Unchecked.defaultof<Main> with get, set
    member val Visibility: int64 = Unchecked.defaultof<int64> with get, set
    member val Wind: Wind = Unchecked.defaultof<Wind> with get, set