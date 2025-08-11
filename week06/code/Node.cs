using System.Diagnostics;
public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        if (value != Data)
        {

            if (value < Data)
            {
                // Insert to the left
                if (Left is null)
                    Left = new Node(value);
                else
                    Left.Insert(value);
            }
            else
            {
                // Insert to the right
                if (Right is null)
                    Right = new Node(value);
                else
                    Right.Insert(value);
            }
        }

    }

    public bool Contains(int value)
    {
        if (value == Data)
        {
            return true;
        }

        if (value < Data)
        {
            // Check in the left
            if (Left is null)
            {
                return false;
            }
            return Left.Contains(value);
        }
        else
        {
            //Check in the right
            if (Right is null)
            {
                return false;
            }
            return Right.Contains(value);
        }


    }

    public int GetHeight()
    {
        if (Left is null && Right is null)
        {
            return 1;
        }

        int left = 0;
        int right = 0;
        if (Left is null)
        {
            left = 0;
        }
        else
        {
            left = Left.GetHeight();
        }

        if (Right is null)
        {
            right = 0;
        }
        else
        {
            right = Right.GetHeight();
        }

        int finalHeigth = left - right;
        if (finalHeigth <= 0)
        {
            return right + 1;
        }
        else
        {
            return left + 1;
        }



    }
}