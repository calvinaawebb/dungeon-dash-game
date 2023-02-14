using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{

    public float transitionTime = 1.5f;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //get the animator from the inspector
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToScene(int sceneNum){ //CALL THIS SCENE FROM ANY SCRIPT IN THE GAME IN ORDER TO CHANGE SCENES. sceneNum is the element number of the scene in Edit >> Build Settings
        Debug.Log("Changing scenes");
        StartCoroutine(ChangeScenes(sceneNum));
    }

    IEnumerator ChangeScenes(int sceneNum){
        //initaiate fade out
        anim.SetTrigger("StartTransition");

        //wait until that's done
        yield return new WaitForSeconds(transitionTime);

        //load new scene
        SceneManager.LoadScene(sceneNum);
    }
}
