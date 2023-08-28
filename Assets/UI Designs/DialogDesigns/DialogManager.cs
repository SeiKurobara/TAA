using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class DialogManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;

    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;

        isActive = true;

        Debug.Log("Started Conversastion! Loaded Message" + messages.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.messasge;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        AnimateTextColor();
    }

    public void NextMessasge()
    {
        activeMessage++;
        if(activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation Ended");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
        }
    }

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }
    public void ExitDialog()
    {
        backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        isActive = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isActive == true)
        {
            NextMessasge();
        }
    }
}
