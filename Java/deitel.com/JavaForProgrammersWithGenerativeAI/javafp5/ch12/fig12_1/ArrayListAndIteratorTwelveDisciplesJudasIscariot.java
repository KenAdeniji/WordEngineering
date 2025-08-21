import java.util.List;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;

/**
	2025-08-20T13:50:00 http://github.com/pdeitel/JavaForProgrammers5e/blob/main/examples/ch12/fig12_01/CollectionTest.java
	2025-08-20T14:14:00	Find and replace color with item.
	2025-08-20T15:01:00 The Olivet Discourse
	List<String> removeItems Collection not List.
*/
public class ArrayListAndIteratorTwelveDisciplesJudasIscariot
{
	public static void main(String[] args) 
	{
		List<String> itemList = addItems
		(
			args[Argument_Index_Items_To_Add]
		);
		List<String> removeList = addItems
		(
			args[Argument_Index_Items_To_Remove]
		);
		printItems(itemList);
		removeItems(itemList, removeList);
		printItems(itemList);
	}
	
	public static List<String> addItems(String items)
	{
		List<String> itemList = new ArrayList<String>();
		for (String item : items.split(","))
		{
			itemList.add(item.trim());
		}
		return itemList;
	}	
	
	public static void printItems(List<String> itemList)
	{
		System.out.println(String.join(", ", itemList));
	}

	public static void removeItems
	(
		Collection<String> allItems,
		List<String> itemsToRemove
	)
	{
		Iterator<String> iterator = allItems.iterator();
		while (iterator.hasNext())
		{
			if
			(
				itemsToRemove.contains
				(
					iterator.next()
				)
			)
			{
				iterator.remove();
			}	
		}	
	}	
	
	public static final int Argument_Index_Items_To_Add = 0;
	public static final int Argument_Index_Items_To_Remove = 1;
}
