-- Zaqvki

-- Problem 05. Izvlichane na vsichki karti za patuvane
SELECT card_number, job_during_journey FROM travel_cards tc
ORDER BY card_number	


-- Problem 06. Izvlechete vsichki kolonisti
SELECT id, CONCAT(first_name, ' ', last_name) AS full_name, ucn FROM colonists
ORDER BY first_name, last_name, id


-- Problem 07. Izvlechete vsichki voenni patuvaniq
SELECT id, journey_start, journey_end FROM journeys 
WHERE purpose = 'Military'
ORDER BY journey_start


-- Problem 08. Izvlechete vsichki piloti
SELECT c.id, CONCAT(c.first_name, ' ', c.last_name) AS full_name FROM colonists c
JOIN travel_cards AS tc ON tc.colonist_id = c.id
WHERE tc.job_during_journey = 'Pilot'
ORDER BY id


-- Problem 09. Izteglete nai barziq kosmicheski korab
SELECT s.`name` AS spaceship_name, spa.name AS spaceport_name FROM spaceships s
JOIN journeys AS j ON j.spaceship_id=s.id
JOIN spaceports AS spa ON spa.id = j.destination_spaceport_id
ORDER BY s.light_speed_rate DESC
LIMIT 1


-- Problem 10. Извлечете всички образователни мисии и космически кораби
SELECT p.name AS planet_name, s.name AS spaceport_name FROM planets p
JOIN spaceports AS s ON s.planet_id = p.id
JOIN journeys AS j ON j.destination_spaceport_id = s.id
WHERE j.purpose = 'Educational'
ORDER BY s.name DESC


-- Problem 11. Извлечете всички планети и тяхното пътуване
SELECT p.name AS planet_name, COUNT(j.id) AS journeys_count FROM planets p
JOIN spaceports AS s ON s.planet_id = p.id
JOIN journeys AS j ON j.destination_spaceport_id = s.id
GROUP BY p.name
ORDER BY journeys_count DESC, p.name ASC