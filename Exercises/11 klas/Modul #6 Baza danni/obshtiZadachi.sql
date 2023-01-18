USE soft_uni
SET GLOBAL log_bin_trust_function_creators = 1

-- Problem 2.
DELIMITER $$
CREATE PROCEDURE usp_get_employees_salary_above_35000 ()
BEGIN 
	START TRANSACTION;
	SELECT first_name, last_name FROM employees AS e
	WHERE e.salary > 35000
	ORDER BY first_name, last_name;
END $$

CALL usp_get_employees_salary_above_35000 ();


-- Problem 3.
DELIMITER $$
CREATE PROCEDURE usp_get_employees_salary_above (salaryVal DOUBLE)
BEGIN 
	START TRANSACTION;
	SELECT first_name, last_name FROM employees
	WHERE salary >= salaryVal
	ORDER BY first_name, last_name;
END $$

CALL usp_get_employees_salary_above(48100);



-- Problem 4.
DELIMITER $$
CREATE PROCEDURE usp_get_towns_starting_with(start_letters VARCHAR(10))
BEGIN 
	SELECT `name` AS town_name FROM towns
	WHERE LEFT(`name`, LENGTH(start_letters)) = start_letters
	ORDER BY `name`;
END $$

CALL usp_get_towns_starting_with('b');

-- Problem 5.
DELIMITER $$
CREATE PROCEDURE usp_get_employees_from_town(town_name VARCHAR(20))
BEGIN
	SELECT first_name, last_name FROM employees e
	JOIN addresses AS a ON a.address_id = e.address_id
	JOIN towns AS t ON t.town_id = a.town_id
	WHERE t.name = town_name
	ORDER BY first_name, last_name;
END $$

CALL usp_get_employees_from_town('Sofia');



-- Problem 6.
DELIMITER $$
CREATE FUNCTION ufn_is_word_comprised(letters VARCHAR(50), word VARCHAR(20))
RETURNS VARCHAR(50)
BEGIN
	DECLARE a INT DEFAULT 0;
	while a < LENGTH(word)	do
		SET a = a+1;
		if (LOCATE(LOWER(SUBSTRING(`word`, a, 1)),LOWER(Letters)) <= 0)
		then RETURN FALSE;
		END if;
	END while;
	RETURN TRUE;
END $$

SELECT ufn_is_word_comprised('Oistmiahf',	'Sofia') AS 'IS_COMPR';