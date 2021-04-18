'use strict';

require('dotenv').config();

var logger = require('morgan');
const express = require('express');
const cors = require('cors')
const path = require('path');
const port = process.env.PORT || 3000;

var users = require('./src/routes/catalog')

const app = express();

app.use(logger('dev'))
app.use(cors())

//AGREGAMOS LAS DOS LINEAS SIGUIENTES

app.use(express.urlencoded({ extended: true }));
app.use(express.json());

//app.engine('html', require('ejs').renderFile);
//app.set('views', path.join(__dirname, '/src/views'));
//app.use(express.static(path.join(__dirname, '/src/public')));

app.use('/', users);

app.listen(port, function() {
    console.log('Servidor corriendo en el puerto ' + port);
});
