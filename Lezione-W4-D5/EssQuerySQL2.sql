SELECT Name AS nome
FROM world.city AS Citta;

SELECT MAX(Name)
FROM world.city
WHERE CountryCode = 'USA';

SELECT MIN(Name)
FROM world.city
WHERE CountryCode = 'USA';

SELECT COUNT(Name) 
FROM world.city
WHERE CountryCode = 'USA'; 

/* ---------------- */


/*
Si consideri una tabella chiamata Vendite con la seguente struttura, almeno 20 elementi generati: SQL 
1. Vendite 
2. id INT, 
3. prodotto VARCHAR(100), 
4. categoria VARCHAR(50), 
5. quantita INT, 
6. prezzo_unitario DECIMAL(6,2), 
7. data_vendita DATE 
8. Scrivi le query SQL per rispondere alle seguenti richieste: Totale vendite per categoria Visualizza, 
per ogni categoria, il numero totale di vendite effettuate. Prezzo medio per categoria Mostra, per ogni categoria, 
il prezzo medio dei prodotti venduti. Quantità totale venduta per ogni prodotto Mostra il totale delle quantità vendute (SUM) per ciascun prodotto. 
Prezzo massimo e minimo venduto nella tabella Mostra il prezzo massimo e il prezzo minimo tra tutti i prodotti venduti. Numero totale di righe nella 
tabella Conta quante vendite sono state registrate nella tabella Vendite. I 5 prodotti più costosi (in base al prezzo_unitario) Elenca i 5 prodotti più 
costosi ordinati in modo decrescente rispetto al prezzo. I 3 prodotti meno venduti per quantità totale Mostra i nomi dei 3 prodotti con la quantità totale 
più bassa venduta (usa SUM e LIMIT).
*/



CREATE TABLE Vendite (
    id INT PRIMARY KEY,
    prodotto VARCHAR(100),
    categoria VARCHAR(50),
    quantita INT,
    prezzo_unitario DECIMAL(6,2),
    data_vendita DATE
);

INSERT INTO Vendite (id, prodotto, categoria, quantita, prezzo_unitario, data_vendita)
VALUES
(1, 'Laptop HP', 'Informatica', 3, 799.99, '2024-01-15'),
(2, 'Mouse Logitech', 'Informatica', 10, 25.50, '2024-02-03'),
(3, 'Tastiera Meccanica', 'Informatica', 5, 59.90, '2024-02-10'),
(4, 'Smartphone Samsung', 'Elettronica', 4, 899.00, '2024-03-12'),
(5, 'Televisore LG', 'Elettronica', 2, 1200.00, '2024-03-20'),
(6, 'Frullatore Philips', 'Elettrodomestici', 7, 85.00, '2024-04-02'),
(7, 'Aspirapolvere Dyson', 'Elettrodomestici', 3, 450.00, '2024-04-15'),
(8, 'Forno a microonde', 'Elettrodomestici', 4, 150.00, '2024-04-20'),
(9, 'Libro "Il Codice Da Vinci"', 'Libreria', 8, 15.90, '2024-05-01'),
(10, 'Libro "1984"', 'Libreria', 12, 12.50, '2024-05-05'),
(11, 'Romanzo "It"', 'Libreria', 6, 18.00, '2024-05-07'),
(12, 'Maglietta Nike', 'Abbigliamento', 9, 29.99, '2024-06-01'),
(13, 'Pantaloni Levi’s', 'Abbigliamento', 5, 89.90, '2024-06-05'),
(14, 'Scarpe Adidas', 'Abbigliamento', 4, 110.00, '2024-06-10'),
(15, 'Smartwatch Apple', 'Elettronica', 3, 499.00, '2024-07-01'),
(16, 'Stampante Epson', 'Informatica', 2, 180.00, '2024-07-12'),
(17, 'Lavatrice Samsung', 'Elettrodomestici', 1, 700.00, '2024-07-15'),
(18, 'Romanzo "Shining"', 'Libreria', 10, 17.50, '2024-08-01'),
(19, 'Giacca The North Face', 'Abbigliamento', 2, 160.00, '2024-08-10'),
(20, 'Cuffie Sony', 'Elettronica', 6, 129.00, '2024-08-15');

/* 1) Totale vendite per categoria */
SELECT categoria, COUNT(*) AS totale_vendite
FROM Vendite
GROUP BY categoria;

/* 2) Prezzo medio per categoria */
SELECT categoria, AVG(prezzo_unitario) AS prezzo_medio
FROM Vendite
GROUP BY categoria;

/* 3) Quantità totale venduta per ogni prodotto */
SELECT prodotto, SUM(quantita) AS totale_quantita
FROM Vendite
GROUP BY prodotto;

/* 4) Prezzo massimo e minimo venduto nella tabella */
SELECT 
MAX(prezzo_unitario) AS prezzo_massimo,
MIN(prezzo_unitario) AS prezzo_minimo
FROM Vendite;

/* 5) Numero totale di righe nella tabella */
SELECT COUNT(*) AS numero_totale_vendite
FROM Vendite;

/* 6) I 5 prodotti più costosi */
SELECT prodotto, prezzo_unitario
FROM Vendite
ORDER BY prezzo_unitario DESC
LIMIT 5;

/* 7) I 3 prodotti meno venduti (per quantità totale) */
SELECT prodotto, SUM(quantita) AS totale_quantita
FROM Vendite
GROUP BY prodotto
ORDER BY totale_quantita ASC
LIMIT 3;
