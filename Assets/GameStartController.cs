using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartController : MonoBehaviour
{

    public Button close;

    public GameObject Box;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnclickClose()
    {
        Box.SetActive(false);
    }

    public void OnclickGame()
    {
        Box.SetActive(false);
        SceneManager.LoadScene(1);//GetActive获取当前Scene
    }
}
