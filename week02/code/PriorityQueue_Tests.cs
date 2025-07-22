using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with soccer players and their respective jersey numbers
    // Expected Result: [Suarez (Pri:9), Ronaldo (Pri:7), Messi (Pri:10), Kross (Pri:8)]
    // Defect(s) Found: No problem found, the players are enqueued as asked.
    public void TestPriorityQueue_1()
    {
        var players = new PriorityQueue();
        players.Enqueue("Suarez", 9);
        players.Enqueue("Ronaldo", 7);
        players.Enqueue("Messi", 10);
        players.Enqueue("Kross", 8);

        var expected = "[Suarez (Pri:9), Ronaldo (Pri:7), Messi (Pri:10), Kross (Pri:8)]";
        Assert.AreEqual(expected, players.ToString());
    }

    [TestMethod]
    // Scenario: Create a queue with soccer players and their respective jersey numbers,
    // then remove the player with the highest jersey number from that newly created queue.
    // Expected Result: Suarez, Ronaldo and Kross, Messi should not be there since his shirt number is the highest
    // Defect(s) Found: The remove method was not applied in the dequeue method at highPriorityIndex index
    public void TestPriorityQueue_2()
    {
        var players = new PriorityQueue();
        players.Enqueue("Suarez", 9);
        players.Enqueue("Ronaldo", 7);
        players.Enqueue("Messi", 10);
        players.Enqueue("Kross", 8);

        players.Dequeue();

        var expected = "[Suarez (Pri:9), Ronaldo (Pri:7), Kross (Pri:8)]";
        Assert.AreEqual(expected, players.ToString());
    }

    [TestMethod]
    // Scenario: Create a queue with soccer players and their respective jersey numbers with multiple identical jersey numbers,
    // then remove the player with the highest jersey number from that newly created queue.
    // Expected Result: Suarez, Ronaldo, Kross, Mbappe and Lewandowsky.
    // Defect(s) Found: When there were values with identical numbers, the item that was removed was not the closest to the front.
    //The queue was looped from beginning to end, searching for the highest value and replacing it with the next one found, that is, the one closest to the back.
    public void TestPriorityQueue_3()
    {
        var players = new PriorityQueue();
        players.Enqueue("Suarez", 9);
        players.Enqueue("Ronaldo", 7);
        players.Enqueue("Messi", 10);
        players.Enqueue("Kross", 8);
        players.Enqueue("Mbappe", 10);
        players.Enqueue("Lewandosky", 9);

        players.Dequeue();

        var expected = "[Suarez (Pri:9), Ronaldo (Pri:7), Kross (Pri:8), Mbappe (Pri:10), Lewandosky (Pri:9)]";
        Assert.AreEqual(expected, players.ToString());
    }

    [TestMethod]
    // Scenario: Create a queue with soccer players and their respective jersey numbers with multiple identical jersey numbers,
    // then remove 3 players with the highest jersey number from that newly created.
    // Expected Result: Ronaldo, Kross, and Lewandowsky
    // Defect(s) Found: When there were values with identical numbers, the item that was removed was not the closest to the front.
    //The queue was looped from beginning to end, searching for the highest value and replacing it with the next one found, that is, the one closest to the back.
    public void TestPriorityQueue_4()
    {
        var players = new PriorityQueue();
        players.Enqueue("Suarez", 9);
        players.Enqueue("Ronaldo", 7);
        players.Enqueue("Messi", 10);
        players.Enqueue("Kross", 8);
        players.Enqueue("Mbappe", 10);
        players.Enqueue("Lewandosky", 9);

        players.Dequeue();
        players.Dequeue();
        players.Dequeue();

        var expected = "[Ronaldo (Pri:7), Kross (Pri:8), Lewandosky (Pri:9)]";
        Assert.AreEqual(expected, players.ToString());
    }

    [TestMethod]
    // Scenario: Create a queue with soccer players and their respective jersey numbers with multiple identical jersey numbers,
    // then remove 3 players with the highest jersey number from that newly created. Get the order in which the numbers were deleted
    // Expected Result: Messi, Mbappe, and Suarez
    // Defect(s) Found: When there were values with identical numbers, the item that was removed was not the closest to the front.
    //The queue was looped from beginning to end, searching for the highest value and replacing it with the next one found, that is, the one closest to the back.
    public void TestPriorityQueue_5()
    {
        var players = new PriorityQueue();
        players.Enqueue("Suarez", 9);
        players.Enqueue("Ronaldo", 7);
        players.Enqueue("Messi", 10);
        players.Enqueue("Kross", 8);
        players.Enqueue("Mbappe", 10);
        players.Enqueue("Lewandosky", 9);

        string player1 = players.Dequeue().ToString();
        string player2 = players.Dequeue().ToString();
        string player3 = players.Dequeue().ToString();
        string order = player1 + ", " + player2 + ", " + player3;

        var expected = "Messi, Mbappe, Suarez";
        Assert.AreEqual(expected, order);
    }
    
    [TestMethod]
    // Scenario: Trying to dequeue an empty queue
    // Expected Result: InvalidOperationException with a message of "The queue is empty."
    // Defect(s) Found: It was already implemented
    public void TestPriorityQueue_6()
    {
        var players = new PriorityQueue();

        try
        {
            players.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}