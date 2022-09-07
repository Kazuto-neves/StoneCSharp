CREATE DATABASE Loja;

USE Loja;

CREATE TABLE Categoria(
	Id_Categoria int identity primary key,
	Descricao varchar(64) not null
)

CREATE TABLE SubCategoria(
	Id_SubCategoria int identity primary key,
	Descricao varchar(64) not null,
	Id_Categoria int not null,
	foreign key (Id_Categoria) references Categoria(Id_Categoria)
)

CREATE TABLE Product(
	Id_Product int identity primary key,
	Nome varchar(64) not null,
	Qtd_Total int not null,
	Id_SB int null,
	foreign key (Id_SB) references SubCategoria(Id_SubCategoria)
)

CREATE TABLE Compra(
	Id_Compra int identity primary key,
	Qtd_Compra int not null,
	Preco decimal(6,2) not null,
	Cancelado tinyint not null,
	Id_Product int not null,
	foreign key (Id_Product) references Product(Id_Product)
)

CREATE TABLE Venda(
	Id_Venda int identity primary key,
	Qtd_Venda int not null,
	Preco decimal(6,2) not null,
	Cancelado tinyint not null,
	Id_Product int not null,
	foreign key (Id_Product) references Product(Id_Product)
)

