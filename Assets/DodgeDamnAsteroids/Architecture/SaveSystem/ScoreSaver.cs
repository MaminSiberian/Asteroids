using UnityEngine;

public static class ScoreSaver
{
    private static string key = "score";

    public static void SaveScore(int scoreValue)
    {
        Score score = new Score { score = scoreValue };
        SaveSystem.SaveToFile(score, key);
    }
    public static int LoadScore()
    {
        var obj = SaveSystem.LoadFromFile<Score>(key);
        if (obj == null) {
            SaveScore(0);
            return 0; }

        Score score = (Score)obj;
        return score.score;
    }
}
