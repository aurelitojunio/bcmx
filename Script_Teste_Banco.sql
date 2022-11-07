/************************************************************************/
--> Preparando o ambiente

IF OBJECT_ID('dbo.CLIENTE') IS NOT NULL
	DROP TABLE dbo.CLIENTE
CREATE TABLE CLIENTE (
	ID_CLIENTE INT PRIMARY KEY IDENTITY NOT NULL,
	NOME VARCHAR(255) NOT NULL
)
GO

IF OBJECT_ID('dbo.PRODUTO') IS NOT NULL
	DROP TABLE dbo.PRODUTO
CREATE TABLE PRODUTO (
	ID_PRODUTO INT PRIMARY KEY IDENTITY NOT NULL,
	DESCRICAO VARCHAR(255) NOT NULL,
	PRECO_UNITARIO DECIMAL(10,2) NOT NULL,
	QUANTIDADE DECIMAL(10,2) NULL
)
GO


IF OBJECT_ID('dbo.PEDIDO') IS NOT NULL
	DROP TABLE dbo.PEDIDO
CREATE TABLE PEDIDO (
	ID_PEDIDO INT PRIMARY KEY IDENTITY NOT NULL,
	ID_CLIENTE INT FOREIGN KEY REFERENCES CLIENTE(ID_CLIENTE) NOT NULL,
	DATA_PEDIDO DATETIME NOT NULL
)
GO

IF OBJECT_ID('dbo.ITEM_PEDIDO') IS NOT NULL
	DROP TABLE dbo.ITEM_PEDIDO
CREATE TABLE ITEM_PEDIDO (
	NUM_ITEM INT PRIMARY KEY IDENTITY NOT NULL,
	ID_PEDIDO INT FOREIGN KEY REFERENCES PEDIDO(ID_PEDIDO) NOT NULL,
	ID_PRODUTO INT FOREIGN KEY REFERENCES PRODUTO(ID_PRODUTO) NOT NULL,
	PRECO_UNITARIO DECIMAL(10,2) NOT NULL,
	QUANTIDADE DECIMAL(10,2) NOT NULL
)
GO

/************************************************************************/
--> Inserindo dados Fakes
INSERT INTO CLIENTE(NOME)
VALUES ('Aurelito'), ('Carlo'), ('Ricardo')
GO

INSERT INTO PRODUTO(DESCRICAO, PRECO_UNITARIO, QUANTIDADE)
VALUES -- ="('"&&"', "&&", 1),"
	('Produto1', 1950.90, 1),
	('Produto2', 6500.00, 1),
	('Produto3', 450.00, 1),
	('Produto4', 900.00, 1),
	('Produto5', 1500.00, 1),
	('Produto6', 700.00, 1),
	('Produto7', 800.00, 1),
	('Produto8', 1200.00, 1),
	('Produto9', 1800.00, 1),
	('Notebook', 1300.00, 1)
GO


INSERT INTO PEDIDO(ID_CLIENTE, DATA_PEDIDO)
VALUES 
(1, '2012-05-01'),
(2, '2012-05-01'),
(3, '2015-05-01')


INSERT INTO ITEM_PEDIDO(ID_PEDIDO, ID_PRODUTO, PRECO_UNITARIO, QUANTIDADE)
VALUES (1, 5, 500.00, 2)
	, (1, 2, 200.00, 3)
	, (2, 1, 1200.00, 5)
	, (3, 10, 250.00, 10)

SELECT * FROM CLIENTE
SELECT * FROM PRODUTO
SELECT * FROM PEDIDO
SELECT * FROM ITEM_PEDIDO


/************************************************************************/
/****** RESOLUÇÃO DAS QUESTÕES ******************************************/
/************************************************************************/

--> Questão 1 (Resposta)

SELECT 
	ped.ID_PEDIDO
	, ped.DATA_PEDIDO
	, cli.NOME
	, SUM(itm.PRECO_UNITARIO * itm.QUANTIDADE) AS VALOR_TOTAL
FROM ITEM_PEDIDO itm
INNER JOIN PEDIDO ped ON itm.ID_PEDIDO = ped.ID_PEDIDO
INNER JOIN CLIENTE cli ON ped.ID_CLIENTE = cli.ID_CLIENTE
WHERE YEAR(DATA_PEDIDO) = 2012
GROUP BY ped.ID_PEDIDO
	, ped.DATA_PEDIDO
	, cli.NOME
ORDER BY DATA_PEDIDO

/************************************************************************/
--> Questão 2 (Resposta)

INSERT INTO PRODUTO(DESCRICAO, PRECO_UNITARIO)
VALUES ('Smart TV', 1950.90)
GO

/************************************************************************/
--> Questão 3 (Resposta)

UPDATE PRODUTO
SET DESCRICAO = 'Notebook'
WHERE ID_PRODUTO = 10
GO

/************************************************************************/
