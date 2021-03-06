const express = require('express')
const app = express();

app.use(express.json())

app.get('/', (req, res) => {
  res.send('Welcome to the Restaurant Microservice!')
});


app.post('/restaurant/receiveOrder', (req, res) => {
  const { clientID, Restaurant, Menu } = req.body
  console.log(req.body);
  res.json({ Message: "We have received the order with the following details: ",
   details: {
   ReceivedMenu: Menu,
   Restaurant: Restaurant,
   ClientID: clientID}
 })
})

app.get('/restaurant/orderStatus', (req, res) => {
  var { OrderID, ClientID } = req.query
  var order = { orderID:"2", status:"In progress" };
  console.log(req.query);
  if(order.orderID===OrderID)
  {
    console.log(order.orderID);
    res.json({ Message: "This is the detail for the requested order ",
    details: {
    clientID : ClientID,
    orderID: order.orderID,
    status: order.status}
  })
  }else
  {
    res.json({Message : "The received order doesnt exist.", IDOrder : OrderID})
  }
})

app.post('/restaurant/notifyDelivery', (req, res) => {
  const { orderID, clientID, restaurant, menu, address } = req.body
  console.log(req.body);
  res.json({ Message: "The following order is ready for delivery: ",
   details: {
   OrderID: orderID,
   ReceivedMenu: menu,
   Restaurant: restaurant,
   ClientID: clientID,
   Address: address}
 })
})

app.listen(8000, () => {
  console.log('Example app listening on port 8000!')
});