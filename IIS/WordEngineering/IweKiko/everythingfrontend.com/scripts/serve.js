var common  = require('./common');
var express = require('express');
var http = require('http');

//var app = express.createServer();

var app = express(); 
var server = http.createServer(app);

var url = '/lib.js';
var port = 8083;
app.get(url, common.package.createServer());
app.listen(port);

console.log('\nYou can load stitched file from:');
console.log('http://localhost:' + port + url);
