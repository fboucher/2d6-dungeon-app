
-- 2d6 Tables
INSERT INTO db2d6.meta_table(code, name)
VALUES('l1p', 'Level 1 Patrols');
INSERT INTO db2d6.meta_table(code, name)
VALUES('bst1', 'Body Search 1');
INSERT INTO db2d6.meta_table(code, name)
VALUES('sct1', 'Scrolls T1');
INSERT INTO db2d6.meta_table(code, name)
VALUES('got1', 'God T1');
INSERT INTO db2d6.meta_table(code, name)
VALUES('bt1', 'Loot Bag T1');
INSERT INTO db2d6.meta_table(code, name)
VALUES('ct1', 'Chest T1');
INSERT INTO db2d6.meta_table(code, name)
VALUES('pt1', 'Pouch T1');
INSERT INTO db2d6.meta_table(code, name)
VALUES('enp1', 'Encounter Prisoner T1');



-- Starting Amour
INSERT INTO db2d6.armour_pieces(name, dice_set, modifier)
VALUES('Jerkin', 4, '-1 Damage');
INSERT INTO db2d6.armour_pieces(name, dice_set, modifier)
VALUES('Padded Tunic', 5, '-1 Damage');
INSERT INTO db2d6.armour_pieces(name, dice_set, modifier)
VALUES('Quilted Coat', 3, '-1 Damage');
INSERT INTO db2d6.armour_pieces(name, dice_set, modifier)
VALUES('Hide doublet', 2, '-1 Damage');

-- Starting Scroll
INSERT INTO db2d6.magic_scrolls(scroll_type, description, modifier)
VALUES('Balance', 'Increses discipline and magical focus for a time', '+1 Discipline for dungeon level');
INSERT INTO db2d6.magic_scrolls(scroll_type, description, modifier)
VALUES('Mental whip', 'A damaging psychic attack', '1 strike of 10 damage');
INSERT INTO db2d6.magic_scrolls(scroll_type, description, modifier)
VALUES('Reflexes', 'Increases combat ability for a time', '+1 Shift for 1 combat');
INSERT INTO db2d6.magic_scrolls(scroll_type, description, modifier)
VALUES('Melt metal', 'Destroys one lock or armour-related interrupt on an enemy', 'Destroy 1 lock or peace of armour');


-- Starting Potion
INSERT INTO db2d6.magic_potions(potion_type, modifier, duration, cost) 
    VALUES('HEALING', 'Heal up to 10 Health Points', 'INSTANT', '18gc');


