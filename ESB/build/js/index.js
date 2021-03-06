const express=require("express"),app=express(),axios=require("axios");var body_parser=require("body-parser").json();const PORT=8090,HOST="localhost";app.use(express.json()),app.get("/",function(e,r){r.send("ESB Service")}),app.post("/esb/services/client/order",(e,r)=>{var{clientID:t,Restaurant:s,Menu:a}=e.body;e.body.id;axios.post("http://localhost:7000/client/order",{clientID:t,Restaurant:s,Menu:a}),r.json({Message:"The order has been sent!"})}),app.get("/esb/services/client/getorderstatus",(e,r)=>{var{OrderID:e}=e.query;axios.get("http://localhost:7000/client/getorderstatus?OrderID="+e).then(function(e){r.send(e.data)})}),app.get("/esb/services/client/getstatusfromdelivery",(e,r)=>{var{OrderID:e}=e.query;axios.get("http://localhost:7000/client/getstatusfromdelivery?OrderID="+e).then(function(e){r.send(e.data)})}),app.post("/esb/services/restaurant/receiveOrder",(e,r)=>{var{clientID:t,Restaurant:s,Menu:e}=e.body;axios.post("http://localhost:8000/restaurant/receiveOrder",{clientID:t,Restaurant:s,Menu:e}),r.json({Message:"The order has been sent to the restaurant!"})}),app.get("/esb/services/restaurant/orderStatus",(e,r)=>{var{OrderID:t,ClientID:e}=e.query;axios.get("http://localhost:8000/restaurant/orderStatus?OrderID="+t+"&ClientID="+e).then(function(e){r.send(e.data)})}),app.post("/esb/services/restaurant/notifyDelivery",(e,r)=>{var{orderID:t,clientID:s,restaurant:a,menu:o,address:e}=e.body;axios.post("http://localhost:8000/restaurant/notifyDelivery",{orderID:t,clientID:s,Restaurant:a,Menu:o,address:e}),r.json({Message:"The delivery guy has been notified about your order!"})}),app.post("/esb/services/delivery/receiveOrder",(e,r)=>{var{orderID:t,clientID:s,restaurant:a,menu:o,address:e}=e.body;axios.post("http://localhost:9000/delivery/receiveOrder",{orderID:t,clientID:s,Restaurant:a,Menu:o,address:e}),r.json({Message:"The delivery guy has received your order!"})}),app.get("/esb/services/delivery/orderStatus",(e,r)=>{var{OrderID:e}=e.query;axios.get("http://localhost:9000/delivery/orderStatus?OrderID="+e).then(function(e){r.send(e.data)})}),app.put("/esb/services/delivery/markAsDelivered",(e,r)=>{var{orderID:e}=e.body;axios.put("http://localhost:9000/delivery/markAsDelivered",{orderID:e}),r.json({Message:"The order has been delivered to the user!"})}),app.listen(PORT,()=>{console.log("ESB app listening on port 8090!")});