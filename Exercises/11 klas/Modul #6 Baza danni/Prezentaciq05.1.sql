USE geography

SELECT mountain_range, peak_name, elevation FROM peaks AS p
JOIN mountains AS m ON p.mountain_id = m.id
WHERE mountain_range = "Rila"
ORDER BY elevation DESC



SELECT mountain_range, peak_name, elevation FROM peaks AS p
JOIN mountains AS m ON p.mountain_id = m.id
JOIN mountains_countries AS mc ON m.id = mc.mountain_id
WHERE country_code = "BG"
ORDER BY elevation DESC



SELECT country_name, mountain_range, peak_name, elevation FROM peaks AS p
JOIN mountains AS m ON p.mountain_id = m.id
JOIN mountains_countries AS mc ON m.id = mc.mountain_id
JOIN countries AS c ON mc.country_code = c.country_code
ORDER BY elevation DESC