using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public ScoreManager scoreManger;

    void OnTriggerExit(Collider other)
    {
        scoreManger.AddScore();
    }
}