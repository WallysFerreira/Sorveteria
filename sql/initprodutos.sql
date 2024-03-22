CREATE DATABASE IF NOT EXISTS Products;

USE Products;

CREATE TABLE IF NOT EXISTS Products (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    category varchar(20),
    name varchar(30),
    price float,
    description varchar(50),
    pic_url varchar(20)
);