class Person
{
	/*
		http://jsdoc.app/about-getting-started
		jsdoc Person.js
		Is the ContactID the same as the PersonID?
			WordEngineering database, Contact table, ContactID column.
			static personIdentity = 0;
		2025-07-05T06:15:00...2025-07-05T06:46:00 google.com toString()
			2025-07-05T06:27:00 We have tried 10AM before.
			http://stackoverflow.com/questions/53154340/es6-how-to-override-tostring-method
			http://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Template_literals
		2025-07-05T06:55:00	urine.
		Uncaught ReferenceError: personIdentity is not defined
			Person http://localhost/Wordengineering/MarcoTulioValente/SoftwareEngineeringAModernApproach/Person.js:31
			pageLoad http://localhost/Wordengineering/MarcoTulioValente/SoftwareEngineeringAModernApproach/ChildrenUse-Cases.html:43
			Person.js:31:3
		2025-07-05T07:05:00	Identity column.
			2025-07-05T07:13:00	http://stackoverflow.com/questions/36855063/how-to-implement-instance-counter-in-es6
		2025-07-05T07:23:00	urine.
	*/

	/**
		* 	Represents a person.
		* 	@constructor
		*	@param {string} firstName - The first name of the person.
		*	@param {string} lastName - The last name of the person.
		*	@param {number} phoneID - The phone number of the person.
	*/	
	constructor
	(
		firstName,
		lastName,
		phoneID = null
	)
	{
		this.constructor.counter = (this.constructor.counter || 0) + 1;
		this._id = this.constructor.counter;		
/*
		setPerson
		(
			firstName,
			lastName,
			phoneID
		);
*/
		this.firstName = firstName;
		this.lastName = lastName;
		this.phoneID = phoneID;
	}	

	_id = null;
	firstName = null;
	lastName = null;
	phoneID = null;

	get id() 
	{
		return this._id;
	}
  
	/**
		* 	This is a description for the setPerson function.
		*	@param {string} firstName - The first name of the person.
		*	@param {string} lastName - The last name of the person.
		*	@param {number} phoneID - The phone number of the person.
	*/	
	setPerson
	(
		firstName,
		lastName,
		phoneID = null
	)
	{
		this.firstName = firstName;
		this.lastName = lastName;
		this.phoneID = phoneID;
	}	

	static
	{

	}	
	
	toString()
	{
		return `ID: ${this._id} First name: ${this.firstName} Last name: ${this.lastName}`
	}	

	static toString()
	{
		return `Count: ${this._id}`
	}	
}
