using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuPanel : MonoBehaviour {

    public GameObject firstPanel;
    public GameObject secondPanel;

    public Sprite[] BtnNornalImg;
    public Sprite[] BtnClickImg;

    public Button[] firstPanelBtns;
    
    public Button[] secondPanelBtns;

    public Button firstCloseBtn;
    public Button secondCloseBtn;
    // Use this for initialization
    void Start () {
        AddEventListener();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void AddEventListener()
    {
        for(int i=0;i< firstPanelBtns.Length;i++)//firsetPanel中按钮设置
        {
            int j = i;
            firstPanelBtns[i].onClick.AddListener(() =>
            {
                firstBtnClickEvent(j);
            });

            secondPanelBtns[i].onClick.AddListener(() =>
            {
                secondBtnClickEvent(j);
            });
        }
        firstCloseBtn.onClick.AddListener(CloseMenuPanel);
        secondCloseBtn.onClick.AddListener(CloseSecondPanel);
    }

    void firstBtnReset()
    {
        for (int i=0;i<3;++i)
        {
            firstPanelBtns[i].GetComponent<Image>().sprite= BtnNornalImg[i];
        }
    }
    void sencondBtnReset()
    {
        for (int i = 0; i < 3; ++i)
        {          
            secondPanelBtns[i].GetComponent<Image>().sprite = BtnNornalImg[i];
            secondPanelBtns[i].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }
    void CloseMenuPanel()
    {
        //增加动画
        Debug.Log("close1");
        gameObject.SetActive(false);
    }
    void CloseSecondPanel()
    {
        Debug.Log("close2");
        sencondBtnReset();
        //判断是否播放视频中
        secondPanel.SetActive(false);
        firstPanel.SetActive(true);
    }

    void firstBtnClickEvent(int index)
    {
       
        firstBtnReset();
        firstPanelBtns[index].GetComponent<Image>().sprite = BtnClickImg[index];
        //增加动画
        firstPanel.SetActive(false);
        secondBtnClickEvent(index);
    }
    void secondBtnClickEvent(int index)
    {
       
        sencondBtnReset();
        secondPanel.SetActive(true);
        secondPanelBtns[index].GetComponent<Image>().sprite = BtnClickImg[index];
        secondPanelBtns[index].transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
    }

    public void ShowMenuPanel()
    {
        Debug.Log("open");
        firstBtnReset();
        gameObject.SetActive(true);
        firstPanel.SetActive(true);
    }
}
