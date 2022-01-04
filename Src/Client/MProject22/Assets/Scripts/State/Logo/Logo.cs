using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    // Start is called before the first frame update

    public Text LogoText;

    void Start()
    {
        StartCoroutine("RunFadeOut");

        //Debug.Log("Start");
        //LogoText.lineSpacing = 0.00f;
    }


    void Update()
    {
        // Debug.Log("Update");
        //if( 0.1 �ʰ� ������>??? )


        //LogoText.lineSpacing += 0.06f;
        //if(LogoText.lineSpacing > 0.68 )
        //{
        //    Application.LoadLevel("Test");
        //}
    }

    IEnumerator RunFadeOut()
    {
        LogoText.lineSpacing = 0.0f;

        while(LogoText.lineSpacing <= 0.68 )
        {
            LogoText.lineSpacing += 0.06f;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1.2f);

        Application.LoadLevel(Defines.GetScenesName(Defines.E_SCENES.TITLE) );

        yield return null;
    }
}
