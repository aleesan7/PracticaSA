const chai = require('chai');
const chaiHttp = require('chai-http');
const express = require('express');
const cors = require('cors');
var request = require('request');
const app = require('../src/routes/catalog')

const expect = chai.expect
chai.use(chaiHttp)
chai.should();
app.use(cors());

app.use(express.urlencoded({ extended: true }));
app.use(express.json());

describe("GET /get_allProducts", () => {

	it("should return status 200", function(done)  {
        chai.request('http://localhost:3000')
            .get('/get_allProducts')
            .end(function(err, response)
            {
                response.should.have.status(200);
                console.log('Obtained status: '+response.status);
                done();
            });
       
	});
});

describe("POST /insertProduct", () => {

	it("should return status 200", function(done)  {
        chai.request('http://localhost:3000')
            .post('/insertProduct')
            .send({
                'ProductName': 'Sushi',
                'ImagePath': 'https://www.guatemala.com/fotos/2019/06/Sushi-Guatemala-885x500.jpg',
                'Description': 'Delicious Sushi',
                'Discount' : '35',
                'Price': '60'
            })
            .end(function(err, response)
            {
                response.should.have.status(200);
                response.should.be.json;
                console.log('Obtained status: '+response.status);
                done();
            });
       
	});
});

describe("PUT /updateProductName", () => {

	it("should return status 200", function(done)  {
        chai.request('http://localhost:3000')
            .put('/updateProductName')
            .send({
                'ProductName': 'MrSushi',
                'idCatalog': 18
            })
            .end(function(err, response)
            {
                response.should.have.status(200);
                response.should.be.json;
                console.log('Obtained status: '+response.status);
                done();
            });
       
	});
});

describe("PUT /updateProductImagePath", () => {

	it("should return status 200", function(done)  {
        chai.request('http://localhost:3000')
            .put('/updateProductImagePath')
            .send({
                'ImagePath': 'https://www.google.com',
                'idCatalog': 18
            })
            .end(function(err, response)
            {
                response.should.have.status(200);
                response.should.be.json;
                console.log('Obtained status: '+response.status);
                done();
            });
	});
});

describe("PUT /updateProductDescription", () => {

	it("should return status 200", function(done)  {
        chai.request('http://localhost:3000')
            .put('/updateProductDescription')
            .send({
                'Description': 'Test Description',
                'idCatalog': 18
            })
            .end(function(err, response)
            {
                response.should.have.status(200);
                response.should.be.json;
                console.log('Obtained status: '+response.status);
                done();
            });
	});
});

// describe("PUT /updateProductName with error", () => {

// 	it("should return status 400", function(done)  {
//         chai.request('http://localhost:3000')
//             .put('/updateProductName')
//             .send({
//                 'ProductName': 'MrSushi',
//                 'idCatalog': 'x'
//             })
//             .end(function(err, response)
//             {
//                 response.should.have.status(200);
//                 console.log('Obtained status: '+response.status);
//                 done();
//             });
       
// 	});
// });

// describe("PUT /updateProductImagePath with error", () => {

// 	it("should return status 400", function(done)  {
//         chai.request('http://localhost:3000')
//             .put('/updateProductImagePath')
//             .send({
//                 'ImagePath': 'https://www.facebook.com',
//                 'idCatalog': 'x'
//             })
//             .end(function(err, response)
//             {
//                 response.should.have.status(200);
//                 console.log('Obtained status: '+response.status);
//                 done();
//             });
// 	});
// });

// describe("PUT /updateProductDescription with error", () => {

// 	it("should return status 400", function(done)  {
//         chai.request('http://localhost:3000')
//             .put('/updateProductDescription')
//             .send({
//                 'Description': 'Incredible sushi',
//                 'idCatalog': 'x'
//             })
//             .end(function(err, response)
//             {
//                 response.should.have.status(200);
//                 console.log('Obtained status: '+response.status);
//                 done();
//             });
// 	});
// });

// describe("PUT /updateProductPrice with error", () => {

// 	it("should return status 400", function(done)  {
//         chai.request('http://localhost:3000')
//             .put('/updateProductPrice')
//             .send({
//                 'Price': '75',
//                 'idCatalog': 'x'
//             })
//             .end(function(err, response)
//             {
//                 response.should.have.status(200);
//                 console.log('Obtained status: '+response.status);
//                 done();
//             });
// 	});
// });

// describe("PUT /updateProductDiscount with error", () => {

// 	it("should return status 400", function(done)  {
//         chai.request('http://localhost:3000')
//             .put('/updateProductDiscount')
//             .send({
//                 'Discount': '35',
//                 'idCatalog': 'x'
//             })
//             .end(function(err, response)
//             {
//                 response.should.have.status(200);
//                 console.log('Obtained status: '+response.status);
//                 done();
//             });
// 	});
// });

/*describe("GET /get_allProducts", () => {

    it('should return status 200', function(done) {
    request('http://localhost:3000/get_allProducts' , function(err, res, body) {
        expect(res.statusCode).to.equal(200);
        console.log(res.statusMessage);
        //console.log(body);
        done();
    });
});

});*_

/*describe("POST /insertProduct", () => {

    it('Main page content', function(done) {
    request.post('http://localhost:3000/insertProduct',{ json:{ 
        ProductName: 'Sushi',
        ImagePath: 'https://www.guatemala.com/fotos/2019/06/Sushi-Guatemala-885x500.jpg',
        Description: 'Delicious Sushi',
        Discount: 35,
        Price: '40',
        hola: 'hola'
    } }, function(err, res, body) {
        expect(res.statusCode).to.equal(200);
        console.log(res.statusMessage);
        done();
    });
    

});

});*/