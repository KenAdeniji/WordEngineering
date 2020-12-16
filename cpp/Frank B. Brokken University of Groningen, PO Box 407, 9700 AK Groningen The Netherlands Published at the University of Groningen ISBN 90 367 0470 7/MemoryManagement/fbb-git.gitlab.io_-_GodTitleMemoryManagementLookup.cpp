/*
	2020-04-29	Created. https://fbb-git.gitlab.io/cppannotations/cppannotations/html
	2016-10-05T06:55:00 http://stackoverflow.com/questions/12248703/creating-an-instance-of-class
	2020-01-14T11:23	LINK : fatal error LNK1104: cannot open file 'libucrt.lib'
	2020-01-16T14:20:00	https://stackoverflow.com/questions/50220966/how-to-use-vectors-of-c-stl-with-webassembly
	2020-01-17T13:23:00	https://stackoverflow.com/questions/37362473/modern-c-way-to-copy-string-into-char
	2020-04-29T21:00:00	https://stackoverflow.com/questions/4754763/object-array-initialization-without-default-constructor
	2020-04-30
--GodTitles[0].setGodTitle("El", "The Strong One.", "");
--Title, Commentary, OrderSequence, Dated, ScriptureReference, GodTitleID, TypeMaster
SELECT
	'GodTitles[' 
	+CONVERT(VARCHAR, GodTitleID - 1)
	+'].setGodTitle("' + Title + '","' + ISNULL(Commentary, '') + '","' + ISNULL(ScriptureReference, '') + '");'
FROM
	WordEngineering..GodTitle
ORDER BY
	GodTitleID
*/

#include <iostream>
#include <string>

#include "fbb-git.gitlab.io_-_GodTitleMemoryManagement.hpp"

using namespace std;

void initialization();
GodTitle getGodTitle(int id);
int getGodTitle(string title);

GodTitle *GodTitles = new GodTitle[73]();

