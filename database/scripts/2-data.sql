
-- 2d6 Tables
INSERT INTO db2d6.meta_table(code, name, level)
VALUES
('art1', 'Armour Random Table 1', 1),
('bst1', 'Body Search Table 1', 1),
('bt1', 'Loot Bag Table 1', 1),
('ct1', 'Chest Table 1', 1),
('ect1', 'Empty Container Table 1', 1),
('enp1', 'Encounter Prisoner Table 1', 1),
('enp2', 'Encounter Prisoner Table 2', 2),
('ext1', 'Exit Type Table 1', 1),
('ext2', 'Exit Type Table 2', 2),
('gmt1', 'Gem Table 1', 1),
('got1', 'God Table 1', 1),
('haoit1', 'Half An Ornate Item Table 1', 1),
('hst1', 'Herbs Table 1', 1),
('iaut1', 'Interruptions and Unexpected Table 1', 1),
('l1a', 'Level 1 Animals', 1),
('l1ce', 'Level 1 Crate Encounters', 1),
('l1d', 'Level 1 Dogs', 1),
('l1f', 'Level 1 Fungal', 1),
('l1g', 'Level 1 Guards', 1),
('l1m', 'Level 1 Martial', 1),
('l1p', 'Level 1 Patrols', 1),
('l1r', 'Level 1 Religious Enemy', 1),
('l1s', 'Level 1 Snakes', 1),
('l1w', 'Level 1 Wardens', 1),
('l1wo', 'Level 1 Workers', 1),
('ma1', 'Magical Amulet Table 1', 1),
('mi1', 'Magical Item Table 1', 1),
('mit1', 'Metal Item Table 1', 1),
('mr1', 'Magical Ring Table 1', 1),
('mw1', 'Magical Wand Table 1', 1),
('pot1', 'Potions Table 1', 1),
('pt1', 'Pouch T1', 1),
('ratt1', 'Religious Artifacts Treasure Table 1', 1),
('rpt1', 'Religious Pouch Table 1', 1),
('rupt1', 'Rubbish Pile Table 1', 1),
('rune1', 'Rune Stone Table 1', 1),
('sct1', 'Scrolls T1', 1),
('sect1', 'Secret Hatch Table 1', 1),
('slt1', 'Sarcophagus Loot Table 1', 1),
('sst1', 'Symbol Selection Table 1', 1),
('tat1', 'Table Table 1', 1),
('tct1', 'Tea Chest Table 1', 1),
('url1', 'Urn Loot Table 1', 1),
('wit1', 'Worship Items Table 1', 1),
('wrt1', 'Wrecked Item Table 1', 1);



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


