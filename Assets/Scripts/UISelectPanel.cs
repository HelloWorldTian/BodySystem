using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UISelectPanel : MonoBehaviour {

    public Button pageUpBtn;
    public Button downUpBtn;
    public Button sureBtn;

    public Image nowPage;
    public Sprite[] nums;
    public int currentPage;

    public UIMenuPanel menuPanel;
    // Use this for initialization
    void Start () {

        pageUpBtn.onClick.AddListener(PageUpBtnClick);
        downUpBtn.onClick.AddListener(PageDownBtnClick);
        sureBtn.onClick.AddListener(SureBtnClick);
        currentPage = 1;
        ShowPage(currentPage);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PageUpBtnClick()
    {
        Debug.Log("up");
        currentPage--;
        if (currentPage <=0)
        {
            currentPage = 8;
        }
        ShowPage(currentPage);
    }
    public void PageDownBtnClick()
    {
        currentPage++;
        if (currentPage >8)
        {
            currentPage = 1;
        }
        Debug.Log("down");
        ShowPage(currentPage);
    }
    public void SureBtnClick()
    {        
        menuPanel.ShowMenuPanel();
    }
    public void ShowPage(int index)
    {
        index--;
        nowPage.sprite = nums[index];
    }
}
