-- Problem 1.
SELECT e.first_name, e.last_name, t.name AS town, a.address_text FROM employees e
JOIN addresses AS a ON e.address_id = a.address_id
JOIN towns AS t ON a.town_id = t.town_id
ORDER BY first_name, last_name
LIMIT 5;

-- Problem 2.
SELECT e.first_name, e.last_name, e.hire_date, d.name AS dept_name FROM employees e
JOIN departments AS d ON e.department_id = d.department_id
								AND d.name IN ('Finance', 'Sales')
								AND DATE(hire_date) > '1999-1-1'
ORDER BY hire_date

-- Problem 3.
SELECT e.employee_id, e.first_name, p.name AS project_name FROM employees e
JOIN employees_projects AS ep ON e.employee_id = ep.employee_id
JOIN projects AS p ON ep.project_id = p.project_id
							AND DATE(p.start_date) > '2002-08-13'
							AND DATE(p.end_date) IS NULL
ORDER BY e.first_name, p.name

-- Problem 4.