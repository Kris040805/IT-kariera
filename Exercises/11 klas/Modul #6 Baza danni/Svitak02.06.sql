CREATE DATABASE svitak0206

-- Problem 1. Online store database
CREATE TABLE item_types
(
	item_type_id INT(11) PRIMARY KEY,
	`name` VARCHAR(50)
);

CREATE TABLE items
(
	item_id INT(11) PRIMARY KEY,
	`name` VARCHAR(50),
	item_type_id INT(11),
	FOREIGN KEY (item_type_id) REFERENCES item_types (item_type_id)
);

CREATE TABLE cities
(
	city_id INT(11) PRIMARY KEY,
	`name` VARCHAR(50)
);

CREATE TABLE customers
(
	customer_id INT(11) PRIMARY KEY,
	`name` VARCHAR(50),
	birthday DATE,
	city_id INT(11),
	FOREIGN KEY (city_id) REFERENCES cities (city_id)
);

CREATE TABLE orders
(
	order_id INT(11) PRIMARY KEY,
	customer_id INT(11),
	FOREIGN KEY (customer_id) REFERENCES customers (customer_id)
);

CREATE TABLE order_items
(
	order_id INT(11),
	item_id INT(11),
	CONSTRAINT fk_oi_orders FOREIGN KEY (order_id)
					REFERENCES orders (order_id),
	CONSTRAINT fk_oi_items FOREIGN KEY (item_id)
					REFERENCES items (item_id),
	PRIMARY KEY (order_id, item_id)
);






-- Problem 2. University database 
CREATE TABLE majors
(
	major_id INT(11) PRIMARY KEY,
	`name` VARCHAR(50)
);

CREATE TABLE students
(
	student_id INT(11) PRIMARY KEY,
	student_number VARCHAR(12),
	student_name VARCHAR(50),
	major_id INT(11),
	FOREIGN KEY (major_id) REFERENCES majors (major_id)
);

CREATE TABLE payments
(
	payment_id INT(11) PRIMARY KEY,
	payment_date DATE,
	payment_amount DECIMAL(8, 2),
	student_id INT(11),
	FOREIGN KEY (student_id) REFERENCES students (student_id)
);

CREATE TABLE subjects
(
	subject_id INT(11) PRIMARY KEY,
	subject_name VARCHAR(50)
);

CREATE TABLE agenda
(
	student_id INT(11),
	subject_id INT(11),
	FOREIGN KEY (student_id) REFERENCES students (student_id),
	FOREIGN KEY (subject_id) REFERENCES subjects (subject_id),
	PRIMARY KEY (student_id, subject_id)
);