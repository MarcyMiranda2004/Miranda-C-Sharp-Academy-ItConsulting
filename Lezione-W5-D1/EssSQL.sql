SELECT * 
FROM city
WHERE CountryCode IN ('USA');

SELECT Name
FROM city
WHERE Population BETWEEN 50000 AND 100000;

/* inner */
SELECT city.Name, country.Name, city.CountryCode
FROM city
INNER JOIN country ON city.Name = country.Name;

/* inner */
SELECT city.ID, country.Name
FROM city
INNER JOIN country ON country.Name = country.Name;

/* left - right */
/* qui recuperiamo i nomi dei paesi con affiancato alla sinistra i nomi delle citta
che condividono il medesimo nomne del paese */
SELECT city.Name, country.Name
FROM country
LEFT JOIN city
ON country.name = city.Name
ORDER BY country.name;

/* cross */
SELECT city.Name
FROM city
CROSS JOIN country;