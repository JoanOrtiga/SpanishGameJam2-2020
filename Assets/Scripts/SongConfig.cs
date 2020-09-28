using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongConfig : MonoBehaviour
{
    public int bpm;

    [SerializeField] public Attacks[] attacks;

    public bool playing;

    private SongUI songUI;

    private GameObject previewObject;

    private float piecesSpeed;
    private float timeToArrive;

    private int health;

    private void Start()
    {
        songUI = GetComponent<SongUI>();

        songUI.compasScrollScript.speed = bpm * 0.1f / 120f;
        piecesSpeed = (bpm * -167f / 120f) * Screen.width / 1920;
        timeToArrive = (bpm * 8.2f / 120f);

        print(piecesSpeed);

        NewPreviewInstrument(attacks[0].instrument);

        for (int i = 0; i < attacks.Length; i++)
        {
            attacks[i].second -= 7.22f;
        }

        songUI.pressBar.playedInstrument.AddListener(UpdateHealthBar);
    }

    private void UpdateHealthBar()
    {
        health++;
        songUI.healthBar.fillAmount = ((float)attacks.Length - health) / attacks.Length;
    }

    private void Update()
    {
        if (playing)
            for (int i = 0; i < attacks.Length; i++)
            {
                if (!attacks[i].played)
                {
                    attacks[i].second -= Time.deltaTime;



                    if (attacks[i].second <= 0)
                    {
                        attacks[i].played = true;
                        if (i + 1 < attacks.Length)
                            NewPreviewInstrument(attacks[i + 1].instrument);
                        else
                        {
                            NewPreviewInstrument(attacks[i].instrument);
                            Destroy(previewObject);
                        }

                        songUI.pua.SetTrigger("Activate");
                    }
                }
            }
    }

    private void NewPreviewInstrument(InstrumentAttack inst)
    {
        for (int i = 0; i < songUI.instruments.Length; i++)
        {
            if (inst == songUI.instruments[i].instrument)
            {
                if (previewObject != null)
                {

                    previewObject.transform.SetParent(songUI.spawnPiece.transform);
                    previewObject.GetComponent<InstrumentMovement>().enabled = true;
                    previewObject.transform.position = songUI.spawnPiece.transform.position;
                    previewObject.transform.localScale = Vector2.one;
                }


                previewObject = Instantiate(songUI.instruments[i].uiInstrument, songUI.previewPiecePlace.transform);
                previewObject.GetComponent<InstrumentMovement>().speed = piecesSpeed;
            }
        }
    }
}

public enum InstrumentAttack
{
    guitar, kick, drum, bass, synth, piano, trumpet, voice, hooter, drop
}



[System.Serializable]
public struct Attacks
{
    public InstrumentAttack instrument;
    [HideInInspector] public bool played;
    public float second;
}