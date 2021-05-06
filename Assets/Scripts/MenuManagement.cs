using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour
{
    public GameObject Menu;
    public GameObject ReturnButton;
    public GameObject ResetButton;

    private bool isMenuEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        ReturnButton.GetComponent<Button>().onClick.AddListener(ReturnToScene);
        ResetButton.GetComponent<Button>().onClick.AddListener(ResetScene);
    }

    void updateMenuStatus() {
        Menu.SetActive(isMenuEnabled);
        Time.timeScale = isMenuEnabled ? 0 : 1;
    }

    void ReturnToScene() {
        isMenuEnabled = false;
        updateMenuStatus();
    }

    void ResetScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ReturnToScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isMenuEnabled = !isMenuEnabled;
            updateMenuStatus();
        }
    }
}
