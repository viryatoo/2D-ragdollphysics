using UnityEngine;

public class ScoreCalculator
{
    private float score;
    private float startRotationDegrees;
    private float endRotationDegrees;
    private float totalTimeInAir;
    private int totalFlips;

    public void StartFlip(float startRotation)
    {
        startRotationDegrees = startRotation;
        endRotationDegrees = startRotationDegrees;
        totalTimeInAir = 0;
    }

    public void UpdateFlip(float deltaRotation)
    {
        totalTimeInAir += Time.fixedDeltaTime;
        endRotationDegrees += deltaRotation;
    }

    public void EndFlip()
    {
        var result = Mathf.Abs(endRotationDegrees - startRotationDegrees);
        if (result > 360)
        {
            totalFlips = (int)(result / 360);
            Debug.Log("Совершено переворотов в воздухе: " + totalFlips);
        }
        totalTimeInAir = 0;
    }
}