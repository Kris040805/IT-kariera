CREATE DATABASE svitak3

-- Problem 7.
CREATE TABLE people
(
	id INT PRIMARY KEY AUTO_INCREMENT,
	`name` VARCHAR(200) NOT NULL,
	picture BLOB,
	height NUMERIC(10, 2),
	weight NUMERIC(10, 2),
	gender ENUM('f', 'm') NOT NULL,
	birthdate DATE NOT NULL,
	biography VARCHAR(8000)
);

INSERT INTO people (`name`, picture, height, weight, gender, birthdate, biography)
VALUES
('Iva', 10001001, 1.34, 35, 'f', '1999/05/14', NULL),
('Ivan', 10001001, 1.34, 35, 'm', '1999/05/14', NULL),
('Iva', 10001001, 1.45, 35, 'f', '1999/05/14', NULL),
('Iva', 10001001, 1.34, 35, 'f', '1999/05/14', NULL),
('Iva', 10001001, 1.34, 35, 'f', '1999/05/14', NULL)





-- Problem 8.
CREATE TABLE users
(
	id INT PRIMARY KEY AUTO_INCREMENT,
	username VARCHAR(30) UNIQUE NOT NULL,
	`password` VARCHAR(26) NOT NULL,
	profile_picture BLOB(900000),
	last_login_time TIMESTAMP, 
	is_deleted BOOL
);

INSERT INTO users (username, `password`, profile_picture, is_deleted)
VALUES
('Iva', 'maajk', 10010, 1),
('Ivan', 'maajk', 10010, 0),
('Alex', 'maajk', 10010, 1),
('Gosho', 'maajk', 10010, 1),
('Simona', 'maajk', 10010, 0)





-- Problem 9.
ALTER TABLE users
DROP PRIMARY KEY,
ADD PRIMARY KEY pk_users (id, username);





-- Problem 10.
ALTER TABLE users
CHANGE COLUMN last_login_time 
last_login_time TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP
