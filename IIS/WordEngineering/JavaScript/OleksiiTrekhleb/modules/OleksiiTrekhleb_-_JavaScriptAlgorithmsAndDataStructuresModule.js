/*
	2021-07-26T07:33:00 Created.
*/

/**
 * @param {number} number
 * @param {number} bitPosition - zero based.
 * @return {number}
 */
const author = "Oleksii Trekhleb";
function getBit(number, bitPosition) {
	return (number >> bitPosition) & 1;
}

export { author, getBit };
