namespace ListViewTutorial

type Monkey() =
    member val Name: string = Unchecked.defaultof<string> with get, set
    member val Location: string = Unchecked.defaultof<string> with get, set
    member val ImageUrl: string = Unchecked.defaultof<string> with get, set
    override this.ToString(): string = this.Name