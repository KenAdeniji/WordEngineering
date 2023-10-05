//2015-09-14	Created.	http://cdn.oreillystatic.com/oreilly/booksamplers/9781449373214_sampler.pdf
var http = require('http');
http.get('http://www.google.com', function(err,res){
	console.log('got a response');
});
