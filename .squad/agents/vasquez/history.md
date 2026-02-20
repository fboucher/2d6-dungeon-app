# Vasquez — History

## Project Context

Project: 2d6 Dungeon App — dungeon crawler game
Stack: .NET Aspire, Blazor web client, C# domain/services
Repo: https://github.com/fboucher/2d6-dungeon-app
Owner: Frank

Key paths:
- Frontend: src/2d6-dungeon-web-client/Components/
- Backend: src/2d6-dungeon-service/
- Domain: src/2d6-dungeon-service/domain/
- Services: src/2d6-dungeon-service/Services/

## Learnings


### Dallas PascalCase Rename Check (Play.razor + Adventurer.razor)

**Task:** Verify no callers break when Dallas renames `[Parameter]` properties from lowercase to PascalCase.

**Findings:**

1. **`state` → `State` in Adventurer.razor**
   - `Adventurer.razor` line 1: `@page "/adventurer/{State}"` — already updated (route segment)
   - `Adventurer.razor` line 22: `public required string state { get; set; }` — **OLD NAME STILL PRESENT** (the `[Parameter]` property itself is still lowercase)
   - `AdventurerPicker.razor` line 71: `Navigation.NavigateTo("adventurer/new")` — uses string literal route, not the parameter name directly. **Safe — no change needed.**
   - No other file passes `state=` or `State=` as a component attribute to `<Adventurer>`.

2. **`adventureId` → `AdventureId` in Play.razor**
   - `Play.razor` line 1: `@page "/play/{adventureId:int}"` — **OLD NAME in route template**
   - `Play.razor` line 114: `public int adventureId { get; set; }` — **OLD NAME in property**
   - `Play.razor` lines 140, 142: internal usages of `adventureId` — **will need updating**
   - `AdventurePicker.razor` line 74: `Navigation.NavigateTo($"play/{adventureId}")` — uses a local variable named `adventureId` (method parameter), **not** the component `[Parameter]`. Safe — no change needed as long as the route template segment name changes consistently.

**Callers that need updating alongside Dallas's changes:**
- `Play.razor` itself — internal references to `adventureId` (lines 114, 140, 142) and route template (line 1) must all be updated together.
- `Adventurer.razor` itself — the property on line 22 must be renamed to `State` to match the route segment already updated on line 1.

**No other external callers** in the web client pass these parameters by old names. Dallas's rename is self-contained within the two files.
