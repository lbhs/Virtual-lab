using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationChecker : MonoBehaviour
{
    private int[] result, correctCombination;
    private bool isOpened;
    public AudioSource ChestOpeningSound;
    public Animator chest;
    private void Start()
    {
        result = new int[] { 0, 0, 0, 0, 0 };
        correctCombination = new int[] { 6, 7, 8, 4, 5 };
        isOpened = false;
        Rotate.Rotated += CheckResults;
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "WheelOne":
                result[0] = number;
                break;

            case "WheelTwo":
                result[1] = number;
                break;

            case "WheelThree":
                result[2] = number;
                break;

            case "WheelFour":
                result[3] = number;
                break;

            case "WheelFive":
                result[4] = number;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1]
            && result[2] == correctCombination[2] && result[3] == correctCombination[3]
            && result[4] == correctCombination[4] && !isOpened)
        {
            isOpened = true;
            chest.SetTrigger("Open");
        }

        else
        {
            chest.SetTrigger("Closed");
        }
    }

    private void OnDestroy()
    {
        Rotate.Rotated -= CheckResults;
    }
}