void initialization()
{
GodTitles[0].setGodTitle("El","The Strong One.","");
GodTitles[1].setGodTitle("El Chaiyai","The God of my Life.","Psalms 42:8");
GodTitles[2].setGodTitle("El Chanun","The Gracious God.","Jonah 4:2");
GodTitles[3].setGodTitle("El De'ot","The God of Knowledge.","1 Samuel 2:3");
GodTitles[4].setGodTitle("El Echad","The One God.","Malachi 2:10");
GodTitles[5].setGodTitle("El Elyon","The Most High God.","Genesis 14:18");
GodTitles[6].setGodTitle("El Emet","The God of Truth.","Psalms 31:5");
GodTitles[7].setGodTitle("El Emunah","The Faithful God.","Deuteronomy 32:4");
GodTitles[8].setGodTitle("El Gibor","The Mighty God.","Isaiah 9:6");
GodTitles[9].setGodTitle("El HaGadol","The Great God.","Deuteronomy 10:17");
GodTitles[10].setGodTitle("El HaKadosh","The Holy God.","Isaiah 5:16");
GodTitles[11].setGodTitle("El HaKavod","The God of Glory.","Psalms 29:3");
GodTitles[12].setGodTitle("El HaNe'eman","The Faithful God.","Deuteronomy 7:9");
GodTitles[13].setGodTitle("El HaShamayim","The God of the Heavens.","Psalm 136:26");
GodTitles[14].setGodTitle("El Kana","The Jealous God.","Deuteronomy 4:24");
GodTitles[15].setGodTitle("El Olam","The God of Eternity.","Genesis 21:33");
GodTitles[16].setGodTitle("El Rachum","The God of Compassion.","Deuteronomy 4:31");
GodTitles[17].setGodTitle("El Rah'ee","The God Who Sees.","Genesis 16:13");
GodTitles[18].setGodTitle("El Roi","The Lord That Seeth.","");
GodTitles[19].setGodTitle("El Sali","God of my Rock.","Psalmx 42:10");
GodTitles[20].setGodTitle("El Simchat Gili","God The Joy of my Exaltation.","Psalmx 43:4");
GodTitles[21].setGodTitle("El Tzadik","The Righteous God.","Isaiah 45:21");
GodTitles[22].setGodTitle("El Yeshuati","The God of my Salvation.","Isaiah 12:2");
GodTitles[23].setGodTitle("El Yisrael","The God of Israel.","Psalms 68:36");
GodTitles[24].setGodTitle("El-Elohe-Israel","God of Israel.","Genesis 33:20");
GodTitles[25].setGodTitle("Elah","An Oak.","");
GodTitles[26].setGodTitle("Elah Sh'maya","God of Heaven.","Ezra 7:23");
GodTitles[27].setGodTitle("Elah Sh'maya V'Arah","God of Heaven and Earth.","Ezra 5:11");
GodTitles[28].setGodTitle("Elah Yerush'lem","God of Jerusalem.","Ezra 7:19");
GodTitles[29].setGodTitle("Elah Yisrael","God of Israel.","Ezra 5:1");
GodTitles[30].setGodTitle("Eloah","The Adorable One.","");
GodTitles[31].setGodTitle("Elohay Chasdi","God of my Kindness.","Psalms 59:11, Psalms 59:18");
GodTitles[32].setGodTitle("Elohay Elohim","God of Gods","Deuteronomy 10:17");
GodTitles[33].setGodTitle("Elohay HaRuchot LeKol Basar","God of the Spirits of all Flesh.","Numbers 16:22");
GodTitles[34].setGodTitle("Elohay Kedem","God of the Beginning.","Deuteronomy 33:27");
GodTitles[35].setGodTitle("Elohay Kol Basar","God of all Flesh.","Jeremiah 32:27");
GodTitles[36].setGodTitle("Elohay Marom","God of Heights.","Micah 6:6");
GodTitles[37].setGodTitle("Elohay Mauzi","God of my Strength.","Psalms 43:2");
GodTitles[38].setGodTitle("Elohay Mikarov","God Who Is Near.","Jeremiah 23:23");
GodTitles[39].setGodTitle("Elohay Mishpat","God of Justice","Isaiah 30:18");
GodTitles[40].setGodTitle("Elohay Selichot","God of Forgiveness.","Nehemiah 9:17");
GodTitles[41].setGodTitle("Elohay Tehilati","God of my Praise.","Psalms 109:1");
GodTitles[42].setGodTitle("Elohay Tzur","God of Rock.","2 Samuel 22:47");
GodTitles[43].setGodTitle("Elohay Yishi","God of My Salvation.","Psalm 18:47, 25:5");
GodTitles[44].setGodTitle("Elohim Chaiyim","Living God.","Jeremiah 10:10");
GodTitles[45].setGodTitle("Elohim Kedoshim","Holy God.","Leviticus 19:2, Joshua 24:19");
GodTitles[46].setGodTitle("Immanu El","God Is With Us.","Isaiah 7:14");
GodTitles[47].setGodTitle("Jah","The Independent One.","");
GodTitles[48].setGodTitle("Jehovah","I AM.","Exodus 3:12");
GodTitles[49].setGodTitle("Jehovah Adonai","The Lord our Sovereign.","Joshua 5:14");
GodTitles[50].setGodTitle("Jehovah El-Shaddai","The God on the Mountain.","Genesis 17:3; Psalms 91:1-2");
GodTitles[51].setGodTitle("Jehovah Elohay","The Lord my God.","");
GodTitles[52].setGodTitle("Jehovah Eloheenu","The Lord our God.","");
GodTitles[53].setGodTitle("Jehovah Elohim","The Eternal Creator.","Genesis 1:1; Genesis 2:4; Isaiah 54:5");
GodTitles[54].setGodTitle("Jehovah Elokehu","The Lord thy God.","");
GodTitles[55].setGodTitle("Jehovah Elyon","The Lord most High.","");
GodTitles[56].setGodTitle("Jehovah Gmolah","The God of Recompenses.","");
GodTitles[57].setGodTitle("Jehovah Hoseenu","The Lord our Maker.","");
GodTitles[58].setGodTitle("Jehovah Jireh","The Lord will Provide.","Genesis 22:14");
GodTitles[59].setGodTitle("Jehovah Mekaddishken","The Lord our Sanctifier.","Ezekiel 37:28");
GodTitles[60].setGodTitle("Jehovah Nissi","The Lord our Banner.","Exodus 17:15");
GodTitles[61].setGodTitle("Jehovah Rohi","The Lord my Shepherd.","Psalms 23:1");
GodTitles[62].setGodTitle("Jehovah Rophe","The Lord our Healer.","Exodus 15:26");
GodTitles[63].setGodTitle("Jehovah Saboath","The Lord of Hosts.","1 Samuel 17:45");
GodTitles[64].setGodTitle("Jehovah Shalom","The Lord our Peace.","Judges 6:24");
GodTitles[65].setGodTitle("Jehovah Shammah","The Lord is Present.","Ezekiel 48:35");
GodTitles[66].setGodTitle("Jehovah Tsidkeenu","The Lord our Righteousness","Jeremiah 23:6; Jeremiah 33:16");
GodTitles[67].setGodTitle("YHVH O'saynu","The Lord our Maker.","Psalms 95:6");
GodTitles[68].setGodTitle("YHVH Tz'vaot","The Lord of Armies.","1 Samuel 1:11");
GodTitles[69].setGodTitle("YHVH Yireh","In the mount of the LORD, it shall be seen.","Genesis 22:14");
GodTitles[70].setGodTitle("Yeshua HaMashiach","","");
GodTitles[71].setGodTitle("Mashiach Nagid","Messiah the King","Daniel 9:25");
GodTitles[72].setGodTitle("Godesh Godashin","Holy of Holies","Isaiah 52:13-15, Isaiah 53:1-12");
}

GodTitle getGodTitle(int id)
{
	return GodTitles[id - 1];
}

int getGodTitle(string title)
{
	GodTitle GodTitleIterate;
	for (size_t index = 0; index != 5; ++index)
	{
		GodTitleIterate = GodTitles[index];
		if 
		(
			//strcasecmp(GodTitleIterate.getTitle().c_str(), title.c_str())
			_stricmp(GodTitleIterate.getTitle().c_str(), title.c_str()) == 0
		)
		{
			return index;
		}	
	}
	return -1;	
}
	
int main(int argc, char *argv[])
{
	initialization();

	cout << GodTitles[5] << std::endl;

	delete[] GodTitles;
	
	return 1;
}
