using System;
using System.Linq;
using System.Xml.Linq;

/*
	2018-11-04	https://books.google.com/books/about/Pro_LINQ.html?id=438nCgAAQBAJ&printsec=frontcover&source=kp_read_button#v=onepage&q&f=false
	2018-11-11	Created.
	2018-11-11	Compile with referencing System.Xml.Linq.dll
	2018-11-11	https://stackoverflow.com/questions/42405824/visual-studio-2015-missing-library-system-xml-linq
*/
public static partial class HelloLinqBibleBookTitle
{
	public static void Main(String[] argv)
	{
		Query();
	}

	public static void Query()
	{
		XElement bibleBooks = XElement.Parse
		(
			BibleBookXML
		);
		
		var titles = 
			from book in bibleBooks.Elements("BibleBook")
			where (string)book.Element("bookTitle") == "John"
			select book.Element("bookTitle");
			
		foreach(var title in titles)
		{
			System.Console.WriteLine
			(
				"{0}",
				title.Value
			);
		}
	}
	
	public const string BibleBookXML =
		@"<Bible>
  <BibleBook>
    <bookId>1</bookId>
    <bookTitle>Genesis</bookTitle>
    <chapters>50</chapters>
    <chapterLastVerseLast>26</chapterLastVerseLast>
    <verseIdSequenceFirst>1</verseIdSequenceFirst>
    <verseIdSequenceLast>1533</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>2</bookId>
    <bookTitle>Exodus</bookTitle>
    <chapters>40</chapters>
    <chapterLastVerseLast>38</chapterLastVerseLast>
    <verseIdSequenceFirst>1534</verseIdSequenceFirst>
    <verseIdSequenceLast>2746</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>3</bookId>
    <bookTitle>Leviticus</bookTitle>
    <chapters>27</chapters>
    <chapterLastVerseLast>34</chapterLastVerseLast>
    <verseIdSequenceFirst>2747</verseIdSequenceFirst>
    <verseIdSequenceLast>3605</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>4</bookId>
    <bookTitle>Numbers</bookTitle>
    <chapters>36</chapters>
    <chapterLastVerseLast>13</chapterLastVerseLast>
    <verseIdSequenceFirst>3606</verseIdSequenceFirst>
    <verseIdSequenceLast>4893</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>5</bookId>
    <bookTitle>Deuteronomy</bookTitle>
    <chapters>34</chapters>
    <chapterLastVerseLast>12</chapterLastVerseLast>
    <verseIdSequenceFirst>4894</verseIdSequenceFirst>
    <verseIdSequenceLast>5852</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>6</bookId>
    <bookTitle>Joshua</bookTitle>
    <chapters>24</chapters>
    <chapterLastVerseLast>33</chapterLastVerseLast>
    <verseIdSequenceFirst>5853</verseIdSequenceFirst>
    <verseIdSequenceLast>6510</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>7</bookId>
    <bookTitle>Judges</bookTitle>
    <chapters>21</chapters>
    <chapterLastVerseLast>25</chapterLastVerseLast>
    <verseIdSequenceFirst>6511</verseIdSequenceFirst>
    <verseIdSequenceLast>7128</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>8</bookId>
    <bookTitle>Ruth</bookTitle>
    <chapters>4</chapters>
    <chapterLastVerseLast>22</chapterLastVerseLast>
    <verseIdSequenceFirst>7129</verseIdSequenceFirst>
    <verseIdSequenceLast>7213</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>9</bookId>
    <bookTitle>1 Samuel</bookTitle>
    <chapters>31</chapters>
    <chapterLastVerseLast>13</chapterLastVerseLast>
    <verseIdSequenceFirst>7214</verseIdSequenceFirst>
    <verseIdSequenceLast>8023</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>10</bookId>
    <bookTitle>2 Samuel</bookTitle>
    <chapters>24</chapters>
    <chapterLastVerseLast>25</chapterLastVerseLast>
    <verseIdSequenceFirst>8024</verseIdSequenceFirst>
    <verseIdSequenceLast>8718</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>11</bookId>
    <bookTitle>1 Kings</bookTitle>
    <chapters>22</chapters>
    <chapterLastVerseLast>53</chapterLastVerseLast>
    <verseIdSequenceFirst>8719</verseIdSequenceFirst>
    <verseIdSequenceLast>9534</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>12</bookId>
    <bookTitle>2 Kings</bookTitle>
    <chapters>25</chapters>
    <chapterLastVerseLast>30</chapterLastVerseLast>
    <verseIdSequenceFirst>9535</verseIdSequenceFirst>
    <verseIdSequenceLast>10253</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>13</bookId>
    <bookTitle>1 Chronicles</bookTitle>
    <chapters>29</chapters>
    <chapterLastVerseLast>30</chapterLastVerseLast>
    <verseIdSequenceFirst>10254</verseIdSequenceFirst>
    <verseIdSequenceLast>11195</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>14</bookId>
    <bookTitle>2 Chronicles</bookTitle>
    <chapters>36</chapters>
    <chapterLastVerseLast>23</chapterLastVerseLast>
    <verseIdSequenceFirst>11196</verseIdSequenceFirst>
    <verseIdSequenceLast>12017</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>15</bookId>
    <bookTitle>Ezra</bookTitle>
    <chapters>10</chapters>
    <chapterLastVerseLast>44</chapterLastVerseLast>
    <verseIdSequenceFirst>12018</verseIdSequenceFirst>
    <verseIdSequenceLast>12297</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>16</bookId>
    <bookTitle>Nehemiah</bookTitle>
    <chapters>13</chapters>
    <chapterLastVerseLast>31</chapterLastVerseLast>
    <verseIdSequenceFirst>12298</verseIdSequenceFirst>
    <verseIdSequenceLast>12703</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>17</bookId>
    <bookTitle>Esther</bookTitle>
    <chapters>10</chapters>
    <chapterLastVerseLast>3</chapterLastVerseLast>
    <verseIdSequenceFirst>12704</verseIdSequenceFirst>
    <verseIdSequenceLast>12870</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>18</bookId>
    <bookTitle>Job</bookTitle>
    <chapters>42</chapters>
    <chapterLastVerseLast>17</chapterLastVerseLast>
    <verseIdSequenceFirst>12871</verseIdSequenceFirst>
    <verseIdSequenceLast>13940</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>19</bookId>
    <bookTitle>Psalms</bookTitle>
    <chapters>150</chapters>
    <chapterLastVerseLast>6</chapterLastVerseLast>
    <verseIdSequenceFirst>13941</verseIdSequenceFirst>
    <verseIdSequenceLast>16401</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>20</bookId>
    <bookTitle>Proverbs</bookTitle>
    <chapters>31</chapters>
    <chapterLastVerseLast>31</chapterLastVerseLast>
    <verseIdSequenceFirst>16402</verseIdSequenceFirst>
    <verseIdSequenceLast>17316</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>21</bookId>
    <bookTitle>Ecclesiastes</bookTitle>
    <chapters>12</chapters>
    <chapterLastVerseLast>14</chapterLastVerseLast>
    <verseIdSequenceFirst>17317</verseIdSequenceFirst>
    <verseIdSequenceLast>17538</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>22</bookId>
    <bookTitle>Song of Solomon</bookTitle>
    <chapters>8</chapters>
    <chapterLastVerseLast>14</chapterLastVerseLast>
    <verseIdSequenceFirst>17539</verseIdSequenceFirst>
    <verseIdSequenceLast>17655</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>23</bookId>
    <bookTitle>Isaiah</bookTitle>
    <chapters>66</chapters>
    <chapterLastVerseLast>24</chapterLastVerseLast>
    <verseIdSequenceFirst>17656</verseIdSequenceFirst>
    <verseIdSequenceLast>18947</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>24</bookId>
    <bookTitle>Jeremiah</bookTitle>
    <chapters>52</chapters>
    <chapterLastVerseLast>34</chapterLastVerseLast>
    <verseIdSequenceFirst>18948</verseIdSequenceFirst>
    <verseIdSequenceLast>20311</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>25</bookId>
    <bookTitle>Lamentations</bookTitle>
    <chapters>5</chapters>
    <chapterLastVerseLast>22</chapterLastVerseLast>
    <verseIdSequenceFirst>20312</verseIdSequenceFirst>
    <verseIdSequenceLast>20465</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>26</bookId>
    <bookTitle>Ezekiel</bookTitle>
    <chapters>48</chapters>
    <chapterLastVerseLast>35</chapterLastVerseLast>
    <verseIdSequenceFirst>20466</verseIdSequenceFirst>
    <verseIdSequenceLast>21738</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>27</bookId>
    <bookTitle>Daniel</bookTitle>
    <chapters>12</chapters>
    <chapterLastVerseLast>13</chapterLastVerseLast>
    <verseIdSequenceFirst>21739</verseIdSequenceFirst>
    <verseIdSequenceLast>22095</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>28</bookId>
    <bookTitle>Hosea</bookTitle>
    <chapters>14</chapters>
    <chapterLastVerseLast>9</chapterLastVerseLast>
    <verseIdSequenceFirst>22096</verseIdSequenceFirst>
    <verseIdSequenceLast>22292</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>29</bookId>
    <bookTitle>Joel</bookTitle>
    <chapters>3</chapters>
    <chapterLastVerseLast>21</chapterLastVerseLast>
    <verseIdSequenceFirst>22293</verseIdSequenceFirst>
    <verseIdSequenceLast>22365</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>30</bookId>
    <bookTitle>Amos</bookTitle>
    <chapters>9</chapters>
    <chapterLastVerseLast>15</chapterLastVerseLast>
    <verseIdSequenceFirst>22366</verseIdSequenceFirst>
    <verseIdSequenceLast>22511</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>31</bookId>
    <bookTitle>Obadiah</bookTitle>
    <chapters>1</chapters>
    <chapterLastVerseLast>21</chapterLastVerseLast>
    <verseIdSequenceFirst>22512</verseIdSequenceFirst>
    <verseIdSequenceLast>22532</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>32</bookId>
    <bookTitle>Jonah</bookTitle>
    <chapters>4</chapters>
    <chapterLastVerseLast>11</chapterLastVerseLast>
    <verseIdSequenceFirst>22533</verseIdSequenceFirst>
    <verseIdSequenceLast>22580</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>33</bookId>
    <bookTitle>Micah</bookTitle>
    <chapters>7</chapters>
    <chapterLastVerseLast>20</chapterLastVerseLast>
    <verseIdSequenceFirst>22581</verseIdSequenceFirst>
    <verseIdSequenceLast>22685</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>34</bookId>
    <bookTitle>Nahum</bookTitle>
    <chapters>3</chapters>
    <chapterLastVerseLast>19</chapterLastVerseLast>
    <verseIdSequenceFirst>22686</verseIdSequenceFirst>
    <verseIdSequenceLast>22732</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>35</bookId>
    <bookTitle>Habakkuk</bookTitle>
    <chapters>3</chapters>
    <chapterLastVerseLast>19</chapterLastVerseLast>
    <verseIdSequenceFirst>22733</verseIdSequenceFirst>
    <verseIdSequenceLast>22788</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>36</bookId>
    <bookTitle>Zephaniah</bookTitle>
    <chapters>3</chapters>
    <chapterLastVerseLast>20</chapterLastVerseLast>
    <verseIdSequenceFirst>22789</verseIdSequenceFirst>
    <verseIdSequenceLast>22841</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>37</bookId>
    <bookTitle>Haggai</bookTitle>
    <chapters>2</chapters>
    <chapterLastVerseLast>23</chapterLastVerseLast>
    <verseIdSequenceFirst>22842</verseIdSequenceFirst>
    <verseIdSequenceLast>22879</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>38</bookId>
    <bookTitle>Zechariah</bookTitle>
    <chapters>14</chapters>
    <chapterLastVerseLast>21</chapterLastVerseLast>
    <verseIdSequenceFirst>22880</verseIdSequenceFirst>
    <verseIdSequenceLast>23090</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>39</bookId>
    <bookTitle>Malachi</bookTitle>
    <chapters>4</chapters>
    <chapterLastVerseLast>6</chapterLastVerseLast>
    <verseIdSequenceFirst>23091</verseIdSequenceFirst>
    <verseIdSequenceLast>23145</verseIdSequenceLast>
    <testament>Old</testament>
  </BibleBook>
  <BibleBook>
    <bookId>40</bookId>
    <bookTitle>Matthew</bookTitle>
    <chapters>28</chapters>
    <chapterLastVerseLast>20</chapterLastVerseLast>
    <verseIdSequenceFirst>23146</verseIdSequenceFirst>
    <verseIdSequenceLast>24216</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>41</bookId>
    <bookTitle>Mark</bookTitle>
    <chapters>16</chapters>
    <chapterLastVerseLast>20</chapterLastVerseLast>
    <verseIdSequenceFirst>24217</verseIdSequenceFirst>
    <verseIdSequenceLast>24894</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>42</bookId>
    <bookTitle>Luke</bookTitle>
    <chapters>24</chapters>
    <chapterLastVerseLast>53</chapterLastVerseLast>
    <verseIdSequenceFirst>24895</verseIdSequenceFirst>
    <verseIdSequenceLast>26045</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>43</bookId>
    <bookTitle>John</bookTitle>
    <chapters>21</chapters>
    <chapterLastVerseLast>25</chapterLastVerseLast>
    <verseIdSequenceFirst>26046</verseIdSequenceFirst>
    <verseIdSequenceLast>26924</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>44</bookId>
    <bookTitle>Acts</bookTitle>
    <chapters>28</chapters>
    <chapterLastVerseLast>31</chapterLastVerseLast>
    <verseIdSequenceFirst>26925</verseIdSequenceFirst>
    <verseIdSequenceLast>27931</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>45</bookId>
    <bookTitle>Romans</bookTitle>
    <chapters>16</chapters>
    <chapterLastVerseLast>27</chapterLastVerseLast>
    <verseIdSequenceFirst>27932</verseIdSequenceFirst>
    <verseIdSequenceLast>28364</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>46</bookId>
    <bookTitle>1 Corinthians</bookTitle>
    <chapters>16</chapters>
    <chapterLastVerseLast>24</chapterLastVerseLast>
    <verseIdSequenceFirst>28365</verseIdSequenceFirst>
    <verseIdSequenceLast>28801</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>47</bookId>
    <bookTitle>2 Corinthians</bookTitle>
    <chapters>13</chapters>
    <chapterLastVerseLast>14</chapterLastVerseLast>
    <verseIdSequenceFirst>28802</verseIdSequenceFirst>
    <verseIdSequenceLast>29058</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>48</bookId>
    <bookTitle>Galatians</bookTitle>
    <chapters>6</chapters>
    <chapterLastVerseLast>18</chapterLastVerseLast>
    <verseIdSequenceFirst>29059</verseIdSequenceFirst>
    <verseIdSequenceLast>29207</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>49</bookId>
    <bookTitle>Ephesians</bookTitle>
    <chapters>6</chapters>
    <chapterLastVerseLast>24</chapterLastVerseLast>
    <verseIdSequenceFirst>29208</verseIdSequenceFirst>
    <verseIdSequenceLast>29362</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>50</bookId>
    <bookTitle>Philippians</bookTitle>
    <chapters>4</chapters>
    <chapterLastVerseLast>23</chapterLastVerseLast>
    <verseIdSequenceFirst>29363</verseIdSequenceFirst>
    <verseIdSequenceLast>29466</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>51</bookId>
    <bookTitle>Colossians</bookTitle>
    <chapters>4</chapters>
    <chapterLastVerseLast>18</chapterLastVerseLast>
    <verseIdSequenceFirst>29467</verseIdSequenceFirst>
    <verseIdSequenceLast>29561</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>52</bookId>
    <bookTitle>1 Thessalonians</bookTitle>
    <chapters>5</chapters>
    <chapterLastVerseLast>28</chapterLastVerseLast>
    <verseIdSequenceFirst>29562</verseIdSequenceFirst>
    <verseIdSequenceLast>29650</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>53</bookId>
    <bookTitle>2 Thessalonians</bookTitle>
    <chapters>3</chapters>
    <chapterLastVerseLast>18</chapterLastVerseLast>
    <verseIdSequenceFirst>29651</verseIdSequenceFirst>
    <verseIdSequenceLast>29697</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>54</bookId>
    <bookTitle>1 Timothy</bookTitle>
    <chapters>6</chapters>
    <chapterLastVerseLast>21</chapterLastVerseLast>
    <verseIdSequenceFirst>29698</verseIdSequenceFirst>
    <verseIdSequenceLast>29810</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>55</bookId>
    <bookTitle>2 Timothy</bookTitle>
    <chapters>4</chapters>
    <chapterLastVerseLast>22</chapterLastVerseLast>
    <verseIdSequenceFirst>29811</verseIdSequenceFirst>
    <verseIdSequenceLast>29893</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>56</bookId>
    <bookTitle>Titus</bookTitle>
    <chapters>3</chapters>
    <chapterLastVerseLast>15</chapterLastVerseLast>
    <verseIdSequenceFirst>29894</verseIdSequenceFirst>
    <verseIdSequenceLast>29939</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>57</bookId>
    <bookTitle>Philemon</bookTitle>
    <chapters>1</chapters>
    <chapterLastVerseLast>25</chapterLastVerseLast>
    <verseIdSequenceFirst>29940</verseIdSequenceFirst>
    <verseIdSequenceLast>29964</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>58</bookId>
    <bookTitle>Hebrews</bookTitle>
    <chapters>13</chapters>
    <chapterLastVerseLast>25</chapterLastVerseLast>
    <verseIdSequenceFirst>29965</verseIdSequenceFirst>
    <verseIdSequenceLast>30267</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>59</bookId>
    <bookTitle>James</bookTitle>
    <chapters>5</chapters>
    <chapterLastVerseLast>20</chapterLastVerseLast>
    <verseIdSequenceFirst>30268</verseIdSequenceFirst>
    <verseIdSequenceLast>30375</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>60</bookId>
    <bookTitle>1 Peter</bookTitle>
    <chapters>5</chapters>
    <chapterLastVerseLast>14</chapterLastVerseLast>
    <verseIdSequenceFirst>30376</verseIdSequenceFirst>
    <verseIdSequenceLast>30480</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>61</bookId>
    <bookTitle>2 Peter</bookTitle>
    <chapters>3</chapters>
    <chapterLastVerseLast>18</chapterLastVerseLast>
    <verseIdSequenceFirst>30481</verseIdSequenceFirst>
    <verseIdSequenceLast>30541</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>62</bookId>
    <bookTitle>1 John</bookTitle>
    <chapters>5</chapters>
    <chapterLastVerseLast>21</chapterLastVerseLast>
    <verseIdSequenceFirst>30542</verseIdSequenceFirst>
    <verseIdSequenceLast>30646</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>63</bookId>
    <bookTitle>2 John</bookTitle>
    <chapters>1</chapters>
    <chapterLastVerseLast>13</chapterLastVerseLast>
    <verseIdSequenceFirst>30647</verseIdSequenceFirst>
    <verseIdSequenceLast>30659</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>64</bookId>
    <bookTitle>3 John</bookTitle>
    <chapters>1</chapters>
    <chapterLastVerseLast>14</chapterLastVerseLast>
    <verseIdSequenceFirst>30660</verseIdSequenceFirst>
    <verseIdSequenceLast>30673</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>65</bookId>
    <bookTitle>Jude</bookTitle>
    <chapters>1</chapters>
    <chapterLastVerseLast>25</chapterLastVerseLast>
    <verseIdSequenceFirst>30674</verseIdSequenceFirst>
    <verseIdSequenceLast>30698</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
  <BibleBook>
    <bookId>66</bookId>
    <bookTitle>Revelation</bookTitle>
    <chapters>22</chapters>
    <chapterLastVerseLast>21</chapterLastVerseLast>
    <verseIdSequenceFirst>30699</verseIdSequenceFirst>
    <verseIdSequenceLast>31102</verseIdSequenceLast>
    <testament>New</testament>
  </BibleBook>
</Bible>";
}	