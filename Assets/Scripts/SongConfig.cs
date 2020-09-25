using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongConfig : MonoBehaviour
{
    [SerializeField] public Attacks[] attacks;

    public bool playing;

    private void Update()
    {
        if (playing)
            for (int i = 0; i < attacks.Length; i++)
            {
                attacks[i].second -= Time.deltaTime;

                if(attacks[i].second <= 0)
                {
                    SendNewInstrument(i);
                }
            }
    }

    public void SendNewInstrument(int i)
    {
        print(attacks[i].instrument.ToString());
    }
}

public enum InstrumentAttack
{
    guitar, percussion, drum, bass, synth, piano, trumpet, voice, hooter, drop
}

[System.Serializable]
public struct Attacks
{
    public InstrumentAttack instrument;
    public float second;
}