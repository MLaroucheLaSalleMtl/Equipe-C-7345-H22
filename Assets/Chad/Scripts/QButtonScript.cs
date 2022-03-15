using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QButtonScript : MonoBehaviour
{
    public int questID;
    public TMP_Text questTitle;

    // SHOW ALL INFOS
    public void ShowAllInfos()
    {
        QuestUIManager.uiManager.ShowSelectedQuest(questID);
        // ACCEPT BUTTON
        if(QuestManager.questManager.RequestAvailableQuest(questID))
        {
            QuestUIManager.uiManager.acceptButton.SetActive(true);
            QuestUIManager.uiManager.acceptButtonScript.questID = questID;
        }
        else
        {
            QuestUIManager.uiManager.acceptButton.SetActive(false);
        }
        // COMPLETE BUTTON
        if (QuestManager.questManager.RequestCompleteQuest(questID))
        {
            QuestUIManager.uiManager.completeButton.SetActive(true);
            QuestUIManager.uiManager.completeButtonScript.questID = questID;
        }
        else
        {
            QuestUIManager.uiManager.completeButton.SetActive(false);
        }
    }

    public void AcceptQuest()
    {
        QuestManager.questManager.AcceptQuest(questID);
        QuestUIManager.uiManager.HideQuestPanel();

        // UPDATE ALL NPCS
        QuestObject[] currentQuestNPCS = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach(QuestObject obj in currentQuestNPCS)
        {
            obj.SetQuestMarker();
        }
    }
    public void CompleteQuest()
    {
        QuestManager.questManager.CompleteQuest(questID);
        QuestUIManager.uiManager.HideQuestPanel();

        // UPDATE ALL NPCS
        QuestObject[] currentQuestNPCS = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach (QuestObject obj in currentQuestNPCS)
        {
            obj.SetQuestMarker();
        }
    }

    public void ClosePanel()
    {
        QuestUIManager.uiManager.HideQuestPanel();
        QuestUIManager.uiManager.acceptButton.SetActive(false);
        QuestUIManager.uiManager.completeButton.SetActive(false);
    }
}
