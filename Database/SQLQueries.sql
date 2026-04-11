-- SQL Queries for IMDB Project
-- 1.Get all movies with ratings
SELECT 
    t.titleID,
    t.primaryTitle,
    t.startYear,
    t.runtimeMinutes,
    r.averageRating,
    r.numVotes
FROM Titles t
LEFT JOIN Ratings r ON t.titleID = r.titleID
ORDER BY t.primaryTitle;

-- 2.Search movies by keyword
SELECT 
    t.titleID,
    t.primaryTitle,
    t.startYear,
    r.averageRating
FROM Titles t
LEFT JOIN Ratings r ON t.titleID = r.titleID
WHERE t.primaryTitle LIKE '%star%';

-- 3.Filter by genre
SELECT 
    t.titleID,
    t.primaryTitle,
    g.Name AS Genre,
    r.averageRating
FROM Titles t
INNER JOIN Title_Genres tg ON t.titleID = tg.titleID
INNER JOIN Genres g ON tg.genreID = g.genreID
LEFT JOIN Ratings r ON t.titleID = r.titleID
WHERE g.Name = 'Drama'
ORDER BY r.averageRating DESC;

-- 4.Top 10 movies
SELECT TOP 10
    t.primaryTitle,
    r.averageRating,
    r.numVotes
FROM Titles t
INNER JOIN Ratings r ON t.titleID = r.titleID
ORDER BY r.averageRating DESC, r.numVotes DESC;

-- 5.Get cast of a movie
SELECT 
    t.primaryTitle,
    n.primaryName,
    p.job_category,
    p.characters
FROM Principals p
INNER JOIN Titles t ON p.titleID = t.titleID
INNER JOIN Names n ON p.nameID = n.nameID;

-- 6.Get directors and their movies
SELECT 
    n.primaryName AS DirectorName,
    t.primaryTitle
FROM Directors d
INNER JOIN Names n ON d.nameID = n.nameID
INNER JOIN Titles t ON d.titleID = t.titleID;
