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
        
        
            //if (Input.GetKeyDown(KeyCode.Space)&& gameObject.CompareTag("Player"))
            //{
            //    if(DialogManager.instance.dialoggroup.alpha == 0)
            //    {
            //        DialogManager.instance.Ondialog(sentences);
            //    }
            //}
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.talk = true;
            playerController.sentences = this.sentences;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") collision.gameObject.GetComponent<PlayerController>().talk = false;
    }
}
