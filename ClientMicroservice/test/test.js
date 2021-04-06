const chai = require('chai');
const chaiHttp = require('chai-http');
const express = require('express');
const cors = require('cors');
const app = require('../index')

const expect = chai.expect
chai.use(chaiHttp)
chai.should();

describe("POST /order", () => {

	it("should return status 200", function(done)  {
        chai.request(app)
            .post('/client/order')
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
        chai.request(app)
            .get('/client/getorderstatus?OrderID=1')
            .end(function(err, response)
            {
                response.should.have.status(200);
                response.should.be.json;
                console.log('Obtained status: '+response.status);
                done();
            });
       
	});
});