# Managing Health & Resolution 🩹

The combat screen displays real-time, interactive status cards for both combatants.

---

## Adventurer Card
- Tracks your **XP, Level, current HP**, and base attributes (**Shift, Discipline, Precision**).
- Displays active **Weapon and trained Manoeuvres**.
- Tracks **Armour Pieces, Magic Scrolls**, and **Magic Potions**.
- Tracks negative status effects like **Bloodied** ("FEVER -1 HP per room") and **Soaked** ("PNEUMONIA -1 HP per room") via FluentSliders.
- **Defeat State:** If the adventurer's HP is edited to `0` or lower, the companion triggers the **Defeat/Game Over** error dialog, logging: `💀 [Adventurer Name] has fallen in battle!` to the Combat Journal.

## Creature Card
- Displays the selected monster's stats, level, description, and available moves.
- **Victory State:** If the creature's HP is reduced to `0` or lower, the companion displays a **Victory!** dialog: *"Victory! You've defeated the [Creature Name]! It's time to check for loot and XP rewards."*

## Starting a New Fight
Once a battle is resolved (or if you need to escape or reset):
* Click the **`Start a new fight`** button.
* This resets the entire combat state, clears the creature, resets the Turn Counter to 0, resets fatigue shifts to base levels, clears health depletion flags, and wipes the **Combat Journal** clean with the message: *"Combat reset - ready for a new fight"*.
