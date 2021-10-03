using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameController gc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gc.Finish();
    }

}
