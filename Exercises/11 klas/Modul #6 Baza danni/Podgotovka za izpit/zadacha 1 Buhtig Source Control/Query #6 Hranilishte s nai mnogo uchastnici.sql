-- Подготовка за изпит. 
-- Задача Buhtig_Source_Control_Dataset


-- Problem 6. Hranilishte s nai mnogo uchastnici
SELECT r.id, r.name,
		(SELECT COUNT(*) FROM commits AS c WHERE c.repository_id = r.id) AS 'commits',
		(SELECT COUNT(*) FROM repositories_contributors AS rc WHERE rc.repository_id = r.id) AS `contributors`
FROM repositories AS r
ORDER BY `contributors` DESC, r.id ASC
LIMIT 1;