-- ESERCIZIO DI GRUPPO
-- CREAZIONE DATABASE
CREATE DATABASE IF NOT EXISTS Libreria;
USE Libreria;

-- CREAZIONE TABELLA
CREATE TABLE IF NOT EXISTS Libri (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Autore VARCHAR(100) NOT NULL,
    Genere VARCHAR(50) NOT NULL,
    Prezzo DECIMAL(5,2),
    AnnoPubblicazione YEAR
);

-- INSERIMENTO DATI CORRETTO
INSERT INTO Libri (Nome, Autore, Genere, Prezzo, AnnoPubblicazione) VALUES
('Sapiens Da animali a dei', 'Yuval Noah Harari', 'Saggio', 19.50, 2011),
('La strada', 'Cormac McCarthy', 'Post-apocalittico', 9.99, 2006),
('Il codice Da Vinci', 'Dan Brown', 'Thriller', 13.90, 2003),
('Harry Potter e la camera dei segreti', 'J.K. Rowling', 'Fantasy', 17.50, 2009),
('Il canto delluniverso', 'Stephen Hawking', 'Saggio', 15.99, 2010),
('La verita sul caso Harry Quebert', 'Joël Dicker', 'Thriller', 18.00, 2013),
('Il trono di spade', 'George R.R. Martin', 'Fantasy', 22.50, 2011),
('La ragazza del treno', 'Paula Hawkins', 'Thriller', 14.99, 2015),
('Hunger Games', 'Suzanne Collins', 'Distopico', 16.50, 2008),
('Ready Player One', 'Ernest Cline', 'Fantascienza', 18.50, 2018);

    -- CREAZIONE 1 QUERY
    SELECT Genere, count(Nome) "Conteggio Libro", avg(Prezzo) "Prezzo Medio"
    FROM Libreria.Libri
    GROUP BY Genere
    ORDER BY Genere;

    -- CREAZIONE 2 QUERY
    SELECT * FROM Libreria.Libri
    WHERE AnnoPubblicazione > 2010
    ORDER BY AnnoPubblicazione DESC, Prezzo;

    select * from Libreria.Libri;