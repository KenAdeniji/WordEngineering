//http://developers.redhat.com/e-books/java-nutshell-guide

/*
	2024-07-24T04:11:00 Created.
Outside of the core JDK libraries, the assert statement is
extremely rarely used. It turns out to be too inflexible for
testing most applications and is not often used by ordinary
developers. Instead, developers use ordinary testing libraries,
such as JUnit.

To enable assertions in all classes except for system classes, use the -ea argument.
To enable assertions in system classes, use -esa. To enable assertions within a
specific class, use -ea followed by a colon and the class name:
java -ea:com.example.sorters.MergeSort com.example.sorters.Test
To enable assertions for all classes in a package and in all of its subpackages, follow
the -ea argument with a colon, the package name, and three dots:
java -ea:com.example.sorters... com.example.sorters.Test
You can disable assertions in the same way, using the -da argument. For example, to
enable assertions throughout a package and then disable them in a specific class or
subpackage, use:
java -ea:com.example.sorters... -da:com.example.sorters.QuickSort
java -ea:com.example.sorters... -da:com.example.sorters.plugins..
Finally, it is possible to control whether or not assertions are enabled or disabled
at classloading time. If you use a custom classloader (see Chapter 11 for details on
custom classloading) in your program and want to turn on assertions, you may be
interested in these methods.
*/
public class AssertVerifyDesignAssumptions
{
	public static void main(String[] args)
	{
		assert ( 1 == 2 ) : "Assertion fails";
	}
}
