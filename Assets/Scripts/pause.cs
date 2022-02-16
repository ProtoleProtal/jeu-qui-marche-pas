using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public Button Resume;
    public Button Menu;
    public static bool InPause = false;
    public bool onPause = false;


    public GameObject fondFlou;

    // Start is called before the first frame update
    void Start()
    {
        Resume.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);

        fondFlou.SetActive(false);
        Resume.onClick.AddListener(OnPlay);
        Menu.onClick.AddListener(OnMenu);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (onPause == false)
            {
                Debug.Log("pause");
                fondFlou.SetActive(true);
                Resume.gameObject.SetActive(true);
                Menu.gameObject.SetActive(true);

                InPause = true;
                onPause = true;

            }
            else if (onPause == true)
            {

                Debug.Log("plus pause");
                Resume.gameObject.SetActive(false);
                Menu.gameObject.SetActive(false);

                fondFlou.SetActive(false);

                InPause = false;
                onPause = false;
            }
            Debug.Log("escape");

        }

    }
    public void OnPlay()
    {
        Debug.Log("reprendre");
        Resume.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
        fondFlou.SetActive(false);
        InPause = false;
        onPause = false;
    }
    public void OnMenu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("Menu");
    }
}