using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class LaunchManager : MonoBehaviourPunCallbacks
{
    [Header("Input Fields")]
    public InputField _nameInputField;
    public InputField _odaIsmiFiled;
    public InputField _oyuncuSayisi;

    [Header("Login Panel")]
    public GameObject _loginPanel;
    public GameObject[] _loginPanelGameObject;
    [Header("Game Settings Panel")]
    public GameObject _gameSettingsPanel;
    public GameObject[] _gameSettingsPanelGameObject;
    [Header("Create Join Room Panel")]
    public GameObject _createRoomPanel;
    public GameObject[] _createRoomPanelGameObject;
    [Header("Random Room Panel")]
    public GameObject _randomRoomPanel;
    public GameObject[] _randomRoomPanelGameObject;

    public Text randomText;
    void Start()
    {
        ActiveLoginPanel();
        PhotonNetwork.AutomaticallySyncScene = true;
        //onGiris();
        //PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region PhotonCallBack
    public override void OnConnectedToMaster()
    {
        Debug.Log("Photona Bağlanıldı.");
        Debug.Log(PhotonNetwork.NickName);
        ActiveGameSettingPanel();
    }
    public override void OnConnected()
    {
        Debug.Log("İnternete Bağlanıldı.");
    }
    #endregion

    #region Unity Methods
    public void ActiveLoginPanel()
    {
        _loginPanel.SetActive(true);
        foreach (GameObject gameObject in _loginPanelGameObject)
        {
            gameObject.SetActive(true);
        }
    }

    public void ActiveRandomRoomPanel()
    {
        _gameSettingsPanel.SetActive(false);
        foreach (GameObject gameObject in _gameSettingsPanelGameObject)
        {
            gameObject.SetActive(false);
        }

        _randomRoomPanel.SetActive(true);
        foreach (GameObject gameObject in _randomRoomPanelGameObject)
        {
            gameObject.SetActive(true);
        }
        PhotonNetwork.JoinRandomRoom();//Boş oda bulana kadar arıyor.
        randomText.text = "Bir oda aranıyor";
    }

    public override void OnJoinedRoom() // Odaya girince yani oyuna girince
    {
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("GameScene");
    }

    public override void OnJoinRandomFailed(short returnCode, string message) //Oda bulmassa kendisi kurmak için.
    {
        Debug.Log("Oda bulunamadı ben kuruyorum.");
        odaKur();
    }

    public void odaKur()
    {
        string randomIsım = "Room "+ Random.Range(10, 100);
        RoomOptions odaAyar = new RoomOptions();
        odaAyar.MaxPlayers = 20;
        odaAyar.IsOpen = true;
        odaAyar.IsVisible = true;
        PhotonNetwork.CreateRoom(randomIsım, odaAyar);
    }

    public void ActiveGameSettingPanel()
    {
        _loginPanel.SetActive(false);
        foreach (GameObject gameObject in _loginPanelGameObject)
        {
            gameObject.SetActive(false);
        }

        _gameSettingsPanel.SetActive(true);
        foreach (GameObject gameObject in _gameSettingsPanelGameObject)
        {
            gameObject.SetActive(true);
        }
    }
    public void onGiris()
    {
        Debug.Log("Button Çalıştı.");
        PhotonNetwork.NickName = _nameInputField.text;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void odaOlusturPaneleGit()
    {
        ActiveCreateJoinRoomPanel();
    }

    public void ActiveCreateJoinRoomPanel()
    {
        _gameSettingsPanel.SetActive(false);
        foreach (GameObject gameObject in _gameSettingsPanelGameObject)
        {
            gameObject.SetActive(false);
        }
        _createRoomPanel.SetActive(true);
        foreach (GameObject gameObject in _createRoomPanelGameObject)
        {
            gameObject.SetActive(true);
        } 
    }

    public void odaOlustur()
    {
        RoomOptions roomCount = new RoomOptions();
        roomCount.MaxPlayers = (byte)int.Parse(_oyuncuSayisi.text);
        PhotonNetwork.CreateRoom(_odaIsmiFiled.text, roomCount);
    }
    #endregion
}
