Create database Activity_DS;
use Activity_DS;

Create table tbl_Usuario(

	idUser int primary key identity(1,1),
	nome varchar(50) Not null,
	email varchar(100) Not null unique,
	nick varchar(50) Not null unique,
	senha varchar(50) Not null,
	tipo varchar(50) Not null DEFAULT 'Cliente',
	ativo varchar(10) Not null DEFAULT 'Ativo',
	cpf varchar(14) Not null unique,


);
CREATE TABLE tbl_Produto(

	idProduto int primary key identity(1,1),
	codBarras varchar(20) not null unique,
	nome varchar(50) not null,
	preco decimal(10,2) not null,
	estoque int not null,
	unidade decimal (10,2) not null,
	tipo varchar(10) not null,
	ativo bit not null,
	imagem varchar(100) not null

);


Select * from tbl_Produto;

DELETE tbl_Produto;