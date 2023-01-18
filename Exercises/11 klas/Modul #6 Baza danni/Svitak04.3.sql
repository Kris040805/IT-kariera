USE soft_uni

-- Problem 1.
SELECT DISTINCT e.job_title, e.salary FROM employees e
WHERE e.salary = 
		(SELECT es.salary FROM employees es
		WHERE es.job_title = e.job_title
		ORDER BY es.salary DESC LIMIT 1)
ORDER BY e.salary DESC, e.job_title

SELECT * FROM departments

-- Problem 2. 
SELECT e.first_name, e.last_name, e.salary, 
			(SELECT name FROM departments d
			WHERE e.department_id = d.department_id
			LIMIT 1) AS department
FROM employees e
WHERE e.salary = 
				(SELECT e2.salary FROM employees e2
				WHERE e2.department_id = e.department_id
				ORDER BY e2.salary ASC
				LIMIT 1)
ORDER BY salary, first_name, last_name 