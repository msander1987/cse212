public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>

    /* THE PLAN: create an array with the length we take from the 'length' 
    parameter and then iterate it and saving the multiples, multiplying the 'number' 
    parameter by all the integers starting from 1 until reaching the length requested through the parameter*/
    public static double[] MultiplesOf(double number, int length)
    {
        //Create the array and set its capacity according to the length parameter
        var multiplesArray = new double[length];
        //Iterate over the array to access each of its positions
        for (int i = 1; i <= length; ++i)
        {
            //In each position we multiply the number we receive as a parameter
            //by all the integers from 1 until we reach the requested length.
            //Since the first position of an array is 0, we take advantage of the variable i
            //that starts at 1 and subtract 1 from it to access the position and save
            // the result of the multiplication, that is, the multiples
            multiplesArray[i - 1] = number * i;
        }

        //We simply return the array already populated with the multiples
        return multiplesArray;
    }







    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>

    /* THE PLAN: Determine the position in the list where we want the reordered List to start (startPosition)
    and also determine the last position (finalPosition), which would simply be the one before 'startPosition'
    (If the new array starts at startPosition, that means that the position before starPosition within the List
    data will be the final position. Then we create a temporary array just to store these ordered values without
    having to change the values ​​in the List data (temporaryArray). We loop through the temporary array twice,
    the first time to save the values ​​by iterating the List data from startPosition to the end,
    and then we iterate it again to save the values ​​from position 0 to finalPosition.
    Finally, we loop through all values of both arrays at the same time in a simple for loop,
    since they have the same size and in each position we tell data List that its value will now be equal
    of the position value of the temporaryArray, which has the values ​​ordered as requested in the formula with their parameters.*/
    public static void RotateListRight(List<int> data, int amount)
    {   //get length of data List and store it in a variable to use before
        var capacity = data.Count;
        //We obtain the position of the data List that will contain
        //the first value when the data List is reordered,
        //and we store it in the startPosition variable.
        var startPosition = capacity - amount;
        //We obtain the position of the data List that will contain
        //the last value when the data List is reordered,
        //and we store it in the finalPosition variable.
        var finalPosition = startPosition - 1;
        //We create a temporary array to store the
        //values without changing the data List values.
        var temporaryArray = new int[capacity];
        //We create and initialize a variable with 0, to loop the
        //temporary array in a correct sequence from the first position
        var temporaryArrayPosition = 0;
        //We create a for loop to iterate the data List from startPosition to the end,
        //as these will now be the first values, we save these values in temporaryArray
        //from the beginning using the temporaryArrayPosition that contains 0.
        for (var i = startPosition; i <= capacity - 1; ++i)
        {   //We get the values of data List that starts at startPosition
            //and save it in temporayArray at the initial position through
            //the variable temporaryArrayPosition
            temporaryArray[temporaryArrayPosition] = data[i];
            //we increase the value by 1, to loop the temporaryArray correctly
            ++temporaryArrayPosition;
        }
        //We create a for loop to iterate the data List from the first position to finalPosition,
        //as these will now be the last values, we save these values in temporaryArray
        //from the last position we iterate, (which is stored in the
        //variable temporaryArrayPosition) until the end.
        for (var j = 0; j <= finalPosition; ++j)
        {   //We get the values of data List that starts at position 0
            //and save it in temporayArray in temporaryArrayPosition
            temporaryArray[temporaryArrayPosition] = data[j];
            //we increase the value by 1, to loop the temporaryArray correctly
            ++temporaryArrayPosition;
        }
        //Finally, we use a for loop to completely iterate
        //through the dataList and temporaryArray
        for (var k = 0; k <= capacity - 1; ++k)
        {   //We simply save the sorted values in temporaryArray in data List,
            // since at position 'k', it will be the same position in both
            data[k] = temporaryArray[k];

        }
        //Now the data list is sorted as requested through the parameters.

    }
}
