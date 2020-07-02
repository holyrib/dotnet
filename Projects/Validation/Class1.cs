using System;

public class Class1
{
	
         public bool IsPhone(string text)
    {
        Regex rx = new Regex(@"^(\d{3}||\(\d{3}\))[\s\-]?\d{3}\-?\d{4}$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);
        return rx.IsMatch(text);
    }
    public bool IsZip(string text)
    {
        Regex rx = new Regex(@"^\d{5}([-\s]\d{4})?$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);
        return rx.IsMatch(text);
    }
    public bool IsMail(string text)
    {
        Regex rx = new Regex(@"^[\w\-\.]+@[a-z]+\.[a-z]+[^\s]$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);
        return rx.IsMatch(text);
    }

}
