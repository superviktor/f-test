module DiscriminatedUnions
    
    type Suit = 
        | Heart
        | Diamond
        | Spade 
        | Club 

    type PlayingCard = 
        | Ace of Suit
        | King of Suit
        | Queen of Suit
        | Jack of Suit
        | ValueCard of int * Suit
        member this.Value =
            match this with 
            | Ace(_)
                -> 11
            | King(_)
            | Queen(_)
            | Jack(_)
                -> 10
            | ValueCard(x,_) when x <= 10 && x >= 2
                -> x
            | ValueCard(_)
                -> failwith "Card with invalida value"
            

    let deckOfCards = 
        [
            for suit in [Heart; Diamond; Spade; Club] do
                yield Ace(suit)
                yield King(suit)
                yield Queen(suit)
                yield Jack(suit)
                for value in 2..10 do 
                    yield ValueCard(value, suit)
        ]

    //describe hole cards 
    //describeHoleCards [ValueCard(2, Heart); ValueCard(2, Heart)]
    let describeHoleCards cards = 
        match cards with 
        | []
        | [_]
            -> failwith "too few cards"
        | cards when cards.Length > 2 
            -> failwith "too many cards"
        | [Ace(_); Ace(_)]
            -> "Pocket Rockets"
        | [King(_); King(_)]
            -> "Cowboy"
        | [ValueCard(2,_); ValueCard(2,_)]
            -> "Ducks"
        | [Queen(_); Queen(_)]
        | [Jack(_); Jack(_)]
            -> "Pair of face cards"
        | [ValueCard(x,_); ValueCard(y, _)] when x = y 
            -> "Pair"
        | [first; second] 
            -> sprintf "Two cards %A and %A" first second
