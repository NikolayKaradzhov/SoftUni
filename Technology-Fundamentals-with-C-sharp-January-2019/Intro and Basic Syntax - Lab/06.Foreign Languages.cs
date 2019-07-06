using System;
					
public class Program
{
	public static void Main()
	{
		string country = Console.ReadLine();
		
		if(country.Equals("England") || country.Equals("USA")) 
		{
			Console.WriteLine("English");
		}
		else if(country.Equals("Spain") || country.Equals("Argentina") || country.Equals("Mexico"))
		{
			Console.WriteLine("Spanish");
		}
		else
		{
			Console.WriteLine("unknown");
		}
	}
}
