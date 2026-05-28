```mermaid
classDiagram
    %% Compact UML for GitHub
    class Character
    class Player
    class Monster
    class Ability
    class Weapon
    class Inventory
    class Party
    class Encounter

    Character <|-- Player
    Character <|-- Monster
    Player --> Ability : uses
    Player --> Inventory : owns
    Character --> Weapon : equips
    Party --> Player : contains
    Encounter --> Party : has
    Encounter --> Monster : spawns

    %% Focused and short so mermaid.live and renderers display reliably
```mermaid
flowchart TB
    %% Flowchart-style diagram modeled after your screenshot
    classDef box fill:#ffdca8,stroke:#333,stroke-width:1px,rx:6,ry:6;
    classDef action fill:#ffd1dc,stroke:#333,stroke-width:1px,rx:6,ry:6;
    classDef person fill:#d0f0c0,stroke:#333,stroke-width:1px,rx:20,ry:20;

    A["Explain the problem"]:::box

    subgraph LeftColumn
        S0(Start timer):::action
        Mary((Mary)):::person
    end

    subgraph RightColumn
        CallIdeas["Call for ideas"]:::box
        WriteIdeas["Write down all ideas"]:::action
        PresentIdea["Present idea"]:::action
        EvaluateIdea["Evaluate idea"]:::action
    end

    Decision{more? / one idea?}

    Dani((Dani)):::person
    Allie((Allie)):::person

    Testing["Testing"]:::box

    A --> S0
    A --> CallIdeas
    CallIdeas --> Decision
    Decision -->|one idea| PresentIdea
    Decision -->|more| WriteIdeas
    WriteIdeas --> EvaluateIdea
    PresentIdea --> EvaluateIdea
    EvaluateIdea -->|accept| Testing
    EvaluateIdea -->|reject| CallIdeas

    S0 --> Mary
    WriteIdeas --> Allie
    Testing --> Dani

    %% layout hints
    class A,S0,CallIdeas,WriteIdeas,PresentIdea,EvaluateIdea,Testing box
    class Mary,Allie,Dani person

    %% Note: copy only the flowchart body into mermaid.live (no ```mermaid)
```
