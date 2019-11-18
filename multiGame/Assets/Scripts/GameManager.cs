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
    [Header("Game UI Buttons")]
    public GameObject _logOutPanel;
    public GameObject _tabPanel;
    public Text _oyuncuSayisi;
    void Start()
    {
        _oyuncuSayisi.text = "Oyuncu Sayısı : " + PhotonNetwork.CurrentRoom.PlayerCount;

        float x = Random.Range(-4f, 4f);
        float z = Random.Range(-4f, 4f);
        Vector3 cikisYeri = new Vector3(x, 0.1f, z);

        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.Instantiate(_gameCharacterPreFab.name, cikisYeri, Quaternion.identity);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_logOutPanel.activeSelf == true)
            {
                _logOutPanel.SetActive(false);
            }
            else
            {
                _logOutPanel.SetActive(true);
            }
        }

        KeyTab();

    }

    public void logOut()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("LobbyScene");
    }

    public void KeyTab()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _tabPanel.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            _tabPanel.SetActive(false);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        _oyuncuSayisi.text = "Oyuncu Sayısı : " + PhotonNetwork.CurrentRoom.PlayerCount;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        _oyuncuSayisi.text = "Oyuncu Sayısı : " + PhotonNetwork.CurrentRoom.PlayerCount;
    }
}