-- rooms Level 1
-- small
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (2, 1, 'EMPTY SPACE', 'small', 'There is nothing in this small space.', 'Archways', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (3, 1, 'STRANGE TEXT', 'small', 'This narrow room connects the corridors and has no furniture. On the wall though is some illegible text.', 'Archways', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (4, 1, 'GRAKADA HOLY PLACE', 'small', 'There is a large mural of Grakada here. Her old face smiles at you. If you call for her favour here -2 to the roll. There is no space to make offerings.', 'Archways', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (5, 1, 'INTUNERIC ALTAR', 'small', 'There is a large mosaic of Intuneric here, a swirling black visage. If you call for his favour here -2 to the roll. There is no space to make offerings.', 'Archways', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (6, 1, 'MADUVA SANCTUARY', 'small', 'There is a rough statue of Maduva here. Its form is twisted sinew. If you call for its favour here -2 to the roll. There is no space to make offerings.', 'Archways', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (7, 1, 'MURATAYNIE FONT', 'small', 'There is a grisly effigy of Murataynie here. It smells of rotting flesh. If you call for its favour here -2 to the roll. There is no space to make offerings.', 'Archways', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (8, 1, 'NEVAZATOR SHRINE', 'small', 'There is a rope doll of Nevazator hanging here, limp and symbolic. If you call for his favour here -2 to the roll. There is no space to make offerings.', 'Archways', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (9, 1, 'RADACINA RELIQUARY', 'small', 'There is a beautiful tapestry of Radacina here, high out of reach. If you call for her favour here -2 to the roll. There is no space to make offerings.', 'Archways', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (10,	1, 'HEATED SPACE', 'small', 'There is a small burner here, that is lit. The space is warm, flickering shadows cast across the space. If you dry yourself roll on L1P. There is nothing else in the room.','Archways', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (11,	1, 'MUSHROOM FARM', 'small', 'In the wall is a small shrine at which you can make an offering, as it has a ledge to place items. It is dedicated to a god, roll on GOT1. Gain 1 FP if applied correctly.', 'Archways', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (12,	1, 'WALL BANNER', 'small', 'On the wall are two crossed spears and a shield. You take a closer look and see they are for display only and useless. There are some cord and metal strips though.', 'Archways', false);


-- regular
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(11, 1, 'EMPTY SPACE', 'regular', 'This room is bare and seems to have been cleared out or forgotten about.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(12, 1, 'ABANDONED GUARD POST', 'regular', 'There is a dusty table here upon which sits a dry tankard and an empty wooden bowl.', 'WOODEN DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(13, 1, 'GUARD POST', 'regular', 'A small burner provides warmth for two chairs around a low table. It is lit and casts shadows.', 'REINFORCED DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(14, 1, 'MASON''S WORKSHOP', 'regular', 'Large blocks of stone scatter the space, iron tools and an old hammer lay around.', 'RANDOM', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(15, 1, 'STORAGE AREA', 'regular', 'Crates are piled high, creating hidden spaces. Sacks and baskets lean to one side.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(16, 1, 'MEETING ROOM', 'regular', 'Three simple chairs are tucked in around a makeshift wooden table.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(21, 1, 'BLACKSMITHS', 'regular', 'There is an anvil on a block, a glowing furnace and walls lined with worn tools.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(22, 1, 'SCUFFED UP SPACE', 'regular', 'There is a pile of rubbish here and the floor is covered in scuff marks.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(23, 1, 'HOLDING CELL', 'regular', 'An iron barred cell where prisoners are kept is in one comer a broken chain on the floor.', 'REINFORCED DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(24, 1, 'WASH ROOM', 'regular', 'There are basins set in worktops here and buckets of soapy water. It is damp here.', 'RANDOM', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(25, 1, 'FIRE PIT ROOM', 'regular', 'A large fire pit in the centre of the room is full of glowing embers and ash.', 'RANDOM', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(26, 1, 'KENNEL', 'regular', 'Kennels line one wall and the floor is littered with bones water bowls and straw.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(31, 1, 'SNAKE PIT', 'regular', 'A dusty bowl set into the floor is home to an angry rooking snake. It rises up towards you.', 'RANDOM', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(32, 1, 'WEAPON DUMP', 'regular', 'Some crates and barrels hold a range of broken and busted weapons.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(33, 1, 'SHACKLE ROOM', 'regular', 'Shackles and chains hang from the stone walls and a cage stands in one corner.', 'REINFORCED DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(34, 1, 'PRAYER ROOM', 'regular', 'To one side is a wall mounted symbol above a small altar and cushion.', 'CURTAINS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(35, 1, 'EMPTY SPACE', 'regular', 'This room has been left empty, the floor swept clean and the walls washed.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(36, 1, 'INDOOR CAMP', 'regular', 'In a corner two chairs are placed at a burner. The room is warm. On a shelf is a ball of twine.', 'WOODEN DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(41, 1, 'SMALL SHRINE', 'regular', 'This room is bare apart from a small stone shrine set into the wall.', 'RANDOM', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(42, 1, 'ABANDONED GUARD POST', 'regular', 'There is a dusty table here upon which sits a dry pewter tankard and an empty bowl.', 'WOODEN DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(43, 1, 'POOL ROOM', 'regular', 'The only feature in this room is a large, tiled bathing pool set into the floor.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(44, 1, 'BARRACKS', 'regular', 'You see two rows of bunks and some hammocks. There are people here talking.', 'WOODEN DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(45, 1, 'STORAGE AREA', 'regular', 'Empty boxes and tea chests fill this space. There are also sacks and bags.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(46, 1, 'CANTEEN', 'regular', 'Three rough tables, a few chairs and stools stand next to a wooden bar.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(51, 1, 'MORGUE', 'regular', 'A stone chamber has been added here. The floor is bloody. Inside lays a corpse on a slab.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(52, 1, 'SLEEPING QUARTERS', 'regular', 'Behind two curtains one on each side, are neat wooden framed beds.', 'RANDOM', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(53, 1, 'HOLDING CELL', 'regular', 'Part of this room has been sectioned off with wooden bars to create a cell.', 'REINFORCED DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(54, 1, 'TRAINING ROOM', 'regular', 'There is a bashed up mannequin and a pole covered in cut marks here.', 'RANDOM', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(55, 1, 'ABATTOIR', 'regular', 'Two large carcasses of unidentifiable animals hang from the ceiling to one side.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(56, 1, 'DUMP', 'regular', 'This space has been used to dump rubbish and stone, piles of which fill two corners.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(61, 1, 'APOTHECARY', 'regular', 'A table is covered in jars and bottles. Scrolls full of script are tacked to the walls.', 'RANDOM', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(62, 1, 'DAMP SPACE', 'regular', 'There is a leak dripping down from above so the space is abandoned and wet.', 'WOODEN DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(63, 1, 'JAIL', 'regular', 'There are some metal bars set into the stone floor forming two dirty prison cells.', 'REINFORCED DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(64, 1, 'CHAPEL', 'regular', 'Set high on some shelves are burning candles above a large wooden statue.', 'CURTAINS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(65, 1, 'EMPTY SPACE', 'regular', 'This cold stone space is bare and seems to have no function.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES(66, 1, 'STOVE ROOM', 'regular', 'To one side is a hot stove, some chairs and a large, muddy, hemp rug and a clay tankard.', 'WOODEN DOORS', false);


-- large
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (2, 1, 'STONE WORKSHOP', 'large', 'This large space has rough walls and piles of stone laying everywhere. There are the remains of a large stone statue that has been smashed. There is no one here.', 'WOODEN DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (3, 1, 'MARBLE HALL', 'large', 'There are evenly spaced pillars running along this large marble lined hall, with a round central burner and a metal grill. If you have some wood, you could start a fire.', 'ARCHWAYS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (4, 1, 'OLD MESS HALL', 'large', 'This room was once a mess hall. Some benches and tables are pushed to one side. Other chairs are stacked around the edges of the room. Roll on IAUT1.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (5, 1, 'PENITENTIARY', 'large', 'The northeast corner is being used to hold captives. There are whips and knives on table. The floor is covered in bloodied straw. Fight a JAILOR and then roll on ENP1.', 'REINFORCED DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (6, 1, 'FOUNTAIN ROOM', 'large', 'In the centre is an ornate fountain bubbling with clear water. It is dedicated to a god and carved in their form. Roll on GOT1. You can make an offering for 1 FP.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (7, 1, 'TEMPLE', 'large', 'Dark murals line the walls. Empty pews form two lines, chandeliers loaded with lit candles hang above. Behind a pulpit stands a figure who attacks. Roll on L1R -1.', 'ARCHWAYS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (8, 1, 'SPARRING CHAMBER', 'large', 'This is a training room, where there is a circle of sand in which a WARRIOR and a SCOUT are sparring. They turn and attack. If you survive roll on BT1 +2.', 'WOODEN DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (9, 1, 'CRATE STORE', 'large', 'This space is used for storage and crates scatter the space, creating hidden spaces. There is a noise so roll on L1CE, then on MIT2, CT1 -2 and BT2 -1.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (10,	1, 'SLATE SHRINE', 'large', 'A large slate monolith stands in the centre. Hanging from it is a gold amulet worth 2D6 GC and it has 4 slots. If you have 4 gems you may roll on GCT1.', 'ARCHWAYS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (11,	1, 'DORMITORY', 'large', 'Lining the walls are bunks and you count enough for twelve men, but most are empty. But, two are occupied. Roll on L1W -1 and L1WO -1. They attack. After, roll on CT2.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (12,	1, 'LIBRARY', 'large', 'Lined with bookshelves, this huge library is protected by two GUARDS. There are also tables covered in scrolls. If you survive roll on SCT1 and SCT2.', 'WOODEN DOORS', true);



-- weapons
INSERT INTO db2d6.weapons(id, name) VALUES(1, 'LONGSWORD');
INSERT INTO db2d6.weapons(id, name) VALUES(2, 'GREATAXE');
INSERT INTO db2d6.weapons(id, name) VALUES(3, 'HEAVY MACE');


-- weapon_manoeuvres
INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 1, '1-2', 'DISGUISED SWOOP', '6D +2');
INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 1, '5-2', 'INCISIVE CUT', '6D +1');
INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 1, '3-2', 'THRUST', '6D');

INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 2, '1-2', 'WEIGHTED CHARGE', '6D +3');
INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 2, '5-2', 'LOW SWISH', '6D +1');
INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 2, '3-2', 'HACK', '6D');

INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 3, '1-2', 'SOLID BELTING', '6D +2');
INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 3, '5-2', 'POMMEL THUMP', '6D +1');
INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 3, '3-2', 'CARVING HIT', '6D +1');


-- creatures
INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('THUG', 1, 'Humanoid', 3, 6, 1, 'None', 'Forearm block on Secondary|4s|-1 damage', '', '3-2|PUNCH|D6 -3 damage', '', 'This rough looking brute has few skill...', 'The thud tries a combo of swing... Gain 1 extra attack', 'The thud manages to grip you.... take D3 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('GUARD', 1, 'Humanoid', 7, 13, 1, 'Roll on PT1 -1', 'Shield BLock on Secondary|3s|-1 damage', 'Shield BLock on Secondary|5s|-1 damage', '5-3|STAB|D6 -3 damage', '6-2|SWIPE|D6 -2 damage', 'A trainer guard wearing light armour who has some basic skills in combat. They have duties within the dungeon and can be seen on patrols and at guard posts.', 'The guard lunges carelessly opens his side and you elbow them hard causing 1 damage.', 'With an unexpected move the guard disarms you. Lose 1 turn as you grab it back off the ground.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('ARTISAN', 1, 'Humanoid', 3, 5, 1, 'Roll on PT1 -2|+ 2D6 SC', 'Deflect on Secondary|1s|-2 damage', 'Distract on Secondary|6s|-1 damage', '5-4|JAB|D6 -3 damage', '', 'A skilled worker who has spent many years learning their art. They are not fither but are well coordinated and wear sturdy leather work clothes. They will defend their home.', 'They grab up a lenght of wood, but it is brittle and crumbles in their hand. Gain an extra attack.', 'The artisant pulls a handful of nails from a pocket and throws them in your face. Take 2 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('JAILOR', 1, 'Humanoid', 6, 10, 1, 'Roll on PT1 +1', 'Barge on Secondary|2s|-2 damage', '', '5-1|SHARP KICK|D6 -2 damage', '3-3|PUNCH|D6 - 3 damage', 'Being a jailor has made them tough but their skill in combat is limited/ As they come forward wrapping a chain around their knuckles, a mad look in theur eyes.', 'The jailor swigs but appears tired and falls back on their haunches giving you an extra attack.', 'With a whip of their fist the chain shoots out and lashes your knucles. Lose 1 HP if not wearing gloves.');
