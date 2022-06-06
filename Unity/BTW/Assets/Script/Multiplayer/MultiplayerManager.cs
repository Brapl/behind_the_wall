using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

public class MultiplayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public TextMeshProUGUI feedbackText;

    void Start()
    {
        PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(2,-1,0), Quaternion.identity, 0);
    }

    public void OnPlayerEnterRoom(Player other)
    {
        LogFeedback(other.name + " s'est connecté.");
    }

    public void OnPlayerLeftRoom(Player other)
    {
        LogFeedback(other.name + " s'est déconnecté.");
    }

    public void OnLeftRoom()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void LogFeedback(string message)
    {
        if (feedbackText == null)
        {
            return;
        }
        else
        {
            feedbackText.text += message + "\n";
        }
    }
}
