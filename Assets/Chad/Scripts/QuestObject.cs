using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObject : MonoBehaviour
{
    private bool inTrigger = false;


    public List<int> availableQuestIDs = new List<int>();
    public List<int> receivableQuestIDs = new List<int>();

    public GameObject questMarker;
    public Image theImage;

    public Sprite questAvailableSprite;
    public Sprite questReceivableSprite;

    void SetQuestMarker()
    {
        if(QuestManager.questManager.CheckCompletedQuests(this))
        {
            questMarker.SetActive(true);
            theImage.sprite = questReceivableSprite;
        }
        else if (QuestManager.questManager.CheckAvailableQuests(this))
        {
            questMarker.SetActive(true);
            theImage.sprite = questAvailableSprite;
        }
        else if (QuestManager.questManager.CheckAcceptedQuests(this))
        {
            questMarker.SetActive(true);
            theImage.sprite = questReceivableSprite;
        }
    }

    void Update()
    {
        if(inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            // Quest UI Manager
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = false;
        }
    }
}
