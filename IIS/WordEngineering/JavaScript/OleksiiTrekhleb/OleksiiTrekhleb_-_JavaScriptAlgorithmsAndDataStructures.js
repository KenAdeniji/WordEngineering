/*
	2019-12-11	Created.	http://github.com/trekhleb/javascript-algorithms
*/

var oleksiiTrekhleb =
{
	factorial: function(number) {
		let result = 1;

		for (let i = 2; i <= number; i += 1) {
		result *= i;
		}

		return result;
	},
	fibonacci: function(n) {
		const fibSequence = [1];

		let currentValue = 1;
		let previousValue = 0;

		if (n === 1) {
			return fibSequence;
		}

		let iterationsCounter = n - 1;

		while (iterationsCounter) {
			currentValue += previousValue;
			previousValue = currentValue - previousValue;

			fibSequence.push(currentValue);

			iterationsCounter -= 1;
		}

		return fibSequence;
	},	
	isEven: function(number) {
		return (number & 1) === 0;
	},
	isPositive: function(number) {
		// Zero is neither a positive nor a negative number.
		if (number === 0) {
			return false;
		}

		// The most significant 32nd bit can be used to determine whether the number is positive.
		return ((number >> 31) & 1) === 0;
	},
	sieveOfEratosthenes: function(maxNumber) {
		const isPrime = new Array(maxNumber + 1).fill(true);
		isPrime[0] = false;
		isPrime[1] = false;

		const primes = [];

		for (let number = 2; number <= maxNumber; number += 1) {
			if (isPrime[number] === true) {
				primes.push(number);

				/*
				* Optimisation.
				* Start marking multiples of `p` from `p * p`, and not from `2 * p`.
				* The reason why this works is because, at that point, smaller multiples
				* of `p` will have already been marked `false`.
				*
				* Warning: When working with really big numbers, the following line may cause overflow
				* In that case, it can be changed to:
				* let nextNumber = 2 * number;
				*/
				let nextNumber = number * number;

				while (nextNumber <= maxNumber) {
					isPrime[nextNumber] = false;
					nextNumber += number;
				}
			}
		}

		return primes;
	},	
	trialDivision: function(number) {
		// Check if number is integer.
		if (number % 1 !== 0) {
			return false;
		}

		if (number <= 1) {
		// If number is less than one then it isn't prime by definition.
			return false;
		}

		if (number <= 3) {
		// All numbers from 2 to 3 are prime.
			return true;
		}

		// If the number is not divided by 2 then we may eliminate all further even dividers.
		if (number % 2 === 0) {
			return false;
		}

		// If there is no dividers up to square root of n then there is no higher dividers as well.
		const dividerLimit = Math.sqrt(number);
		for (let divider = 3; divider <= dividerLimit; divider += 2) {
			if (number % divider === 0) {
			  return false;
			}
		}

		return true;
	}	
};
