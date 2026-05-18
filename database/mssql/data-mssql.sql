
-- Starting Amour
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Jerkin', '1', '-1 Damage', 1);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Padded Tunic', '2', '-1 Damage', 1);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Quilted Coat', '3', '-1 Damage', 1);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Hide doublet', '4', '-1 Damage', 1);

-- Other Amour
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Bishop''s Mantle', '1-2', '-1 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Long Leather Jacket', '1-3', '-1 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Leather Breast Plate', '1-4', '-1 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Leather Bracers', '1-5', '-1 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Brigandine Overcoat', '2-3', '-1 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Studded Buckler', '2-4', '-1 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Steel Buckler', '2-5', '-2 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Wooden Shield', '2-6', '-2 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Banded Shield', '3-4', '-2 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Shoulder Platelets', '3-5', '-2 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Mail Coif', '3-6', '-2 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Metal Bracers', '4-5', '-2 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Helmet', '4-6', '-2 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Winged Helmet', '5-6', '-2 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Great Helm', '1-2+3', '-3 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Gauntlets', '1-2+4', '-3 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Long Gauntlets', '1-2+5', '-3 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Scale Jacket', '1-2+6', '-3 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Exquisite Scale Jacket', '1-3+4', '-3 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Chainmail Shirt', '1-3+5', '-3 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Metal Breast Plate', '1-3+6', '-3 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Reinforced Banded Mail', '1-4+2-5', '-4 Damage', 0);
INSERT INTO dbo.armour_pieces(name, dice_set, modifier, is_initial)
VALUES('Full Plate', '1-4+2-6', '-4 Damage', 0);

-- Starting Scroll
INSERT INTO dbo.magic_scrolls(scroll_type, description, duration, orbit, dispel_doubles, cost, fail,  modifier, is_initial) VALUES
    ('BALANCE', 'You sense an inner stability and become aware of magic flowing through the air.', 'UNTIL USED', 'FACULTY', 'NONE', '15gs', '-1', '+1 DISCIPLINE FOR 1 DUNGEON LEVEL', 1),
    ('BRUTE FORCE', 'Your muscles tighten and bulge and you feel strength coursing through your body.', 'NEXT COMBAT', 'METAMORPH', 'NONE', '17gs', '+2', '+2 DAMAGE FOR 1 COMBAT', 0),
    ('DEEP FOCUS', 'You feel connected to the streams of magic energy and control them with ease.', 'UNTIL USED', 'FACULTY', 'NONE', '25gs', '-1', '+2 DISCIPLINE FOR 1 DUNGEON LEVEL', 0),
    ('DISTRACT', 'You enter the enemy''s mind and turn their thoughts against their companion.', 'INSTANT', 'PSYCHE', 'NONE', '30gs', '+1', 'IF YOU FACE 2 FOES 1 LEAVES', 0),
    ('FIREBALL', 'You blast a ball of fire from your open palm, at your enemy, who bursts into flames.', 'INSTANT', 'PRIMORDIAL', '4-4', '20gs', '-1', 'CAUSES 20 DAMAGE', 0),
    ('FLAMING WEAPON', 'Flames erupt from the blade of your weapon and burn those you strike.', 'NEXT COMBAT', 'PRIMORDIAL', '1-1', '32gs', '0', '+4 DAMAGE FOR 1 COMBAT', 0),
    ('FLEETING ACTION', 'You feel your pulse quicken and become swift and graceless.', 'NEXT COMBAT', 'FACULTY', '3-3', '10gs', '-1', '+2 SHIFT FOR 1 COMBAT', 0),
    ('INSIGHTFUL COMBAT', 'The world slows and details seem clearer as you study your opponent''s movements.', 'NEXT COMBAT', 'PSYCHE', 'NONE', '70gs', '-2', '+20 PERCEPT XP FROM 1 COMBAT', 0),
    ('INVISIBILITY', 'You glance down to see your body has disappeared and that you have vanished.', 'NEXT COMBAT', 'METAMORPH', '5-5', '21gs', '-1', 'AVOID 1 COMBAT AND ROOM CONTENTS', 0),
    ('LIGHTNING STRIKE', 'A fork of bluish lightning explodes from your chest to strike your foe with unholy force.', 'INSTANT', 'PRIMORDIAL', '3-3-6-6', '50gs', '-3', '1 STRIKE OF 50 DAMAGE', 0),
    ('MELT METAL', 'You concentrate on the metal and watch it melt into a soft dripping gloop.', 'INSTANT', 'METAMORPH', 'NONE', '18gs', '0', 'DESTROY 1 LOCK OR INTERRUPT ARMOUR', 1),
    ('MENTAL WHIP', 'You reach out a thought into their mind and it transforms to become a barbed lash.', 'INSTANT', 'PSYCHE', 'NONE', '20gs', '-1', '1 STRIKE OF 10 DAMAGE', 1),
    ('PARALYSIS', 'You clench your fist and focus on one foe and they freeze to the spot motionless.', 'INSTANT', 'PSYCHE', 'NONE', '22gs', '+1', '+3 FREE SWINGS IN 1 COMBAT', 0),
    ('REFLEXES', 'Warmth floods your body making you feel at ease and unexpectedly flexible.', 'NEXT COMBAT', 'FACULTY', 'NONE', '10gs', '-2', '+1 SHIFT FOR 1 COMBAT', 1),
    ('STEADY HAND', 'You sense your movements as if magnified allowing you to steady yourself.', 'UNTIL USED', 'FACULTY', 'NONE', '13gs', '-1', '+1 PRECISION FOR 1 DUNGEON LEVEL', 0),
    ('SUNDER', 'There is a loud crack and the ceiling above your foe collapses inwards on them.', 'INSTANT', 'METAMORPH', '2-2', '30gs', '-1', '1 STRIKE OF 20 DAMAGE TO ALL FOES', 0),
    ('SURGING HEALTH', 'You watch as your wounds close and heal and renewed vigour surges through you.', 'INSTANT', 'METAMORPH', '4-4', '55gs', '-1', '+20 HEALTH POINTS', 0),
    ('SWAMP LUNG', 'You watch as a torrent of swamp water pours from your foe''s mouth.', 'INSTANT', 'PRIMORDIAL', '5-5', '25gs', '-1', '1 FREE SWING + 20 DAMAGE', 0);

