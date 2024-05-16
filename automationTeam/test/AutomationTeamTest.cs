using Xunit;

namespace automationTeam;

public class AutomationTeamTest
{
    [Fact]
    public void TestMembersActions()
    {
        AutomationTeam automationTeam = new AutomationTeam("ABC");
        automationTeam.AddMemeber("BCD")
            .AddMemeber("CDF")
            .AddMemeber("DFG");

        Assert.Equal(4, automationTeam.GetMemebersCount());

        automationTeam.RemoveMember("BCD");

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        Assert.Equal(3, automationTeam.GetMemebersCount());

        automationTeam.SortNames();
        var output = stringWriter.ToString();
        string expectedOutput = "ABC\nCDF\nDFG\n";
        Assert.Equal(expectedOutput, output);

    }

    [Fact]
    public void TestCountDeletions()
    {
        AutomationTeam automationTeam = new AutomationTeam("");

        Assert.Equal(2, automationTeam.CountDeletions("CCBCCB"));
        Assert.Equal(3, automationTeam.CountDeletions("SSSS"));
        Assert.Equal(4, automationTeam.CountDeletions("GGGGG"));
        Assert.Equal(0, automationTeam.CountDeletions("FGFGFGFG"));
        Assert.Equal(4, automationTeam.CountDeletions("UUUIII"));
        Assert.Equal(5, automationTeam.CountDeletions("UUUIIII"));


    }
}
