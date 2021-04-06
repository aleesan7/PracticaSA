var express = require('express');
var router = express.Router();

const catalog_controller = require('../controllers/catalog_controller')

//router.get('/principal', function(req, res, next) {
//  res.render('vista.html');
//});

router.get('/get_allProducts', catalog_controller.get_allProducts);

router.post('/insertProduct', catalog_controller.insertProduct);

router.put('/updateProductName', catalog_controller.updateProductName);

router.put('/updateProductImagePath', catalog_controller.updateProductImagePath);

router.put('/updateProductDescription', catalog_controller.updateProductDescription);

router.put('/updateProductPrice', catalog_controller.updateProductPrice);

router.put('/updateProductDiscount', catalog_controller.updateProductDiscount);

router.put('/updateProductCategory', catalog_controller.updateProductCategory);

router.put('/deleteProduct', catalog_controller.deleteProduct);

//router.get('/get_allProducts', function(req,res,next){
//    res.send('hola');
//});



module.exports = router;
