USE soft_uni;

-- Problem 1. и 2. са решени в Svitak03.03

-- Problem 3.
SELECT employee_id AS id,
		 first_name AS 'First Name',
		 last_name AS 'Last Name',
		 middle_name AS 'Middle Name'
FROM employees
ORDER BY salary DESC, first_name ASC, last_name DESC, middle_name ASC

-- Problem 4., 5., 6. и 7. са решени в Svitak03.03

-- Problem 8.
USE geography;

SELECT country_name, country_code,
		-- I начин:	
		-- if	(currency_code = 'EUR', 'Euro', 'Not Euro') AS currency
		-- II начин:
CASE
	when currency_code = 'EUR' 
	then 'Euro'
	ELSE 'Not Euro' 
END AS currency
FROM countries
ORDER BY country_name ASC;