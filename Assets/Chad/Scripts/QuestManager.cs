using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager questManager;

    public List<Quest> questList = new List<Quest>(); // Master Quest List
    public List<Quest> currentQuestList = new List<Quest>(); // Current Quest List

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

    // QUEST REQUEST
    public void QuestRequest(QuestObject NPCQuestObject)
    {
        if(NPCQuestObject.availableQuestIDs.Count > 0)
        {
            for(int i = 0; i < questList.Count; i++)
            {
                for(int j = 0; j < NPCQuestObject.availableQuestIDs.Count; j++)
                {
                    if(questList[i].id == NPCQuestObject.availableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.AVAILABLE)
                    {
                        Debug.Log("Quest ID: " + NPCQuestObject.availableQuestIDs[j] + " " + questList[i].progress);
                        // Testing
                        //AcceptQuest(NPCQuestObject.availableQuestIDs[j]);
                        // Quest UI Manager
                        QuestUIManager.uiManager.questAvailable = true;
                        QuestUIManager.uiManager.availableQuests.Add(questList[i]);
                    }
                }
            }
        }
        // ACTIVE QUEST
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.receivableQuestIDs.Count; j++)
            {
                if(currentQuestList[i].id == NPCQuestObject.receivableQuestIDs[j] && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED || currentQuestList[i].progress == Quest.QuestProgress.COMPLETE)
                {
                    Debug.Log("Quest ID: " + NPCQuestObject.receivableQuestIDs[j] + " is " + currentQuestList[i].progress);

                    //CompleteQuest(NPCQuestObject.receivableQuestIDs[j]);
                    // Quest UI Manager
                    QuestUIManager.uiManager.questRunning = true;
                    QuestUIManager.uiManager.activeQuests.Add(currentQuestList[i]);
                }
            }
        }
    }

    // ACCEPT QUEST
    public void AcceptQuest(int questID)
    {
       for (int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE)
            {
                currentQuestList.Add(questList[i]);
                questList[i].progress = Quest.QuestProgress.ACCEPTED;
            }
        }
    }
   
    
    // COMPLETE QUEST
    public void CompleteQuest(int questID)
    {
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            if(currentQuestList[i].id == questID && currentQuestList[i].progress == Quest.QuestProgress.COMPLETE)
            {
                currentQuestList[i].progress = Quest.QuestProgress.DONE;
                currentQuestList.Remove(currentQuestList[i]);

                // REWARD
            }
        }
        // Check for chain quests
        CheckChainQuests(questID);
    }

    // CHECK CHAIN QUESTS
    void CheckChainQuests(int questID)
    {
        int tempID = 0;
        for(int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].nextQuest > 0)
            {
                tempID = questList[i].nextQuest;
            }
        }
        if(tempID > 0)
        {
            for(int i = 0; i < questList.Count; i++)
            {
                if(questList[i].id == tempID && questList[i].progress == Quest.QuestProgress.NOT_AVAILABLE)
                {
                    questList[i].progress = Quest.QuestProgress.AVAILABLE;
                }
            }
        }
    }

    // ADD ITEMS
    public void AddQuestItem(string questObjective, int itemAmount)
    {
        for(int i = 0; i < currentQuestList.Count; i++ )
        {
            if(currentQuestList[i].questObjective == questObjective && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                currentQuestList[i].questObjectiveCount += itemAmount;
            }

            if(currentQuestList[i].questObjectiveCount >= currentQuestList[i].questObjectiveRequirement && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                currentQuestList[i].progress = Quest.QuestProgress.COMPLETE;
            }
        }
    }

    // BOOL 
    public bool RequestAvailableQuest(int questID)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE)
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
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.ACCEPTED)
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
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.COMPLETE)
            {
                return true;
            }
        }
        return false;
    }

    // BOOL 2

    public bool CheckAvailableQuests(QuestObject NPCQuestObject)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            for(int j = 0; j < NPCQuestObject.availableQuestIDs.Count; j++)
            {
                if(questList[i].id == NPCQuestObject.availableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.AVAILABLE)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckAcceptedQuests(QuestObject NPCQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.receivableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestObject.receivableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.ACCEPTED)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckCompletedQuests(QuestObject NPCQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.receivableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestObject.receivableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.COMPLETE)
                {
                    return true;
                }
            }
        }
        return false;
    }

    //SHOW QUEST LOG 
    public void ShowQuestLog(int questID)
    {
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            if(currentQuestList[i].id == questID)
            {
                QuestUIManager.uiManager.ShowQuestLog(currentQuestList[i]);
            }
        }
    }

}
