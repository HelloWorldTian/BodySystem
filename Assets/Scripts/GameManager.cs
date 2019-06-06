using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

   
    private LoadingPanel loadingPanel;
    public GameObject StartPanel;
    public GameObject SelectPanel;
    public GameObject SelectPanelUI;

    public GameObject SystemContainer;

    public int currentSelectIndex;

    public static GameManager Instance;

    private ISystem SelectSystem;
    private void Awake()
    {
        Instance = this;
        currentSelectIndex=1;
        loadingPanel = GameObject.Find("LoadingPanelUI").GetComponent<LoadingPanel>();
        InitGame();
    }
    // Use this for initialization
    void Start () {
        
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

                            SetSelectSystem(currentSelectIndex);
                        }
                        
                    }
                }
            }
        }
    }
   
    public void SetSelectSystem(int index)//滑动切换或点击页码按钮
    {
        if (!DataManager.Instance.m_SystemList.TryGetValue(index, out SelectSystem))
        {
            Debug.Log("未找到" + index + "数据");
            return;
        }
        currentSelectIndex = index;   
        SelectPanelUI.GetComponent<UISelectPanel>().ShowIntroduce(SelectSystem);//显示介绍面板
    }
}
