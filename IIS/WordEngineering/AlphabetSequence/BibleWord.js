/*
	2026-08-03T10:46:00 Date created.
*/
export class BibleWord
{
	static wordSearch
	(
		bible,
		bibleWord
	)
	{	
		bibleWord = bibleWord.toLowerCase().replace(/[^\p{L}\p{N}\p{Z}]/gu, "").replace(/\s{2,}/g, " ");
		
		var bibleSet = null;
		
		bibleSet = BibleWord.entirePhrase(bible, bibleWord);
		if (bibleSet.length > 0) { return bibleSet; }

		bibleSet = BibleWord.eachWord(bible, bibleWord);
		if (bibleSet != null && bibleSet.length > 0) { return bibleSet; }

		bibleSet = BibleWord.ignorePartsOfSpeech(bible, bibleWord);
		if (bibleSet != null && bibleSet.length > 0) { return bibleSet; }
		
		return bibleSet;
	}
	
	static entirePhrase
	(
		bible,
		bibleWord
	)
	{	
		return bible.Table.filter(function(element) { return (element.KingJamesVersion.toLowerCase().replace(/[^\p{L}\p{N}\p{Z}]/gu, "").replace(/\s{2,}/g, " ")) === bibleWord; });
	}

	static eachWord
	(
		bible,
		bibleWord
	)
	{	
		var bibleWords = bibleWord.split(" ");
		var bibleWordsFilter = "";
		bibleWords.forEach((word) => {
			if (word != null) 
			{ 
				if (bibleWordsFilter !== "")
				{
					bibleWordsFilter += " && ";
				}	
				bibleWordsFilter += ' element.KingJamesVersion.toLowerCase().replace(/[^\p{L}\p{N}\p{Z}]/gu, "").replace(/\s{2,}/g, " ").includes("' + word + '")' ;
			}	
		});
		var filterStatement = "bible.Table.filter(function(element) { return ( " + bibleWordsFilter + " ) } ) ";
		var bibleSet = eval( filterStatement );
		return bibleSet;
	}
	
	static ignorePartsOfSpeech
	(
		bible,
		bibleWord
	)
	{	
		var bibleWords = bibleWord.split(" ");
		var wordPosition;
		BibleWord.PartsOfSpeechCollection.forEach((word) => {
			wordPosition = bibleWords.indexOf(word);
			if (wordPosition > -1)
			{
				bibleWords.splice(wordPosition, 1);
			}		
		});
		bibleWord = bibleWords.join(" ");
		var bibleSet = BibleWord.entirePhrase(bible, bibleWord);
		
		return bibleSet;	
	}
	
	static PartsOfSpeech = 
			"can, could, will, would, shall, should, may, might, must, " + //Verbs
			"have, has, had, do, does, did,be, am, is, are, was, were, been, being, " +
			"a, an, the, " + //Adjectives
			"I, he, we, she, they, me, him, us, her, them, it, this, that, who, which, what, " + //Pronouns
			"my, mine, his, her, hers, our, ours, their, theirs, your, yours, its, whose, " +
			"at, to, with, from, for, of, on, in, into, onto,between, under, over, against, around, " + //Prepositions
			"for, and, nor, but, or, yet, so, " + //Conjunctions
			"because, when, while, as, since, although, whenever, " +
			"not, very, often, here, almost, always, never, there, too, " + //Adverbs
			"Oh, Ouch, yes, no, false, true"; //Interjections
	static PartsOfSpeechCollection = BibleWord.PartsOfSpeech.split(", ");
}
