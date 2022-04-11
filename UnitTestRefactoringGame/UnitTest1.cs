using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestRefactoringGame;

namespace UnitTestRefactoringGame
{
    [TestClass]
    public class UnitTest1
    {
        public double Tolerance = 0.001;

        [TestMethod]
        public void noGamesInSeasonEnsureZeroSavePercentage()
        {
            //arrange
            Season season = new Season();

            //act
            GoalieStatistics statistics = season.getGoalieStatistics();

            //assert
            Assert.AreEqual(0.0, statistics.getSavePercentage());

        }

        [TestMethod]
        public void noGamesInSeasonEnsureZeroGoalsAgainstAverage()
        {
            //arrange
            Season season = new Season();

            //act
            GoalieStatistics statistics = season.getGoalieStatistics();

            //assert
            Assert.AreEqual(0.0, statistics.getGoalsAgainstAverage());

        }

        [TestMethod]
        public void oneGameInSeasonEnsureCorrectGoaliesAgainstAverage()
        {
            //arrange
            Season season = new Season();

            //act
            GoalieStatistics statistics = season.getGoalieStatistics();
            season.addGame(new Game(3, 10, 60.0));

            //assert
            Assert.AreEqual(3.0, statistics.getGoalsAgainstAverage());

        }

        [TestMethod]
        public void oneGameInSeasonEnsureCorrectSavePercentage()
        {
            //arrange
            Season season = new Season();

            //act
            GoalieStatistics statistics = season.getGoalieStatistics();
            season.addGame(new Game(3, 10, 90.0));

            //assert
            Assert.AreEqual(0.7, statistics.getSavePercentage());

        }

        [TestMethod]
        public void twoGameInSeasonEnsureCorrectSavePercentage()
        {
            //arrange
            Season season = new Season();

            //act
            GoalieStatistics statistics = season.getGoalieStatistics();
            season.addGame(new Game(3, 10, 60.0));
            season.addGame(new Game(2, 17, 90.0));

            //assert
            Assert.AreEqual(0.8148, statistics.getSavePercentage(), Tolerance);

        }

        [TestMethod]
        public void twoGameInSeasonEnsureCorrectGoaliesAgainstAverage()
        {
            //arrange
            Season season = new Season();

            //act
            GoalieStatistics statistics = season.getGoalieStatistics();
            season.addGame(new Game(3, 10, 60.0));
            season.addGame(new Game(2, 17, 90.0));

            //assert
            Assert.AreEqual(2, statistics.getGoalsAgainstAverage(), Tolerance);

        }
    }
}