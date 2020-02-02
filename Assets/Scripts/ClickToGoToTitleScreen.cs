using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToGoToTitleScreen : MonoBehaviour
{
	AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponentInChildren<AudioSource>();
		    sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetMouseButtonDown(0)) {
			SceneManager.LoadScene("TitleScreen");
		}
    }
}
