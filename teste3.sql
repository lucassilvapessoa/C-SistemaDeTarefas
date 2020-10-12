drop database teste3;
create database teste3;
use teste3;


create table login(
id int not null auto_increment primary key,
usuario varchar(200),
senha varchar(50)
);
create table tarefa(
id int auto_increment primary key,
descricao_tarefa varchar(300),
tipo varchar(10),
id_cliente int not null,
foreign key(id_cliente) references login (id)
);

select * FROM login;