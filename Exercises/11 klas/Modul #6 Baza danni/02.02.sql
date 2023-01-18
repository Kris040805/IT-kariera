CREATE DATABASE Demo;
USE Demo;

CREATE TABLE mountains
(
	mountain_id INT PRIMARY KEY AUTO_INCREMENT,
	mountan_name VARCHAR(50)
)



CREATE TABLE peaks 
(
	peak_id INT PRIMARY KEY AUTO_INCREMENT,
	peak_name VARCHAR(30),
	-- mountain_id INT FOREIGN KEY REFERENCES mountains(mountain_id)
	mountain_id INT,
	CONSTRAINT fk_peaks_mountains FOREIGN KEY (mountain_id)
				  REFERENCES mountains (mountain_id)
)

INSERT INTO mountains (mountan_name) VALUES ('Rila'), ('Pirin')
SELECT * FROM mountains

INSERT INTO peaks (peak_name, mountain_id)
				VALUES ('Musala', 1), ('Malyovica', 1), ('Vihren', 2)
SELECT * FROM peaks

INSERT INTO peaks (peak_name, mountain_id)
				VALUES ('Botev', 3) -- Error - няма планина с ID 3
				
SELECT peak_name, mountan_name FROM peaks
JOIN mountains ON peaks.mountain_id = mountains.mountain_id




-- Many to many
CREATE TABLE employees
(
	employee_id INT PRIMARY KEY AUTO_INCREMENT,
	employee_name VARCHAR(50)
)

INSERT INTO employees (employee_name)
				VALUES ('Ivan'), ('Dimo'), ('Veso')
SELECT * FROM employees



CREATE TABLE projects
(
	project_id INT PRIMARY KEY AUTO_INCREMENT,
	project_name VARCHAR(50)
);

INSERT INTO projects (project_name)
				VALUES ('Shop'), ('School'), ('Center');
SELECT * FROM projects


CREATE TABLE employees_projects 
(
	employee_id INT,
	project_id INT,
	CONSTRAINT fk_e_p_e FOREIGN KEY (employee_id) 
				  REFERENCES employees (employee_id),
	CONSTRAINT fk_e_p_p FOREIGN KEY (project_id) 
				  REFERENCES projects (project_id),
	CONSTRAINT pk_e_p PRIMARY KEY (employee_id, project_id)
)

INSERT INTO employees_projects 
				VALUES (1,1), (1, 3), (2, 1), (2, 2), (3, 1)
SELECT * FROM employees_projects




-- one to one

CREATE TABLE Driver
(
	driver_id INT PRIMARY KEY AUTO_INCREMENT,
	driver_name VARCHAR(50)
);

INSERT INTO Driver (driver_name)
				VALUES ('Ivan'), ('Pesho');
				
CREATE TABLE cars
(
	car_id INT PRIMARY KEY AUTO_INCREMENT,
	driver_id INT UNIQUE,
	CONSTRAINT fk_cars_drivers FOREIGN KEY (driver_id)
					REFERENCES Driver (driver_id)
);

INSERT INTO cars (driver_id) VALUES (2), (1)
SELECT * FROM cars

-- cascade delete 
CREATE TABLE drivers 
(
	driver_id INT PRIMARY KEY,
	driver_name VARCHAR(50)
)

CREATE TABLE cars1
(
	car_id INT PRIMARY KEY,
	driver_id INT,
	CONSTRAINT fk_car_driver FOREIGN KEY(driver_id)
					REFERENCES drivers (driver_id) ON DELETE CASCADE
);

INSERT INTO drivers VALUES (1, 'Dimo'), (2,'Ivan')
INSERT INTO cars1 VALUES (1, 1), (2,2)

SELECT * FROM drivers
SELECT * FROM cars1

DELETE FROM drivers WHERE driver_id = 1




-- cascade update 
CREATE TABLE drivers2 
(
	driver_id INT PRIMARY KEY,
	driver_name VARCHAR(50)
)

CREATE TABLE cars2
(
	car_id INT PRIMARY KEY,
	driver_id INT,
	CONSTRAINT fk_car2_driver2 FOREIGN KEY(driver_id)
					REFERENCES drivers2 (driver_id) ON UPDATE CASCADE
);

INSERT INTO drivers2 VALUES (1, 'Dimo'), (2,'Ivan');
INSERT INTO cars2 VALUES (1, 1), (2,2)

SELECT * FROM drivers2
SELECT * FROM cars2

UPDATE drivers2
SET driver_id = 5
WHERE driver_id = 1



