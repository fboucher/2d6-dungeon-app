
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
INSERT INTO dbo.magic_scrolls(scroll_type, description, duration, orbit, dispel_doubles, cost, fail,  modifier) VALUES
    ('BALANCE', 'Roll +4 on balance and stability and increase number of balance is still good', 'LITTLE USED', 'FACILITY', 'NONE', '15g', '+1', '±1 DISCIPLINE, ±1 ACROBAT'),
    ('BRUTE FORCE', 'Your physical attack goes through with force, strength soaring through your body', 'NEXT COMBAT', 'METABOLISM', 'NONE', '17g', '+2', '+3 COMBAT, ±2 DAMAGE'),
    ('CUNNING', 'You have advantage in checks to hide or discern magic or use dexterity checks', 'LITTLE USED', 'FACILITY', 'NONE', '16g', '+1', '+2 PERCEPTION, ±1 HIDE'),
    ('DISTRACT', 'You surive the enemy''s mind and turn their thoughts to something else', 'INSTANT', 'PSYCHE', 'NONE', '20g', '+1', '±1 FOLIAGE IS CALLING, ±1 NOTICE'),
    ('FIREWALL', '+2 Fire Resistance against all fire based or fire damage and attacks', 'INSTANT', 'PRIMORDIAL', '4-4', '26g', '+1', '+2 BURN CLEANSE, ±1 DAMAGE'),
    ('FOCUSED WEAPON', 'Heavy strike from the blade of your weapon add +1 to next damage roll', 'NEXT COMBAT', 'METABOLISM', 'NONE', '18g', '+2', '+2 DAMAGE, ±1 ATTACK'),
    ('FLEETING ACTION', 'You bead your pulse quickly and near automatically move from location', 'NEXT COMBAT', 'FACILITY', '1-1', '16g', '-1', '+2 FLEE, ±1 EVASION'),
    ('BRIGHTEN COMBAT', '+1 Coordination added to your next attack and action during combat', 'NEXT COMBAT', 'METABOLISM', 'NONE', '17g', '+1', '+1 COMBAT, ±1 PRECISION'),
    ('INSPIRING WORDS', 'Yourself and nearby allies get +1 on any wisdom and skill checks', 'NEXT COMBAT', 'PRIMORDIAL', '3-3', '19g', '+2', '+1 MORAL, ±1 MORALE'),
    ('LIGHTNING STRIKE', 'Bolt of time raining upon strikes toward your next attack hit and damage', 'INSTANT', 'PRIMORDIAL', '3-3-6-6', '56g', '+3', '+3 ELECTRIC, ±2 LIGHT'),
    ('LUCKY SHOT', 'Reroll any attack roll you made or let someone reroll a saving throw', 'INSTANT', 'PSYCHE', 'NONE', '25g', '+1', '±1 ACCURACY, ±1 REROLL'),
    ('MENTAL WHIP', 'Your reach out it should strike tiny furrowed mind and it will hurt', 'INSTANT', 'PSYCHE', 'NONE', '29g', '+1', '±1 PSYCHE DAMAGE, ±1 MENTAL'),
    ('PARALYZE', 'Freeze muscle and in order foe can''t for the next time', 'INSTANT', 'PSYCHE', 'NONE', '22g', '+4', '±1 FREEZE TIME, ±1 PARALYZE'),
    ('SCENT TRAIL', 'Sharpen sense you you and decide any misted cards', 'INSTANT', 'FACILITY', 'NONE', '13g', '+1', '+1 SMELL, ±1 PERCEIVE'),
    ('STEADY HAND', 'Far stone near momentarily is I magical', 'LITTLE USED', 'FACILITY', 'NONE', '13g', '+1', '±1 PRECISION, ±1 ACCURACY'),
    ('SUNBOLT', 'You take a strike in a sunline that must cover you', 'INSTANT', 'METABOLISM', 'NONE', '30g', '-1', '+3 LIGHT, ±2 RADIANT'),
    ('WARD HEALTH', '+1 Health protection that heals 1d4 health and spiritual damage', 'INSTANT', 'METABOLISM', '2-2', '55g', '-1', '+1 HEALTH, ±1 WARD'),
    ('SWAMP LUNG', 'You torch air a burst of swamp water pass over and is to terrain', 'INSTANT', 'PRIMORDIAL', '5-5', '25g', '+1', '+1 FREE WATER, ±1 SWAMP');

-- Starting Potion
INSERT INTO dbo.magic_potions(potion_type, modifier, duration, cost) VALUES
    ('ALACRITY', '+1 Dexterity skill +1 Dexterity for 1 wagon/potion', 'INSTANT', '10g'),
    ('BLESSED ACTIONS', '+2 Shift from your opponent''s Shift points for 1 whole combat', 'ONE COMBAT', '180g'),
    ('DIVINE SHIELD', '+10 damage taken is split and 50% rolled back for 1 whole combat', 'ONE COMBAT', '130g'),
    ('DIMINUTION', '+2 Bargains for 1 dungeon level', 'INSTANT', '5g'),
    ('EXAMINATION', '+5 Fire Resistance rolls per 1 wagon', 'INSTANT', '10g'),
    ('EXTRA WEANING', 'Heal up to 30 Health Points', 'INSTANT', '25g'),
    ('FIDELITY', '+1 Precision for 1 dungeon level', 'INSTANT', '15g'),
    ('FINESSE', '+2 Shift for 1 whole combat', 'ONE COMBAT', '50g'),
    ('LIMIT HEALTH', '+5 Health Points (max exceed baseline level)', 'INSTANT', '35g'),
    ('GAIN HEALTH', '+5 Health Points (can exceed baseline level)', 'INSTANT', '75g'),
    ('HEALING', 'Heal up to 10 Health Points', 'INSTANT', '20g'),
    ('MIGHTY STRENGTH', '+2 Damage per hit for 1 whole combat', 'ONE COMBAT', '20g'),
    ('PHASING', 'Phase through walls and one (phased) life blocked status', 'INSTANT', '60g'),
    ('PROWESS', '+1 Shift for 1 whole combat', 'ONE COMBAT', '25g'),
    ('RANCID BREATH', '+10 on melee or damage per round for 1 whole combat', 'ONE COMBAT', '75g'),
    ('REGENERATION', 'Heal up to 60 Health Points', 'INSTANT', '60g'),
    ('RESIST MAGIC', '+3 Damage resistance from magic attacks per line for 1 magic based', 'INSTANT', '45g'),
    ('SHIELD AURA', '+1 Damage taken per round (all 1 whole combat)', 'ONE COMBAT', '10g'),
    ('SPEED BURST', '+2 Haste attacks at the start of 1 combat', 'ONE COMBAT', '1g'),
    ('STARKNESS', '+2 Precision for 1 dungeon level', 'INSTANT', '40g'),
    ('STRENGTH', '+1 Damage per hit for 1 whole combat', 'ONE COMBAT', '15g'),
    ('WILLPOWER', '+1 Discipline for 1 dungeon level', 'INSTANT', '30g');


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