using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
	AudioSource titleMusic;

    // Start is called before the first frame update
    void Start()
    {
		titleMusic = GetComponent<AudioSource>();
		titleMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0)) {
		  SceneManager.LoadScene("MainGameScene");
	   }
    }
}
