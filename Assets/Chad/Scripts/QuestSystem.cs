using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public enum QuestProgress {NOT_AVAILABLE, AVAILABLE, ACCEPTED, COMPLETE, DONE}

    public string title;            // Title for the quest
    public int id;                  // ID number for the quest
    public QuestProgress progress;  // State of the current quest (enum)
    public string description;      // String from our quest giver/receiver
    public string hint;             // String from our quest giver/receiver
    public string congraluation;    // String from our quest giver/receiver
    public string summary;          // String from our quest giver/receiver
    public int nextQuest;           // The next quest (If needed/chain quest)

    public string questObjective;   // Name of the quest objective
    public int questObjectiveCount; // Current number of questObjective count
    public int questObjectiveRequirement;   // Required amount of quest objective objects

    public int expReward;
    public int goldReward;
    public string itemReward;
}
