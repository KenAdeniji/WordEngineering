export class StateOfJS2025 {
	static version = "2025";
	static nullishCoalescing(firstValue, secondValue) {
		return firstValue ?? secondValue;
	}
	static {
		console.log("Class static initialization block called");
	}
}
