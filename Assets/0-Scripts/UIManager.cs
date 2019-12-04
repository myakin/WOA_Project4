using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text messageText;
    public Transform saveLoadPanel;
    public Button saveButton, loadButton, benjaminButton;
    private bool coroutineBlocker;

    private List<MessageToPlayer> messages = new List<MessageToPlayer>();

    private void Start() {
        saveButton.onClick.AddListener(SaveButtonFunction);
        loadButton.onClick.AddListener(LoadButtonFunction);
        benjaminButton.onClick.AddListener(BenjaminButtonFunction);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if (!saveLoadPanel.gameObject.activeSelf) {
                Utilities.utilities.UnlockMouse();

            } else {
                Utilities.utilities.LockMouse();
                
            }
            BenjaminButtonFunction();
        }
    }

    private void SaveButtonFunction() {
        DataManager.dataManager.Save();
    }
    private void LoadButtonFunction() {
        DataManager.dataManager.Load();
    }
    private void BenjaminButtonFunction() {
        saveLoadPanel.gameObject.SetActive(!saveLoadPanel.gameObject.activeSelf);
    }
    
    public void SetMessageText(string aMessage, float duration) {
        MessageToPlayer m = new MessageToPlayer(aMessage, duration);
        messages.Add(m);
        if (!coroutineBlocker) {
            coroutineBlocker=true;
            StartCoroutine(EndMessages());
        }
    }

    private IEnumerator EndMessages() {
        messageText.text = messages[0].messaage;
        yield return new WaitForSeconds(messages[0].duration);
        messageText.text = "";
        messages.RemoveAt(0);
        if (messages.Count==0) {
            StopCoroutine(EndMessages());
            coroutineBlocker=false;
        } else {
            yield return EndMessages();
        } 
    }
}

public class MessageToPlayer {
    public string messaage;
    public float duration;

    public MessageToPlayer (string aMessage, float aDuration) {
        this.messaage = aMessage;
        this.duration = aDuration;
    }
}
