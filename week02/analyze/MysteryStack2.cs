public static class MysteryStack2
{
    private static bool IsFloat(string text)
    {
        return float.TryParse(text, out _);
    }

    public static float Run(string text)
    {
        var stack = new Stack<float>();
        foreach (var item in text.Split(' '))
        {
            if (item == "+" || item == "-" || item == "*" || item == "/")
            {
                if (stack.Count < 2)//when the item is +-*/ the stack must have at least 2 floats
                    throw new ApplicationException("Invalid Case 1!");
                //if the flow is here, its because
                var op2 = stack.Pop();//deletes and stores last item
                var op1 = stack.Pop();//deletes and stores last item (last item now is diferent)
                float res;
                if (item == "+")
                {//depending on operator we apply that between op1 and op2 and stor it in res variable.
                    res = op1 + op2;
                }
                else if (item == "-")
                {
                    res = op1 - op2;
                }
                else if (item == "*")
                {
                    res = op1 * op2;
                }
                else
                {
                    if (op2 == 0)//if is a division and op2 is 0, throw an error
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;
                }

                stack.Push(res);//the stack stores the result.
            }
            else if (IsFloat(item))
            {//if it is a float
                stack.Push(float.Parse(item));//stores the float in the stack
            }
            else if (item == "")
            {//do nothing
            }
            else
            {//if is not +-*/ or is not a float or is not empty
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)//when the loop ends the stack should have just one item
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();//return the unique value in stack
    }
}
//5 3 7 + *
/*prediction:
- the stack will store 5, 3, and 7
- the loop item will be + and operation will be: 3 + 7 = 10
- the stack stores 10 and now the stack has: 5 10
- the loop item will be * and operation will be: 5 * 10 = 50
- the stack stores 50 and this it is the unique item in stack.
- the loop ends and stack fulfills the last condition
- 50 is returned
*/


//6 2 + 5 3 - /
/*prediction:
- the stack will store 6 and 2
- the loop item will be + and operation will be: 6 + 2 = 8
- the stack stores 8 and now the stack has only: 8
- the stack will store 5 and 3, and now stack has: 8 5 3
- the loop item will be - and operation will be: 5 - 3 = 2
- the stack stores 2 and now the stack has: 8 2
- the loop item will be / and operation will be: 8 / 2 = 4
- the stack stores 4 and this it is the unique item in stack.
- the loop ends and stack fulfills the last condition
- 4 is returned
*/