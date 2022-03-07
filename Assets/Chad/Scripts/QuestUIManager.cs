using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUIManager : MonoBehaviour
{
    public static QuestUIManager uiManager;

    //BOOLS
    public bool questAvailable = false;
    public bool questRunning = false;
    private bool questPanelActive = false;
    private bool questLogActive = false;

    //PANELS
    public GameObject questPanel;
    public GameObject questLogPanel;

    //QUEST OBJECT
    private QuestObject currentQuestObject;

    //QUEST LISTS
    public List <Quest> availableQuests = new List<Quest>();
    public List <Quest> activeQuests = new List<Quest>();

    //BUTTONS
    public GameObject qButton;
    public GameObject qLogButton;
    private List <GameObject> qButtons = new List<GameObject>();

    private GameObject acceptButton;
    private GameObject completeButton;

    //SPACER
    public Transform qButtonSpacer1; // qButton available
    public Transform qButtonSpacer2; // qButton active
    public Transform qLogButtonSpacer; // active in qLog

    //QUEST INFOS
    public TMP_Text questTitle;
    public TMP_Text questDescription;
    public TMP_Text questSummary;
    
    //QUEST LOG INFOS
    public TMP_Text questLogTitle;
    public TMP_Text questLogDescription;
    public TMP_Text questLogSummary;

    private void Awake()
    {
        if (uiManager == null)
        {
            uiManager = this;
        }
        else if (uiManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        HideQuestPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            questPanelActive = !questPanelActive;
            // Show QuestLog Pannel
        }
    }

    // CALLED FROM QUEST OBJECT
    public void CheckQuest(QuestObject questObject)
    {
        currentQuestObject = questObject;
        QuestManager.questManager.QuestRequest(questObject);
        if((questRunning || questAvailable) && !questPanelActive)
        {
            ShowQuestPanel();
        }
        else
        {
            Debug.Log("No Quests Available");
        }
    }

    // SHOW PANEl 
    public void ShowQuestPanel()
    {
        questPanelActive = true;
        questPanel.SetActive(questPanelActive);
        // FILL IN DATA
        FillQuestButtons();
    }

    // QUEST LOG 


    // HIDE QUEST PANEL
    public void HideQuestPanel()
    {
        questPanelActive = false;
        questAvailable = false;
        questRunning = false;

        // CLEAR TEXT
        questTitle.text = "";
        questDescription.text = "";
        questSummary.text = "";

        // CLEAR LISTS
        availableQuests.Clear();
        activeQuests.Clear();

        // CLEAR BUTTON LIST
        for(int i = 0; i < qButtons.Count; i++)
        {
            Destroy(qButtons[i]);
        }
        qButtons.Clear();

        // HIDE PANEL
        questPanel.SetActive(questPanelActive);
    }

    // FILL BUTTONS FOR QUEST PANEL
    void FillQuestButtons()
    {
        foreach(Quest availableQuest in availableQuests)
        {
            GameObject questButton = Instantiate(qButton);
            QButtonScript qBScript = questButton.GetComponent<QButtonScript>();

            qBScript.questID = availableQuest.id;
            qBScript.questTitle.text = availableQuest.title;

            questButton.transform.SetParent(qButtonSpacer1, false);
            qButtons.Add(questButton);
        }
        foreach (Quest activeQuest in activeQuests)
        {
            GameObject questButton = Instantiate(qButton);
            QButtonScript qBScript = questButton.GetComponent<QButtonScript>();

            qBScript.questID = activeQuest.id;
            qBScript.questTitle.text = activeQuest.title;

            questButton.transform.SetParent(qButtonSpacer2, false);
            qButtons.Add(questButton);
        }
    }

    // SHOW QUEST ON BUTTON PRESS IN QUEST PANEL
    public void ShowSelectedQuest(int questID)
    {
        for(int i = 0; i < availableQuests.Count; i++)
        {
            if (availableQuests[i].id == questID)
            {
                questTitle.text = availableQuests[i].title;
                if(availableQuests[i].progress == Quest.QuestProgress.AVAILABLE)
                {
                    questDescription.text = availableQuests[i].description;
                    questSummary.text = availableQuests[i].questObjective + " : " + availableQuests[i].questObjectiveCount + " / " + availableQuests[i].questObjectiveRequirement;
                }
            }
        }
        for(int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i].id == questID)
            {
                questTitle.text = activeQuests[i].title;
                if(activeQuests[i].progress == Quest.QuestProgress.ACCEPTED)
                {
                    questDescription.text = activeQuests[i].hint;
                    questSummary.text = activeQuests[i].questObjective + " : " + activeQuests[i].questObjectiveCount + " / " + activeQuests[i].questObjectiveRequirement;
                }
                else if(activeQuests[i].progress == Quest.QuestProgress.COMPLETE)
                {
                    questDescription.text = activeQuests[i].congraluation;
                    questSummary.text = activeQuests[i].questObjective + " : " + activeQuests[i].questObjectiveCount + " / " + activeQuests[i].questObjectiveRequirement;
                }
            }
        }
    }
}
