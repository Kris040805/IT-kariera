-- Подготовка за изпит. 
-- Задача Buhtig_Source_Control_Dataset


-- Problem 4. Failove bez direktorii
SELECT f1.id, f1.name, CONCAT(f1.size, 'KB') FROM files AS f1
WHERE f1.id NOT IN (
							SELECT DISTINCT f2.parent_id FROM files AS f2
							WHERE f2.parent_id IS NOT NULL
						 )
ORDER BY f1.id;