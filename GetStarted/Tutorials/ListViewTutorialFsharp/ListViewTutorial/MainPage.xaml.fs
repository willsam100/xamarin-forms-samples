namespace ListViewTutorial

open System.Collections.Generic
open Xamarin.Forms
open Xamarin.Forms.Xaml

type MainPage() as this =
    inherit ContentPage()
    let _ = base.LoadFromXaml typeof<MainPage>
    let mutable _monkeys = Unchecked.defaultof<IList<Monkey>>

    do
        _monkeys <- new List<Monkey>()
        this.Monkeys.Add
            (new Monkey(Name = "Baboon", Location = "Africa & Asia",
                        ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"))
        this.Monkeys.Add
            (new Monkey(Name = "Capuchin Monkey", Location = "Central & South America",
                        ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"))
        this.Monkeys.Add
            (new Monkey(Name = "Blue Monkey", Location = "Central and East Africa",
                        ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg"))
        this.Monkeys.Add
            (new Monkey(Name = "Squirrel Monkey", Location = "Central & South America",
                        ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Saimiri_sciureus-1_Luc_Viatour.jpg/220px-Saimiri_sciureus-1_Luc_Viatour.jpg"))
        this.Monkeys.Add
            (new Monkey(Name = "Golden Lion Tamarin", Location = "Brazil",
                        ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Golden_lion_tamarin_portrait3.jpg/220px-Golden_lion_tamarin_portrait3.jpg"))
        this.Monkeys.Add
            (new Monkey(Name = "Howler Monkey", Location = "South America",
                        ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/Alouatta_guariba.jpg/200px-Alouatta_guariba.jpg"))
        this.Monkeys.Add
            (new Monkey(Name = "Japanese Macaque", Location = "Japan",
                        ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Macaca_fuscata_fuscata1.jpg/220px-Macaca_fuscata_fuscata1.jpg"))
        this.Monkeys.Add
            (new Monkey(Name = "Mandrill", Location = "Southern Cameroon, Gabon, Equatorial Guinea, and Congo",
                        ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Mandrill_at_san_francisco_zoo.jpg/220px-Mandrill_at_san_francisco_zoo.jpg"))
        this.Monkeys.Add
            (new Monkey(Name = "Proboscis Monkey", Location = "Borneo",
                        ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/e/e5/Proboscis_Monkey_in_Borneo.jpg/250px-Proboscis_Monkey_in_Borneo.jpg"))
        this.Monkeys.Add
            (new Monkey(Name = "Red-shanked Douc", Location = "Vietnam, Laos",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/Portrait_of_a_Douc.jpg/159px-Portrait_of_a_Douc.jpg"))
        this.Monkeys.Add
            (new Monkey(Name = "Gray-shanked Douc", Location = "Vietnam",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Cuc.Phuong.Primate.Rehab.center.jpg/320px-Cuc.Phuong.Primate.Rehab.center.jpg"))
        this.Monkeys.Add
            (new Monkey(Name = "Golden Snub-nosed Monkey", Location = "China",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c8/Golden_Snub-nosed_Monkeys%2C_Qinling_Mountains_-_China.jpg/165px-Golden_Snub-nosed_Monkeys%2C_Qinling_Mountains_-_China.jpg"))
        this.Monkeys.Add
            (new Monkey(Name = "Black Snub-nosed Monkey", Location = "China",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/59/RhinopitecusBieti.jpg/320px-RhinopitecusBieti.jpg"))
        this.Monkeys.Add
            (new Monkey(Name = "Tonkin Snub-nosed Monkey", Location = "Vietnam",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9c/Tonkin_snub-nosed_monkeys_%28Rhinopithecus_avunculus%29.jpg/320px-Tonkin_snub-nosed_monkeys_%28Rhinopithecus_avunculus%29.jpg"))
        this.Monkeys.Add
            (new Monkey(Name = "Thomas's Langur", Location = "Indonesia",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/31/Thomas%27s_langur_Presbytis_thomasi.jpg/142px-Thomas%27s_langur_Presbytis_thomasi.jpg"))
        this.Monkeys.Add
            (new Monkey(Name = "Purple-faced Langur", Location = "Sri Lanka",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/02/Semnopithèque_blanchâtre_mâle.JPG/192px-Semnopithèque_blanchâtre_mâle.JPG"))
        this.Monkeys.Add
            (new Monkey(Name = "Gelada", Location = "Ethiopia",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/Gelada-Pavian.jpg/320px-Gelada-Pavian.jpg"))
        this.BindingContext <- this

    member this.Monkeys
        with get (): IList<Monkey> = _monkeys
        and set value = _monkeys <- value

    member this.OnListViewItemSelected(sender: obj, e: SelectedItemChangedEventArgs) =
        let mutable selectedItem = (e.SelectedItem :?> Monkey)
        ()

    member this.OnListViewItemTapped(sender: obj, e: ItemTappedEventArgs) =
        let mutable tappedItem = (e.Item :?> Monkey)
        ()