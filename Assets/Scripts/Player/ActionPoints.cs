// script for control AP system

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ActionPoints : fadeInOut
{
    // how many days in one season
    private int daysinOneSeason = 5;
    // amount of max AP
    private int maxActionPoints = 100;

    // initialize UI values
    public static int actionPoints = 100;
    public static int date = 0;

    // UI texts
    public TextMeshProUGUI ActionPointsText;
    public TextMeshProUGUI DateText;

    // update UI when starting the scene
    void Start()
    {
        UpdateActionPointsUI();
        UpdateDateUI();
    }

    // update AP when event using AP occurs
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            ReduceActionPoints(10);

        if (Input.GetKeyDown(KeyCode.T))
            ReduceActionPoints(20);
    }

    // function to update AP
    void ReduceActionPoints(int amount)
    {
        // if require more than remaining AP, action is not happens
        if (actionPoints < amount)
            Debug.Log("Running out of Action Points!");

        // if AP is enough, reduce AP and update UI
        else
        {
            actionPoints -= amount;            
            UpdateActionPointsUI();

            // if AP becomes zero, move to scene where bed is located
            if (actionPoints == 0)
            {
                SceneManager.LoadScene("Indoor");
            }
        }
    }

    // coroutine to do sleep
    protected IEnumerator sleep()
    {
        // fill the AP to max and add date
        actionPoints = maxActionPoints;
        date++;

        // fade out and move to SleepScene
        StartCoroutine(FadeFunction(0f));
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SleepScene");
    }

    // function to update AP UI
    void UpdateActionPointsUI()
    {
        // express AP as "amount / max amount"
        if (ActionPointsText != null)
        {
            ActionPointsText.text = actionPoints.ToString() + " / " + maxActionPoints.ToString();
        }
    }

    // function to update Date UI
    void UpdateDateUI()
    {
        // express Date as "season - day"
        if (DateText != null)
        {
            switch(date / daysinOneSeason)
            {
                case 0: DateText.text = "SPRING - " + ((date % daysinOneSeason) + 1).ToString(); break;
                case 1: DateText.text = "SUMMER - " + ((date % daysinOneSeason) + 1).ToString(); break;
                case 2: DateText.text = "FALL - " + ((date % daysinOneSeason) + 1).ToString(); break;
                case 3: DateText.text = "WINTER - " + ((date % daysinOneSeason) + 1).ToString(); break;
                default: DateText.text = "Game End!"; break;
            }
        }
    }
}