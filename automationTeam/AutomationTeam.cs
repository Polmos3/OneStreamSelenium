namespace automationTeam;

public class AutomationTeam
{

    private List<string> memberNames;

    public AutomationTeam(string memberName)
    {
        memberNames = [memberName];
    }

    public AutomationTeam AddMemeber(string memeberName)
    {
        memberNames.Add(memeberName);
        return this;
    }

    public int GetMemebersCount()
    {
        return memberNames.Count;
    }

    public void RemoveMember(string memberName)
    {
        memberNames.Remove(memberName);
    }

    public void SortNames()
    {
        memberNames.Sort();
        PrintMembers();
    }

    public void PrintMembers()
    {
        foreach (string memberName in memberNames)
        {
            Console.WriteLine(memberName);
        }
    }



    public List<string> GetMemebers()
    {
        return memberNames;
    }

    public int CountDeletions(string text)
    {
        string formatedText = text.Trim().ToLower();
        return countDeletionRec(formatedText, 0);

    }

    // Recursive approach 
    // Since the repeated caracters are deleted, the string is traverse form left ot right
    // Steps:
    // Start traversing the string from index 0 
    // If char in curent index is equal to the next one
    // Add one to the count and call function with current index and a substring removing the repeated char
    // If chars are not equal call function and increase the currentIndex
    // When currentIndex is 
    private int countDeletionRec(string text, int currentIndex)
    {
        if (currentIndex >= text.Length - 1)
        {
            return 0;
        }

        if (text[currentIndex] == text[currentIndex + 1])
        {

            string restText = currentIndex + 2 > text.Length ? "" : text.Substring(currentIndex + 2);
            return 1 + countDeletionRec(text.Substring(0, currentIndex + 1) + restText, currentIndex);
        }


        return countDeletionRec(text, currentIndex + 1);

    }


}
