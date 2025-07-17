//racecar
//stressed
//a nut for a jar of tuna

public static class MysteryStack1
{
    public static string Run(string text)
    {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);//inserts the letters in order

        var result = "";
        while (stack.Count > 0)//pop all stack content
            result += stack.Pop();//takes last in and returns its value and adds it in result variable

        return result;
        //for racecar: r a c e c a r : haha, inverted word but stills the same.
        //for stressed: desserts
        //for a nut for a jar of tuna: anut fo raj a rof tun a
    }
}