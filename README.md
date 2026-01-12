วีรภัทร สุขพิไลกุล
683450193-9

classDiagram
    class IngredientStock {
        +int Water
        +int Coffee
        +int Milk
        +int Chocolate
        +HasEnough()
        +Use()
        +Refill()
    }
     class Drink {
        +string Name
        +Dictionary Ingredients
    }
        class CoffeeMachine {
        +MakeDrink()
    }
     class Program {
        +Main()
    }
    CoffeeMachine --> IngredientStock : uses
    CoffeeMachine --> Drink : makes
    Program --> CoffeeMachine : controls
