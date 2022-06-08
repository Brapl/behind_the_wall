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

    private GameObject plaayerCam;
    private GameObject cameraCam;
    public Vector3 offset;

    void Start()
    {
        GameObject p = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0,2,0), Quaternion.identity, 0);
        plaayerCam = p;
        cameraCam = Camera.main.gameObject;
        cameraCam.transform.position = plaayerCam.transform.position;
    }
    
    private void FixedUpdate()
    {
        if (plaayerCam != null && cameraCam != null)
        {
            cameraCam.transform.position = plaayerCam.transform.position + offset;
        }
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
