using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTImerUI : MonoBehaviour
{
    // Start is called before the first frame update
	public int timeLeft = 5;
	public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
		StartCoroutine(gameTimer());
    }

	IEnumerator gameTimer() {
		while(true) {
			txt.text = timeLeft.ToString(); 
			if(--timeLeft <= 0) SceneManager.LoadScene("LoseGame");
			yield return new WaitForSeconds(1);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
