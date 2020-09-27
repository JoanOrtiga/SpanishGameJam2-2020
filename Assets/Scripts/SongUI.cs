using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SongUI : MonoBehaviour
{
    public GameObject previewPiecePlace;
    public GameObject spawnPiece;

    public Animator pua;

    public UnityEngine.UI.Image healthBar;

    public Scroll compasScrollScript;

    public PressBar pressBar;

    public InstrumentsUI[] instruments;

}

[System.Serializable]
public struct InstrumentsUI
{
    public InstrumentAttack instrument;
    public GameObject uiInstrument;
}