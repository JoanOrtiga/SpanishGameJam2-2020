using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivatePieces : MonoBehaviour
{
    public bool playing = true;

    public Pieces[] pieces;

    private void Update()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            if((pieces[i].times < 2))
            {
                if (pieces[i].active)
                {
                    pieces[i].timeToDeActivate -= Time.deltaTime;

                    if (pieces[i].timeToDeActivate <= 0)
                    {
                        pieces[i].active = false;
                        pieces[i].times++;
                        pieces[i].piece.DeActivate();
                    }
                }
                else
                {
                    pieces[i].timeToReactivate -= Time.deltaTime;

                    if (pieces[i].timeToReactivate <= 0)
                    {
                        pieces[i].active = true;
                        pieces[i].times++;
                        pieces[i].piece.ReActivate();
                        
                    }
                }
            }

        }
    }
}

[System.Serializable]
public struct Pieces
{
    public DesactivableObject piece;
    public float timeToDeActivate;
    public float timeToReactivate;
    public bool active;
    public int times;
}
