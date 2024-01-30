using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public Canvas OptionsCanvas;
    public Variables gameVariables;

    private bool buttonsActive = false;
    private bool nextEventButtonActive = true; //set to false before it would matter if button was pressed
    private Queue<StoryEvent> eventsInGame;
    private StoryEvent currentEvent;

    private static int statsToChoose = 3; //amount of buttons of which stats will be chosen
    private int[] statIndexsForEvent = new int[statsToChoose]; //holds the indexes for the stats chosen for this event, NOT THEIR VALUES

    [SerializeField] public TextMeshProUGUI mainNarrative;

    [SerializeField] public TextMeshProUGUI victoryPoints;
    private int victoryPointsWon = 1;
    private int victoryPointsLost = -1;

    [SerializeField] public TextMeshProUGUI topButton;
    [SerializeField] public TextMeshProUGUI midButton;
    [SerializeField] public TextMeshProUGUI botButton;
    [SerializeField] public TextMeshProUGUI topText;
    [SerializeField] public TextMeshProUGUI midText;
    [SerializeField] public TextMeshProUGUI botText;

    [SerializeField] public TextMeshProUGUI nextEventButtonText;

    [SerializeField] public TextMeshProUGUI resultNarrative;

    private int topButtonIndex = 0;
    private int midButtonIndex = 1;
    private int botButtonIndex = 2;
    private int topTextIndex = 0;
    private int midTextIndex = 1;
    private int botTextIndex = 2;

    private void Update()
    {
        victoryPoints.SetText("" + gameVariables.GetVictoryPoints());
    }

    public void StartGame()
    {
        gameVariables.Debugger();
        eventsInGame = gameVariables.GetGameEvents();
        LoadNextEvent();
        ToggleOptions();
        Debug.Log("Start Game");
    }

    public void LoadNextEvent()
    {
        resultNarrative.SetText(""); //reset to nothing
        ChooseStats();
        if (eventsInGame.Count > 0)
        {
            currentEvent = eventsInGame.Dequeue();
            LoadText();
            currentEvent.Debugger();
            SetButtonStatus(); //allows button presses to do something. gets reset when a button is pressed
        }
        else
        {
            mainNarrative.SetText("End Game");
        }
    }

    public void LoadNextEventCheck()
    {
        if (nextEventButtonActive)
        {
            LoadNextEvent();
        }
    }

    public void RollAgainstTop()
    {
        if (buttonsActive)
        {
            //buttonsActive = false;
            SetButtonStatus();
            int roll = Random.Range(1, 11); //1d10
            if(gameVariables.StatRollByIndex(statIndexsForEvent[topButtonIndex]) >= roll)
            {
                resultNarrative.SetText(currentEvent.GetStatPass(statIndexsForEvent[topTextIndex]));
                gameVariables.ChangeVictoryPoints(victoryPointsWon);
            }
            else
            {
                resultNarrative.SetText(currentEvent.GetStatFail(statIndexsForEvent[topTextIndex]));
                gameVariables.ChangeVictoryPoints(victoryPointsLost);
            }

            //nextEventButtonActive = true; //allows flag for user to start next event

        }
    }
    public void RollAgainstMid()
    {
        if (buttonsActive)
        {
            SetButtonStatus();
            int roll = Random.Range(1, 11); //1d10
            if (gameVariables.StatRollByIndex(statIndexsForEvent[topButtonIndex]) >= roll)
            {
                resultNarrative.SetText(currentEvent.GetStatPass(statIndexsForEvent[midTextIndex]));
                gameVariables.ChangeVictoryPoints(victoryPointsWon);
            }
            else
            {
                resultNarrative.SetText(currentEvent.GetStatFail(statIndexsForEvent[midTextIndex]));
                gameVariables.ChangeVictoryPoints(victoryPointsLost);
            }

        }
    }
    public void RollAgainstBot()
    {
        if (buttonsActive)
        {
            SetButtonStatus(); 
            int roll = Random.Range(1, 11); //1d10
            if (gameVariables.StatRollByIndex(statIndexsForEvent[topButtonIndex]) >= roll)
            {
                resultNarrative.SetText(currentEvent.GetStatPass(statIndexsForEvent[botTextIndex]));
                gameVariables.ChangeVictoryPoints(victoryPointsWon);
            }
            else
            {
                resultNarrative.SetText(currentEvent.GetStatFail(statIndexsForEvent[botTextIndex]));
                gameVariables.ChangeVictoryPoints(victoryPointsLost);
            }

        }
    }

    private void ToggleOptions()
    {
        OptionsCanvas.enabled = !OptionsCanvas.enabled; //flips from true to false
    }

    private void ChooseStats()
    {
        WipeStatArrays(); //resets stat arrays
        int statIndexChosen = -1;
        int preStat1 = -1;
        int preStat2 = -1;

        for(int i = 0; i < statsToChoose; i++)
        {
            statIndexChosen = Random.Range(0, gameVariables.noStats);
            if((statIndexChosen == preStat1) || (statIndexChosen == preStat2))
            {
                i--; //essentially resets this loop once for every time a stat that has been picked gets picked again
            }
            else
            {
                statIndexsForEvent[i] = statIndexChosen;

                if(preStat1 == -1)
                {
                    preStat1 = statIndexChosen;
                }else if(preStat2 == -1)
                {
                    preStat2 = statIndexChosen;
                }
            }

        }
    }

    private void WipeStatArrays()
    {
        for(int i = 0; i < statsToChoose; i++)
        {
            statIndexsForEvent[i] = -1; //-1 impossible stat index hence a "wipe"
        }
    }

    private void LoadText()
    {
        topButton.SetText(gameVariables.GetStatStringByIndex(statIndexsForEvent[topButtonIndex]));
        midButton.SetText(gameVariables.GetStatStringByIndex(statIndexsForEvent[midButtonIndex]));
        botButton.SetText(gameVariables.GetStatStringByIndex(statIndexsForEvent[botButtonIndex]));
        topText.SetText(currentEvent.GetStatText(statIndexsForEvent[topTextIndex]));
        midText.SetText(currentEvent.GetStatText(statIndexsForEvent[midTextIndex]));
        botText.SetText(currentEvent.GetStatText(statIndexsForEvent[botTextIndex]));
        mainNarrative.SetText(currentEvent.NarrativeStart());

    }

    private void SetButtonStatus()
    {
        buttonsActive = !buttonsActive;
        nextEventButtonActive = !nextEventButtonActive;

        if (!nextEventButtonActive)
        {
            nextEventButtonText.SetText("Pick a Stat!");
        }
        else
        {
            nextEventButtonText.SetText("Next Event");
        }
    }
}
