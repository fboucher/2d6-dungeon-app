
-- Starting Amour
INSERT INTO dbo.armour_pieces(name, dice_set, modifier)
VALUES('Jerkin', 4, '-1 Damage');
INSERT INTO dbo.armour_pieces(name, dice_set, modifier)
VALUES('Padded Tunic', 5, '-1 Damage');
INSERT INTO dbo.armour_pieces(name, dice_set, modifier)
VALUES('Quilted Coat', 3, '-1 Damage');
INSERT INTO dbo.armour_pieces(name, dice_set, modifier)
VALUES('Hide doublet', 2, '-1 Damage');

-- Starting Scroll
INSERT INTO dbo.magic_scrolls(scroll_type, description, modifier)
VALUES('Balance', 'Increses discipline and magical focus for a time', '+1 Discipline for dungeon level');
INSERT INTO dbo.magic_scrolls(scroll_type, description, modifier)
VALUES('Mental whip', 'A damaging psychic attack', '1 strike of 10 damage');
INSERT INTO dbo.magic_scrolls(scroll_type, description, modifier)
VALUES('Reflexes', 'Increases combat ability for a time', '+1 Shift for 1 combat');
INSERT INTO dbo.magic_scrolls(scroll_type, description, modifier)
VALUES('Melt metal', 'Destroys one lock or armour-related interrupt on an enemy', 'Destroy 1 lock or peace of armour');

-- Starting Potion
INSERT INTO dbo.magic_potions(potion_type, modifier, duration, cost) 
    VALUES('HEALING', 'Heal up to 10 Health Points', 'INSTANT', '18gc');


-- rooms Level 1
-- small
INSERT INTO dbo.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (2,1,'Empty space', 'small','There is nothing in this small space', 'Archways',0);
INSERT INTO dbo.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (3,1,'Strange Text', 'small','This narrow room connects the corridors and has no furniture. On the wall though...', 'Archways',0);
INSERT INTO dbo.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (4,1,'Grakada Mural', 'small','There is a large mural of Grakada here. Her old faces smiles...', 'Archways',1);


-- regular
INSERT INTO dbo.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES (11,1,'Empty space', 'regular','This room is bare and seems to have been cleared out or forgotten about', 'The room is quiet. You hear nothing', 'Archways',0);
INSERT INTO dbo.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES (12,1,'Abandoned Gard post', 'regular','There is dusty table...', 'Beneath the table is a pile of rubbish...', 'Wooden doors',0);
INSERT INTO dbo.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES (13,1,'Gard post', 'regular','A small burner provides...', 'There is someone here...', 'Enforced doors',0);

-- large
INSERT INTO dbo.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (2,1,'Stone workshop', 'large','This large space has rough walls and piles of stone laying everywhere. There are...', 'Wooden doors',0);
INSERT INTO dbo.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (3,1,'Grand hall', 'large','There are evently spaced pillars running along this large marble lined hall, ...', 'Archways',1);
INSERT INTO dbo.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (4,1,'Church', 'large','This room is lined with pews and chairs. Behind am allar...', 'Wooden doors',1);



-- weapons
INSERT INTO dbo.weapons(id, name) VALUES(1, 'LONGSWORD');
INSERT INTO dbo.weapons(id, name) VALUES(2, 'GREATAXE');
INSERT INTO dbo.weapons(id, name) VALUES(3, 'HEAVY MACE');


-- weapon_manoeuvres
INSERT INTO dbo.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 1, '1-2', 'DISGUISED SWOOP', '6D +2');
INSERT INTO dbo.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 1, '5-2', 'INCISIVE CUT', '6D +1');
INSERT INTO dbo.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 1, '3-2', 'THRUST', '6D');

INSERT INTO dbo.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 2, '1-2', 'WEIGHTED CHARGE', '6D +3');
INSERT INTO dbo.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 2, '5-2', 'LOW SWISH', '6D +1');
INSERT INTO dbo.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 2, '3-2', 'HACK', '6D');

INSERT INTO dbo.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 3, '1-2', 'SOLID BELTING', '6D +2');
INSERT INTO dbo.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 3, '5-2', 'POMMEL THUMP', '6D +1');
INSERT INTO dbo.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 3, '3-2', 'CARVING HIT', '6D +1');