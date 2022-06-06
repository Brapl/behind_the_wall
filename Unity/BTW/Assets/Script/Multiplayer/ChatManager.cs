using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class ChatManager : MonoBehaviour
{
    public TMP_InputField input;
    static TMP_InputField chatInput;
    public TextMeshProUGUI chatContent;
    private static PhotonView _photView;
    private List<string> _messages = new List<string>();
    private float _buildDelay = 0f;
    private int _maximumMessages = 5;

    public GameObject chatSub;
    private bool isTyping;
    
    void Start()
    {
        _photView = GetComponent<PhotonView>();
        chatInput = input;
    }

    [PunRPC]
    void RPC_AddNewMessage(string mess)
    {
        _messages.Add(mess);
    }

    public static void SendChat(string mess)
    {
        string NewMess = PhotonNetwork.NickName + " : " + mess;
        _photView.RPC("RPC_AddNewMessage", RpcTarget.All, NewMess);
    }

    public static void SubmitChat()
    {
        string blankCheck = chatInput.text;
        blankCheck = Regex.Replace(blankCheck, @"\s", "");
        if (blankCheck == "")
        {
            chatInput.ActivateInputField();
            chatInput.text = "";
            return;
        }
        
        SendChat(chatInput.text);
        chatInput.ActivateInputField();
        chatInput.text = "";
    }

    void BuildChatContent()
    {
        string NewCont = "";
        foreach (string s in _messages)
        {
            NewCont += s + "\n";
        }

        chatContent.text = NewCont;
    }
    
    void Update()
    {
        if (PhotonNetwork.InRoom)
        {
            if (_messages.Count > _maximumMessages)
            {
                _messages.RemoveAt(0);
            }
            if (_buildDelay < Time.time)
            {
                BuildChatContent();
                _buildDelay = Time.time + 0.25f;
            }
        }
        else if (_messages.Count > 0)
        {
            _messages.Clear();
            chatContent.text = "";
        }
    }
}
