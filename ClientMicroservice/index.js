const express = require('express')
const app = express();

app.use(express.json())

app.get('/', (req, res) => {
  res.send('Clients Microservice!')
});

app.post('/client/order', (req, res) => {
  const { clientID, Restaurant, Menu } = req.body
  console.log(req.body);
  res.json({ Message: "This is the order that you have requested: ",
   details: {
   ReceivedMenu: Menu,
   Restaurant: Restaurant,
   ClientID: clientID}
 })
})

app.get('/client/getorderstatus', (req, res) => {
  var { OrderID, ClientID } = req.query
  var order = { orderID:"3", status:"In progress" };
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

app.get('/client/getstatusfromdelivery', (req, res) => {
  var { OrderID, ClientID } = req.query
  var order = { orderID:"3", status:"On its way to your location." };
  console.log(req.query);
  if(order.orderID===OrderID)
  {
    console.log(order.orderID);
    res.json({ Message: "This is the information of your order with the delivery guy: ",
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

app.listen(7000, () => {
  console.log('Example app listening on port 7000!')
});