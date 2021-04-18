var mysql = require('mysql');
const host = process.env.HOST || '172.22.0.2';
const db = process.env.db || 'UsersDB'
const user = process.env.user || 'root'
const password = process.env.password || '1234'

var pool = mysql.createPool({
    connectionLimit: 10,
    host: '172.22.0.2', //container IP Address
    user: user,
    password: password,
    database: db,
    multipleStatements: true
});



module.exports = pool;
