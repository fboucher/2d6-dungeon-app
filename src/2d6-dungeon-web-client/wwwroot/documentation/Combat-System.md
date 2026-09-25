# Combat System ⚔️🎲

Waging battles, managing tactical maneuvers, and tracking fatigue in classic dungeon crawlers can involve a mountain of tedious arithmetic. The **2D6 Dungeon App** digital companion automates all the health tracking, shift calculations, fatigue scaling, and maneuver matching so you can focus on outsmarting and defeating the terrifying creatures lurking in the dark!

This guide covers how to select your foe, log combat initiative, roll and shift dice, resolve weapon maneuvers, roll damage, and manage health.

---

## 🖥️ Entering Combat & Selecting Your Foe

When your adventurer encounters a creature in a newly discovered room:
1. Navigate to the **Combat** tab in the main interface.
2. If no battle is active, you will see a prompt: **"Select the creature mentioned in the room description."**
3. Use the **`CreaturePicker`** component to select the foe your adventurer is facing. 
4. Once selected, the screen populates with the creature's full statistics card (**`CreatureCard`**):
   - **Name, Level, and Type:** e.g., Level 2 Undead (U).
   - **Health Points (HP):** The creature's current health.
   - **Experience (XP) & Shift Points (SH):** Rewards and tactical attributes.
   - **Description & Loot:** Details of the beast and potential rewards.
   - **Interrupts:** Unique defensive/offensive triggers (e.g., `interrupt1` and `interrupt2`).
   - **Maneuvers:** The combat maneuvers available to the creature.
   - **Prime Attack & Mishap Rolls:** The specific ranges that trigger devastating prime or mishap outcomes.

---

## ⚔️ Combat Initiative (Who Attacks First?)

Immediately after selecting your foe, the **Combat Initiative** dialog (**`SelectFirstFighterDialog`**) will overlay on your screen:
1. Determine who strikes first.
2. Select either **Adventurer** or **Creature** based on your initiative roll or situational rules.
3. Once selected:
   - The battle begins on **Turn 1**.
   - The selected fighter is designated as the active attacker and highlighted with a glowing border and shadow (`box-shadow:0 0 8px var(--accent-fill-rest);`) and a prominent **`Current turn`** badge.
   - The Combat Journal logs the event: *"[Fighter Name] attacks first"*.

---

## 🎲 Running Combat Turns & Logging Actions

Combat proceeds in active turns. The active turn is displayed in the main header: **"Turn [TurnNumber] - [Active Fighter]"**.

During a turn, the attacking fighter executes their attack sequence:
1. **Click `Roll` (`Roll2Dice`):** This rolls the two standard 2D6 combat dice:
   - **Red Primary Dice:** Represents the tens/primary value.
   - **Purple Secondary Dice:** Represents the units/secondary value.
2. **Review Roll Outcomes:**
   - Rolling doubles triggers a visual dice celebration (the dice bounce and glow)!
   - The results are instantly outputted to the **Combat Journal** (e.g., *"Rolled 4 and 2"*).
3. **Shift Adjustment / Shifting the Dice:**
   - If the rolled numbers do not match your trained weapon maneuvers, you can use your adventurer's **Shift points** to nudge the dice up or down.
   - Use the **Shift Left** and **Shift Right** (`ShiftButtons`) next to each die to increment or decrement the active values.
   - The interface tracks your remaining shift pool dynamically. Each point used reduces the **Shift Left** counter.
   - If you make a mistake, click the **`Reset`** button to return the dice to their original rolled values.
4. **Select a Maneuver:**
   - Compare the final adjusted primary and secondary dice results to the active fighter's list of maneuvers to see what attack hits.
5. **Roll Damage:**
   - On a successful hit, click **`Roll 1D6`** or **`Roll 2D6`** in the Damage panel to determine damage.
   - The system rolls the damage dice and displays them visually.
6. **Apply Damage & Update HP:**
   - Manually deduct the damage from the defender's HP in their card.
7. **Click `End Turn` (`NextTurn`):**
   - Click the prominent **`End Turn`** button to pass the action to the defender.
   - The active fighter toggles.
   - When the action returns to the first fighter, the turn counter increments and fatigue is recalculated.

---

## 📈 Combat Fatigue & Shift Adjustment

As battles drag on, fatigue sets in, making maneuvers more frantic and giving both combatants more room to adapt. This is represented by the **Fatigue and Shift** system:

* **Fatigue Dice:** A virtual white D6 dice tracks fatigue, starting at 1. Every complete turn cycle increments the fatigue value.
* **Shift Bonus:**
  - **Turn 4:** Fatigue reaches 4, triggering a **+1 Shift** adjustment.
  - **Turn 5:** Fatigue reaches 5, triggering a **+2 Shift** adjustment.
  - **Turn 6+:** Fatigue reaches 6, triggering a **+3 Shift** adjustment (which remains active until combat ends).
* **Shared Benefit:** This fatigue shift modifier applies to **both** the adventurer and the creature, allowing both fighters to shift their dice more drastically in late-combat rounds! The adjusted shift is automatically computed and displayed in your card.

---

## 🩹 Managing Health and Combat Resolution

The combat screen displays real-time, interactive status cards for both combatants:

### Adventurer Card
- Tracks your **XP, Level, current HP**, and base attributes (**Shift, Discipline, Precision**).
- Displays active **Weapon and trained Manoeuvres**.
- Tracks **Armour Pieces, Magic Scrolls**, and **Magic Potions**.
- Tracks negative status effects like **Bloodied** ("FEVER -1 HP per room") and **Soaked** ("PNEUMONIA -1 HP per room") via FluentSliders.
- **Defeat State:** If the adventurer's HP is edited to `0` or lower, the companion triggers the **Defeat/Game Over** error dialog, logging: `💀 [Adventurer Name] has fallen in battle!` to the Combat Journal.

### Creature Card
- Displays the selected monster's stats, level, description, and available moves.
- **Victory State:** If the creature's HP is reduced to `0` or lower, the companion displays a **Victory!** dialog: *"Victory! You've defeated the [Creature Name]! It's time to check for loot and XP rewards."*

### Starting a New Fight
Once a battle is resolved (or if you need to escape or reset):
* Click the **`Start a new fight`** button.
* This resets the entire combat state, clears the creature, resets the Turn Counter to 0, resets fatigue shifts to base levels, clears health depletion flags, and wipes the **Combat Journal** clean with the message: *"Combat reset - ready for a new fight"*.
