USE soft_uni

-- Problem 2.
(SELECT first_name, last_name, "manager" AS `position`, salary FROM employees
WHERE employee_id IN (SELECT DISTINCT manager_id FROM employees
								WHERE manager_id IS NOT NULL)
ORDER BY salary DESC, first_name, last_name LIMIT 3)
UNION 
(SELECT first_name, last_name, "employee", salary FROM employees
WHERE employee_id NOT IN (SELECT DISTINCT manager_id FROM employees
									WHERE manager_id IS NOT NULL)
ORDER BY salary DESC, first_name, last_name LIMIT 3)


-- Problem 3.
(SELECT mountain_range,  
       (SELECT peak_name FROM peaks WHERE mountain_id = m.id ORDER by elevation DESC LIMIT 1) peak_name,
       (SELECT elevation FROM peaks WHERE mountain_id = m.id ORDER by elevation DESC LIMIT 1) elevation
 from mountains m  
 WHERE id IN (SELECT mountain_id FROM mountains_countries WHERE country_code = 'BG')
   AND id IN (SELECT DISTINCT mountain_id FROM peaks))
UNION
(SELECT mountain_range, "no",  "info"
 from mountains m  
 WHERE id IN (SELECT mountain_id FROM mountains_countries WHERE country_code = 'BG')
   AND NOT EXISTS (SELECT 1 FROM peaks WHERE mountain_id = m.id))
ORDER BY mountain_range