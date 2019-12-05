﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverStage : MonoBehaviour {
    public Image winner;
    public Image seccond;
    public SpriteRenderer thisWinner;
    public SpriteRenderer thisLose;
    public Animator WinnerAnim;
    public Animator LooserAnim;

    void Start () {
        GameObject Loser = GameManager.Get().GetLose();
        GameObject Winner = GameManager.Get().GetWinner();
        GameManager.Get().RestartPlayer();
        thisLose = Loser.GetComponent<SpriteRenderer>();
        thisWinner = Winner.GetComponent<SpriteRenderer>();
        WinnerAnim.SetInteger("Player", Winner.name == "player" ? 1 : 2);
        LooserAnim.SetInteger("Player", Loser.name =="player" ? 1 : 2);
        seccond.sprite = thisLose.sprite;
        winner.sprite = thisWinner.sprite;
    }
}