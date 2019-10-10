using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARtoTown : MonoBehaviour
{
    public FadeAnimation fa;
    public void OnButtonPressed() {
        fa.trigger = true;
    }

}
