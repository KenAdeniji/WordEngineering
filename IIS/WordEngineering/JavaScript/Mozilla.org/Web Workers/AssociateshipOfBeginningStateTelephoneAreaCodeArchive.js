/*
	2020-05-12	https://stackoverflow.com/questions/9907419/how-to-get-a-key-in-a-javascript-object-by-its-value/36705765
	2020-05-12	https://stackoverflow.com/questions/12462318/find-a-value-in-an-array-of-objects-in-javascript
	2020-05-12	https://en.wikipedia.org/wiki/Telephone_numbers_in_Australia#Central_East_region_(02)
*/

onmessage = function(e) {
	console.log('Worker: Message received from main script');
	let workerResult = states.find(o => o.name === e.data[0]);
    console.log('Worker: Posting message back to main script');
    postMessage(workerResult);
}

var states = [
    { name:"2", value:"Central East region"},
    { name:"3", value:"South-east region"},
	{ name:"7", value:"North-east region"},
	{ name:"8", value:"Central and West region"},
];
