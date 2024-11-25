using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>{
    public Player Player;
    private GameObject _playerPostionSetting;
    public Transform playerPrefab;

    public void ResetPlayer(){
    }

    private void Start(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1){
        _playerPostionSetting = GameObject.Find("PlayerSpawnPostion"); 

        Transform a;
        a = Instantiate(playerPrefab, _playerPostionSetting.transform.position, Quaternion.identity);
        a.parent = null;
        Player = a.GetComponent<Player>();
    }

    private void Awake(){
        try
        {
            _playerPostionSetting = GameObject.Find("PlayerSpawnPostion"); 
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        Player = Instantiate(playerPrefab, _playerPostionSetting.transform.position, Quaternion.identity).GetComponent<Player>();
        if (SceneManager.GetActiveScene().name == "JHStart")
        {
            Player.transform.Find("PlayerUI").gameObject.SetActive(false);
        }
    }
}