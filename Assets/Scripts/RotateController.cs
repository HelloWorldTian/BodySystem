using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotateController : MonoBehaviour {

    public RotateController Instance;
    GameObject canvas;
    int num = 8;
    float angle = 0;
    private float shortRadius = 200;
    float longRadius = 600;
    Dictionary<int, RotateItem> storeItem;
    public static bool run = true;
    public static int index = 0;

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
            a.transform.localPosition = new Vector2(Mathf.Cos(i * angle * Mathf.Deg2Rad) * longRadius, Mathf.Sin(i * angle * Mathf.Deg2Rad) * longRadius);

            RotateItem _go = new RotateItem();
            _go._o = a;
            _go.angle = i * angle;
            _go.index = i;
            storeItem.Add(i, _go);
            i++;
        }
        ControlRotate(true);
    }
    public void ControlRotate(bool canRotate)
    {
        run = canRotate;
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
                kk._o.transform.localPosition = new Vector2(Mathf.Cos(kk.angle * Mathf.Deg2Rad) * longRadius, Mathf.Sin(kk.angle * Mathf.Deg2Rad) * shortRadius);

                kk._o.transform.localScale = Vector3.one * (1 - ((kk._o.transform.localPosition.y-(-shortRadius))/shortRadius/2));
            }
        }
 

    }

    class RotateItem
    {
        public GameObject _o;
        public int index = 0;
        public float angle = 0;
    }
}
