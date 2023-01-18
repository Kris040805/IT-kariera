-- Подготовка за изпит. 
-- Задача Buhtig_Source_Control_Dataset


-- Problem 5. Aktivni hranilishta
SELECT r.id, r.name, COUNT(i.id) FROM repositories AS r
JOIN issues AS i ON i.repository_id = r.id
GROUP BY i.repository_id
ORDER BY COUNT(i.id) DESC, r.id ASC
LIMIT 5;