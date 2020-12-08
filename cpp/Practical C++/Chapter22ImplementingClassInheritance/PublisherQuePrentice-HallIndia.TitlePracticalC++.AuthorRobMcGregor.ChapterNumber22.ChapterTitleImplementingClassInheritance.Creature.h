/*
	2016-10-04	PublisherQuePrentice-HallIndia.TitlePracticalC++.AuthorRobMcGregor.ChapterNumber22.ChapterTitleImplementingClassInheritance.Creature.h
	2016-10-04	http://stackoverflow.com/questions/1549930/c-equivalent-of-java-tostring
*/

#ifndef __CREATURE_H__
#define __CREATURE_H__

class Creature
{
	public:
		int yearsLived;
		
		string firstMention;
		string gender;
		string lastMention;
		string name;
		string nameMeaning;
		string scriptureReference;
		
		// operator overloading
		friend ostream& operator <<(ostream& outputStream, const Creature& creature);
		friend ostream& operator <<(ostream& outputStream, const Creature& creature){
			outputStream
				<< "name=" << creature.name
				<< "yearsLived=" << creature.yearsLived
				;
			return outputStream;
		}		
};

#endif //__CREATURE_H__
