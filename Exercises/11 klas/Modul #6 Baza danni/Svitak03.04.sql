-- Problem 1.
USE soft_uni;

INSERT INTO towns (`name`)
				VALUES ('Sofia'), 
						 ('Plovdiv'), 
						 ('Varna'), 
						 ('Burgas');

INSERT INTO departments (`name`, manager_id)
VALUES ('Software Development', 248);

INSERT INTO employees (first_name, middle_name, last_name, job_title, department_id, hire_date, salary)
				VALUES ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 17, '2013-02-01', 3500),
						 ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000),
						 ('Maria', 'Petrova', 'Ivanova', 'Intern', 13, '2016-08-28', 525.25),
						 ('Georgi', 'Terziev', 'Ivanov', 'CEO', 3, '2007-12-09', 3000),
						 ('Peter', 'Pan', 'Pan', 'Intern', 4, '2016-08-08', 599.88);


-- Problem 2.
USE soft_uni;

SELECT * FROM towns;
SELECT * FROM departments;
SELECT * FROM employees;


-- Problem 3.
USE soft_uni;

SELECT `name` FROM towns;
SELECT `name` FROM departments;
SELECT first_name, last_name, job_title, salary FROM employees;


-- Problem 4.
USE soft_uni;

UPDATE employees
SET salary = salary * 1.10;

SELECT salary FROM employees;