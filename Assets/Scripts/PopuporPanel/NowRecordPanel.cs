using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class NowRecordPanel : BasePlane
{

    public Text zongshoushu;
    public Text meishouhaoshi;
    public Text pingjundichi;
    public Text pingjunmairu;

    public Transform playerContent;
    public Transform viewersContent;

    public Text pangguanCount;

    public Button backBtn;

    public Text baoxianBuy;
    public Text baoxianScore;
    public Image baoxianCoinBg;
    public Text caishoupaiBuy;
    public Text caishoupaiScore;
    public Image caishoupaiCoinBg;

    void Awake() {

        backBtn = transform.Find("BackBtn").GetComponent<Button>();

        zongshoushu = transform.Find("Title/zongshoushu/Text").GetComponent<Text>();
        meishouhaoshi= transform.Find("Title/meishouhaoshi/Text").GetComponent<Text>();
        pingjundichi= transform.Find("Title/pingjundichi/Text").GetComponent<Text>();
        pingjunmairu= transform.Find("Title/pingjunmairu/Text").GetComponent<Text>();

        playerContent = transform.Find("infoPanel/Viewport/Content/messageItem/playerItem/info");
        viewersContent= transform.Find("infoPanel/Viewport/Content/messageItem/viewersItem/info");

        pangguanCount= transform.Find("infoPanel/Viewport/Content/messageItem/viewersItem/viewersTitle/pangguan/Text").GetComponent<Text>();

        baoxianBuy = playerContent.Find("baoxianItem").GetChild(2).GetComponent<Text>();
        baoxianScore = playerContent.Find("baoxianItem").GetChild(3).GetChild(0).GetComponent<Text>();
        baoxianCoinBg = playerContent.Find("baoxianItem").GetChild(3).GetComponent<Image>();
        caishoupaiBuy = playerContent.Find("caishoupaiItem").GetChild(2).GetComponent<Text>();
        caishoupaiScore = playerContent.Find("caishoupaiItem").GetChild(3).GetChild(0).GetComponent<Text>();
        caishoupaiCoinBg = playerContent.Find("caishoupaiItem").GetChild(3).GetComponent<Image>();

        backBtn.onClick.AddListener(()=> {
            GameUIManager.GetSingleton().planeManager.RemoveSidePlane();
            //ClubManager.GetSingleton().planeManager.RemoveTopPlane();
            //gameObject.SetActive(false);
        });
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public override void OnAddComplete()
    {

    }

    public override void OnAddStart()
    {
        NetMngr.GetSingleton().Send(InterfaceGame.getNowRecord, new object[] { });
    }

    public override void OnRemoveComplete()
    {

    }

    public override void OnRemoveStart()
    {

    }

    public void GetNowRecordCallBack(Hashtable data) {
        zongshoushu.text = data["zongshoushu"].ToString();
        meishouhaoshi.text = data["meishouhaoshi"].ToString();
        pingjundichi.text = data["pingjundichi"].ToString();
        pingjunmairu.text = data["pingjunmairu"].ToString();
        pangguanCount.text = "("+data["pangguanCount"].ToString()+")";
        baoxianBuy.text = data["baoxianBuy"].ToString();
        baoxianScore.text = data["baoxianScore"].ToString();
        if (int.Parse(baoxianScore.text) > 0)
        {
            this.baoxianScore.text = "+" + baoxianScore.text;
            this.baoxianCoinBg.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("img/损失BG");
        }
        else {
            this.baoxianScore.text =  baoxianScore.text;
            this.baoxianCoinBg.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("img/盈利BG");
        }
        
        caishoupaiBuy.text = data["caishoupaiBuy"].ToString();
        caishoupaiScore.text = data["caishoupaiScore"].ToString();
        if (int.Parse(caishoupaiScore.text) > 0)
        {
            this.caishoupaiScore.text = "+" + caishoupaiScore.text;
            this.caishoupaiCoinBg.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("img/损失BG");
        }
        else {
            this.caishoupaiScore.text =  caishoupaiScore.text;
            this.caishoupaiCoinBg.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("img/盈利BG");
        }
        
        BroadcastMessage("DelSelf", SendMessageOptions.DontRequireReceiver);

        ArrayList List = data["playerList"] as ArrayList;

        if (List == null)
        {
            return;
        }
        for (int i = 0; i < List.Count; i++)
        {
            Hashtable ht = List[i] as Hashtable;
            GameObject obj = Instantiate(Resources.Load("GamePopup/GamePopupItem/item")) as GameObject;
            var listv = obj.GetComponent<PlayerItem>();
            listv.transform.parent = playerContent;
            listv.transform.localScale = new Vector2(1, 1);
            //赋值
            listv.SetInfo(ht["playerName"].ToString(), ht["mairu"].ToString(), ht["score"].ToString());
        }
    
        ArrayList leaveList = data["leaveList"] as ArrayList;
        if (leaveList == null)
        {
            return;
        }
        for (int i = 0; i < leaveList.Count; i++)
        {
            Hashtable ht = leaveList[i] as Hashtable;
            GameObject obj = Instantiate(Resources.Load<GameObject>("GamePopup/GamePopupItem/leaveListItem"));
            var lists = obj.GetComponent<PlayerItem>();
            lists.transform.parent = playerContent;
            lists.transform.localScale = new Vector2(1,1);
            //赋值
            lists.SetInfo(ht["playerName"].ToString(),ht["mairu"].ToString(),ht["score"].ToString());
        }

        ArrayList List2 = data["viewerList"] as ArrayList;

        if (List2 == null)
        {
            return;
        }
        for (int i = 0; i < List2.Count; i++)
        {
            Hashtable ht = List2[i] as Hashtable;
            
            GameObject obj = Instantiate(Resources.Load("GamePopup/GamePopupItem/viewerItem")) as GameObject;
            var listv = obj.GetComponent<ViewerItem>();
            listv.transform.parent = viewersContent;
            listv.transform.localScale = new Vector2(1, 1);
            //赋值
            listv.SetInfo(ht["headUrl"].ToString(), ht["name"].ToString());
        }

        var seenList = data["seenList"] as ArrayList;
        if (seenList ==null)
        {
            return;
        }

        for (var i = 0; i < seenList.Count; i++)
        {
            var ht = seenList[i] as Hashtable;
            var obj = Instantiate(Resources.Load<GameObject>("GamePopup/GamePopupItem/seenListItem"));
            var lists = obj.GetComponent<ViewerItem>();
            lists.transform.SetParent(viewersContent);
            lists.transform.localScale = new Vector2(1,1);
            //赋值
            lists.SetInfo(ht["headUrl"].ToString(),ht["name"].ToString());
        }
    }
}
