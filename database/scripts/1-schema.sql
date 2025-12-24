CREATE DATABASE IF NOT EXISTS db2d6;


CREATE TABLE IF NOT EXISTS db2d6.meta_table (
  id int NOT NULL AUTO_INCREMENT,
  code varchar(25) DEFAULT NULL,
  name varchar(50) DEFAULT NULL,
  PRIMARY KEY (id)
);



CREATE TABLE IF NOT EXISTS db2d6.adventurers (
  id int NOT NULL AUTO_INCREMENT,
  name varchar(255) DEFAULT NULL,
  level int DEFAULT 0,
  xp int DEFAULT 0,
  serialiazedObj longtext DEFAULT NULL,
  PRIMARY KEY (id)
);


CREATE TABLE IF NOT EXISTS db2d6.adventures (
  id int NOT NULL AUTO_INCREMENT,
  name varchar(255) DEFAULT NULL,
  adventurer_id int DEFAULT NULL,
  level int DEFAULT 0,
  last_saved_datetime varchar(50) DEFAULT NULL,
  serialiazedObj longtext DEFAULT NULL,
  PRIMARY KEY (id)
);


CREATE TABLE IF NOT EXISTS db2d6.armour_pieces (
  id int NOT NULL AUTO_INCREMENT,
  name varchar(255) DEFAULT NULL,
  dice_set int DEFAULT 0,
  modifier varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
);


CREATE TABLE IF NOT EXISTS db2d6.magic_potions (
  id int NOT NULL AUTO_INCREMENT,
  potion_type varchar(255) NOT NULL,
  modifier varchar(255) NOT NULL,
  duration varchar(50) DEFAULT NULL,
  cost varchar(50) DEFAULT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS db2d6.magic_scrolls (
  id int NOT NULL AUTO_INCREMENT,
  scroll_type varchar(255) NOT NULL,
  description varchar(255) NOT NULL,
  duration varchar(50) DEFAULT NULL,
  orbit varchar(50) DEFAULT NULL,
  dispel_doubles varchar(50) DEFAULT NULL,
  cost varchar(50) DEFAULT NULL,
  fail varchar(50) DEFAULT NULL,
  modifier varchar(255) NOT NULL,
  PRIMARY KEY (id)
);


CREATE TABLE IF NOT EXISTS db2d6.rooms (
  id int NOT NULL AUTO_INCREMENT,
  roll int DEFAULT 0,
  level int DEFAULT 1,
  size varchar(10) DEFAULT NULL,
  room_type varchar(255) DEFAULT NULL,
  description varchar(255) DEFAULT NULL,
  encounter varchar(255) DEFAULT NULL,
  exits varchar(255) DEFAULT NULL,
  is_unique bool DEFAULT false,
  PRIMARY KEY (id)
);


CREATE TABLE IF NOT EXISTS db2d6.weapons (
  id int NOT NULL,
  name varchar(100) DEFAULT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS db2d6.weapon_manoeuvres (
  id int NOT NULL AUTO_INCREMENT,
  level int DEFAULT 0,
  weapon_id int DEFAULT NULL,
  dice_set varchar(5) DEFAULT '1-1',
  description varchar(100) DEFAULT NULL,
  modifier varchar(50) DEFAULT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (weapon_id)
        REFERENCES weapons(id)
);


CREATE TABLE IF NOT EXISTS db2d6.creatures (
  id int NOT NULL AUTO_INCREMENT,
  name varchar(100) NOT NULL,
  level int DEFAULT 1,
  creature_type varchar(25) NOT NULL,
  health_points int DEFAULT 1,
  experience int DEFAULT 0,
  shift_points int DEFAULT 0,
  treasure varchar(100),
  interrupt1 varchar(100),
  interrupt2 varchar(100),
  manoeuvre1 varchar(100),
  manoeuvre2 varchar(100),
  description varchar(255),
  prime_attack_rolls varchar(150),
  mishap_attack_rolls varchar(150),
  PRIMARY KEY (id)
);
