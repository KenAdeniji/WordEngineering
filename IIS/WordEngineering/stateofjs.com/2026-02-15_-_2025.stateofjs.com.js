export class StateOfJS2025 {
	static	#privateField;
	static 	version = "2025";
	/*
	static 	errorCause () {
		try {
		  connectToDatabase();
		} catch (err) {
		  throw new Error("Connecting to database failed.", { cause: err });
		}
	}
	
	static* factorials (n) {
	  let result = 1;
	  for (let i = 1; i <= n; i++) {
		result *= i;
		yield result;
	  }	
	}
	*/
	/**
		Operators to assign a value to a variable based on its own truthy/falsy status.
		2026-02-18 21:04:28.3633333	http://apnews.com/article/california-billionaires-bernie-sanders-gavin-newsom-democrats-87a1e54f463aad49a2093382969e5cca?utm_source=firefox-newtab-en-us	
			2026-02-18T21:19:00 You can change the value... of a constant.
				Matthew 17:24
				2026-02-18T21:34:00	Attribute, property, field.
				2026-02-18T21:57:00	JavaScript object.
				2026-02-18T21:19:00...2026-02-18T22:11:00 microsoft windows operating system, mozilla firefox hourglass http://localhost/Wordengineering/WordUnion/GetAPage.html
				2026-02-19T09:32:00...2026-02-19T10:09:00
					faeces, running stomach, on trousers.
					dizzy, sleepy.
		2026-02-28T17:28:00	console.log( StateOfJS2025.stringMatchAll("test1test2", "t(e)(st(\d?))") );
			2026-02-28T17:56:00 debug. penis tear, pierce.
			2026-02-28T17:28:00...2026-02-28T18:42:00 mozilla firefox error.
			2026-02-28T18:42:00 http://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/matchAll
	*/
	static 	logicalAssignment(operandFirstField, secondOperand) {
		operandFirstField ||= secondOperand;
		return operandFirstField;
	}
	static 	nullishCoalescing(firstValue, secondValue) {
		return firstValue ?? secondValue;
	}
	static stringMatchAll(search, pattern, flags="gi") {
		var regex = new RegExp(pattern, flags);
		return [...search.matchAll(regex)];
	}
	static stringReplaceAll(search, pattern, replacement) {
		return search.replaceAll(pattern, replacement);
	}
	static {
		console.log("Class static initialization block called");
	}
}
