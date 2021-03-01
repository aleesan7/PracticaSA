const express = require('express')
var Map = require("collections/map")
const app = express();
const port = 7000;

var orderID = 0;

var map = new Map();

app.use(express.json())

app.get('/', (req, res) => {
  res.send('Clients Microservice!')
});

app.post('/client/order', (req, res) => {
  const { clientID, Restaurant, Menu } = req.body
  
  const obj = req.body;
  orderID = orderID + 1;
  map.set(orderID, obj);

  //console.log(map.entries());
  res.json({ Message: "This is the order that you have requested: ",
   details: {
   ReceivedMenu: Menu,
   Restaurant: Restaurant,
   ClientID: clientID}
 })
})

app.get('/client/getorderstatus', (req, res) => {
  var { OrderID } = req.query
  
  var order = map.get(parseInt(OrderID));
  //console.log(OrderID);
  //console.log(map.get(parseInt(OrderID)));
  if(order!=null)
  {
    res.json({ Message: "This is the requested order ",
    order
  })
  }else
  {
    res.json({Message : "The received order doesnt exist.", IDOrder : OrderID})
  }
})

app.get('/client/getstatusfromdelivery', (req, res) => {
  var { OrderID } = req.query
  var order = { orderID:"2", status:"On its way to your location." };
  console.log(req.query);
  if(order.orderID===OrderID)
  {
    console.log(order.orderID);
    res.json({ Message: "This is the information of your order with the delivery guy: ",
    details: {
    orderID: order.orderID,
    status: order.status}
  })
  }else
  {
    res.json({Message : "The received order doesnt exist.", IDOrder : OrderID})
  }
})

app.listen(port, () => {
  console.log('Example app listening on port 7000!')
});