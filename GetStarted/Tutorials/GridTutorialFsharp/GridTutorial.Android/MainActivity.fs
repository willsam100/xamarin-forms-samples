namespace GridTutorial.Droid

open System
open Android.App
open Android.Content.PM
open Android.Runtime
open Android.Views
open Android.Widget
open Android.OS

[<Activity(Label = "GridTutorial", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,
           ConfigurationChanges = (ConfigChanges.ScreenSize ||| ConfigChanges.Orientation))>]
type MainActivity() =
    inherit global.Xamarin.Forms.Platform.Android.FormsAppCompatActivity()
    override this.OnCreate(savedInstanceState: Bundle) =
        global.Xamarin.Forms.Platform.Android.FormsAppCompatActivity.TabLayoutResource <- Resources.Layout.Tabbar
        global.Xamarin.Forms.Platform.Android.FormsAppCompatActivity.ToolbarResource <- Resources.Layout.Toolbar
        base.OnCreate(savedInstanceState)
        global.Xamarin.Forms.Forms.Init(this, savedInstanceState)
        base.LoadApplication(new GridTutorial.App())