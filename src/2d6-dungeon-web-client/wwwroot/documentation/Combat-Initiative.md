# Combat Initiative 🎯

Immediately after selecting your foe, the **Combat Initiative** dialog (**`SelectFirstFighterDialog`**) will overlay on your screen.

---

1. Determine who strikes first.
2. Select either **Adventurer** or **Creature** based on your initiative roll or situational rules.
3. Once selected:
   - The battle begins on **Turn 1**.
   - The selected fighter is designated as the active attacker and highlighted with a glowing border and shadow (`box-shadow:0 0 8px var(--accent-fill-rest);`) and a prominent **`Current turn`** badge.
   - The Combat Journal logs the event: *"[Fighter Name] attacks first"*.

---

With initiative set, continue to [Running Combat Turns](Combat-Turns).
