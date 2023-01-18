SELECT e.first_name, e.last_name, t.name AS town, a.address_text FROM employees AS e
JOIN addresses AS a ON e.address_id = a.address_id
JOIN towns AS t ON a.town_id = t.town_id
ORDER BY e.first_name, e.last_name
LIMIT 5;



SELECT first_name, last_name, hire_date, `name` FROM employees AS e
JOIN departments AS d ON e.department_id = d.department_id
								AND DATE(hire_date) >'1999-1-1'
								AND `name` IN ('Sales', 'Finance')
ORDER BY hire_date