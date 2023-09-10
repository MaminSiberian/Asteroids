using UnityEngine;

public static class ScoreSaver
{
    public static void SaveScore(int scoreValue)
    {
        Score score = new Score { score = scoreValue };
        SaveSystem.SaveToFile(score);
    }
    public static int LoadScore()
    {
        var obj = SaveSystem.LoadFromFile<Score>();
        if (obj == null) {
            SaveScore(0);
            return 0; }

        Score score = (Score)obj;
        return score.score;
    }
}
