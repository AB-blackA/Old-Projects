using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{

    private int victoryPoints = 0;

    public readonly int noStats = 4;
    private int statMin = 4; private int statMax = 7;

    public int str;
    public int wis;
    public int cha;
    public int dex;

    public readonly int strIndex = 0;
    public readonly int wisIndex = 1;
    public readonly int chaIndex = 2;
    public readonly int dexIndex = 3;


    public int[] statRollsByIndex; //contains the stat rolls for each stat by their above index

    public string[] statStringsByIndex;

    private int noEventsGame = 2; //goal was 20
    private static int noEventsAll = 3;
    private Queue<StoryEvent> eventsInGame = new Queue<StoryEvent>();
    private static StoryEvent[] allEvents = new StoryEvent[noEventsAll];


    // Start is called before the first frame update
    void Start()
    {
        RollStats();
        FillStringArrays();
        FillStoryEvents();
    }

    // Update is called once per frame
    private void RollStats()
    {
        int[] statVals = new int[noStats]; statVals[0] = 4; statVals[1] = 5; statVals[2] = 6; statVals[3] = 7;
        int[] pickedVals = new int[noStats]; pickedVals[0] = -1; pickedVals[1] = -1; pickedVals[2] = -1; pickedVals[3] = -1;
        int pickCount = 0;
        int statRoll;

        while( pickCount < noStats)
        {
            statRoll = Random.Range(0, statVals.Length);
            
            for(int i = 0; i < pickedVals.Length; i++)
            {
                if(statVals[statRoll] == pickedVals[i])
                {
                    break;
                }

                if(i == (pickedVals.Length - 1))
                {
                    if(pickCount == strIndex)
                    {
                        str = statVals[statRoll];
                    }else if (pickCount == wisIndex)
                    {
                        wis = statVals[statRoll];
                    }else if (pickCount == chaIndex)
                    {
                        cha = statVals[statRoll];
                    }else if (pickCount == dexIndex)
                    {
                        dex = statVals[statRoll];
                    }

                    pickedVals[pickCount] = statVals[statRoll];
                    pickCount++;


                }
            }
        }

        statRollsByIndex = new int[noStats]; statRollsByIndex[strIndex] = str; statRollsByIndex[wisIndex] = wis; statRollsByIndex[chaIndex] = cha; statRollsByIndex[dexIndex] = dex;




        Debug.Log("str " + str + "wis" + wis + "cha" + cha + "dex" + dex);
    }

    private void FillStringArrays()
    {
        statStringsByIndex = new string[noStats];
        statStringsByIndex[strIndex] = "STR";
        statStringsByIndex[wisIndex] = "WIS";
        statStringsByIndex[chaIndex] = "CHA";
        statStringsByIndex[dexIndex] = "DEX";
    }

    public string GetStatStringByIndex(int i)
    {
        if(i > 3)
        {
            Debug.Log("ERROR: GetStatStringIndex out of bounds, returning 0");
            i = 0;
        }
        return statStringsByIndex[i];
    }

    private void FillStoryEvents()
    {
        GameObject[] eventHolders = GameObject.FindGameObjectsWithTag("Script Holder");

        for (int i = 0; i < noEventsAll; i++)
        {
            allEvents[i] = eventHolders[i].GetComponent<StoryEvent>();
            allEvents[i].Debugger();

        }

        int[] pickedEvents = new int[noEventsGame];
        for(int i = 0; i < pickedEvents.Length; i++)
        {
            pickedEvents[i] = -1; //-1 will never be code for an event
        }

        int pickCount = 0;
        int eventToAdd;

        
        while (pickCount < noEventsGame)
        {
            eventToAdd = Random.Range(0, (noEventsAll));

            for(int i = 0; i < pickedEvents.Length; i++)
            {
                if(eventToAdd == pickedEvents[i])
                {
                    break;
                }

                if(i == (pickedEvents.Length - 1)){

                    eventsInGame.Enqueue(allEvents[eventToAdd]);
                    pickedEvents[pickCount] = eventToAdd;
                    Debug.Log(allEvents[eventToAdd]);
                    pickCount++;
                }
            }
        }

        Debug.Log(pickCount + "picked");

    }

    public Queue<StoryEvent> GetGameEvents()
    {
        return eventsInGame;
    }

    public void Debugger()
    {
        Debug.Log("Variables script");
    }

    public int StatRollByIndex(int i)
    {
        return statRollsByIndex[i];
    }

    public void ChangeVictoryPoints(int i)
    {
        victoryPoints += i;
    }

    public int GetVictoryPoints()
    {
        return victoryPoints;
    }
}
