FROM mysql:latest

ENV MYSQL_ROOT_PASSWORD 1234 
ENV MYSQL_DATABASE Delivery  

COPY . /docker-entrypoint-initdb.d

EXPOSE 3306
