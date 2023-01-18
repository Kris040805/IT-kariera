USE soft_uni;

-- Problem 1.
SELECT first_name, last_name, salary FROM employees
WHERE salary = (SELECT salary FROM employees
						ORDER BY salary
						LIMIT 1)
						
-- Problem 2.
SELECT first_name, last_name, salary FROM employees
WHERE salary < 1.1 * (SELECT salary FROM employees
							ORDER BY salary
							LIMIT 1)
ORDER BY salary

-- Problem 3.
SELECT first_name, last_name, job_title FROM employees
WHERE employee_id IN (SELECT DISTINCT manager_id FROM employees)
ORDER BY first_name, last_name

-- Problem 4.
SELECT first_name, last_name FROM employees  
WHERE address_id in 
  (SELECT address_id FROM addresses
   WHERE town_id = 
	(select town_id from towns WHERE `name` = "San Francisco")
)
ORDER BY first_name, last_name