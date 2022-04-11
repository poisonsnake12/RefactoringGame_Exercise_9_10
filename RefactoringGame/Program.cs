public class Game
{

    private double minutesPlayed;
    private int goalsAgainst;
    private int shotsOnGoalAgainst;

    public Game(int goalsAgainst, int shotsOnGoalAgainst, double minutesPlayed)
    {
        this.goalsAgainst = goalsAgainst;
        this.shotsOnGoalAgainst = shotsOnGoalAgainst;
        this.minutesPlayed = minutesPlayed;
    }

    public int getGoalsAgainst()
    {
        return goalsAgainst;
    }

    public int getShotsOnGoalAgainst()
    {
        return shotsOnGoalAgainst;
    }

    public double getMinutesPlayed()
    {
        return minutesPlayed;
    }
}

public class Season
{

    private List<Game> games;

    public Season(List<Game> games)
    {
        this.games = new List<Game>(games);
    }

    public Season()
    {
        this.games = new List<Game>();
    }

    public void addGame(Game game)
    {
        games.Add(game);
    }

    public void removeGame(Game game)
    {
        games.Remove(game);
    }

    public List<Game> getGames()
    {
        return games;
    }

    public GoalieStatistics getGoalieStatistics()
    {
        return new GoalieStatistics(this);
    }

    public bool hasStarted()
    {
        return games.Any();
    }

    public int getTotalGoalsAgainst()
    {
        return games.Sum(x=>Convert.ToInt32(x.getGoalsAgainst()));
    }

    public int getTotalMinutesPlayed()
    {
        return games.Sum(x=>Convert.ToInt32(x.getMinutesPlayed()));
    }

    public int getTotalShotsOnGoalAgainst()
    {
        return games.Sum(x=>Convert.ToInt32((x.getShotsOnGoalAgainst())));
    }
}

public class GoalieStatistics
{

    private Season season;

    public GoalieStatistics(Season season)
    {
        this.season = season;
    }
    public double getGoalsAgainstAverage()
    {

        if (!season.hasStarted())
        {
            return 0.0;
        }
        else
        {
            int totalGoalsAgainst = season.getTotalGoalsAgainst();

            double totalMinutesPlayed = season.getTotalMinutesPlayed();

            return (totalGoalsAgainst / totalMinutesPlayed) * 60;
        }
    }

    public double getSavePercentage()
    {

        if (!season.hasStarted())
        {
            return 0.0;
        }
        else
        {
            int totalGoalsAgainst = season.getTotalGoalsAgainst();
            int totalSogAgainst = season.getTotalShotsOnGoalAgainst();
            return ((double)totalSogAgainst - totalGoalsAgainst) / totalSogAgainst;
        }
    }

}