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

        if (!season.getGames().Any())
        {
            return 0.0;
        }
        else
        {
            List<Game> games = season.getGames();
            int tga = 0;
            double mins = 0;

            foreach (Game game in games)
            {
                tga += game.getGoalsAgainst();
                mins += game.getMinutesPlayed();
            }

            return (tga / mins) * 60;
        }
    }

    public double getSavePercentage()
    {

        if (!season.getGames().Any())
        {
            return 0.0;
        }
        else
        {
            List<Game> games = season.getGames();
            int g = 0;
            int tsoga = 0;

            foreach (Game game in games)
            {
                g += game.getGoalsAgainst();
                tsoga += game.getShotsOnGoalAgainst();
            }

            return ((double)tsoga - g) / tsoga;
        }
    }
}