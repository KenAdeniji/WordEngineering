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
	2026-04-29T17:11:00	http://docs.github.com/en/actions/tutorials/create-actions/create-a-javascript-action
	2026-04-30T10:46:00	Natural primary key. get() method ... set() method.
		this.men.find((element) => element.named === "Jacob")["correct"] = "Genesis 48:19";
		this.men.find((element) => element.named === "Joseph")["correct"] = "Genesis 50:20, Genesis 39:8-9";
		2026-04-30 12:26:11.033
			Whoever practice sin is a slave of sin... the slave doesn't reside in the house, forever.	
				John 8:34-35, Matthew 24:15-16, Mark 13:14, Luke 21:20-21
	2026-04-30T15:21:00...2026-04-30T15:39:00	onlySon boolean type?
		http://stackoverflow.com/questions/2647867/how-can-i-determine-if-a-variable-is-undefined-or-null
	2026-04-30T16:39:28
		Have I not chosen you twelve... one will betray me.	
		John 6:70
	2026-04-30T18:16:00
		OnlySon() {
			return !(this.onlySon == null);
		}	
		YoungestSon() {
			return !(this.youngestSon == null);
		}	
		versus (VS)
		isOnlySon() {
			return !(this.onlySon == null);
		}	
		isYoungestSon() {
			return !(this.youngestSon == null);
		}
	2026-04-30T17:57:00...2026-04-30T19:03:00
		this.men.find
		(
			(element) => element.named === "Judas Iscariot"
		).betray != null,
	2026-04-30T16:39:28	dated constructor parameter	
	2026-04-29T16:06:00
		Man.correct()
			http://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/find
			http://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/filter
		2026-05-01T02:36:00 filter allows you to do count... 
			statistics length.
*/
class Man {
	constructor(dated, named, father, mother, titled, vocation) {
		this.dated = dated;
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
	//2026-04-29T16:34:00
	/*
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
	*/	
	isOnlySon() {
		return !(this.onlySon == null);
	}	
	isYoungestSon() {
		return !(this.youngestSon == null);
	}	
}

class Woman extends Man {
	constructor(named, father, mother, titled, vocation) {
		super(named, father, mother, titled, vocation);
	}
}

this.men = [
	new Man(new Date("2026-01-22T00:00:00"), "Adam", "God", null, "First man", "Gardener"),
	new Woman(new Date("2026-01-22T00:00:00"), "Eve", null, null, "Mother of all the living", "Helper"),
	new Man(new Date("2026-01-22T00:00:00"), "Cain", "Adam", "Eve", "Possession", "Tiller of the ground"),
	new Man(new Date("2026-01-22T00:00:00"), "Abel", "Adam", "Eve", null, "Animal breeder"),
	new Man(new Date("2026-01-22T00:00:00"), "Seth", "Adam", "Eve", "Substitute", "Call on the name of God"),
	new Man(new Date("2026-01-22T00:00:00"), "Enosh", "Seth", null, null, "Call on the name of God"),
	new Man(new Date("2026-04-30T00:00:00"), "Abraham", "Terah", null, "Father of many nations", null),
	new Man(new Date("2026-04-30T00:00:00"), "Isaac", "Abraham", "Sarah", "God has made me laugh", null),
	new Man(new Date("2026-04-30T00:00:00"), "Jacob", "Isaac", "Rebecca", "Israel - Prince with God", null),
	new Man(new Date("2026-04-30T00:00:00"), "Joseph", "Jacob", "Rachel", "Dreamer", null),
	new Man(new Date("2026-04-30T00:00:00"), "David", "Jesse", null, "A man after God's own heart", "A man of war"),
	new Man(new Date("2026-04-30T16:39:28"), "Judas Iscariot", null, null, "The betrayal", "Tax collector"),	
];

/*
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
*/

//2026-04-30T10:46:00	Natural primary key. get() method ... set() method.
this.men.find((element) => element.named === "Jacob")["correct"] = "Genesis 48:19";
this.men.find((element) => element.named === "Joseph")["correct"] = "Genesis 50:20, Genesis 39:8-9";

//2026-04-30T14:16:00	Out of him
this.men.find((element) => element.named === "Adam")["outOfHim"] = "Genesis 2:23";

this.men.find((element) => element.named === "Abraham")["heir"] = "Genesis 15:4";

this.men.find((element) => element.named === "Isaac")["seed"] = "Genesis 21:12";
this.men.find((element) => element.named === "Isaac")["onlySon"] = "Genesis 22:2";

this.men.find((element) => element.named === "David")["seed"] = "2 Samuel 7:12";
this.men.find((element) => element.named === "David")["youngestSon"] = "1 Samuel 16:11";

this.men.find((element) => element.named === "Judas Iscariot")["betray"] = "John 6:70";

console.log(this.men);

console.log
(
	"Isaac.isOnlySon()",
	this.men.find
	(
		(element) => element.named === "Isaac"
	).isOnlySon(),
	"Jacob.isOnlySon()",
	this.men.find
	(
		(element) => element.named === "Jacob"
	).isOnlySon(),
	"Isaac.isYoungestSon()",
	this.men.find
	(
		(element) => element.named === "Isaac"
	).isYoungestSon(),
	"David.isYoungestSon()",
	this.men.find
	(
		(element) => element.named === "David"
	).isYoungestSon(),
	"Judas Iscariot.betray != null",
	this.men.find
	(
		(element) => element.named === "Judas Iscariot"
	).betray != null,
);
