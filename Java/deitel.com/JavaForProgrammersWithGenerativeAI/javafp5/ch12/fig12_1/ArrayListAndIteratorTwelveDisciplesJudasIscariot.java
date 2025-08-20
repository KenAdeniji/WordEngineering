import java.util.List;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;

/**
	14:14:00	Find and replace color with item.
*/
public class ArrayListAndIteratorTwelveDisciplesJudasIscariot
{
	public static void main(String[] args) 
	{
		List<String> itemList = addColors(args[ArgumentIndexAddItem]);
		printItems(itemList);
	}
	
	public static List<String> addItems(String items)
	{
		List<String> itemList = new ArrayList<String>;
		for (String item : itemss.split(","))
		{
			itemList.add(item.trim());
		}
		return itemList;
	}	
	
	public static void printItems(List<String> itemList)
	{
		System.out.println(itemList.join(", ");
	}
	
	const int ArgumentIndexAddItems = 0;
}
