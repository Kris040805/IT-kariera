USE geography

-- Problem 1.
SELECT c.country_name, r.river_name FROM countries c
LEFT JOIN countries_rivers AS cr ON c.country_code = cr.country_code
LEFT JOIN rivers AS r ON cr.river_id = r.id
LEFT JOIN continents AS con ON c.continent_code = con.continent_code
WHERE con.continent_name = "Africa"
ORDER BY c.country_name 
LIMIT 5;

-- Problem 2. 
SELECT c.country_name, mc.mountain_id FROM  countries c
LEFT JOIN mountains_countries AS mc ON mc.country_code = c.country_code
WHERE mc.mountain_id IS NULL;

-- Problem 3.
