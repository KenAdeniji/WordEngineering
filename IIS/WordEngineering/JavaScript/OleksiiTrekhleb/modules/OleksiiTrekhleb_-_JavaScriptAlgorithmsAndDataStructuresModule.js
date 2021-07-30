/*
	2021-07-26T07:33:00 Created.
*/

//	2021-07-26T22:15:00	https://github.com/trekhleb/javascript-algorithms/blob/master/src/algorithms/math/bits/getBit.js
/**
 * @param {number} number
 * @param {number} bitPosition - zero based.
 * @return {number}
 */
export function getBit(number, bitPosition) {
	return (number >> bitPosition) & 1;
}

/*
	2021-07-26T22:15:00	https://stackoverflow.com/questions/30429821/how-can-i-get-the-position-of-bits
*/
export function getBitCustom(number, bitPosition) {
	var base2 = number.toString(2);
	return parseInt(base2.charAt(base2.length - bitPosition - 1));
}
