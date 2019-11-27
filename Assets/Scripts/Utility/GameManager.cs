﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager> {
    #region Events
    public delegate void PlayerState (float enrageVal);
    public static event PlayerState OnPause;
    #endregion

    #region List
    public List<GameObject> players;
    public List<GameObject> pjs;
    #endregion

    #region Floats
    public float velLoad;
    float Load;
    #endregion

    public string scene;
    public override void Awake () {

        base.Awake ();
        Load = 0;
        scene = "Game";
    }

    void Start () {
        PauseManager.Scene += ActualScene;
        Loading.Scene += ActualScene;
    }

    void Update () {
        if (players.Count == 1 && scene == "Game") {
            Time.timeScale = 0.5f;
            if (Load >= 100) {
                Load = 0;
                Time.timeScale = 1.0f;
                RestartPause ();
                scene = "GameOver";
                SceneManager.LoadScene ("GameOver");
            } else {
                Load = Load + (Time.deltaTime * velLoad);
            }

        }
    }

    public void SetPlayers (GameObject player) {
        players.Add (player);
    }
    public GameObject GetWinner () {
        for (int j = 0; j < 1; j++) {
            for (int i = 0; i < 2; i++) {
                if (pjs[i].name != players[j].name) {
                    return pjs[i];
                }
            }
        }
        return new GameObject ();
    }
    public GameObject GetLose () {
        return players[0];
    }
    public void RemovePlayers () {
        players.Clear ();
    }
    void RestartPause () {
        if (OnPause != null) {
            float amount = 1;
            OnPause (amount);
        }
    }
    void ActualScene (float v, string _scene) {

        scene = _scene;

    }
}