using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowDisclaimer : MonoBehaviour
{
	bool willLoad;
	IEnumerator goToTitle() {
		while(true) { 
			if(willLoad) SceneManager.LoadScene("TitleScreen");
			willLoad = true;
			yield return new WaitForSeconds(3);
		}
	}
    // Start is called before the first frame update
    void Start()
    {
		willLoad = false;
		StartCoroutine(goToTitle());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
