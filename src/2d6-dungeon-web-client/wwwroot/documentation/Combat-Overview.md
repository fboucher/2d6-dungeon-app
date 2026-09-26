# Entering Combat & Selecting Your Foe ⚔️

Waging battles, managing tactical maneuvers, and tracking fatigue in classic dungeon crawlers can involve a mountain of tedious arithmetic. The **2D6 Dungeon App** digital companion automates all the health tracking, shift calculations, fatigue scaling, and maneuver matching so you can focus on outsmarting and defeating the terrifying creatures lurking in the dark!

---

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

Once your foe is selected, continue to [Combat Initiative](Combat-Initiative) to determine who attacks first.
