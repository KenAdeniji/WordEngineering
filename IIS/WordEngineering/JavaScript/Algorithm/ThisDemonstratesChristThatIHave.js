/*
	2024-03-28 15:11:46.273 word.
	2024-04-02T20:15:00...2024-04-02T20:34:00	Created.
*/
class ScriptureReference
{
	literal = "";
	constructor(literal)
	{
		this.literal = literal;
	}
	append(extra)
	{
		this.literal += extra;
	}	
}
