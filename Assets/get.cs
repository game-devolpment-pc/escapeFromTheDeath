using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class get : MonoBehaviour
{
    public GameObject UiObject;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        UiObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UiObject.SetActive(true);
            flag = true;
            }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && flag)
        {
            Destroy(this.gameObject);
            UiObject.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
            UiObject.SetActive(false);
    }
}
