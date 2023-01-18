USE soft_uni

-- Problem 1.
SELECT e.employee_id, e.job_title, e.address_id, a.address_text FROM employees AS e
JOIN addresses AS a ON e.address_id = a.address_id
ORDER BY e.address_id
LIMIT 5;

-- Problem 2.
SELECT e.employee_id, e.first_name, e.last_name, d.name FROM employees AS e
JOIN departments AS d ON e.department_id = d.department_id
WHERE d.name = "Sales"
ORDER BY employee_id DESC;

-- Problem 3.
SELECT e.employee_id, e.first_name, e.salary, d.name FROM employees AS e
JOIN departments AS d ON e.department_id = d.department_id
WHERE e.salary > 15000
ORDER BY e.department_id DESC
LIMIT 5;