using System.Text.Json;
using System.Diagnostics;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        var wordsSet = new HashSet<string>(words);
        var pairsSet = new HashSet<string>();
        string pair;
        foreach (var word in wordsSet)
        {

            char[] chars = { word[1], word[0] };
            if (word[0] == word[1])
            {

            }
            else
            {
                string symmetric = new string(chars);

                if (wordsSet.Contains(symmetric))
                {
                    pair = symmetric + " & " + word;
                    pairsSet.Add(pair);
                    wordsSet.Remove(symmetric);
                }
            }
        }
        string[] pairArray = new string[pairsSet.Count];
        var i = 0;
        foreach (var item in pairsSet)
        {
            pairArray[i] = item;
            i++;
        }
        return pairArray;
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (degrees.ContainsKey(fields[3]))
            {
                var value = degrees[fields[3]];
                degrees[fields[3]] = value + 1;
            }
            else
            {
                degrees.Add(fields[3], 1);
            }
        }
        foreach (var item in degrees)
        {
            Debug.Write(item);
        }
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var str1 = word1.ToLower().Replace(" ", "");
        var str2 = word2.ToLower().Replace(" ", "");
        if (str1.Length != str2.Length)
        {
            return false;
        }
        var chars1 = new Dictionary<char, int>();
        var chars2 = new Dictionary<char, int>();

        for (var i = 0; i < str1.Length; i++)
        {
            if (chars1.ContainsKey(str1[i]))
            {
                chars1[str1[i]] = chars1[str1[i]] + 1;
            }
            else
            {
                chars1.Add(str1[i], 1);
            }

            if (chars2.ContainsKey(str2[i]))
            {
                chars2[str2[i]] = chars2[str2[i]] + 1;
            }
            else
            {
                chars2.Add(str2[i], 1);
            }
        }

        foreach (var item in chars1)
        {
            char ch = item.Key;
            if (chars2.ContainsKey(ch))
            {
                if (chars1[ch] != chars2[ch])
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
  public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        //Debug.Write(json);

        var data = featureCollection.Features;
        /*foreach (var item in data)
        {
            Debug.Write(item.Properties.Place + " - Mag " + item.Properties.Mag + "\n");
        }*/
        var dataResult = new List<string>();
        foreach (var item in data)
        {
            string line = item.Properties.Place + " - Mag " + item.Properties.Mag;
            dataResult.Add(line);
        }
        string[] dataArray = dataResult.ToArray();

        return dataArray;

    }
}