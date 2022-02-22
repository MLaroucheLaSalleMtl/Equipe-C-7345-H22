using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QuestManager : MonoBehaviour
{
    public static QuestManager questManager;

    public List<QuestSystem> questList = new List<QuestSystem>(); // Master Quest List
    public List<QuestSystem> currentQuestList = new List<QuestSystem>(); // Current Quest List

    // Private vars for our QuestObject

    private void Awake()
    {
        if (questManager == null)
        {
            questManager = this;
        }
        else if(questManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // ACCEPT QUEST

    public void AcceptQuest(int questID)
    {
       
    }
   
    
    // COMPLETE QUEST



    // ADD ITEMS

    public void AddQuestItem(string questObjective, int itemAmount)
    {
        for(int i = 0; i < currentQuestList.Count; i++ )
        {
            if(currentQuestList[i].questObjective == questObjective && currentQuestList[i].progress == QuestSystem.QuestProgress.ACCEPTED)
            {
                currentQuestList[i].questObjectiveCount += itemAmount;
            }

            if(currentQuestList[i].questObjectiveCount >= currentQuestList[i].questObjectiveRequirement && currentQuestList[i].progress == QuestSystem.QuestProgress.ACCEPTED)
            {
                currentQuestList[i].progress = QuestSystem.QuestProgress.COMPLETE;
            }
        }
    }

    // REMOVE ITEMS


    // BOOL 

    public bool RequestAvailableQuest(int questID)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].progress == QuestSystem.QuestProgress.AVAILABLE)
            {
                return true;
            }
        }
        return false;
    }
    public bool RequestAcceptedQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == QuestSystem.QuestProgress.ACCEPTED)
            {
                return true;
            }
        }
        return false;
    }
    public bool RequestCompleteQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == QuestSystem.QuestProgress.COMPLETE)
            {
                return true;
            }
        }
        return false;
    }

}
