using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text messageText;
    private bool coroutineBlocker;

    private List<MessageToPlayer> messages = new List<MessageToPlayer>();
    
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
