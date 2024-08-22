use master;
GO

CREATE DATABASE EcommerceCore;

USE EcommerceCore;
GO



CREATE TABLE Categories (
    CategoryID int identity(1,1) primary key,
    CategoryName varchar(225),
    CategoryImage varchar(225)
);

CREATE TABLE Products (
    ProductID int identity(1,1) primary key,
    ProductName varchar(225), 
    Description varchar(225),
    Price int,
    CategoryID int,
    ProductImage varchar(MAX),
	FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);




INSERT INTO Categories (CategoryName, CategoryImage)
VALUES ('Electronics', 'electronics.jpg'),
       ('Books', 'books.jpg'),
       ('Clothing', 'clothing.jpg'),
       ('Home Appliances', 'home_appliances.jpg'),
       ('Toys', 'toys.jpg');

INSERT INTO Products (ProductName, Description, Price, CategoryID, ProductImage)
VALUES ('Laptop', 'High-performance laptop', 1000, 1, 'laptop.jpg'),
       ('Smartphone', 'Latest model smartphone', 700, 1, 'smartphone.jpg'),
       ('Novel', 'Bestselling novel', 20, 2, 'novel.jpg'),
       ('Textbook', 'Educational textbook', 50, 2, 'textbook.jpg'),
       ('T-Shirt', 'Comfortable cotton t-shirt', 20, 3, 'tshirt.jpg'),
       ('Jacket', 'Warm winter jacket', 120, 3, 'jacket.jpg'),
       ('Blender', 'Multi-function blender', 80, 4, 'blender.jpg'),
       ('Microwave', 'Compact microwave oven', 150, 4, 'microwave.jpg'),
       ('Toy Car', 'Remote-controlled toy car', 35, 5, 'toy_car.jpg'),
       ('Doll', 'Fashion doll with accessories', 30, 5, 'doll.jpg');