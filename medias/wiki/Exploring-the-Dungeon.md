# Exploring the Dungeon 🧭🗺️

One of the most tedious parts of classic solo dungeon crawling is drawing the map, tracking coordinates, and cross-referencing tables for room generation. The **2D6 Dungeon App** companion completely automates this bookkeeping! 

This guide covers how to master the **Dungeon Map** interface, navigate your adventurer, generate new rooms, place doorways, and track your pathways through the dark.

---

## 🖥️ The Dungeon Map Interface

The **Dungeon Map** tab is your central exploration dashboard. It is split into a dynamic map viewer canvas on the left, and a contextual control panel on the right.

### Core Components of the Screen:
1. **Current Room Details Accordion:** Displays your active room's description (e.g., "An ancient library covered in cobwebs") and any active encounter information. It also provides immediate, step-by-step game turn instructions.
2. **Action Bar:** Prominent buttons to **Roll Dice** and **Pick a Door** to explore further.
3. **Interactive Grid Canvas (`#dotCanvas`):** A custom-drawn 2D grid viewer that renders your dungeon's layout, rooms, exits, and active position in real-time.
4. **Visual Dice Roller:** Animates and displays the results of your active dice rolls (Red primary dice and Purple secondary dice) using retro-styled 3D assets.

---

## 🧭 Map Viewer Interactions & Navigation

As your dungeon grows, it will expand far beyond your screen's default boundaries. The companion app includes advanced viewport controls to keep your adventurer in view:

### Viewport Navigation Controls (Sidebar):
* **Pan Map View (Arrow Buttons):** Click the arrow buttons in the sidebar to pan the map left, right, up, or down.
* **Physical Keyboard Navigation:** You can also use your keyboard's physical **Arrow Keys** (←, ↑, →, ↓) to pan around the map dynamically. It is recommended to move approximately 2 grid squares at a time.
* **Center on Current Room (`Center` Button):** Instantly refocuses and centers the camera on the exact middle of the room your adventurer currently occupies.
* **Reset View (`Reset` Button):** Snaps the viewport back to the origin coordinates.

---

## 🚪 Moving and Exploring: Picking a Door

When you are ready to leave your current room, your journey begins with the **Pick a Door** action:

1. Click **`Pick a Door`** in your exploration action bar.
2. The **Select Door** dialog will open, reading the available exits for the current room:
   * The dialog displays available exits as buttons arranged in a compass layout (**Door to the North**, **Door to the West**, **Door to the East**, and **Door to the South**).
   * **Locked Doors:** If a door is locked based on your dungeon state, it will render with a locked icon (calendar-lock style) instead of a standard open doorway icon.
3. **Navigating to an Existing Room:** If you choose an exit that leads to a room you have already explored, the app automatically transitions your adventurer there, updates your coordinates, sets "You Are Here" on the canvas, and displays: *"You already visited that room, Pick another door!"*.
4. **Exploring Uncharted Territory:** If you select an unexplored exit, the app automatically initiates the **New Room Generation Wizard**.

---

## 🎲 The New Room Generation Wizard

The New Room Wizard (**"Let's see what room you are getting in!"**) walks you step-by-step through Toby Lancaster's official room generation rules:

### Step 1: Dimensions (Determine Room Size)
* Click **`Roll 2D6`** to roll for dimensions.
* **Special Rules:**
  * **Double Sized Rooms:** Rolling doubles can trigger a massive double-sized room generation.
  * **Corridors:** If your roll generates a corridor, the wizard automatically identifies it, pre-fills the description as *"You found a corridor"*, sets the corridor flags, and automatically **disables and skips** the Room Description step!
  * **Doubles Celebration:** Rolling any double on your room dimensions triggers a custom Blazor dice celebration, making the dice bounce and glow!

### Step 2: Exits (Determine Room Doors)
* Click **`Roll 1D6`** to roll for exits.
* This determines how many exits (doors) are in the new room, excluding the entrance door you just came through.

### Step 3: Description (Determine Room Contents)
* Click **`Roll 2 Dice`** (2D6) to determine what is inside the room (e.g., shrines, storage crates, tombs, or fountains).
* *Note: This step is skipped automatically if the room is a Corridor.*
* Just like Step 1, rolling doubles here triggers a visual celebration on your active dice!

### Step 4: Summary
* Displays a neat final summary of your generated room (e.g., dimensions, exit counts, and room description) before you finalize.
* Click **`Finish`** to close the wizard and render the room.

---

## 📐 Positioning & Customizing the New Room

Once the room is generated, the app calculates its initial alignment based on the door you used to enter. However, you have complete freedom to reposition or adjust the room before permanently pinning it to your map:

### 1. Position New Room Controls
Before finalizing, you can adjust the room's exact placement on the grid. Use the arrow buttons under **"Position New Room"** in your sidebar to shift the room left, right, up, or down in 1-square increments.

### 2. Manual Customization: Edit Room
If a room's doors do not line up with your physical table-rolling preferences, click **`Edit Room`**:
* This opens the **Edit Room Dialog**, letting you manually **Move a Door**.
* Select the door you want to move (North, West, East, or South).
* A responsive **FluentSlider** will appear. The slider automatically adjusts its orientation to match the wall (Horizontal for North/South walls, Vertical for East/West walls).
* Slide the door along the wall to change its grid position. The slider's boundaries are dynamically restricted to the room's exact width or height.
* Click **Save** to commit your door adjustment.

### 3. Finalize: Add Room to Map
* When you are satisfied with the room's placement and door alignments, the **`Add Room to Map`** button will highlight with a glowing border and shadow.
* Click **`Add Room to Map`** to permanently save the room to your database.
* The adventurer is moved into the new room, and the game automatically prompts you to proceed with the next step of exploration or combat!

---

## 💾 Saving Your Progress

Dungeon exploration is fully persistent:
* Clicking **`Add Room to Map`** automatically executes an background save of your active adventure state.
* You can also manually save your campaign at any point during your session by clicking the **Save Icon** (💾) in the top-left action header of the page.
* This stores your entire explored map grid, adventurer statistics, inventory, and notes safely in your local MySQL database, letting you pick up your quest anytime!
