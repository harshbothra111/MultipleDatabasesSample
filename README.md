# MultipleDatabasesSample

## Objective
This is a .NET 8 Web API project with Entity Framework - Code First Approach  demonstrates access of Multiple Databases having different different DbContext and Repositories wrapped into Unit of Work pattern using Clean Architecture.

## Usage

### ConnectionStrings
Replace ConnectionStrings in API/appSettings.Development.json

### Create Database
-- Create CustomerDatabase
CREATE DATABASE CustomerDatabase;
GO

-- Use the CustomerDatabase
USE CustomerDatabase;
GO

-- Create Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(15),
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO

-- Create Addresses table
CREATE TABLE Addresses (
    AddressID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    Street NVARCHAR(255) NOT NULL,
    City NVARCHAR(100) NOT NULL,
    State NVARCHAR(100) NOT NULL,
    PostalCode NVARCHAR(10),
    Country NVARCHAR(100),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);
GO

-- Create ProductsDatabase
CREATE DATABASE ProductsDatabase;
GO

-- Use the ProductsDatabase
USE ProductsDatabase;
GO

-- Create Products table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(500),
    Price DECIMAL(10, 2) NOT NULL,
    StockQuantity INT NOT NULL
);
GO

-- Create Categories table
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) NOT NULL
);
GO

-- Add relationship between Products and Categories
ALTER TABLE Products
ADD CategoryID INT,
FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID);
GO


-- Create OrdersDatabase
CREATE DATABASE OrdersDatabase;
GO

-- Use the OrdersDatabase
USE OrdersDatabase;
GO

-- Create Orders table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10, 2) NOT NULL,
    Status NVARCHAR(50)
);
GO

-- Create OrderDetails table
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    -- Foreign key referencing Orders and Products tables
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);
GO

-- Create Payments table
CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
    PaymentDate DATETIME DEFAULT GETDATE(),
    PaymentAmount DECIMAL(10, 2) NOT NULL,
    PaymentMethod NVARCHAR(50),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);
GO

### Insert Data
-- Use CustomerDatabase
USE CustomerDatabase;
GO

-- Insert data into Customers table
INSERT INTO Customers (FirstName, LastName, Email, Phone)
VALUES 
('John', 'Doe', 'john.doe@example.com', '1234567890'),
('Jane', 'Smith', 'jane.smith@example.com', '0987654321'),
('Alice', 'Johnson', 'alice.johnson@example.com', '1122334455');

-- Insert data into Addresses table
INSERT INTO Addresses (CustomerID, Street, City, State, PostalCode, Country)
VALUES 
(1, '123 Maple St', 'New York', 'NY', '10001', 'USA'),
(2, '456 Oak St', 'Los Angeles', 'CA', '90001', 'USA'),
(3, '789 Pine St', 'Chicago', 'IL', '60601', 'USA');
GO


-- Use ProductsDatabase
USE ProductsDatabase;
GO

-- Insert data into Categories table
INSERT INTO Categories (CategoryName)
VALUES 
('Electronics'),
('Books'),
('Clothing');
GO

-- Insert data into Products table
INSERT INTO Products (ProductName, Description, Price, StockQuantity, CategoryID)
VALUES 
('Laptop', 'High-end gaming laptop', 1200.00, 10, 1),
('Smartphone', 'Latest model smartphone', 800.00, 25, 1),
('Novel', 'Fictional novel', 20.00, 100, 2),
('T-shirt', 'Cotton t-shirt', 15.00, 200, 3);
GO


-- Use OrdersDatabase
USE OrdersDatabase;
GO

-- Insert data into Orders table
INSERT INTO Orders (CustomerID, OrderDate, TotalAmount, Status)
VALUES 
(1, '2024-09-01', 2020.00, 'Completed'),
(2, '2024-09-05', 820.00, 'Pending'),
(3, '2024-09-10', 35.00, 'Shipped');

-- Insert data into OrderDetails table
INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice)
VALUES 
(1, 1, 1, 1200.00), -- Order 1, Product Laptop (ID 1)
(1, 2, 1, 800.00),  -- Order 1, Product Smartphone (ID 2)
(2, 2, 1, 800.00),  -- Order 2, Product Smartphone (ID 2)
(3, 3, 1, 20.00),   -- Order 3, Product Novel (ID 3)
(3, 4, 1, 15.00);   -- Order 3, Product T-shirt (ID 4)

-- Insert data into Payments table
INSERT INTO Payments (OrderID, PaymentDate, PaymentAmount, PaymentMethod)
VALUES 
(1, '2024-09-02', 2020.00, 'Credit Card'),
(2, '2024-09-06', 820.00, 'PayPal');
GO

### Generate Contexts
Scaffold-DbContext Name=ConnectionStrings:CustomerDatabase Microsoft.EntityFrameworkCore.SqlServer -o Databases\CustomerDatabase\Models -Context CustomerDbContext -ContextDir "Databases\CustomerDatabase"

Scaffold-DbContext Name=ConnectionStrings:OrdersDatabase Microsoft.EntityFrameworkCore.SqlServer -o Databases\OrdersDatabase\Models -Context OrderDbContext -ContextDir "Databases\OrdersDatabase"

Scaffold-DbContext Name=ConnectionStrings:ProductsDatabase Microsoft.EntityFrameworkCore.SqlServer -o Databases\ProductsDatabase\Models -Context ProductDbContext -ContextDir "Databases\ProductsDatabase"
