using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RhythmHeavenMania.Games.Minigame;

public class GameScoreManager : Singleton<GameScoreManager>
{
    public int currentScore;
    public int maxScore;
    public int scorePerHit = 10;
    public int scoreNotPerfect = 5;
    public void recordScore(Eligible eligible)
    {
        //maxScore += scorePerHit;
        if (eligible.perfect)
        {
            currentScore += scorePerHit;
        }
        else if (eligible.notPerfect())
        {
            currentScore += scoreNotPerfect;
        }
        EventPool.Trigger("scoreChange");
    }

    public void registerScore()
    {

        maxScore += scorePerHit;
        EventPool.Trigger("scoreChange");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
