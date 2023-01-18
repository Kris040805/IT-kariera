-- Подготовка за изпит. 
-- Задача Buhtig_Source_Control_Dataset


-- Problem 3. Problems and users
SELECT i.id, CONCAT(u.username, ' : ', i.title) FROM issues i
JOIN users AS u ON u.id = i.assignee_id
ORDER BY i.id DESC;