/*
	2026-01-22T19:38:00	http://www.objectplayground.com
	2026-01-22T21:25:00	http://stackoverflow.com/questions/52377344/javascript-array-of-instances-of-a-class
	2026-01-22T22:07:00 Vocation
*/
class Man {
	constructor(named, father, mother, titled, vocation) {
		this.named = named;
		this.father = father;
		this.mother = mother;
		this.titled = titled;
		this.vocation = vocation;
	}	
	breathe() {}
	name() {}
	knew() {}
	sacrifice() {}
}

class Woman extends Man {
	constructor(named, father, mother, titled, vocation) {
		super(named, father, mother, titled, vocation);
	}
}

this.men = [
	new Man("Adam", "God", null, "First man", "Gardener"),
	new Woman("Eve", null, null, "Mother of all the living", "Helper"),
	new Man("Cain", "Adam", "Eve", "Possession", "Tiller of the ground"),
	new Man("Abel", "Adam", "Eve", null, "Animal breeder"),
	new Man("Seth", "Adam", "Eve", "Substitute", "Call on the of God"),
	new Man("Enosh", "Seth", null, null, "Call on the of God"),
];
