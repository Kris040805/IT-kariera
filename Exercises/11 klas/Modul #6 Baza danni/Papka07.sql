USE soft_uni
SET GLOBAL log_bin_trust_function_creators = 1

-- 07.1
DELIMITER $$
CREATE FUNCTION udf_projects_weeks (start_date DATETIME, end_date DATETIME)
RETURNS INT
BEGIN
	DECLARE project_weeks INT;
	if (end_dates IS NULL)
	then SET end_date = NOW();
	END if;
	SET project_weeks = DATEDIFF (DATE(end_date), DATE(start_date))/7;
	RETURN project_weeks;
END
$$



-- zadachс ot prezentaciqta
-- 1
DELIMITER $$
CREATE FUNCTION udf_get_salary_level (salary DECIMAL(19,4))
RETURNS VARCHAR(10)
BEGIN 
	DECLARE salary_level VARCHAR(10);
	IF	(salary < 30000)
	then SET salary_level = 'Low';
	ELSEIF (salary > 50000)
	then SET salary_level = 'High';
	ELSE SET salary_level = 'Average';
	END IF;
	RETURN salary_level;
END
$$

DELIMITER $$
CREATE FUNCTION udf_get_salary_level1 (salary DECIMAL(19,4))
RETURNS VARCHAR(10)
BEGIN 
	DECLARE salary_level VARCHAR(10);
	IF	(salary < 30000)
	then SET salary_level = 'Low';
	ELSE
		IF (salary > 50000)
		then SET salary_level = 'High';
		ELSE SET salary_level = 'Average';
		END IF;
	END IF;
	RETURN salary_level;
END
$$

SELECT first_name, last_name, salary, udf_get_salary_level(salary) AS 'salary_level'
FROM employees;


-- 2
DELIMITER $$
CREATE FUNCTION udf_count_employees_by_town (town_name VARCHAR(20))
RETURNS INT
BEGIN 
	DECLARE e_count INT;
	SET e_count = (SELECT COUNT(*)
						FROM employees AS e
						JOIN addresses AS a ON a.address_id = e.address_id
						JOIN towns AS t ON t.town_id = a.town_id
						WHERE t.name = town_name);
	RETURN e_count;
END
$$

SELECT udf_count_employees_by_town ('Sofia');




-- 07.3
DELIMITER $$
CREATE PROCEDURE udp_select_employees_by_seyority()
BEGIN
	SELECT * FROM employees
	WHERE ROUND(DATEDIFF(NOW(), hire_date)/365.25) < 15;
END 
$$

CALL udp_select_employees_by_seyority();

--
DELIMITER $$
CREATE PROCEDURE udp_select_employees_by_seyority1 (min_years_at_work INT)
BEGIN
	SELECT first_name, last_name, hire_date,
	ROUND(DATEDIFF(NOW(), hire_date)/365.25) AS years
	FROM employees
	WHERE ROUND(DATEDIFF(NOW(), hire_date)/365.25) <= min_years_at_work;
END 
$$

CALL udp_select_employees_by_seyority1(15);


--
DELIMITER $$
CREATE PROCEDURE usp_sum_two_numbers (first_num INT, second_num INT, OUT result INT)
BEGIN 
	SET result = first_num + second_num;
END
$$

SET @answer = 0;
CALL usp_sum_two_numbers(182, 232, @answer);
SELECT @answer;



--
USE bank

DELIMITER $$
CREATE PROCEDURE usp_withdraw_money (account_id INT, amount DECIMAL(10,2))
BEGIN 
	START TRANSACTION;
	UPDATE accounts
	SET balance = balance - amount
	WHERE id = account_id;
	if (SELECT COUNT(*) FROM accounts WHERE id = account_id) <> 1
	then 
		 SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid account';
		 ROLLBACK;
	END if;
	COMMIT;
END
$$

CALL usp_withdraw_money (4,400);
SELECT * FROM accounts;


-- zadacha - uwelichavane na zaplati v okazan departament
USE soft_uni

DELIMITER $$
CREATE PROCEDURE usp_rise_salaries(department_name VARCHAR(50))
BEGIN
	UPDATE employees AS e
	JOIN departments AS d ON d.department_id = e.department_id
	SET e.salary = e.salary * 1.05
	WHERE d.name = department_name;
END $$

CALL usp_rise_salaries('Engineering');


-- uvelichavane na zaplata na okazano id
DELIMITER $$
CREATE PROCEDURE usp_rise_salaries_by_id (id INT)
BEGIN 
	START TRANSACTION;
	if ( (SELECT COUNT(employee_id) FROM employees WHERE employee_id = id) <> 1)
	then ROLLBACK;
	ELSE
		UPDATE employees AS e
		SET salary = salary * 1.05
		WHERE e.employee_id = id;
	END if;
END $$

CALL usp_rise_salaries_by_id(7);
SELECT employee_id, salary FROM employees



-- 07.4
USE soft_uni

CREATE TABLE employees_projects_history(
	employee_id INT NOT NULL,
	project_id INT NOT NULL,
	PRIMARY KEY (employee_id, project_id)
);

DELIMITER $$
CREATE TRIGGER tr_delete_records
AFTER DELETE
ON employees_projects
FOR EACH ROW
BEGIN 
	INSERT INTO employees_projects_history (employee_id, project_id)
				VALUES (OLD.employee_id, OLD.project_id);
END $$

DELETE FROM employees_projects
WHERE employee_id = 4

SELECT * FROM employees_projects
SELECT * FROM employees_projects_history


