namespace ImageTutorial

open Xamarin.Forms

type App() =
    inherit Application()
    do base.MainPage <- new MainPage()
    override this.OnStart() = ()
    override this.OnSleep() = ()
    override this.OnResume() = ()