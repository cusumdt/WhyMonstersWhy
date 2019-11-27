﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverStage : MonoBehaviour {
    public Image winner;
    public Image seccond;
    public SpriteRenderer thisWinner;
    public SpriteRenderer thisLose;
    bool init;
    void Start () {
        init = false;

    }

    void Update () {
        if (!init) {
            GameObject asd = GameManager.Get ().GetLose ();
            GameObject ase = GameManager.Get ().GetWinner ();
            thisLose = asd.GetComponent<SpriteRenderer> ();
            thisWinner = ase.GetComponent<SpriteRenderer> ();
            seccond.sprite = thisLose.sprite;
            winner.sprite = thisWinner.sprite;
            init = true;
        }
    }
}