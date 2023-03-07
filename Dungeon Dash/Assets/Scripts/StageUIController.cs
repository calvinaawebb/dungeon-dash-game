using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUIController : MonoBehaviour
{

    public int winningPlayer;

    public TransitionController transition;

    // Start is called before the first frame update
    void Start()
    {
        if (winningPlayer == 1)
        {
            this.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "Congratulations Player One!\n\nplease choose an option to continue:";
        }
        else
        {
            this.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "Congratulations Player Two!\n\nplease choose an option to continue:";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextLevel()
    {
        int sceneNum = SceneManager.GetActiveScene().buildIndex;
        if (sceneNum != 3)
        {
            transition.ChangeToScene(sceneNum + 1);
        }
        else
        {
            transition.ChangeToScene(1);
        }

    }

    public void ToHome()
    {
        transition.ChangeToScene(0);
    }
}
