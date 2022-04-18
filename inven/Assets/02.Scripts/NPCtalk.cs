using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCtalk : MonoBehaviour
{

    public string[] sentences;

    private void OnMouseDown()
    {
        if(DialogManager.instance.dialoggroup.alpha == 0)
        {
            DialogManager.instance.Ondialog(sentences);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(DialogManager.instance.dialoggroup.alpha == 0)
            {
                DialogManager.instance.Ondialog(sentences);
            }
        }
    }
}
