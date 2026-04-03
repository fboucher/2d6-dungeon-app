# Squad Decisions

## Active Decisions

### 2026-04-03: Character Sheet UI Organization (Issue #173)

**Status:** Approved  
**Author:** Lambert (Frontend Dev)  
**Date:** 2026-04-03

#### Decision
Reorganized the AdventurerCard.razor expanded view to display all domain model fields grouped into logical sections using FluentCard components.

#### Rationale
The character sheet was missing ~20 fields from the Adventurer domain model:
- Status effects (Bloodied, Fever, Soaked, Pneumonia)
- Resources (Rations, coins)
- Quest tracking (Treasures, Side Quests, Legend Status, Liberated Prisoners)
- Favor of the Gods (6 deity values)
- Core stat (Discipline)

Organized fields into thematic cards:
1. **Core Stats** — HP, Shift, Precision, Discipline
2. **Status Effects** — All condition tracking
3. **Resources** — Rations, Applied Runes
4. **Currency** — Gold/Silver/Copper breakdown
5. **Quest Progress** — Tracking items with conditional list rendering
6. **Favor of the Gods** — All six deities
7. **Combat** — Weapon, Manoeuvres, Armour, Magic items (each in own card)

#### Trade-offs
- **More vertical space:** Character sheet is now longer when expanded, but organized
- **No editability yet:** Most new fields are read-only (matching existing pattern for Shift, Precision)
- **Assumption-based labels:** Used descriptive names since rulebook pages 38-41 not available

#### Open Questions
1. Do field labels match official rulebook terminology?
2. Should any new fields be editable in the UI?
3. Is the grouping/order aligned with physical character sheet?
4. Are there additional fields in the rulebook not yet in the domain model?

#### Next Steps
- Get rulebook pages 38-41 to validate labels and organization
- Add edit capabilities if needed (e.g., FluentNumberField for Rations, Coins)
- Consider adding icons/visual indicators for status effects
- May need service/API calls to update new editable fields

---

## Governance

- All meaningful changes require team consensus
- Document architectural decisions here
- Keep history focused on work, decisions focused on direction
