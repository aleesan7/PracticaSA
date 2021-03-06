const express = require('express')
const app = express();

app.use(express.json())

app.get('/', (req, res) => {
  res.send('Delivery Microservice!')
});

app.post('/delivery/receiveOrder', (req, res) => {
  const { orderID, clientID, restaurant, menu, address } = req.body
  console.log(req.body);
  res.json({ Message: "The delivery guy has received the order with the following details: ",
   details: {
   OrderID: orderID,
   ReceivedMenu: menu,
   Restaurant: restaurant,
   ClientID: clientID,
   ClientAddiress: address
  }
 })
})

app.get('/delivery/orderStatus', (req, res) => {
  var { OrderID } = req.query
  var order = { orderID:"2", status:"On its way to your location, 5 minutes away." };
  console.log(req.query);
  if(order.orderID===OrderID)
  {
    console.log(order.orderID);
    res.json({ Message: "This is the detail for the requested order ",
    details: {
    orderID: order.orderID,
    status: order.status}
  })
  }else
  {
    res.json({Message : "The received order doesnt exist.", IDOrder : OrderID})
  }
})

app.put('/delivery/markAsDelivered', (req, res) => {
  const { orderID } = req.body
  console.log(req.body);
  res.json({ Message: "The following order has been delivered to the user: ",
   details: {
   OrderID: orderID
  }
 })
})

app.listen(9000, () => {
  console.log('Example app listening on port 9000!')
});