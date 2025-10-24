SELECT city.Name, CountryCode 
FROM world.city
ORDER BY Name ASC
LIMIT 25;

SELECT city.Name, COUNT(city.ID)
FROM world.city
GROUP BY city.Name;

SELECT city.Name, COUNT(city.ID)
FROM world.city
GROUP BY city.Name
ORDER BY COUNT(city.ID) DESC;

SELECT country.Name AS Country, COUNT(city.ID) AS numero_citta
FROM world.city
JOIN world.country ON city.CountryCode = country.Code
GROUP BY country.Name
ORDER BY numero_citta DESC;

/*----------------------------------------------*/

/* ESS1 */

/*
Utilizzo di DISTINCT e WHERE Elencare, senza ripetizioni, tutte le regioni (Region) dei paesi che appartengono al continente (Continent) 'Europe'.
*/
SELECT DISTINCT Region
FROM country
WHERE Continent = 'Europe';

/* ESS2 */

/*
Combinazione di WHERE, ORDER BY Elencare i nomi (Name) e la popolazione (Population) delle città (City) degli Stati Uniti 
(CountryCode = 'USA') che hanno una popolazione superiore a 1.000.000 abitanti, 
ordinando i risultati dalla città più popolosa alla meno popolosa.
*/
SELECT Name, Population
FROM city
WHERE CountryCode = 'USA' AND Population > 1000000
ORDER BY Population DESC;

/* ESS3 */

/*
GROUP BY con funzioni di aggregazione Mostrare per ogni continente (Continent) presente nella tabella Country:
Il numero totale di paesi appartenenti a ciascun continente. 
La popolazione totale del continente. Ordinare il risultato per popolazione totale in ordine decrescente.
*/
SELECT Continent, COUNT(*) AS numero_paesi, SUM(Population) AS popolazione_totale
FROM country
GROUP BY Continent
ORDER BY popolazione_totale DESC;
