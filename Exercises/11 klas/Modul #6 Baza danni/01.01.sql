CREATE DATABASE employees;

CREATE TABLE people
(
	id INT NOT NULL,
	email VARCHAR(50) NOT NULL,
	first_name VARCHAR(50),
	last_name VARCHAR(50)
)

DROP TABLE people1

SELECT * FROM people

INSERT INTO people (id, email, first_name, last_name)
				VALUES (1, "dsf@sds.bob", "Emil", "Dobr");
				
INSERT INTO people (first_name, last_name, id, email)
				VALUES ("Sdsdwd", "Shiss", 2, "sssd@sk.bdb");

INSERT INTO people (id, email)
				VALUES (3, "bbbb@bb.bbb"),
						 (4, "kkk@kk.kkk"),
						 (5, "lll@ll.lll"),
						 (6, "dkdlb@dd.woi")
				
SELECT * FROM people
--
USE soft_uni;
SELECT * FROM employees;
SELECT first_name, last_name, job_title FROM employees
LIMIT 5;


--
CREATE TABLE people1
(
	id INT PRIMARY KEY AUTO_INCREMENT,
	email VARCHAR(50) NOT NULL UNIQUE,
	first_name VARCHAR(50),
	last_name VARCHAR(50),
	balance DECIMAL(10,2) DEFAULT 0,
	town VARCHAR(50) DEFAULT "Haskovo"
)

INSERT INTO people1 (email, first_name, last_name)
				VALUES  ("sjjs@kks.djdj", "An", "Dan");
INSERT INTO people1 (email, first_name, last_name)
				VALUES  ("jsksj@sksl.sks", "An", "Dan");
INSERT INTO people1 (email, first_name, last_name)
				VALUES  ("sjjs@kks.djdj", "An", "Dan");				
INSERT INTO people1 (email, first_name, last_name)
				VALUES  ("rfrf@dds.klsk", "An", "Dan");
				
								
SELECT * FROM people1


--
SELECT * FROM people
ALTER TABLE people
ADD salary DECIMAL

ALTER TABLE people
DROP COLUMN last_name

ALTER TABLE people
MODIFY COLUMN email VARCHAR(100)
employees
ALTER TABLE people
ADD CONSTRAINT pk_id PRIMARY KEY (id)

ALTER TABLE people DROP PRIMARY KEY;

ALTER TABLE people
ADD CONSTRAINT pk_id PRIMARY KEY (id)

ALTER TABLE people
ADD CONSTRAINT uq_email UNIQUE (email)

ALTER TABLE people
ALTER COLUMN salary SET DEFAULT 0

INSERT INTO people (id, email, first_name)
				VALUES (7, "simw@kwis.ksj", "a")
				
--
TRUNCATE TABLE people

--
DROP TABLE people

--
DROP DATABASE soft_uni

--
ALTER TABLE 

ALTER TABLE people1
ADD CONSTRAINT uq_email UNIQUE (email) 

ALTER TABLE people1
DROP CONSTRAINT uq_email

/*
ALTER TABLE people1
ADD CONSTRAINT pk_id PRIMARY KEY (id) 
*/

ALTER TABLE people1
DROP CONSTRAINT pk_id

--
ALTER TABLE people1
ALTER COLUMN balance DROP DEFAULT

--Задаване на AUTO-INCREMENT, първо правим PK
ALTER TABLE people 
ADD PRIMARY KEY (id)

ALTER TABLE people 
AUTO_INCREMENT = 1

--
SELECT * FROM people1
DELETE FROM people1 WHERE id=2

--
CREATE TABLE IF NOT EXISTS people3
(
	id INT PRIMARY KEY AUTO_INCREMENT,
	`name` VARCHAR(50) NOT NULL,
	birthday DATE,
	age INT CHECK (age>0),
	gender ENUM ('f','m'),
	currency VARCHAR(4) CHECK (currency = "BG" OR currency = "EURO")
)

INSERT INTO people3 (`name`, birthday, age, gender, currency)
				 VALUES ("Ani", "2000-05-15", 22, "f", "BG")
				 		  ("Ani", "2000-05-15", -5, "f", "BG") -- ERROR
				 		  ("Ani", "2000-05-15", 22, "k", "BG")
				 		  
