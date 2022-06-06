using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    public Button coButton;
    public Text feedbackText;

    public byte maxPlayers = 4;
    bool isConnecting;

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Connect()
    {
        feedbackText.text = "";
        isConnecting = true;
        coButton.interactable = false;

        if (PhotonNetwork.IsConnected)
        {
            LogFeedback("Joining Room...");
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            LogFeedback("Connecting...");
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public void LogFeedback(string message)
    {
        if(feedbackText == null)
        {
            return;
        }
        else
        {
            feedbackText.text += System.Environment.NewLine + message;
        }
    }

    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            LogFeedback("OnConnectedToMaster: Next -> try to Join Random Room");
            Debug.Log("PUN Basics : OnConnectedToMaster() was called. Now this client is connected and could join a room.\n Calling: PhotonNetwork.JoinRandomRoom(); Operation will fail if no room found");

           
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        LogFeedback("<Color=Red>OnJoinRandomFailed</Color>: Next -> Create a new Room");
        Debug.Log("PUN Basics :OnJoinRandomFailed() was called. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPlayers });
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        LogFeedback("<Color=Red>OnDisconnected</Color> " + cause);
        Debug.LogError("PUN Basics :Disconnected");

        isConnecting = false;
        coButton.interactable = true;
    }

    public override void OnJoinedRoom()
    {
        LogFeedback("<Color=Green>OnJoinedRoom</Color> with " + PhotonNetwork.CurrentRoom.PlayerCount + " Player(s)");
        Debug.Log("PUN Basics : OnJoinedRoom() called. Now this client is in a room.\nFrom here on, your game would be running.");

        
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("We load the 'Room for 1' ");
 
            PhotonNetwork.LoadLevel("test");
        }
    }
}
