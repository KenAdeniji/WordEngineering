/*
	2020-05-12	https://stackoverflow.com/questions/9907419/how-to-get-a-key-in-a-javascript-object-by-its-value/36705765
	2020-05-12	https://stackoverflow.com/questions/12462318/find-a-value-in-an-array-of-objects-in-javascript
	2020-05-12	https://en.wikipedia.org/wiki/States_and_territories_of_Australia
*/

onmessage = function(e) {
	console.log('Worker: Message received from main script');
	let workerResult = states.find(o => o.name === e.data[0]);
    console.log('Worker: Posting message back to main script');
    postMessage(workerResult);
}

var states = [
    { name:"ACT", value:"Australia Capital Territory"},
	{ name:"NSW", value:"New South Wales"},
	{ name:"NT", value:"Northern Territory"},
    { name:"QLD", value:"Queensland"},
	{ name:"SA", value:"South Australia"},
	{ name:"TAS", value:"Tasmania"},
	{ name:"VIC", value:"Victoria"},
	{ name:"WA", value:"Western Australia"},
	
];
