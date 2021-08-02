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
    }


    //void Update()
    //{
    //    Company.lineSpacing += 0.06f;
    //}

    IEnumerator RunFadeOut()
    {
        LogoText.lineSpacing = 0.0f;

        while(LogoText.lineSpacing <= 0.68 )
        {
            LogoText.lineSpacing += 0.06f;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1.2f);

        //Application.LoadLevel(S)

        yield return null;
    }
}
