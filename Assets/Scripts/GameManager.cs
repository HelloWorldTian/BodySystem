using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

   
    private LoadingPanel loadingPanel;
    public GameObject StartPanel;
    public GameObject SelectPanel;
    public GameObject SelectPanelUI;

    public GameObject SystemContainer;

	// Use this for initialization
	void Start () {
        loadingPanel = GameObject.Find("LoadingPanelUI").GetComponent<LoadingPanel>();
        InitGame();
    }
	
	// Update is called once per frame
	void Update () {
        BtnClickUpdate();
    }
    public void InitGame()
    {
        loadingPanel.SetLoading();//载入界面初始化
        DataManager.Instance.InitInfo();//资源信息初始化
    }
    void BtnClickUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            SoundManager.Instance.PlayClickSound();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                if (hit.collider!=null)
                {
                    Debug.Log("ClickEnter");
                    if (hit.collider.name=="BtnEnter")
                    {
                        Debug.Log("ClickEnter");
                        if (!loadingPanel.gameObject.activeSelf)
                        {
                            SystemContainer.SetActive(true);
                            SelectPanelUI.SetActive(true);
                            SelectPanel.SetActive(true);
                            StartPanel.SetActive(false);
                        }
                        
                    }
                }
            }
        }
    }
}
