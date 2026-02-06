namespace AdvancedTopics.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Shorten the string to number of words needed
    /// </summary>
    /// <param name="str">The string value</param>
    /// <param name="numberOfWords">The number of words needed</param>
    /// <returns>Return the shorten version of string</returns>
    public static string Shorten(this string str, int numberOfWords)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberOfWords);

        var words = str.Trim().Split(" ");

        if (words.Length <= numberOfWords)
        {
            return str;
        }

        return string.Join(" ", words.Take(numberOfWords)) + "...";
    }
}
