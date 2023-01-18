USE geography

SELECT capital AS `name` FROM countries
UNION
SELECT country_name FROM countries


SELECT capital AS `name` FROM countries
UNION ALL
SELECT country_name FROM countries


SELECT mountain_range AS `mountain_name` FROM mountains
UNION ALL
SELECT peak_name FROM peaks


SELECT river_name AS `Rivers and mounatins` FROM rivers
WHERE id IN (
		SELECT river_id FROM countries_rivers
		WHERE country_code='BG')
UNION
SELECT mountain_range FROM mountains
WHERE id IN (
		SELECT mountain_id FROM mountains_countries
		WHERE country_code='BG')
		
		
(SELECT river_name AS `Rivers and mountains` FROM rivers
	ORDER BY `length` DESC LIMIT 3)
UNION 
(SELECT peak_name FROM peaks
	ORDER BY elevation DESC LIMIT 3)
ORDER BY `Rivers and mountains`