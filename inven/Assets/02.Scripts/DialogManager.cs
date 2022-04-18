using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogManager : MonoBehaviour, IPointerDownHandler
{
    public Text dialogText;
    public GameObject nextText;

    public Queue<string> sentences;

    private string currentSentence;
    public float typingSpeed = 0.1f;

    private bool istyping;

    public CanvasGroup dialoggroup;

    void Start()
    {
        sentences = new Queue<string>();    
    }

    public void Ondialog(string[] lines)
    {
        sentences.Clear();
        foreach(string line in lines)
        {
            sentences.Enqueue(line);
        }
        dialoggroup.alpha = 1;
        dialoggroup.blocksRaycasts = true;

        NextSentence();
    }

    public void NextSentence()
    {
        if (sentences.Count != 0)
        {
            currentSentence = sentences.Dequeue();
            //코루틴 타이핑효과
            istyping = true;
            nextText.SetActive(false);
            StartCoroutine(Typing(currentSentence));
        }
        else
        {
            dialoggroup.alpha = 0;
            dialoggroup.blocksRaycasts = false;
        }
    }

    IEnumerator Typing(string line)
    {
        dialogText.text = "";
        foreach( char letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
        // 대사 한줄 끝
        if (dialogText.text.Equals(currentSentence))
        {
            nextText.SetActive(true);
            istyping = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!istyping)
        NextSentence();
    }
}
