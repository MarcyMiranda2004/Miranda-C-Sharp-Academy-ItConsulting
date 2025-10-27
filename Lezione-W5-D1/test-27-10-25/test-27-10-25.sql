CREATE TABLE Libri (
   id INT,
   titolo VARCHAR(100),
   autore VARCHAR(100),
   genere VARCHAR(50),
   anno_pubblicazione INT,
   prezzo DECIMAL(6,2)
);

CREATE TABLE Vendite (
   id INT,
   id_libro INT,
   data_vendita DATE,
   quantita INT,
   negozio VARCHAR(100)
);

-- Inserimenti per la tabella Libri
INSERT INTO Libri (id, titolo, autore, genere, anno_pubblicazione, prezzo) VALUES
(1, 'Il Piccolo Principe', 'Antoine de Saint-Exupéry', 'Favola', 1943, 12.50),
(2, '1984', 'George Orwell', 'Distopia', 1949, 15.00),
(3, 'Harry Potter e la Pietra Filosofale', 'J.K. Rowling', 'Fantasy', 1997, 20.00),
(4, 'Il Signore degli Anelli', 'J.R.R. Tolkien', 'Fantasy', 1954, 25.00),
(5, 'La Divina Commedia', 'Dante Alighieri', 'Poetico', 1321, 18.50),
(6, 'Orgoglio e Pregiudizio', 'Jane Austen', 'Romanzo', 1813, 14.00),
(7, 'Il Nome della Rosa', 'Umberto Eco', 'Giallo', 1980, 22.00),
(8, 'Il Codice Da Vinci', 'Dan Brown', 'Thriller', 2003, 19.50),
(9, 'La Coscienza di Zeno', 'Italo Svevo', 'Romanzo', 1923, 16.00),
(10, 'Il Gattopardo', 'Giuseppe Tomasi di Lampedusa', 'Romanzo Storico', 1958, 17.50);

-- Inserimenti per la tabella Vendite
INSERT INTO Vendite (id, id_libro, data_vendita, quantita, negozio) VALUES
(1, 1, '2025-01-10', 3, 'Libreria Centrale'),
(2, 2, '2025-01-12', 2, 'Libreria Moderna'),
(3, 3, '2025-02-05', 5, 'Libreria Centrale'),
(4, 4, '2025-02-20', 1, 'Libreria Mondadori'),
(5, 5, '2025-03-12', 4, 'Libreria Moderna'),
(6, 6, '2025-03-18', 2, 'Libreria Feltrinelli'),
(7, 7, '2025-04-22', 1, 'Libreria Mondadori'),
(8, 8, '2025-05-30', 3, 'Libreria Feltrinelli'),
(9, 9, '2025-06-14', 2, 'Libreria Centrale'),
(10, 10, '2025-07-01', 1, 'Libreria Moderna');

/* Ess1 */
SELECT l.titolo, l.autore, v.data_vendita, v.negozio
FROM libri l
INNER JOIN Vendite v ON l.id = v.id_libro
WHERE LOWER(l.autore) LIKE '%italo%';

/* Ess2 */
SELECT l.titolo, l.anno_pubblicazione, l.prezzo, v.data_vendita
FROM libri l
LEFT JOIN vendite v ON l.id = v.id_libro
WHERE l.anno_pubblicazione BETWEEN 2000 AND 2010;

/* Ess3 */
SELECT v.negozio, l.titolo, v.quantita, (v.quantita * l.prezzo) AS prezzo_totale
FROM libri l
INNER JOIN vendite v ON l.id = v.id_libro
WHERE v.negozio IN ('Libreria Centrale', 'BookFeltrinelli');

/* Ess4 */
SELECT l.titolo, v.data_vendita, l.prezzo, v.quantita
FROM libri l
RIGHT JOIN vendite v ON l.id = v.id_libro
WHERE v.data_vendita BETWEEN '2025-01-01' AND '2025-04-01'
AND LOWER(v.negozio) LIKE '%centrale%';

/* Ess5 */
SELECT l.titolo, l.autore, l.prezzo, v.data_vendita
FROM libri l
INNER JOIN vendite v ON l.id = v.id_libro
WHERE l.genere IN ('Fantasy', 'Thriller' 'Giallo') 
AND l.anno_pubblicazione > 1900
AND v.negozio LIKE '%Mondadori%'
ORDER BY v.data_vendita ASC















