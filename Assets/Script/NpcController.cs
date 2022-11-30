using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public GameObject DialogBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayDialog()
    {
        DialogBox.SetActive(true);
    }

    public void CloseDialog()
    {
        DialogBox.SetActive(false);
    }
}
