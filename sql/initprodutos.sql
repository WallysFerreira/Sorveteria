USE Produtos;

CREATE TABLE IF NOT EXISTS Produtos (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    categoria varchar(20),
    nome varchar(30),
    preco float,
    descricao varchar(50),
    foto varchar(20)
);