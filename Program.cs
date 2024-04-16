string? str = string.Empty;

while (str == string.Empty)
{
    Console.WriteLine("please insert any palindrome string : ");
    str = Console.ReadLine();
}

Console.WriteLine("found palindrome string is : ");
Console.WriteLine(findpalindrome(str!));

string findpalindrome(string str)
{
    var leftMatched = string.Empty;
    var rightMatched = string.Empty;
    var lastIndex = str.Length - 1;
    for (int i = 0; i < lastIndex; i++)
    {
        var leftChar = str[i];
        var nextLeftChar = str[i + 1];
        for (int j = lastIndex; j > i; j--)
        {
            var rightChar = str[j];
            var nextRightChar = str[j - 1];
            if (leftChar == rightChar && nextLeftChar == nextRightChar)
            {
                leftMatched += leftChar;
                rightMatched = rightChar + rightMatched;
                lastIndex = j - 1;
                break;
            }
        }

        if (leftMatched != string.Empty && i + 1 == lastIndex)
        {
            leftMatched += str[lastIndex];
        }
    }
    return leftMatched + rightMatched;
}
