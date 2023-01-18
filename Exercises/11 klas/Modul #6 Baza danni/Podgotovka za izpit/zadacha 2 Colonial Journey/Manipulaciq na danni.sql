-- Manipulaciq na dannite 

-- Vmakvane na danni
INSERT INTO travel_cards (id, card_number, job_during_journey, colonist_id, journey_id)
		VALUES (96, '1994191458', 'Pilot', 96, 1),
				 (97, '1981222886', 'Engineer', 97, 2),
				 (98, '197090435', 'Pilot', 98, 9),
				 (99, '196318580', 'Cook', 99, 5),
				 (100, '196715685', 'Pilot', 100, 1);
				 
				 
-- Obnovqvane na danni
UPDATE journeys AS j
SET purpose =
case
	when (j.id % 2 = 0) then 'Medical'
	when (j.id % 3 = 0) then 'Technical'
	when (j.id % 5 = 0) then 'Educational'
	when (j.id % 7 = 0) then 'Military'
	ELSE purpose
END;


-- Iztrivane na danni
DELETE FROM colonists
WHERE id NOT IN (
						SELECT tc.colonist_id
						FROM travel_cards AS tc
					 )