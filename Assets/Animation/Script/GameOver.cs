using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Button menuButton;

    // Start is called before the first frame update
	void Start () {
		//Button btn = menuButton.GetComponent<Button>();
	}

	public void RestartGame() 
    {
        SceneManager.LoadScene(0);
    }
}
