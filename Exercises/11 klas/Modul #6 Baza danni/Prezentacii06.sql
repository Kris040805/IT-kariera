-- Prezentaciq 06.1
USE soft_uni 



SELECT MIN(salary) FROM employees

SELECT department_id, MIN(salary) FROM employees
GROUP BY department_id 

SELECT job_title, MIN(salary) FROM employees 
GROUP BY job_title



SELECT department_id, COUNT(*), COUNT(salary), COUNT(manager_id), COUNT(middle_name)
FROM employees 
GROUP BY department_id



SELECT department_id, SUM(salary) FROM employees 
GROUP BY department_id



SELECT department_id, MAX(salary), MIN(salary), AVG(salary) FROM employees
GROUP BY department_id



SELECT e1.manager_id, e2.first_name, e2.last_name, COUNT(*) AS "Подчинени"
FROM employees AS e1
JOIN employees AS e2 ON e1.manager_id = e2.employee_id
GROUP BY e1.manager_id



SELECT department_id, SUM(salary)
FROM employees
GROUP BY department_id
ORDER BY department_id

SELECT e.department_id, `name`, COUNT(*)
FROM employees AS e 
JOIN departments AS d ON d.department_id = e.department_id
GROUP BY e.department_id




SELECT department_id, SUM(salary) AS TotslSalary
FROM employees
GROUP BY department_id
HAVING TotalSalary > 15000
ORDER BY department_id