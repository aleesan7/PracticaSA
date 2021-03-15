const chai = require('chai');
const chaiHttp = require('chai-http');
const express = require('express');
const cors = require('cors');
//const app = require('../index')

const expect = chai.expect
chai.use(chaiHttp)
chai.should();
//app.use(cors());

//app.use(express.urlencoded({ extended: true }));
//app.use(express.json());

describe("POST /order", () => {

	it("should return status 200", function(done)  {
        chai.request('http://localhost:8090')
            .post('/esb/services/client/order')
            .send({
                'clientID': '201114336',
	            'Restaurant': 'Pizza Hut',
	            'Menu': 'Pizza de peperoni'
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

describe("GET /getorderstatus", () => {

	it("should return status 200", function(done)  {
        chai.request('http://localhost:8090')
            .get('/esb/services/client/getorderstatus?OrderID=1')
            .end(function(err, response)
            {
                response.should.have.status(200);
                console.log('Obtained status: '+response.status);
                done();
            });
       
	});
});


/*
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
});*/

