using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotateController : MonoBehaviour {

    public static RotateController Instance;
    GameObject canvas;
    int num = 8;
    float angle = 0;
    private float shortRadius = 200;
    float longRadius = 600;
    Dictionary<int, RotateItem> storeItem;
    public static bool run;
    public static int index = 0;

    private bool isTuring;
    private int speed;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        num = DataManager.Instance.m_SystemList.Count;

        storeItem = new Dictionary<int, RotateItem>();
        angle = 360.0f / num;

        int i = 0;
        foreach (var item in DataManager.Instance.m_SystemList)
        {
            GameObject a = item.Value.gameObject;
            a.transform.SetParent(transform);
            a.transform.localPosition = new Vector2(Mathf.Cos(i * angle * Mathf.Deg2Rad) * longRadius, Mathf.Sin(i * angle * Mathf.Deg2Rad) * shortRadius);
            a.transform.localScale = Vector3.one * (1 - ((a.transform.localPosition.y - (-shortRadius)) / shortRadius / 2));
            RotateItem _go = new RotateItem();
            _go._o = a;
            _go.angle = i * angle;
            _go.targetAngle = _go.angle;
            _go.index = i;
            storeItem.Add(i, _go);
            i++;
        }
        //ControlRotate(true);
    }
    
    // Update is called once per frame

    void Update()
    {
        if (run)
        {
            foreach (var kk in storeItem.Values)
            {
                kk.angle = kk.angle + 0.1f;
                if (kk.angle >= 360)
                {
                    kk.angle = kk.angle - 360;
                }
                if (kk.angle <= 0)
                {
                    kk.angle = kk.angle + 360;
                }
                kk._o.transform.localPosition = new Vector2(Mathf.Cos(kk.angle * Mathf.Deg2Rad) * longRadius, Mathf.Sin(kk.angle * Mathf.Deg2Rad) * shortRadius);

                kk._o.transform.localScale = Vector3.one * (1 - ((kk._o.transform.localPosition.y-(-shortRadius))/shortRadius/2));
            }
        }
        if (isTuring)
        {
            foreach (var kk in storeItem.Values)
            {
                kk.angle = kk.angle + 0.1f*speed;
                if (kk.angle >= 360)
                {
                    kk.angle = kk.angle - 360;
                }
                if (kk.angle <= 0)
                {
                    kk.angle = kk.angle + 360;
                }
                if (Mathf.Abs(kk.angle - kk.targetAngle) < 2f)
                {
                    kk.angle = kk.targetAngle;
                    HasReach();
                    break;
                }
                kk._o.transform.localPosition = new Vector2(Mathf.Cos(kk.angle * Mathf.Deg2Rad) * longRadius, Mathf.Sin(kk.angle * Mathf.Deg2Rad) * shortRadius);
                kk._o.transform.localScale = Vector3.one * (1 - ((kk._o.transform.localPosition.y - (-shortRadius)) / shortRadius / 2));             
            }
        }
    }
    void HasReach()
    {
        isTuring = false;
        foreach (var kk in storeItem.Values)
        {
            kk.angle = kk.targetAngle;
            kk._o.transform.localPosition = new Vector2(Mathf.Cos(kk.angle * Mathf.Deg2Rad) * longRadius, Mathf.Sin(kk.angle * Mathf.Deg2Rad) * shortRadius);
            kk._o.transform.localScale = Vector3.one * (1 - ((kk._o.transform.localPosition.y - (-shortRadius)) / shortRadius / 2));
        }
    }
    public void ControlRotate(bool canRotate)
    {
        run = canRotate;
    }
    public void TurnNext(bool isRight)
    {
        Debug.Log("TurnNext");
        isTuring = true;
        speed = isRight ? 10 : -10;
        foreach (var kk in storeItem.Values)
        {
            kk.targetAngle += 360 / num * (isRight ? 1 : -1);
            if (kk.targetAngle>=360)
            {
                kk.targetAngle -= 360;
            }
            if (kk.targetAngle <= 0)
            {
                kk.targetAngle += 360;
            }
        }
    }
    class RotateItem
    {
        public GameObject _o;
        public int index = 0;
        public float angle = 0;
        public float targetAngle=0;
    }
}
