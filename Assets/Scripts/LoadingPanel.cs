using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadingPanel : MonoBehaviour {

    public GameObject Loading;
    public GameObject StartPanel;
    public Text LoadingTxt;
    public Animation anim;
    private const string animName="TurnBlack";

    private float processValue;

    private bool isLoading;
    private bool isPlayAnim;

    private float timer=2;
    private float second;
	// Use this for initialization

	// Update is called once per frame
	void Update () {

        if (isLoading)
        {
            second += Time.deltaTime;
            processValue = Mathf.Lerp(0, 100, second/timer);
            if (processValue > 99)
            {
                processValue = 100;
                isLoading = false;
                if (anim!=null)
                {
                    anim.Play();
                    isPlayAnim = true;
                }
            }
        }
        LoadingTxt.text = (int)processValue + "%";

        if (isPlayAnim)
        {
            if (anim.isPlaying&&anim[animName].normalizedTime>=0.9f)
            {
                StartPanel.SetActive(true);
                Loading.SetActive(false);
                gameObject.SetActive(false);               
            }
        }
    }
    public void SetLoading()
    {
        isLoading = true;
    }
}
