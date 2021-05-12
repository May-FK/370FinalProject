public static class Score
{
    private static int score;

    public static int getScore()
    {
        return score;
    }

    public static void increaseScore()
    {
        score += 1;
    }

    public static void resetScore()
    {
        score = 0;
    }
}
