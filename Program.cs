
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


var data = new int[][] {
    new int[] { 1,0 },
    new int[] { 1,0 },
    new int[] { 1,0 },
    new int[] { 1,1 }
};
var k = 4;
KWeakestRows(data, k);
int[] KWeakestRows(int[][] mat, int k)
{
    int[] ground = new int[mat.Length];
    int[] indexes = new int[mat.Length];
    int[] result = new int[k];
    for (int i = 0; i < mat.Length; i++)
    {
        int soldiers = 0;

        for (int j = 0; j < mat[i].Length; j++)
        {
            if (mat[i][j] == 0)
            {
                break;
            }
            soldiers++;
        }

        ground[i] = soldiers;
        indexes[i] = i;
    }
    for (int i = 0; i < mat.Length - 1; i++)
    {
        for (int j = i + 1; j < mat.Length; j++)
        {
            if (ground[indexes[i]] > ground[indexes[j]])
            {
                var temp = indexes[i];
                indexes[i] = indexes[j];
                indexes[j] = temp;
            }
        }
        if (i < k)
        {
            result[i] = indexes[i];
            if (mat.Length - 1 == i + 1 && i + 1 < k)
            {
                result[i + 1] = indexes[i + 1];
            }
        }
    }
    return result;
}