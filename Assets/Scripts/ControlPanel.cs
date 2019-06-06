using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour {

    private Button smallBtn;
    private Button bigBtn;
    // Use this for initialization
    void Start () {

        smallBtn = transform.Find("smallBtn").GetComponent<Button>();
        bigBtn = transform.Find("bigBtn").GetComponent<Button>();
        smallBtn.onClick.AddListener(smallBtnClick);
        bigBtn.onClick.AddListener(bigBtnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowControlPanel()
    {
        gameObject.SetActive(true);
    }

    public void smallBtnClick()
    {
    }
    public void bigBtnClick()
    {
    }
}
