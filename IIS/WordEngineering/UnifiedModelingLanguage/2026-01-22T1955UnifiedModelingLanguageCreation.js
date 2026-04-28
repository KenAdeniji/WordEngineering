/*
	2026-01-22T19:38:00	http://www.objectplayground.com
	2026-01-22T21:25:00	http://stackoverflow.com/questions/52377344/javascript-array-of-instances-of-a-class
	2026-01-22T22:07:00 vocation
	2026-04-27T22:06:00 marriage
	Importance of this work?
		Scripture reference documentation
		When was this object instantiated... when was this operation called?
		When was this object instantiated... when was this operation initiated?
	Marriage pre-condition
		Prior to resurrection.
		Matthew 22:30 ... “For in the resurrection they neither marry, nor are given in marriage, but are as the angels of God in heaven.” King James Version (KJV).
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
	marriage() {}
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
	new Man("Seth", "Adam", "Eve", "Substitute", "Call on the name of God"),
	new Man("Enosh", "Seth", null, null, "Call on the name of God"),
];
