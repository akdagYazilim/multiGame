using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon;
using Photon.Pun;
using Photon.Realtime;


public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject _gameCharacterPreFab;
    public Text roomName;
    void Start()
    {
        

        float x = Random.Range(-4f, 4f);
        float z = Random.Range(-4f, 4f);
        Vector3 cikisYeri = new Vector3(x, 0.1f, z);

        if (PhotonNetwork.IsConnectedAndReady)
        {
            roomName.text = "Oda No : " + PhotonNetwork.CurrentRoom.Name;
            PhotonNetwork.Instantiate(_gameCharacterPreFab.name, cikisYeri, Quaternion.identity);
        }
    }
    
    void Update()
    {


    }

 




}
