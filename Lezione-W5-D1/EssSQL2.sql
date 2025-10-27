/* Ess1 */
CREATE TABLE Clienti (
id INT,
nome VARCHAR(100),
cognome VARCHAR(100),
email VARCHAR(100),
eta INT,
citta VARCHAR(100)
);

INSERT INTO Clienti (id, nome, cognome, email, eta, citta) VALUES
(1, 'Luca', 'Bianchi', 'luca.bianchi@gmail.com', 28, 'Milano'),
(2, 'Giulia', 'Rossi', 'giulia.rossi@example.com', 25, 'Roma'),
(3, 'Marco', 'Esposito', 'marco.esposito@gmail.com', 31, 'Napoli'),
(4, 'Sara', 'Conti', 'sara.conti@example.com', 22, 'Torino'),
(5, 'Alessandro', 'Greco', 'alessandro.greco@example.com', 35, 'Firenze'),
(6, 'Chiara', 'Russo', 'chiara.russo@example.com', 27, 'Bologna'),
(7, 'Francesco', 'Romano', 'francesco.romano@example.com', 29, 'Genova'),
(8, 'Elena', 'Marino', 'elena.marino@example.com', 24, 'Palermo'),
(9, 'Davide', 'Galli', 'davide.galli@example.com', 33, 'Verona'),
(10, 'Martina', 'Ferrari', 'martina.ferrari@example.com', 26, 'Bari'),
(11, 'Simone', 'Moretti', 'simone.moretti@example.com', 32, 'Padova'),
(12, 'Valentina', 'Ricci', 'valentina.ricci@example.com', 21, 'Catania'),
(13, 'Matteo', 'Lombardi', 'matteo.lombardi@example.com', 40, 'Trieste'),
(14, 'Federica', 'Rinaldi', 'federica.rinaldi@example.com', 34, 'Parma'),
(15, 'Giorgio', 'De Luca', 'giorgio.deluca@gmail.com', 30, 'Salerno'),
(16, 'Beatrice', 'Leone', 'beatrice.leone@example.com', 23, 'Pisa'),
(17, 'Tommaso', 'Serra', 'tommaso.serra@example.com', 36, 'Modena'),
(18, 'Laura', 'Costa', 'laura.costa@example.com', 28, 'Perugia'),
(19, 'Emanuele', 'Ferri', 'emanuele.ferri@example.com', 37, 'Livorno'),
(20, 'Ilaria', 'Grassi', 'ilaria.grassi@example.com', 25, 'Ancona');

/* 1 */
SELECT 	*
FROM clienti
WHERE email LIKE '%gmail%';

/* 2 */
SELECT * 
FROM clienti
WHERE email LIKE '%@gmail.com';

/* 3 */
SELECT *
FROM clienti
WHERE nome LIKE '%A%';

/* 4 */
SELECT *
FROM clienti
WHERE nome LIKE 'A%';

/* 5 */
SELECT *
FROM clienti
WHERE LENGTH(cognome) = 5;

/* 6 */
SELECT *
FROM clienti
WHERE CHAR_LENGTH(cognome) = 5;

/* 7 */
SELECT *
FROM clienti
WHERE eta BETWEEN 31 AND 39
ORDER BY eta ASC;

/* 7 */
SELECT *
FROM clienti
WHERE eta BETWEEN 30 AND 40
ORDER BY eta ASC;

/* 8 */
SELECT *
FROM clienti
WHERE lower(citta) LIKE '%roma%';

/* Ess2 */
CREATE TABLE Clienti2 (
id INT,
nome VARCHAR(100),
citta VARCHAR(100)
);

CREATE TABLE Ordini (
id INT,
id_cliente INT,
data_ordine DATE,
importo DECIMAL(7,2)
);

-- Inserimenti per la tabella Clienti2
INSERT INTO Clienti2 (id, nome, citta) VALUES
(1, 'Luca Rossi', 'Napoli'),
(2, 'Maria Bianchi', 'Roma'),
(3, 'Giovanni Verdi', 'Milano'),
(4, 'Francesca Neri', 'Torino'),
(5, 'Antonio Esposito', 'Napoli'),
(6, 'Laura Romano', 'Firenze'),
(7, 'Paolo Gallo', 'Bologna'),
(8, 'Sara Ferri', 'Genova'),
(9, 'Marco Conte', 'Venezia'),
(10, 'Elena Greco', 'Palermo');

-- Inserimenti per la tabella Ordini
INSERT INTO Ordini (id, id_cliente, data_ordine, importo) VALUES
(1, 1, '2025-01-10', 150.50),
(2, 2, '2025-02-15', 220.00),
(3, 3, '2025-03-05', 75.90),
(4, 4, '2025-04-20', 300.00),
(5, 5, '2025-05-12', 180.75),
(6, 6, '2025-06-18', 99.99),
(7, 7, '2025-07-22', 450.00),
(8, 8, '2025-08-30', 250.20),
(9, 9, '2025-09-14', 130.00),
(10, 10, '2025-10-01', 175.60);

/* 1 - Inner */
SELECT clienti2.nome, ordini.data_ordine, ordini.importo
FROM clienti2
INNER JOIN ordini ON clienti2.id = ordini.id_cliente;

/* 2 - Left */
SELECT clienti2.nome, ordini.data_ordine, ordini.importo
FROM clienti2
LEFT JOIN ordini ON clienti2.id = ordini.id_cliente;

/* 3 - Right */
SELECT clienti2.nome, ordini.data_ordine, ordini.importo
FROM clienti2
RIGHT JOIN ordini ON clienti2.id = ordini.id_cliente;

/* Ess3 */

/*
Elenca i clienti attivi, cioè quelli che hanno effettuato almeno un ordine, 
mostrando per ciascuno:

Nome del cliente
Totale ordini effettuati
Somma totale degli importi spesi
*/
/* 1 - Inner */
SELECT clienti2.nome, 
	COUNT(ordini.id) AS totale_ordini, 
	SUM(ordini.importo) AS somma_ordini
FROM clienti2
INNER JOIN ordini ON clienti2.id = ordini.id_cliente
GROUP BY clienti2.nome;

/*
Elenca i clienti inattivi, cioè quelli che non hanno mai effettuato ordini, 
mostrando solo:

Nome del cliente
Città di residenza
*/
/* 2 - LEFT */
SELECT clienti2.nome, clienti2.citta
FROM clienti2 
LEFT JOIN ordini ON clienti2.id = ordini.id_cliente
WHERE ordini.id IS NULL;


/*
Individua gli ordini orfani, cioè ordini presenti in tabella 
ma senza un cliente valido associato (es. cliente cancellato), 
e mostra:

ID dell'ordine
Data dell'ordine
Importo
(Cliente = NULL)
*/
/* 3 - RIGHT */
SELECT  ordini.id AS id_ordine, ordini.data_ordine, ordini.importo
FROM clienti2
RIGHT JOIN ordini ON clienti2.id = ordini.id_cliente
WHERE clienti2.id IS NULL;



