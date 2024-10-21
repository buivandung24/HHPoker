using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NoticeListBottomPanel : BasePlane {

    private Button myMsg;
    private Button paiMsg;
	private Button sysMsg;
    private Transform parent;
    private Text title;
    private Text paiTitile;
	private Text sysTitle;

	private string sysId;
	private string sysType;

    private Hashtable data;

    private void Awake()
    {
        parent = transform.Find("Scroll View/Viewport/Content");
        myMsg = parent.Find("MyMsg").GetComponent<Button>();
        title = parent.Find("MyMsg/Title").GetComponent<Text>();
        paiTitile = parent.Find("PaiMsg/Title").GetComponent<Text>();
        paiMsg = parent.Find("PaiMsg").GetComponent<Button>();

		sysTitle = parent.Find("SysMsg/Title").GetComponent<Text>();
		sysMsg = parent.Find("SysMsg").GetComponent<Button>();

        myMsg.onClick.AddListener(() =>
        {
            HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().myMsgTopPanel);
        });
        paiMsg.onClick.AddListener(() =>
        {
            HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().paiMsgTopPanel);
        });

		sysMsg.onClick.AddListener(() =>
		{
				HallManager.GetSingleton().noticeListContentTopPanel.id = sysId;
				HallManager.GetSingleton().noticeListContentTopPanel.type = sysType;
				HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().noticeListContentTopPanel);
		});
    }

    void Start ()
    {
        title.text = "俱乐部消息(" + StaticData.MyMessage + ")";
        paiTitile.text = "牌局消息(" + StaticData.PaiMessage + ")";
		sysTitle.text = "系统消息";
    }

	void Update ()
    {
	
	}

    public void SetData(Hashtable data)
    {
		this.data = data;
		if (gameObject.activeInHierarchy) {
			RefreshList();
		}
    }

    /// <summary>
    /// 清空列表
    /// </summary>
    private void ClearList()
    {
        if (data == null)
            return;
        if (parent != null)
        {
            int childCount = parent.childCount;
            for (int i = 3; i < childCount; i++)
            {
                Destroy(parent.GetChild(i).gameObject);
            }
        }
      
    }
    /// <summary>
    /// 刷新列表
    /// </summary>
    private void RefreshList()
    {
        if (data == null)
            return;
        ClearList();
        ArrayList withList = data["notices"] as ArrayList;
        if (withList.Count == 0)
        {
            return;
        }
		Object objItem = Resources.Load("HallItem/NoticeItem");
        for (int i = 0; i < withList.Count; i++)
        {
			string type =  ((Hashtable)withList[i])["type"].ToString();
			string id =  ((Hashtable)withList[i])["type"].ToString();
			if (type == "1") //系统消息
			{
				sysId = id;
				sysType = type;
				continue;
			}

            GameObject go = Instantiate(objItem) as GameObject;
            go.transform.SetParent(parent);
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            NoticeItem noticeItem = go.AddComponent<NoticeItem>();
            noticeItem.type2 = "1";
			noticeItem.id = id;
			noticeItem.type = type;
            noticeItem.SetData(withList[i] as Hashtable);
        }
    }
    public override void OnAddComplete()
    {
        NetMngr.GetSingleton().Send(InterfaceMain.GetNotice, new object[] { });
    }

    public override void OnAddStart()
    {
        TouchMove.Instance().RemoveFunction();
        title.text = "我的消息("+StaticData.MyMessage+")";
        paiTitile.text = "牌局消息(" + StaticData.PaiMessage + ")";
    }

    public override void OnRemoveComplete()
    {

    }

    public override void OnRemoveStart()
    {

    }
}
