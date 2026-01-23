/*
	2026-01-22T19:38:00	http://www.objectplayground.com
	2026-01-22T21:25:00	http://stackoverflow.com/questions/52377344/javascript-array-of-instances-of-a-class
*/
class Man {
	constructor(named, father, mother) {
		this.named = named;
		this.father = father;
		this.mother = mother;	
	}	
	breathe() {}
}

class Woman extends Man {
	constructor(named, father, mother) {
		super(named, father, mother);
	}
	breathe() {
		super.breathe();
	}
}

this.men = [
	new Man("Adam", "God", null),
	new Woman("Eve", null, null)
];
