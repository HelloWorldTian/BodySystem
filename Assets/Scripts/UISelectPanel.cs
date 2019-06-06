using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UISelectPanel : MonoBehaviour {

    public Button pageUpBtn;
    public Button downUpBtn;
    public Button sureBtn;

    public Image nowPage;
    public Sprite[] nums;
    public int currentPage;

    public UIMenuPanel menuPanel;
    public Text systemName;

    public GameObject IntroducePanel;
    public Text desTitle;
    public Text desTitleEnglish;
    public Text desContent;
    private bool isShow;
    private Tweener tweener;
    // Use this for initialization
    void Start () {

        pageUpBtn.onClick.AddListener(PageUpBtnClick);
        downUpBtn.onClick.AddListener(PageDownBtnClick);
        sureBtn.onClick.AddListener(SureBtnClick);
        currentPage = GameManager.Instance.currentSelectIndex;
        //ShowPage(currentPage);
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
        GameManager.Instance.SetSelectSystem(currentPage);
        GameManager.Instance.TurnToNext(false);
    }
    public void PageDownBtnClick()
    {
        currentPage++;
        if (currentPage >8)
        {
            currentPage = 1;
        }
        Debug.Log("down");

        GameManager.Instance.SetSelectSystem(currentPage);
        GameManager.Instance.TurnToNext(true);
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
    public void ShowIntroduce(ISystem system)
    {
        if (system == null)
        {
            Debug.LogError("数据为空");
            return;
        }
        Debug.Log("显示介绍");
        ShowSystemName(system.GetSystemName());

        desTitle.text = system.GetSystemName();
        desTitleEnglish.text = system.GetEnglishName();
        desContent.text = system.GetSystemDes();
        
        if (isShow)
        {
            tweener = IntroducePanel.transform.DOScaleY(0, 0.3f);
            tweener.Play();
            tweener.OnComplete(()=> 
            {
                tweener = IntroducePanel.transform.DOScaleY(1, 0.3f);
                tweener.Play();
            });
        }
        else
        {
            isShow = true;
            tweener = IntroducePanel.transform.DOScaleY(1, 0.3f);
            tweener.Play();
        }

    }
    void ShowSystemName(string name)
    {
        systemName.text = name;
    }
}
