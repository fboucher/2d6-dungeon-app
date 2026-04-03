# lambert — Project History

## Core Context

- **Project:** 2d6-dungeon-app — Blazor companion app for the 2d6 Dungeon tabletop RPG
- **Stack:** Blazor WebAssembly / .NET 9, Aspire, JavaScript canvas, Fluent UI components
- **Key dirs:** `src/2d6-dungeon-web-client/` (Blazor), `src/2d6-dungeon-service/` (backend), `src/AppHost/` (Aspire)
- **User:** fboucher
- **Joined:** 2026-04-03

## Learnings

### 2026-04-03 — Issue #173: Character Sheet Completion Audit

**Task:** Investigate and implement missing fields for the Adventurer/Character sheet based on domain model.

**Files Modified:**
- `src/2d6-dungeon-web-client/Components/Shared/AdventurerCard.razor` — Expanded character sheet display

**Files Analyzed:**
- `src/2d6-dungeon-service/domain/Adventurer.cs` — Full domain model with 32+ properties
- `src/2d6-dungeon-service/domain/Coins.cs` — Currency tracking (Gold, Silver, Copper)
- `src/2d6-dungeon-service/domain/FavorOfTheGods.cs` — Six deity favor values
- `src/2d6-dungeon-web-client/Components/Shared/ArmourPieces.razor` — List component
- `src/2d6-dungeon-web-client/Components/Shared/MagicScrolls.razor` — List component
- `src/2d6-dungeon-web-client/Components/Shared/MagicPotions.razor` — List component
- `src/2d6-dungeon-web-client/Components/Shared/Manoeuvre.razor` — Individual item component

**What Was Missing (Now Added):**
1. **Discipline** — Core stat that was in model but not displayed
2. **Status Effects** — Bloodied (int), Fever (bool), Soaked (int), Pneumonia (bool)
3. **Resources** — Rations count (was in model, not UI)
4. **Currency** — Full coin breakdown (Gold, Silver, Copper from Coins object)
5. **Quest Progress** — Legend Status Level Tracker, Liberated Prisoners, Treasures list, Side Quests list
6. **Favor of the Gods** — All six deities: Grakada, Intuneric, Maduva, Murataynie, Nevazator, Radacina
7. **Weapon Display** — Explicit weapon name section (was commented out)

**UI Pattern:**
- Grouped related fields into FluentCard components for better organization
- Used consistent `sheetTitle` class for labels
- Maintained horizontal wrapping layout for space efficiency
- Collections (Treasures, Side Quests) render as lists only when non-empty
- Weapon section conditionally renders when weapon exists

**Still Unknown (Requires Rulebook Pages 38-41):**
- Exact field labels/terminology from official rulebook
- Any additional fields not in the domain model yet
- Preferred grouping/organization per official character sheet
- Whether any fields should be editable vs. read-only

**Build Status:** ✅ Compiles successfully (verified with `dotnet build`)