-- regular (aka ancestry)
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(11, 1, 'EMPTY SPACE', 'regular', 'This room is bare and seems to have been cleared out or forgotten about.', 'The room is quiet. You hear nothing.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(12, 1, 'ABANDONED GUARD POST', 'regular', 'There is a dusty table here upon which sits a dry tankard and an empty wooden bowl.', 'Beneath the table is a pile of rubbish. Roll on table RUP1 +1.', 'WOODEN DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(13, 1, 'GUARD POST', 'regular', 'A small burner provides warmth for two chairs around a low table. It is lit and casts shadows.', 'There is someone here. Roll on L1G. If you survive roll on table RUP1.', 'REINFORCED DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(14, 1, 'MASON''S WORKSHOP', 'regular', 'Large blocks of stone scatter the space, iron tools and an old hammer lay around.', 'Roll a D6. 1-4= An ARTISAN is here. You must fight them. If you survive roll on TCT1.', 'RANDOM', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(15, 1, 'STORAGE AREA', 'regular', 'Crates are piled high, creating hidden spaces. Sacks and baskets lean to one side.', 'Roll a D6. 1-3= A random patrol comes by roll on L1G -1. If you survive roll on TCT1 -1.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(16, 1, 'MEETING ROOM', 'regular', 'Three simple chairs are tucked in around a makeshift wooden table.', 'Two people stand as you enter. Roll on L1M -1 and L1F -1. If you survive roll on CT1.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(21, 1, 'BLACKSMITHS', 'regular', 'There is an anvil on a block, a glowing furnace and walls lined with worn tools.', 'There is someone here. You must fight the BLACKSMITH. If you survive roll on MIT1.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(22, 1, 'SCUFFED UP SPACE', 'regular', 'There is a pile of rubbish here and the floor is covered in scuff marks.', 'You can check the rubbish pile. Roll on table RUP1 and then on IAUT1.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(23, 1, 'HOLDING CELL', 'regular', 'An iron barred cell where prisoners are kept is in one comer a broken chain on the floor.', 'Roll a D6. 1-4= the JAILOR is here. You must fight them. If you survive roll on ENP1.', 'REINFORCED DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(24, 1, 'WASH ROOM', 'regular', 'There are basins set in worktops here and buckets of soapy water. It is damp here.', 'Roll a D6. 1-3= A fungal creature emerges. Roll on L1F. If you survive roll on IAT1.', 'RANDOM', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(25, 1, 'FIRE PIT ROOM', 'regular', 'A large fire pit in the centre of the room is full of glowing embers and ash.', 'There''s a MERCHANT sitting on a stool by the pit. They stand and attack. If you survive roll on CT1.', 'RANDOM', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(26, 1, 'KENNEL', 'regular', 'Kennels line one wall and the floor is littered with bones water bowls and straw.', 'A GUARD handler stands and releases a dog. Roll on L1D and then face the GUARD after.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(31, 1, 'SNAKE PIT', 'regular', 'A dusty bowl set into the floor is home to an angry rooking snake. It rises up towards you.', 'To open the chest in the pit you must face a snake roll on L1S. If you survive roll on CT2 -2.', 'RANDOM', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(32, 1, 'WEAPON DUMP', 'regular', 'Some crates and barrels hold a range of broken and busted weapons.', 'You begin to search the space. First roll on IAUT1 and then on MIT2.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(33, 1, 'SHACKLE ROOM', 'regular', 'Shackles and chains hang from the stone walls and a cage stands in one corner.', 'A form moves from the darkness. Roll on table L1WO. If you survive roll on ENP1.', 'REINFORCED DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(34, 1, 'PRAYER ROOM', 'regular', 'To one side is a wall mounted symbol above a small altar and cushion.', 'Roll a D6. 1-4= Roll on L1R. After you search the room and if you survive roll on RATT1.', 'CURTAINS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(35, 1, 'EMPTY SPACE', 'regular', 'This room has been left empty, the floor swept clean and the walls washed.', 'The space is silent. There is nobody here.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(36, 1, 'INDOOR CAMP', 'regular', 'In a corner two chairs are placed at a burner. The room is warm. On a shelf is a ball of twine.', 'Someone is sitting by the burner. They attack. Roll on L1W -1. If you survive roll on IAUT1.', 'WOODEN DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(41, 1, 'SMALL SHRINE', 'regular', 'This room is bare apart from a small stone shrine set into the wall.', 'Roll on GOT1 to identify the shrine''s god. When offerings are correctly applied gain 1 FP.', 'RANDOM', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(42, 1, 'ABANDONED GUARD POST', 'regular', 'There is a dusty table here upon which sits a dry pewter tankard and an empty bowl.', 'There is something on the rough table. Roll on table TAT1.', 'WOODEN DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(43, 1, 'POOL ROOM', 'regular', 'The only feature in this room is a large, tiled bathing pool set into the floor.', 'In the pool is a chest. If you jump in for it you acquire the soaked status. Roll on CT1.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(44, 1, 'BARRACKS', 'regular', 'You see two rows of bunks and some hammocks. There are people here talking.', 'Roll on L1M-1 twice. If you survive the fight roll on TCT1 as you find a tea chest in a corner.', 'WOODEN DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(45, 1, 'STORAGE AREA', 'regular', 'Empty boxes and tea chests fill this space. There are also sacks and bags.', 'Roll a D6. 1-4= A random patrol comes by roll on L1P-1. If you survive roll on BT1.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(46, 1, 'CANTEEN', 'regular', 'Three rough tables, a few chairs and stools stand next to a wooden bar.', 'The barman yells and attacks (use LABOURER stats). Also face a patron. Roll on L1W -1.', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(51, 1, 'MORGUE', 'regular', 'A stone chamber has been added here. The floor is bloody. Inside lays a corpse on a slab.', 'There is an ARTISAN here who you must fight. If you survive you find some herbs. Roll on HST1', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(52, 1, 'SLEEPING QUARTERS', 'regular', 'Behind two curtains one on each side, are neat wooden framed beds.', 'Someone jumps up. Roll on L1R. You see a religious carving atop a cupboard. Roll on RATT1.', 'RANDOM', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(53, 1, 'HOLDING CELL', 'regular', 'Part of this room has been sectioned off with wooden bars to create a cell.', 'Roll D6. 1-4= There is a prisoner here. Roll on ENP1. After roll on IAUT1.', 'REINFORCED DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(54, 1, 'TRAINING ROOM', 'regular', 'There is a bashed up mannequin and a pole covered in cut marks here.', 'A WARRIOR is practicing here, slashing at the pole. You must fight them. After roll on IAUT1.', 'RANDOM', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(55, 1, 'ABATTOIR', 'regular', 'Two large carcasses of unidentifiable animals hang from the ceiling to one side.', 'A butcher works away at one, turns and attacks, cleaver raised (use ARTISAN stats).', 'WOODEN DOORS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(56, 1, 'DUMP', 'regular', 'This space has been used to dump rubbish and stone, piles of which fill two corners.', 'You can rummage through the rubbish. Roll on RUP1 and then on IAUT1.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(61, 1, 'APOTHECARY', 'regular', 'A table is covered in jars and bottles. Scrolls full of script are tacked to the walls.', 'You must face the APOTHECARY. If you survive search the table. Roll on POT1 and POT2.', 'RANDOM', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(62, 1, 'DAMP SPACE', 'regular', 'There is a leak dripping down from above so the space is abandoned and wet.', 'Fight a fungal creature living here. Roll a D6. 1-3= MUST BLOATER, 4-6= FUNGAL GEIST.', 'WOODEN DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(63, 1, 'JAIL', 'regular', 'There are some metal bars set into the stone floor forming two dirty prison cells.', 'A JAILOR jumps up. You must face them. If you survive roll on ENP1 -2.', 'REINFORCED DOORS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(64, 1, 'CHAPEL', 'regular', 'Set high on some shelves are burning candles above a large wooden statue.', 'A DARK CLERIC stands and attacks. After you can make an offering to Maduva for 1 FP.', 'CURTAINS', true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(65, 1, 'EMPTY SPACE', 'regular', 'This cold stone space is bare and seems to have no function.', 'There is nobody here or anything of interest.', 'ARCHWAYS', false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES(66, 1, 'STOVE ROOM', 'regular', 'To one side is a hot stove, some chairs and a large, muddy, hemp rug and a clay tankard.', '2 seated people jump up and attack. Roll on L1G-1 and L1M-1. After roll on TCT1-2.', 'WOODEN DOORS', false);


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
VALUES('APOTHECARY', 1, 'Humanoid', 12, 35, 1, 'Roll on POT1', 'Blinding Smoke on Primary|1s and 4s|-2 damage', 'Glowing Shield on Secondary|2s|-2 damage', '4-5|FIRE BOMB|D6 -2 damage', '1-5|GAS CLOUD|D6 -2 + special - you may not attack next turn', 'The apothecary wears breeches and a leather tunic which they open to reveal a collection of vials. Pulling one free they throw it at you as they attack.', 'They retrieve a larger bottle and throw it. Flames burst up around you. Lose D6 HP.', 'One of the vials smashes at your feet but nothing happens. You gain an extra attack.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('ARTISAN', 1, 'Humanoid', 3, 5, 1, 'Roll on PT1 -2|+ 2D6 SC', 'Deflect on Secondary|1s|-2 damage', 'Distract on Secondary|6s|-1 damage', '5-4|JAB|D6 -3 damage', '', 'A skilled worker who has spent many years learning their art. They are not fither but are well coordinated and wear sturdy leather work clothes. They will defend their home.', 'They grab up a lenght of wood, but it is brittle and crumbles in their hand. Gain an extra attack.', 'The artisant pulls a handful of nails from a pocket and throws them in your face. Take 2 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('BLACKSMITH', 1, 'Humanoid', 6, 9, 1, 'Roll on MIT1 and PT1', 'Crossed Arms on Secondary|3s and 6s|-2 damage', '', '4-3|HAMMER BLOW|D6 -1 damage', '', 'A hardy artisan, wearing a heavy leather apron, used to hammering metal so they are strong and resistant.', 'The blacksmith pulls out a large hook and throws it at you. It catches your arm. Lose D3 HP.', 'As the blacksmith attacks they catch their hammer in their apron. You kick out and cause D3 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('CRAZED PREACHER', 1, 'Humanoid', 4, 5, 1, 'Roll on RPT1', 'Bible Block on Primary|4s|-2 damage', '', '4-3|WILD SCRATCH|D6 -3 damage', '', 'Spreading their vile words in amongst the inhabitants of the dungeon, these crazed robed preachers are full of fury. They scream and rush towards you.', 'They jump forward and somehow latch on to you and are able to perform WILD SCRATCH twice.', 'The wild preacher becomes caught up in their robes and misses a round of combat.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('CULTIST', 1, 'Humanoid', 5, 6, 1, 'Roll on RPT1', 'Robe Swoop on Secondary|4s|-1 damage', '', '5-4|PUNCH|D6 -2 damage', '', 'Serving the religious leaders in the dungeon these worshippers are twisted by hate and set to evil tasks. They wear red robes and face paint, their eyes bulging as they attack.', 'They pull a long chain and fling it at you and it wraps around your arm causing 1 damage.', 'The Cultist pulls a dagger and throws it but it falls at your feet. You throw it back for 2 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('DARK CLERIC', 1, 'Humanoid', 12, 28, 1, 'Roll on RPT2 +10 GC', 'Dark Magic Haze on Secondary|1s, 2s and 3s|the Dark Cleric heals 1 point of damage if injured and gains one point if not', '', '3-2|NECROTIC PROD|D6 -1 damage', '4-3|STAFF BASH|D6 -2 damage', 'These brooding magic wielders worship Maduva and harness the power of the dead, turning it upon their enemies. They wear textured grey and black cloaks and padded armour.', 'The air turns cold as the cleric raises their staff. You feel a chill run through you. Lose 2 HP.', 'The cleric swings his staff but misses and slips from their hands. Gain 1 extra attack.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('FUNGAL GEIST', 1, 'Plant', 5, 6, 1, 'D3 Geist Mushrooms', 'Rubbery hide on Secondary|4s|-2 damage', '', '3-3|MYCELIUM LASH|D6 -3 damage', '', 'A squat fungal humanoid, part mushroom part unknown beast. Their appearance can be varied, but they usually have a wide textured cap and small mushrooms sometimes cover their torso.', 'The geist raises its cap revealing narrow gills from which it fires a series of darts. Lose D3 HP.', 'The geist attempts a volley of kicks all of which fall short allowing you to prod it hard causing 2 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('GIANT HORNED ANACONDA', 1, 'Animal', 15, 30, 1, 'None', 'Scale block on Secondary|2s and 5s|-2 damage', '', '5-3|SMOTHER|D6 -2 damage + special attack - miss next round (once per combat)', '2-3|HORN JAB|D6 -2 damage', 'A large brown snake with rock like horned ridges, it uses to attack aggressors. They live in rocky environments often near dungeons or caves, where their appearance is perfect camouflage.', 'The snake rises high on its tail and swoops down performing a successful HORN JAB.', 'The snake snaps back and tries to bash you with its head, but instead smashes the wall for D3 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('GUARD', 1, 'Humanoid', 7, 13, 1, 'Roll on PT1 -1', 'Shield BLock on Secondary|3s|-1 damage', 'Shield BLock on Secondary|5s|-1 damage', '5-3|STAB|D6 -3 damage', '6-2|SWIPE|D6 -2 damage', 'A trainer guard wearing light armour who has some basic skills in combat. They have duties within the dungeon and can be seen on patrols and at guard posts.', 'The guard lunges carelessly opens his side and you elbow them hard causing 1 damage.', 'With an unexpected move the guard disarms you. Lose 1 turn as you grab it back off the ground.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('GUARD DOG', 1, 'Animal', 6, 8, 1, 'None', 'Body barge|Secondary 4s|-2 damage', '', '4-3|BITE|D6 -2 damage', '', 'A trained guard dog, appears vicious but has little experience fighting.', 'The dog thrusts forward and clamps its jaws around your arm causing D3 damage.', 'The dog skids as it lunges and you are able to get in an extra attack with +1 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('HUGE INFECTED RAT', 1, 'Animal', 5, 9, 1, 'None', 'Pounce|Secondary 1s and 6s|-1 damage', '', '4-3|INFECTED BITE|D6 -3 damage + special - next two turns lose 1 HP', '2-3|SLASH|D6 -2 damage', 'A large grim looking rodent covered in pus-filled blisters that appears to be in a rabid state. Its red eyes bulge as it screeches and attacks.', 'The rat evades your defence and scurries up your leg and bites your neck using INFECTED BITE.', 'The creature is sickly and seems to cough and spits blood causing it D3 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('HUGE RAT', 1, 'Animal', 3, 2, 1, 'A rat tail without becoming bloodied', '', '', '2-5|BITE|D6 -4 damage', '', 'Not a giant but bigger than a normal rat that will savagely attack anything, even larger creatures, when hungry. They are always hungry.', 'The rat pounces and lands on your face. It bites you before you brush it off. Lose 1 HP.', 'The rat attacks but slips and rolls on its back. You bring down your boot and crush its head, killing it.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('HUGE SPIDER', 1, 'Insect/Arachnid', 2, 2, 1, 'None', '', '', '5-4|FANG PUNCTURE|D6 -3 damage', '', 'Not a giant but bigger than a normal spider with a tough carapace and enlarged fangs. It will attack if something breaks its web.', 'The spider jumps, spins a web, and pings onto your back where it sinks in its fangs. Lose 1 HP.', 'The spider falls as its web breaks and you spin and slice it in two, killing it instantly.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('INFERNAL MONK', 1, 'Humanoid', 6, 15, 1, 'Roll on RPT1+1', 'Heat Wave|Primary 2s and 5s|-1 damage', '', '3-3|MACE BASH|D6 -2 damage', '2-6|FIRE WHIP|D6 -1 damage', 'Dressed in red leather bands and black clothes the bald monk can call upon Grakada to summon fire that extends from their arm as an infernal whip. It lashes towards you as they attack.', 'A second fire whip appears on their other hand and together they strike you. Lose 3 HP.', 'Their whip lashes the air and flings back in their face causing them 2 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('JAILOR', 1, 'Humanoid', 6, 10, 1, 'Roll on PT1 +1', 'Barge on Secondary|2s|-2 damage', '', '5-1|SHARP KICK|D6 -2 damage', '3-3|PUNCH|D6 - 3 damage', 'Being a jailor has made them tough but their skill in combat is limited/ As they come forward wrapping a chain around their knuckles, a mad look in theur eyes.', 'The jailor swigs but appears tired and falls back on their haunches giving you an extra attack.', 'With a whip of their fist the chain shoots out and lashes your knucles. Lose 1 HP if not wearing gloves.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('LABOURER', 1, 'Humanoid', 4, 5, 1, 'Roll on PT1 -2', 'Shove|Primary 2s|-2 damage', '', '2-5|UPPERCUT|D6 -3 damage', '', 'Poorly equipped and unarmed, this labourer offers little challenge, but they have learned patience and do a range of jobs around the dungeon which they will fiercely defend.', 'The labourer barrels past your defence swinging wildly and a punch lands. Take 1 damage.', 'The labourer flays wildly and loses their balance. You quickly counter gaining an extra attack.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('MEDIC', 1, 'Humanoid', 4, 5, 1, 'Roll on PT1 -2 + Malako Leaves', 'Nimble Move|Primary 3s and 4s|-1 damage', '', '3-3|STAB|D6 -2 damage', '', 'The nearest thing the dungeon has to a herbalist and medic who looks after the injured but has very little skill. From a bloody apron they pull out a short knife and attack.', 'The medic whips the apron free, throws it over your head and stabs you causing 2 damage.', 'There must be blood on the medic\'s shoes for they lose their footing and fall. Gain 1 extra attack.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('MERCHANT', 1, 'Humanoid', 5, 6, 1, 'A wallet with D6 GC and D6 SC', 'Divert Blow|Primary 2s and 5s|-1 damage', '', '1-3|QUICK SLASH|D6 -2 damage', '', 'Dressed in fine clothes the merchant manages trade in the dungeon and makes a profit doing so. They pull out a curved sword and prepare to defend their position.', 'The merchant throws a potion at you that explodes. It causes D3 damage.', 'They try a flurry of complex swings, trip and slash their own leg. They take one damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('MUSTY BLOATER', 1, 'Fungi', 9, 12, 1, 'D6 spores', 'Blinding Spore Cloud|Primary 3s, 4s and 5s|-1 damage', '', '5-3|SPORE SPRAY|D6 -2 damage', '', 'Animated by primordial magic these swollen fungi shoot hot spores at their victims. They lumber forward, rising up and swelling, from what appears to be flat mould or mildew.', 'Suddenly the Bloater swells, the pressure shooting out a shower of spores. Lose D3 HP.', 'The creature seems to lose some of its swell and shrinks for a moment. It misses a round of combat.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('SCARLET COBRA', 1, 'Animal', 3, 6, 1, 'No treasure', 'Darts Aside|Primary 2s and 3s|-1 damage', '', '2-3|BITE|D6 -3 damage + special attack - poisoned - lose 1 HP per round for 2 rounds', '', 'A poisonous black snake with scarlet red banding. Lives in deep burrows sometimes finding its way down through cracks in the walls and ceiling of the dungeon.', 'The cobra corners, coils and whips forward past your defence successfully biting you, see BITE attack.', 'The snake shoots out its head in an attempted bite, but misses and you\'re able to slash it for D3 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('SCOUT', 1, 'Humanoid', 5, 9, 1, 'Roll on PT1', 'Swift Jump|Primary 1s and 6s|-2 damage', '', '5-3|JAB|D6 -3 damage', '6-2|QUICK CHARGE|D6 -2 damage', 'Usually out of the dungeon scouting the area they strive to avoid combat but are not afraid of a fight. Dressed in green and agile on their feet they thrust the point of a dagger towards you.', 'The scout leaps back, pulls out a short bow and looses an arrow. Take D3 damage.', 'The scout tries to grab your weapon but instead twists their wrist and takes 1 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('SHARD ROCK PYTHON', 1, 'Animal', 10, 18, 1, 'None', 'Deflect|Primary 1s|-2 damage', '', '4-3|STRANGLE|D6 -1 damage + special attack - when you attack next round you do one less damage', '', 'A heavy snake, with textured rough skin that is a grey rock colour. It wraps around its victims and strangles the life out of them.', 'The python corners you, wraps its bulk around your leg causing lose D6 HP.', 'The snake\'s slow attack allows you to bash it on the head as it tries to move in closer causing D6 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('SLIMY GORGER', 1, 'Fungi', 10, 16, 1, 'Sticky glue like substance (need container)', 'Gelatinous Body|Secondary 2s and 6s|-2 damage', '', '4-3|STICKY SUCTION|D6 -1 damage + special attack - you may not use one random piece of armour this turn', '', 'A dark green slime animated by primordial magic, that lives in wet and cold abandoned spaces. It can rear up and attack with its stretchy gelatinous body.', 'The slime billows out into a wide sheet of green that engulfs you. You struggle free but lose 2 HP.', 'The slime rises, but cannot take an attacking form and misses a round of combat.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('THUG', 1, 'Humanoid', 3, 6, 1, 'None', 'Forearm block on Secondary|4s|-1 damage', '', '3-2|PUNCH|D6 -3 damage', '', 'This rough looking brute has few skill...', 'The thud tries a combo of swing... Gain 1 extra attack', 'The thud manages to grip you.... take D3 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('VETERAN', 1, 'Humanoid', 10, 30, 1, 'Roll on PT1 +1 and an extra D6 GC', 'Parry|Primary 3s and 4s|-2 damage', 'Armour deflection|Secondary 5s and 6s|-1 damage', '6-3|CRUSHING BLOW|D6 -1 damage', '3-2|THRUST|D6 -3 damage', 'A strong and experienced old fighter, who used to be a soldier, and knows how to handle themselves. They appear grizzled and slow but can parry efficiently. They sneer as they attack.', 'Out of nowhere the veteran twists and performs a successful CRUSHING BLOW.', 'The old veteran stumbles and falls. Gain 2 extra hits as he tries to rise.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('WAR HOUND', 1, 'Animal', 10, 25, 1, 'A spiked collar', 'Raised Legs|Primary 5s and 6s|-2 damage', '', '6-2|BITE|D6 -1 damage', '4-3|SPIKE CHARGE|D6 -2 damage', 'A vicious dog trained to fight. Wears a spiked collar it uses in its charge attack.', 'The dog barrels into you dragging its spiked collar down your thigh causing D6 damage.', 'The dog seems keen on simply barking in an attempt to scare you and misses the next round.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('WARRIOR', 1, 'Humanoid', 9, 22, 1, 'Roll on PT1', 'Bracer block|Primary 4s|-1 damage', 'Dodge|Secondary 3s|-1 damage', '4-3|FLURRY|D6 -3 damage', '1-2|SLASH|D6 -2 damage', 'A capable warrior trained in the art of combat. They move quickly and appear well equipped. They wear thick metal bracers which they can use to block attacks.', 'The warrior pulls a small dagger from his boot and flicks it at you. It glances off your cheek. Lose 1 HP.', 'The warrior swings but loses his balance and you kick them hard in the ribs causing D3 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('WORK DOG', 1, 'Animal', 4, 4, 1, 'None', 'Side Swipe|Secondary 2s|-2 damage', '', '4-3|BITE|D6 -3 damage', '', 'A working dog with a need to defend its owner, and although not trained to fight still has a savage bite.', 'The dog wrestles through your defence and slashes you with a paw. Lose 1 HP.', 'The dog flinches and slips as it comes forward afraid of your attack. It hits the wall taking 1 damage.');


