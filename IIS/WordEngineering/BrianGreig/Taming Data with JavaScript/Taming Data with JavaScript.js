window.fetchData = window.fetchData || {};

filterInfo = function(yr, state){
{
	fetch('Taming Data with JavaScript.json')
	.then( response => {
	  return response.json();
	}).then( jsonData => {
	  window.fetchData.jsonData = jsonData;
	}).catch( err => {
	  console.log("Fetch process failed", err);
}

filterData = function(yr, state){
{
	if (yr == "All"){
	let total = this.jsonData.filter(dState => dState.state==state)
	.reduce((accumulator, currentValue) => {
	  return accumulator + currentValue.total;
	}, 0)
	return [{'year': 'All', 'state': state, 'total': total}];
	}
	if (state == "All"){
	let total = this.jsonData.filter(dYr => dYr.year==yr)
	.reduce((accumulator, currentValue) => {
	  return accumulator + currentValue.total;
	}, 0)
	return [{'year': yr, 'state': 'All', 'total': total}];
	}
	let subset = this.jsonData.filter(dYr => dYr.year==yr)
	.filter(dSt => dSt.state== state);
	return subset;
}