-- Starting Potion
INSERT INTO dbo.magic_potions(potion_type, modifier, duration, cost) VALUES
    ('CONSTANCY', '+1 Precision and +1 Discipline for 1 dungeon level', 'INSTANT', '45gs'),
    ('DEXTEROUS ACTIONS', '-2 Shift from your opponent''s Shift Points for 1 whole combat', 'ONE COMBAT', '100gs'),
    ('DIVINE SHIELD', '-10 damage from each hit you take for 1 whole combat', 'ONE COMBAT', '110gs'),
    ('DOMINATION', '+2 Discipline for 1 dungeon level', 'INSTANT', '50gs'),
    ('EXAMINATION', 'Go to the treasure rolls in 1 room', 'INSTANT', '10gs'),
    ('EXTRA HEALING', 'Heal up to 30 Health Points', 'INSTANT', '28gs'),
    ('FIDELITY', '+1 Precision for 1 dungeon level', 'INSTANT', '8gs'),
    ('FINESSE', '+2 Shift for 1 whole combat', 'ONE COMBAT', '50gs'),
    ('FURTHER HEALTH', 'Gain 25 Health Points (can exceed baseline level)', 'INSTANT', '40gs'),
    ('GAIN HEALTH', 'Gain 15 Health Points (can exceed baseline level)', 'INSTANT', '25gs'),
    ('HEALING', 'Heal up to 10 Health Points', 'INSTANT', '18gs'),
    ('MIGHTY STRENGTH', '+2 damage per hit for 1 whole combat', 'ONE COMBAT', '20gs'),
    ('PHASING', 'Phase through one locked door ignoring the locked status', 'INSTANT', '4gs'),
    ('PROWESS', '+1 Shift for 1 whole combat', 'ONE COMBAT', '10gs'),
    ('RANCID BREATH', 'Do an extra 5 points of damage per round for 1 whole combat', 'ONE COMBAT', '55gs'),
    ('REGENERATION', 'Heal up to 60 Health Points', 'INSTANT', '60gs'),
    ('RESIST MAGIC', 'Ignore 1 successful enemy manoeuvre against you that is magic based', 'INSTANT', '10gs'),
    ('SHIELD AURA', '-1 Damage taken per round in 1 whole combat', 'ONE COMBAT', '18gs'),
    ('SPEED BLAST', '+2 free attacks at the start of 1 combat', 'INSTANT', '12gs'),
    ('STEADINESS', '+2 Precision for 1 dungeon level', 'INSTANT', '40gs'),
    ('STRENGTH', '+1 damage per hit for 1 whole combat', 'ONE COMBAT', '15gs'),
    ('WILLPOWER', '+1 Discipline for 1 dungeon level', 'INSTANT', '30gs');


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