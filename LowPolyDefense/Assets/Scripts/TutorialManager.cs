using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    private void Start()
    {
        //Checks to see if the current scene is the tutorial level
        if(SceneManagement.CurrentLevelName() == "Tutorial")
        {
            StartCoroutine(PlayTutorial());
        }
    }

    private IEnumerator PlayTutorial()
    {
        DataHelper.instance.ShowData("Welcome to the Tutorial Level!");

        yield return new WaitForSeconds(1f);

        DataHelper.instance.ShowData("To exit the Tutorial Level, press the button in the top right!");

        yield return new WaitForSeconds(1f);

        DataHelper.instance.ShowData("Let's place a tower!");

        yield return new WaitForSeconds(0.5f);

        DataHelper.instance.ShowData("Click on one of the tower icons to preview it!");

        yield return new WaitForSeconds(1f);


    }

}
