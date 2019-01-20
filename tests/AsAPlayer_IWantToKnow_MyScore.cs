using System;
using System.IO;
using Xunit;
using app;

namespace tests
{
    public class AsAPlayer_IWantToKnow_MyScore
    {
        [Theory]
        [InlineData("1-1,1-1,1-1,1-1,1-1,1-1,1-1,1-1,1-1,1-1", "2,2,2,2,2,2,2,2,2,2", "20")] // All open frames
        [InlineData("10,10,10,10,10,10,10,10,10,10-10-10", "30,30,30,30,30,30,30,30,30,30", "300")] // All strikes
        public void RunningTheProgram_WithGivenInputString_WillWriteTheOutput_InTheConsole(string rolls, string expectedScoreByFrame, string expectedTotalScore)
        {
            using(StringWriter sw = new StringWriter())
            {
                // We set this StringWriter as Console output so that we can test the output
                Console.SetOut(sw);
                Program.Main(new[]{"-r", rolls});
                string consoleOut = sw.ToString();
                string[] lines = consoleOut.Split(Environment.NewLine);

                //Assert
                Assert.Equal(4, lines.Length);
                string outRolls = lines[0];
                string outScoreByFrame = lines[1];
                string outTotalScore = lines[2];

                Assert.Equal(rolls, outRolls);
                Assert.Equal(expectedScoreByFrame, outScoreByFrame);
                Assert.Equal(expectedTotalScore, outTotalScore);
            }
        }
    }
}
