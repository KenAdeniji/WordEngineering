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
	2026-04-29T16:06:00
		Man.correct()
			http://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/find
			http://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/filter	
	2026-04-29T16:34:00 new Man("Joseph", "Jacob", "Rachel", "Dreamer", null), Hakeem Olajuwon, the Dream of all basketball coaches
	2026-04-29T16:52:00	http://mozilladatacollective.com/datasets?utm_source=mdn&utm_medium=paid&utm_campaign=open-data
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
	correct() {
		var scriptureReference = "";
		switch(this.named)
		{
			case "Jacob":
				scriptureReference = "Genesis 48:19";
				break;
			case "Joseph":
				scriptureReference = "Genesis 50:20, Genesis 39:8-9";
				break;
		}	
		return scriptureReference;
	}	
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
	new Man("Jacob", "Isaac", "Rebecca", "Israel - Prince with God", null),
	new Man("Joseph", "Jacob", "Rachel", "Dreamer", null),
];

console.log
(
	"Joseph.(correct)",
	this.men.find
	(
		(element) => element.named === "Joseph"
	).correct(),
	"Jacob.(correct)",
	this.men.find
	(
		(element) => element.named === "Jacob"
	).correct()
);


