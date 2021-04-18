const mysqlConnection = require('../conexion');

const GetAllUsers = (req, res) => {
    mysqlConnection.query('SELECT * FROM Users', (err, rows, fields) => {
        if (!err) {
            res.json(rows);
            //res.json({meesage: 'hola!'});
        } else {
            console.log(err);
            return res.status(400).end();
        }
    });
    
}



module.exports = {
    GetAllUsers : GetAllUsers
}