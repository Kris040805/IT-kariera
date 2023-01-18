CREATE DATABASE broker_business_db;

USE broker_business_db;

CREATE TABLE cities
(
	id INT PRIMARY KEY AUTO_INCREMENT,
	`name` VARCHAR(45) NOT NULL,
	country_name VARCHAR(60)
);

CREATE TABLE companies
(
	id INT PRIMARY KEY AUTO_INCREMENT,
	`name` VARCHAR(45) NOT NULL,
	/*
	rate INT CHECK (rate = 0 OR rate = 1 OR rate =2 OR
							 rate =3 OR rate =4 OR 
							 rate =5 OR rate =6 OR           <----- Вариант 1
							 rate =7 OR rate =8 OR 
							 rate =9 OR rate =10),
	*/
	rate INT CHECK (rate BETWEEN 0 AND 10),         -- <----- Вариант 2
	created_on DATE NOT NULL
);

CREATE TABLE building_types
(
	id INT PRIMARY KEY AUTO_INCREMENT,
	`name` VARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE persons
(
	id INT PRIMARY KEY AUTO_INCREMENT,
	username VARCHAR(30) NOT NULL UNIQUE,
	company_id INT,
	FOREIGN KEY (company_id) REFERENCES companies(id),
	city_id INT NOT NULL,
	FOREIGN KEY (city_id) REFERENCES cities(id)
);

CREATE TABLE person_info
(
	id INT PRIMARY KEY AUTO_INCREMENT,
	first_name VARCHAR(60) NOT NULL,
	last_name VARCHAR(60),
	money DECIMAL(15,2) DEFAULT 0,
	person_id INT,
	FOREIGN KEY (person_id) REFERENCES persons(id)
);

CREATE TABLE buildings
(
	id INT PRIMARY KEY AUTO_INCREMENT,
	`name` VARCHAR(80) NOT NULL UNIQUE,
	rent_amount DECIMAL(17,2) NOT NULL,
	height DECIMAL(15,2) NOT NULL,
	floors INT,
	finished_year INT,
	`status` ENUM('FREE', 'RENTED', 'DEPOSITED') NOT NULL,
	city_id INT NOT NULL,
	FOREIGN KEY (city_id) REFERENCES cities(id),
	type_id INT NOT NULL,
	FOREIGN KEY (type_id) REFERENCES building_types(id),
	company_id INT NOT NULL,
	FOREIGN KEY (company_id) REFERENCES companies(id)
);

CREATE TABLE persons_buildings
(
	person_id INT NOT NULL,
	FOREIGN KEY (person_id) REFERENCES persons(id),
	building_id INT NOT NULL,
	FOREIGN KEY (building_id) REFERENCES buildings(id),
	PRIMARY KEY(person_id, building_id)
);




-- Заявки

-- Заявка 1: Хора
SELECT id, username, company_id FROM persons
WHERE city_id = 10 AND company_id IS NOT NULL
ORDER BY username, id;

-- Заявка 2: Заети сгради
SELECT id, `name` AS building_name, rent_amount, height, `status` FROM buildings
WHERE rent_amount > 5000 AND height > 500
ORDER BY rent_amount DESC, `name`;

-- Заявка 3: Компания West
SELECT p.id, p.username, pei.first_name, pei.last_name, c.name AS 'company_name' FROM persons p
JOIN person_info AS pei ON pei.person_id = p.id
JOIN companies AS c ON c.id = p.company_id
WHERE c.name = 'West'
ORDER BY pei.first_name, pei.last_name;

-- Заявка 4: Първите 15
SELECT p.username, c.name AS company_name, ci.name AS city_name, ci.country_name FROM persons p
JOIN companies AS c ON c.id = p.company_id
JOIN cities AS ci ON ci.id = p.city_id
WHERE p.id <= 15
ORDER BY c.id, p.username;

-- Заявка 5: Типове сгради
SELECT bt.name AS building_type, COUNT(*) AS `buildings_count`, 
(SELECT rent_amount FROM buildings b WHERE b.type_id = bt.id ORDER BY rent_amount DESC LIMIT 1),
(SELECT rent_amount FROM buildings b WHERE b.type_id = bt.id ORDER BY rent_amount ASC LIMIT 1)
FROM building_types bt
JOIN buildings AS b ON b.type_id = bt.id
GROUP BY bt.name
ORDER BY `buildings_count` DESC

-- Заявка 6: Поръчки по държави
SELECT b.name AS building_name, bt.name AS building_type, b.`status`, c.name AS city_name, COUNT(pb.person_id) AS `persons_count` FROM buildings b
JOIN building_types AS bt ON bt.id = b.type_id
JOIN cities AS c ON c.id = b.city_id
JOIN persons_buildings AS pb ON pb.building_id = b.id
GROUP BY pb.building_id
ORDER BY `persons_count` DESC
LIMIT 20;

-- Заявка 7: Поръчки от род
