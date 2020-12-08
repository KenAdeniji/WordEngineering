using System;

using System.Text;

public static partial class ArrayHelpers 
{
	public static void Main(string[] argv)
	{
		byte[] EndOfStream = Encoding.ASCII.GetBytes("---3141592---");
		byte[] FakeReceivedFromStream = Encoding.ASCII.GetBytes("Hello, world!!!---3141592---"); 
		if (FakeReceivedFromStream.Contains(EndOfStream))
		{ 
			Console.WriteLine("Message received"); 
		}

        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; 
		int shiftCount = 1;
        Rotate(ref array, shiftCount);
        Console.WriteLine(string.Join(", ", array));   	// Output: [10, 1, 2, 3, 4, 5, 6, 7, 8, 9]
		
        array = new []{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        shiftCount = 15;
        Rotate(ref array, shiftCount);
        Console.WriteLine(string.Join(", ", array));   	// Output: [6, 7, 8, 9, 10, 1, 2, 3, 4, 5]
        array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        shiftCount = -1;
        Rotate(ref array, shiftCount); 
		Console.WriteLine(string.Join(", ", array));   	// Output: [2, 3, 4, 5, 6, 7, 8, 9, 10, 1]
        array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        shiftCount = -35;
        Rotate(ref array, shiftCount); 
		Console.WriteLine(string.Join(", ", array));  	// Output: [6, 7, 8, 9, 10, 1, 2, 3, 4, 5] 		
	}
	
	public static bool Contains<T>(this T[] array, T[] candidate)
    {   
		if (IsEmptyLocate(array, candidate))            return false;
        if (candidate.Length > array.Length)            return false;
        for (int a = 0; a <= array.Length - candidate.Length; a++)
        {
			if (array[a].Equals(candidate[0]))
			{
				int i = 0; 
				for (; i < candidate.Length; i++) 
				{                    
					if (false == array[a + i].Equals(candidate[i]))
						break;        
				}
				if (i == candidate.Length) 
					return true;
			}
		}	
        return false;    
	}
	
    public static bool IsEmptyLocate<T>(this T[] array, T[] candidate)
    { 
		return array == null || candidate == null || array.Length == 0 || candidate.Length == 0 || candidate.Length > array.Length;  
	} 
	
    private static void Rotate<T>(ref T[] array, int shiftCount) 
	{
        T[] backupArray= new T[array.Length];
        for (int index = 0; index < array.Length; index++) 
		{ 
			backupArray[(index + array.Length + shiftCount % array.Length) % array.Length] = array[index];        
		}
		array = backupArray;    
	}
}
