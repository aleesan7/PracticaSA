var express = require('express');
var router = express.Router();

const catalog_controller = require('../controllers/catalog_controller')

//router.get('/principal', function(req, res, next) {
//  res.render('vista.html');
//});

router.get('/GetUsers', catalog_controller.GetAllUsers);



module.exports = router;
