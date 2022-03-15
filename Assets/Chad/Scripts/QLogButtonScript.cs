using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QLogButtonScript : MonoBehaviour
{
    public int questID;
    public TMP_Text questTitle;

    public void ShowAllInfos()
    {
        QuestManager.questManager.ShowQuestLog(questID);
    }

    public void ClosePanel()
    {
        QuestUIManager.uiManager.HideQuestLogPanel();
    }
}
