namespace AppLifecycleTutorial

open System
open Xamarin.Forms

type App() as this =
    inherit Application()
    let displayText = "displayText"
    do base.MainPage <- new MainPage(this)
    member val DisplayText: string = Unchecked.defaultof<string> with get, set

    override this.OnStart() =
        if base.Properties.ContainsKey(displayText) then 
            this.DisplayText <- (base.Properties.[displayText] :?> string)
        Console.WriteLine("OnStart")

    override this.OnSleep() =
        base.Properties.[displayText] <- this.DisplayText
        Console.WriteLine("OnSleep")

    override this.OnResume() = Console.WriteLine("OnResume")

    interface IApp with 
        member __.DisplayText
            with get() = this.DisplayText
            and set(value) = this.DisplayText <- value