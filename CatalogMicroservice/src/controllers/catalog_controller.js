const mysqlConnection = require('../conexion');

const get_allProducts = (req, res) => {
    mysqlConnection.query('SELECT * FROM Catalog', (err, rows, fields) => {
        if (!err) {
            res.json(rows);
        } else {
            console.log(err);
            return res.status(400).end();
        }
    });
}

const insertProduct = (req, res) => {


    //  const query = `
    // SET @id =0;
    // SET @username= ?;
    // SET @contenido = ?;
    //  CALL ADD_OR_EDIT_USER(@id, @username, @contenido);
    // `;

    const query = `insert into Catalog(ProductName, ImagePath, Description, Price, Discount, Category, DateAdded) values ('${req.body.ProductName}','${req.body.ImagePath}','${req.body.Description}','${req.body.Price}','${req.body.Discount}','${req.body.Category}',Now());`


    mysqlConnection.query(query, (err, rows, fields) => {
        if (!err) {
            res.json({ status: 'Producto Agregado' });
        } else {
            console.log(err);
            return res.status(400).end();
        }
    });
}

const updateProductName = (req, res) => {

    const query = `update Catalog set ProductName = '${req.body.ProductName}' where idCatalog = ${req.body.idCatalog}`

    mysqlConnection.query(query, (err, rows, fields) => {
        if (!err) {
            res.json({ status: 'Producto Actualizado' });
        } else {
            console.log(err);
            return res.status(400).end();
        }
    });
}

const updateProductImagePath = (req, res) => {

    const query = `update Catalog set ImagePath = '${req.body.ImagePath}' where idCatalog = ${req.body.idCatalog}`

    mysqlConnection.query(query, (err, rows, fields) => {
        if (!err) {
            res.json({ status: 'Producto Actualizado' });
        } else {
            console.log(err);
            return res.status(400).end();
        }
    });
}

const updateProductDescription = (req, res) => {

    const query = `update Catalog set Description = '${req.body.Description}' where idCatalog = ${req.body.idCatalog}`

    mysqlConnection.query(query, (err, rows, fields) => {
        if (!err) {
            res.json({ status: 'Producto Actualizado' });
        } else {
            console.log(err);
            return res.status(400).end();
        }
    });
}

const updateProductPrice = (req, res) => {

    const query = `update Catalog set Price = '${req.body.Price}' where idCatalog = ${req.body.idCatalog}`

    mysqlConnection.query(query, (err, rows, fields) => {
        if (!err) {
            res.json({ status: 'Producto Actualizado' });
        } else {
            console.log(err);
            return res.status(400).end();
        }
    });
}

const updateProductDiscount = (req, res) => {

    const query = `update Catalog set Discount = '${req.body.Discount}' where idCatalog = ${req.body.idCatalog}`

    mysqlConnection.query(query, (err, rows, fields) => {
        if (!err) {
            res.json({ status: 'Producto Actualizado' });
        } else {
            console.log(err);
            return res.status(400).end();
        }
    });
}

const updateProductCategory = (req, res) => {

    const query = `update Catalog set Category = '${req.body.Category}' where idCatalog = ${req.body.idCatalog}`

    mysqlConnection.query(query, (err, rows, fields) => {
        if (!err) {
            res.json({ status: 'Producto Actualizado' });
        } else {
            console.log(err);
            return res.status(400).end();
        }
    });
}

const deleteProduct = (req, res) => {

    const query = `DELETE FROM  Catalog where idCatalog = ${req.body.idCatalog}`

    mysqlConnection.query(query, (err, rows, fields) => {
        if (!err) {
            res.json({ status: 'Producto Eliminado' });
        } else {
            console.log(err);
            return res.status(400).end();
        }
    });
}

module.exports = {
    get_allProducts : get_allProducts,
    insertProduct : insertProduct,
    updateProductName : updateProductName,
    updateProductImagePath : updateProductImagePath,
    updateProductDescription : updateProductDescription,
    updateProductPrice : updateProductPrice,
    updateProductDiscount : updateProductDiscount,
    updateProductCategory : updateProductCategory,
    deleteProduct : deleteProduct
}