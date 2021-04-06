var mysql = require('mysql');
const host = process.env.HOST || 'mysql-database-practicaSA';
const db = process.env.db || 'Delivery'
const user = process.env.user || 'root'
const password = process.env.password || '1234'

/*var connection = mysql.createConnection({
    host : host,
    database : db,
    user : user,
    port: 33070,
    password : password
});

connection.connect(function(err) {
    if (err) {
        console.error('Error de conexion: ' + err.stack);
        return;
    }
    console.log('Conectado con el identificador ' + connection.threadId);
});*/

var pool = mysql.createPool({
    connectionLimit: 10,
    host: host,
    user: user,
    password: password,
    database: db,
    multipleStatements: true
});



module.exports = pool;
