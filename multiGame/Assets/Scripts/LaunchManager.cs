﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class LaunchManager : MonoBehaviourPunCallbacks
{

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();

        //ActiveLoginPanel();
        //PhotonNetwork.AutomaticallySyncScene = true;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region PhotonCallBack
    public override void OnConnectedToMaster()
    {
        Debug.Log("Photon'a bağlandınız.");
        OdaOlustur();

        //Debug.Log("Photona Bağlanıldı.");
        //Debug.Log(PhotonNetwork.NickName);
        //ActiveGameSettingPanel();
    }
    public override void OnConnected()
    {
        Debug.Log("İnternete Bağlanıldı.");
    }
    #endregion

    public override void OnJoinedRoom() // Odaya girince yani oyuna girince
    {
        PhotonNetwork.LoadLevel("GameScene");
    }

    public override void OnCreatedRoom() // Oda oluştuktan sonra
    {
        
    }

    public void OdaOlustur()
    {
        //string randomIsım = "Room " + Random.Range(10, 100);
        string randomIsım = "Room 96";
        RoomOptions odaAyar = new RoomOptions();
        odaAyar.MaxPlayers = 20;
        odaAyar.IsOpen = true;
        odaAyar.IsVisible = true;
        PhotonNetwork.CreateRoom(randomIsım, odaAyar);
    }
   
}
