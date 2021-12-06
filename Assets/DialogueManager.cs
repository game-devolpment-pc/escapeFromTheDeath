using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text DialogueText;

    public Animator animator;

    private Queue<string> sentensces;


    // Start is called before the first frame update
    void Start()
    {
        sentensces = new Queue<string>();
    }


    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        Debug.Log("Starting conversation ");

        sentensces.Clear();

        foreach (string sentensce in dialogue.sentensces)
        {
            sentensces.Enqueue(sentensce);
        }
        
        StartCoroutine(Delay());
        
    }

    public void DisplayNextSentensce()
    {
        if (sentensces.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentensce = sentensces.Dequeue();
        //StopAllCoroutines();
        
        //StartCoroutine(TypeSentence(sentensce));
        DialogueText.text = sentensce;
        Debug.Log(sentensce);
    }
    private IEnumerator Delay()
    {

        while (true)
        {
            DisplayNextSentensce();
            yield return new WaitForSeconds(5F);
        }

    }

    IEnumerator TypeSentence (string sentence)
    {
        
        DialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(1 / 10F);
        }

    }

    void EndDialogue()
    {
        //Debug.Log("End of conversation. ");
        animator.SetBool("IsOpen", false);
    }


}
