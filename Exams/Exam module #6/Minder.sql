CREATE DATABASE Minder;
USE Minder;


SET default_storage_engine=INNODB;

CREATE TABLE characteristics
(
	characteristic_id INT PRIMARY KEY AUTO_INCREMENT,
	title VARCHAR(255) NOT NULL
);

CREATE TABLE users
(
	user_id INT PRIMARY KEY AUTO_INCREMENT,
	username VARCHAR(50) NOT NULL,
	email VARCHAR(255) NOT NULL,
	`password` VARCHAR(255) NOT NULL,
	first_name VARCHAR(255) NOT NULL,
	last_name VARCHAR(255) NOT NULL,
	birthdate DATE NOT NULL,
	gender ENUM('m', 'f') NOT NULL,
	bio TEXT,
	latitude DOUBLE NOT NULL,
	longitude DOUBLE NOT NULL,
	profile_picture VARCHAR(50)
);

CREATE TABLE characteristics_users
(
	characteristic_id INT,
	FOREIGN KEY (characteristic_id) REFERENCES characteristics(characteristic_id),
	user_id INT,
	FOREIGN KEY (user_id) REFERENCES users(user_id),
	PRIMARY KEY (characteristic_id, user_id),
	`value` VARCHAR(255) NOT NULL
);

CREATE TABLE connections
(
	`connection_id` INT PRIMARY KEY AUTO_INCREMENT,
	from_user_id INT NOT NULL,
	FOREIGN KEY(from_user_id) REFERENCES users(user_id),
	to_user_id INT NOT NULL,
	FOREIGN KEY(to_user_id) REFERENCES users(user_id),
	accepted TINYINT(1) NOT NULL DEFAULT 0
);

CREATE TABLE likes
(
	liked_by_user_id INT NOT NULL,
	FOREIGN KEY (liked_by_user_id) REFERENCES users(user_id),
	liked_user_id INT NOT NULL,
	FOREIGN KEY (liked_user_id) REFERENCES users(user_id),
	PRIMARY KEY (liked_by_user_id, liked_user_id)
);

-- Заявки

-- Заявка 1: Характеристики
SELECT title FROM characteristics
ORDER BY title
LIMIT 5;

-- Заявка 2: Всички връзки инициирани от потребител 481
SELECT from_user_id, to_user_id, accepted FROM connections
WHERE from_user_id = 481 AND accepted = 1
ORDER BY to_user_id DESC;

-- Заявка 3: Изведете потребителските имена на тримата най-харесвани потребители
SELECT u.username FROM users u
JOIN likes AS l ON u.user_id = l.liked_user_id
GROUP BY u.user_id
ORDER BY COUNT(l.liked_by_user_id) DESC
LIMIT 3;

-- Заявка 4: Никой не ме харесва
SELECT u.user_id, u.username, u.first_name, u.last_name FROM users u
WHERE u.user_id NOT IN (
								SELECT l.liked_user_id FROM likes l
							  )
ORDER BY first_name, last_name
LIMIT 10;

-- Заявка 5: Синеоки момичета родени през 90-те
SELECT u.username FROM users u
JOIN characteristics_users AS cu ON cu.user_id = u.user_id
WHERE u.gender = 'f' 
AND cu.value = 'blue' 
AND u.birthdate >= '1990-1-1'
AND u.birthdate <= '1999-12-31'
ORDER BY u.username DESC;

-- Заявка 6: Каква е средната височина на потребителите?
SELECT ROUND(AVG(cu.value), 2) AS average_height FROM characteristics_users cu
WHERE cu.characteristic_id = 1;

-- Заявка 7: Какъв цвят на очите имат харесваните и харесаните?
SELECT uby.username AS `liked_by`, uon.username AS `liked`, cuby.value AS `liked_by_eye_color`, cuon.value AS `liked_eye_color` FROM likes l 
JOIN users AS uby ON uby.user_id = l.liked_by_user_id
JOIN users AS uon ON uon.user_id = l.liked_user_id
JOIN characteristics_users AS cuby ON cuby.user_id = l.liked_by_user_id
JOIN characteristics_users AS cuon ON cuon.user_id = l.liked_user_id
WHERE cuby.characteristic_id = 3 AND cuon.characteristic_id = 3
ORDER BY `liked_by`, `liked`
LIMIT 5