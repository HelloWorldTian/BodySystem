using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIMenuPanel : MonoBehaviour {

    public GameObject firstPanel;
    public GameObject secondPanel;

    public Sprite[] BtnNornalImg;
    public Sprite[] BtnClickImg;

    public Button[] firstPanelBtns;
    
    public Button[] secondPanelBtns;

    public Button firstCloseBtn;
    public Button secondCloseBtn;

    private float tweenTime = 0.2f;
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
        Tweener tweener = firstPanel.transform.DOScaleY(0, tweenTime);
        tweener.SetEase(Ease.Linear);
        tweener.OnComplete(() =>
        {
            Debug.Log("123");
            gameObject.SetActive(false);
        });

    }
    void CloseSecondPanel()
    {
        Debug.Log("close2");
        sencondBtnReset();
        //判断是否播放视频中

 
        Tweener tweener = secondPanel.transform.DOScaleY(0, tweenTime);
        tweener.SetEase(Ease.Linear);
        tweener.Play();//动画播放
        tweener.OnComplete(() =>
        {
            secondPanel.SetActive(false);
            firstPanel.SetActive(true);
            tweener = firstPanel.transform.DOScaleY(1, tweenTime);
            tweener.SetEase(Ease.Linear);
            tweener.Play();//动画播放
        });

    }

    void firstBtnClickEvent(int index)
    {
       
        firstBtnReset();
        firstPanelBtns[index].GetComponent<Image>().sprite = BtnClickImg[index];

  
        Tweener tweener = firstPanel.transform.DOScaleY(0, tweenTime);
        tweener.SetEase(Ease.Linear);
        tweener.OnComplete(() =>
        {
            firstPanel.SetActive(false);
            tweener = secondPanel.transform.DOScaleY(1, tweenTime); 
            tweener.Play();
            secondBtnClickEvent(index);
        });

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

        Tweener tweener = firstPanel.transform.DOScaleY(1, tweenTime);
        tweener.SetEase(Ease.Linear);
        tweener.Play();//动画播放
        tweener.OnComplete(()=> 
        {
            for (int i=0;i< firstPanelBtns.Length;++i)
            {
                firstPanelBtns[i].GetComponent<Animation>().Play();
            }
        });
    }

    
}
 