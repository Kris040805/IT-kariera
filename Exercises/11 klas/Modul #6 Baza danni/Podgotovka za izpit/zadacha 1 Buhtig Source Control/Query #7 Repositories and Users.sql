-- Подготовка за изпит. 
-- Задача Buhtig_Source_Control_Dataset


-- Problem 7. Repositories and Users
SELECT r.id, r.name,
		(SELECT COUNT(DISTINCT c.contributor_id) FROM commits AS c WHERE c.repository_id = r.id) AS `users`
FROM repositories r
ORDER BY `users` DESC, r.id ASC;