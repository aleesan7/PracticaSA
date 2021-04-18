use `UsersDB`;

CREATE TABLE if not exists Users (
  carnet varchar(250) NOT NULL,
  nombre varchar(250) DEFAULT NULL
) ENGINE=InnoDB;

insert into Users (carnet, nombre) values ('201114336','Kevin Alejandro Sanchez Samayoa');


ALTER USER 'root' IDENTIFIED WITH mysql_native_password BY '1234';
GRANT ALL PRIVILEGES ON *.* TO 'root'@'%' WITH GRANT OPTION;
FLUSH PRIVILEGES;


LOAD DATA INFILE "/docker-entrypoint-initdb.d/usuarios2.csv" INTO TABLE Users FIELDS TERMINATED BY ',' LINES TERMINATED By '\r\n' IGNORE 1 ROWS;