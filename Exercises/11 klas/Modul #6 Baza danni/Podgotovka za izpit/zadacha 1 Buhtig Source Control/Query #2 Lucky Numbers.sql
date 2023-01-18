-- Подготовка за изпит. 
-- Задача Buhtig_Source_Control_Dataset


-- Problem 2. Lucky numbers
SELECT repository_id, contributor_id FROM repositories_contributors
WHERE repository_id = contributor_id
ORDER BY repository_id;