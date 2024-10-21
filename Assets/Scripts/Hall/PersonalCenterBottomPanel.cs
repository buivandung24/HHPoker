using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PersonalCenterBottomPanel : BasePlane
{
	public CircleImage icon;
    private Text playerName;
    private Text id;
    private Text signature;
    private Button modificationBtn;
    private Text diamond;
    private Button diamondBtn;
    private Text gold;
    private Button goldBtn;
    private Button myData;
    private Button myPai;
    //private Text myPhoneInfo;
    private Button myScore;
    private Button friend;
    private Button share;
    private Button serives;
    private Button setting;
    private Image sex0;
    private Image sex1;
    private RawImage bgImgae;
    private RectTransform bgimage;
    private RectTransform content;

    public bool isStart = false;

    public string fixedDiamond="30";

    
    private void Awake()
    {
        icon = transform.Find("Scroll View/Viewport/Content/Top/Title/Icon").GetComponent<CircleImage>();
        playerName = transform.Find("Scroll View/Viewport/Content/Top/Title/Name").GetComponent<Text>();
        id = transform.Find("Scroll View/Viewport/Content/Top/Title/ID").GetComponent<Text>();
        signature = transform.Find("Scroll View/Viewport/Content/Top/Title/Signature").GetComponent<Text>();
		modificationBtn = transform.Find("Scroll View/Viewport/Content/Top/Title/bianji").GetComponent<Button>();
		diamond = transform.Find("Scroll View/Viewport/Content/Top/zuanshi/Text").GetComponent<Text>();
		diamondBtn = transform.Find("Scroll View/Viewport/Content/Top/zuanshi/Button").GetComponent<Button>();
		gold = transform.Find("Scroll View/Viewport/Content/Top/jinbi/Text").GetComponent<Text>();
		goldBtn = transform.Find("Scroll View/Viewport/Content/Top/jinbi/Button").GetComponent<Button>();
        myData = transform.Find("Scroll View/Viewport/Content/MyData").GetComponent<Button>();
        myPai = transform.Find("Scroll View/Viewport/Content/MyPai").GetComponent<Button>();
        //myPhone = transform.Find("Scroll View/Viewport/Content/MyPhone").GetComponent<Button>();
        //myPhoneInfo = transform.Find("Scroll View/Viewport/Content/MyPhone/Tip").GetComponent<Text>();
		myScore = transform.Find("Scroll View/Viewport/Content/zhanji").GetComponent<Button>();
        friend = transform.Find("Scroll View/Viewport/Content/Friend").GetComponent<Button>();
        share = transform.Find("Scroll View/Viewport/Content/Share").GetComponent<Button>();
        serives = transform.Find("Scroll View/Viewport/Content/Serives").GetComponent<Button>();
        setting = transform.Find("Scroll View/Viewport/Content/Setting").GetComponent<Button>();
        sex0 = transform.Find("Scroll View/Viewport/Content/Top/Title/Sex0").GetComponent<Image>();
        sex1 = transform.Find("Scroll View/Viewport/Content/Top/Title/Sex1").GetComponent<Image>();
        bgImgae = transform.Find("Scroll View/Viewport/Content/Top/BG").GetComponent<RawImage>();
        content = transform.Find("Scroll View/Viewport/Content").GetComponent<RectTransform>();
        bgimage = transform.Find("Scroll View/Viewport/Content/Top/BG").GetComponent<RectTransform>();

        modificationBtn.onClick.AddListener(() =>
        {
            HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().personalInfoTopPanel);
        });
        diamondBtn.onClick.AddListener(() =>
        {
            HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().shopDiamondTopPanel);
        });
        goldBtn.onClick.AddListener(() =>
        {
            HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().shopGoldTopPanel);
        });
        myData.onClick.AddListener(() =>
        {
            HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().myDataTopPanel);
        });
		myScore.onClick.AddListener(() =>
        {
			HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().scoreBottomPanel);
        });
        myPai.onClick.AddListener(() =>
        {
            HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().myPaiPuTopPanel);
        });
        friend.onClick.AddListener(() =>
        {
            HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().friendTopPanel);
        });
        share.onClick.AddListener(() =>
        {
            ClubManager.GetSingleton().erweimaPopup.ShowView();
        });
        serives.onClick.AddListener(() =>
        {
            HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().servicesTopPanel);
        });
        setting.onClick.AddListener(() => 
        {
            HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().settingTopPanel);
        });
    }

    public void SetData(Hashtable data)
    {
        StaticData.url = data["playerURL"].ToString();
        StaticData.ID= data["playerID"].ToString();
        StaticData.username= data["playerName"].ToString();
        StaticData.sex = data["playerSex"].ToString();
        StaticData.signature = data["playerSignature"].ToString();
        StaticData.diamond = int.Parse(data["playerDiamond"].ToString());
        StaticData.gold = int.Parse(data["playerGold"].ToString());
        playerName.text = data["playerName"].ToString();
        GameTools.GetSingleton().GetTextureFromNet(data["playerURL"].ToString(), GetNetSprite);
        id.text = "ID:" + data["playerID"].ToString();
        signature.text = data["playerSignature"].ToString();
        if (data["playerSex"].ToString() == "1")
        {
            sex1.gameObject.SetActive(true);
            sex0.gameObject.SetActive(false);
        }
        else
        {
            sex0.gameObject.SetActive(true);
            sex1.gameObject.SetActive(false);
        }
        diamond.text = data["playerDiamond"].ToString();
        gold.text = data["playerGold"].ToString();
//        if (string.IsNullOrEmpty(data["playerBlindPhone"].ToString()))
//        {
//            myPhoneInfo.text = "绑定手机号,可以获得" + fixedDiamond + "钻石";
//        }
//        else
//        {
//            myPhoneInfo.text = data["playerBlindPhone"].ToString();
//            myPhone.interactable = false;
//            myPhone.transform.Find("Btn").gameObject.SetActive(false);
//        }
       // GameTools.GetSingleton().GetTextureFromNet(data["playerURL"].ToString(), GetNetTexture);
    }
    private void GetNetTexture(Texture texture)
    {
//        bgImgae.texture = texture;
    }

    private void GetNetSprite(Sprite sprite)
    {
        icon.sprite = sprite;
    }

    void Start ()
    {
	
	}
	

	void Update ()
    {
        
	}
    public void SetDropPro()
    {
        if (isStart)
        {
            if (content.rect.y < -0.1f)
            {
                print("sssssss");
                bgimage.sizeDelta = new Vector2(750 - content.anchoredPosition3D.y, 750 - content.rect.y);
                bgimage.anchoredPosition3D = new Vector3(0, bgimage.rect.height / 2, 0);
            }
        }
    }

    public void SetStartDrag()
    {
        //isStart = true;
    }

    public void SetEndDrag()
    {
        //isStart = false;
    }

    public override void OnAddComplete()
    {
        NetMngr.GetSingleton().Send(InterfaceMain.GetPlayerInfo, new object[] { });
    }

    public override void OnAddStart()
    {
        TouchMove.Instance().RemoveFunction();
        
    }

    public override void OnRemoveComplete()
    {

    }

    public override void OnRemoveStart()
    {

    }
}
