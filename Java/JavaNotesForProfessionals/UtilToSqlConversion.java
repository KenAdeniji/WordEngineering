/*
	2022-04-26 Created.
	http://goalkicker.com/JavaBook/JavaNotesForProfessionals.pdf
	http://www.javatpoint.com/java-date-format
	javac UtilToSqlConversion.java
	java UtilToSqlConversion
*/
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
public class UtilToSqlConversion {
	public static void main(String args[])
	{
		java.util.Date utilDate = new java.util.Date();
		System.out.println("java.util.Date is : " + utilDate);
		java.sql.Date sqlDate = convert(utilDate);
		System.out.println("java.sql.Date is : " + sqlDate);
		DateFormat df = new SimpleDateFormat("dd/MM/YYYY - hh:mm:ss");
		System.out.println("dateFormated date is : " + df.format(utilDate));
	}
	private static java.sql.Date convert(java.util.Date uDate) {
		java.sql.Date sDate = new java.sql.Date(uDate.getTime());
		return sDate;
	}
}
