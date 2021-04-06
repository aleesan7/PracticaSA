use `Delivery`;

CREATE TABLE if not exists Catalog (
  idCatalog int(11) NOT NULL AUTO_INCREMENT,
  ProductName varchar(250) NOT NULL,
  ImagePath varchar(250) DEFAULT NULL,
  Description varchar(250) DEFAULT NULL,
  Price varchar(45) DEFAULT NULL,
  Discount varchar(45) DEFAULT '0',
  Category varchar(45) DEFAULT NULL,
  DateAdded datetime NOT NULL,
  PRIMARY KEY (`idCatalog`)
) ENGINE=InnoDB AUTO_INCREMENT=2;

insert into Catalog (ProductName, ImagePath, Description, Price, DateAdded) values ('Fried Chicken', 'https://i.pinimg.com/564x/90/e4/e9/90e4e9cae6ded1516d2fae45a25fe9ee.jpg', 'Delicious Fried Chicken', '15.75', now());

create table if not exists roles
(
    id   bigint auto_increment
        primary key,
    name varchar(60) null,
    constraint UK_nb4h0p6txrmfc0xbrd1kglp9t
        unique (name)
);

create table if not exists users
(
    id         bigint auto_increment
        primary key,
    created_at datetime     not null,
    updated_at datetime     not null,
    created_by bigint       null,
    updated_by bigint       null,
    email      varchar(40)  null,
    name       varchar(255) null,
    password   varchar(100) null,
    username   varchar(255)  null,
    constraint UK_sx468g52bpetvlad2j9y0lptc
        unique (email)
);

create table if not exists user_roles
(
    user_id bigint not null,
    role_id bigint not null,
    primary key (user_id, role_id),
    constraint FKh8ciramu9cc9q3qcqiv4ue8a6
        foreign key (role_id) references roles (id),
    constraint FKhfh9dx7w3ubf1co1vdev94g3f
        foreign key (user_id) references users (id)
);

insert into roles (name) values('ROLE_ADMIN');
insert into roles (name) values('ROLE_USER');


-- ----------TABLA ORDENES
CREATE TABLE IF NOT EXISTS ORDEN (

    orden_id     int auto_increment, 
    estado       varchar (45) not null,
    tipo_entrega varchar (15) not null,
    direccion    varchar (80), 
    precio_total decimal (7,2) not null,
    fecha datetime not null,
    USERS_id   bigint,
    PRIMARY KEY (orden_id),
    constraint fk_users foreign key (USERS_id) references users(id)    
);

-- insert into ORDEN(estado, tipo_entrega, direccion, precio_total,fecha,USERS_id) values ('Nueva Orden', 'Domicilio','5ta calle blah blah', 51.25,now(),1);
-- insert into ORDEN(estado, tipo_entrega, direccion, precio_total,fecha,USERS_id) values ('Nueva Orden', 'Restaurante',null, 35.55,now(), 1); 
-- insert into ORDEN(estado, tipo_entrega, direccion, precio_total,fecha,USERS_id) values ('Nueva Orden', 'Restaurante',null, 35.55,now(), null);  -- ORDEN SIN usuario

    
-- TABLA HISTORIAL_ORDEN
CREATE TABLE IF NOT EXISTS HISTORIAL_ORDEN (
    cantidad int not null,
    ORDEN_orden_id int not null,
    CATALOG_idcatalog int not null, 
    constraint fk_orden foreign key (ORDEN_orden_id ) references ORDEN(orden_id),
    constraint fk_catalog foreign key (CATALOG_idcatalog) references Catalog(idCatalog)
);
-- insert into HISTORIAL_ORDEN (cantidad, ORDEN_orden_id, CATALOG_idcatalog) values (2, 1, 1);
-- insert into HISTORIAL_ORDEN (cantidad, ORDEN_orden_id, CATALOG_idcatalog) values (1, 1, 1);



             
ALTER USER 'root' IDENTIFIED WITH mysql_native_password BY '1234';
GRANT ALL PRIVILEGES ON *.* TO 'root'@'%' WITH GRANT OPTION;
FLUSH PRIVILEGES;

