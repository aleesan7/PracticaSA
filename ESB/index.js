const express = require('express');
const app = express();
const axios = require("axios")
var body_parser = require('body-parser').json();

const PORT = 8090;
const HOST = 'localhost';

app.use(express.json())

app.get('/', function(req, res) {
    res.send("ESB Service")
});

app.post('/esb/services/client/order', (req, res) => {
    const { clientID, Restaurant, Menu } = req.body

    var order = req.body.id
    axios.post('http://localhost:7000/client/order',{'clientID':clientID, 'Restaurant':Restaurant, 'Menu':Menu})
    res.json({Message: "The order has been sent!"}) 
})

app.get('/esb/services/client/getorderstatus', (req, res) => {
  var { OrderID } = req.query
  
  axios.get('http://localhost:7000/client/getorderstatus?OrderID='+OrderID)
  .then(function(response){
    res.send(response['data'])
});
})

app.get('/esb/services/client/getstatusfromdelivery', (req, res) => {
  var { OrderID } = req.query
  
  axios.get('http://localhost:7000/client/getstatusfromdelivery?OrderID='+OrderID)
  .then(function(response){
    res.send(response['data'])
  });
})

app.post('/esb/services/restaurant/receiveOrder', (req, res) => {
  const { clientID, Restaurant, Menu } = req.body
  
  axios.post('http://localhost:8000/restaurant/receiveOrder',{'clientID':clientID, 'Restaurant':Restaurant, 'Menu':Menu})
  res.json({Message: "The order has been sent to the restaurant!"}) 
})

app.get('/esb/services/restaurant/orderStatus', (req, res) => {
  var { OrderID, ClientID } = req.query

  axios.get('http://localhost:8000/restaurant/orderStatus?OrderID='+OrderID+'&ClientID='+ClientID)
  .then(function(response){
    res.send(response['data'])
  });
})

app.post('/esb/services/restaurant/notifyDelivery', (req, res) => {
  const { orderID, clientID, restaurant, menu, address } = req.body
  
  axios.post('http://localhost:8000/restaurant/notifyDelivery',{'orderID':orderID, 'clientID':clientID, 'Restaurant':restaurant, 'Menu':menu, 'address':address})
  res.json({Message: "The delivery guy has been notified about your order!"}) 
})

app.post('/esb/services/delivery/receiveOrder', (req, res) => {
  const { orderID, clientID, restaurant, menu, address } = req.body
  
  axios.post('http://localhost:9000/delivery/receiveOrder',{'orderID':orderID, 'clientID':clientID, 'Restaurant':restaurant, 'Menu':menu, 'address':address})
  res.json({Message: "The delivery guy has received your order!"}) 
})

app.get('/esb/services/delivery/orderStatus', (req, res) => {
  var { OrderID, ClientID } = req.query

  axios.get('http://localhost:9000/delivery/orderStatus?OrderID='+OrderID)
  .then(function(response){
    res.send(response['data'])
  });
})

app.put('/esb/services/delivery/markAsDelivered', (req, res) => {
  const { orderID } = req.body

  axios.put('http://localhost:9000/delivery/markAsDelivered', { orderID: orderID });
  res.json({Message: "The order has been delivered to the user!"}) 
})

app.listen(PORT, () => {
    console.log('ESB app listening on port 8090!')
  });
