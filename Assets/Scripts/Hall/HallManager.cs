using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine.Networking;
public class HallManager : MonoBehaviour
{
    public HallBottomPanel hallBottomPanel;
    public NoticeListBottomPanel noticeListBottomPanel;
    public ScoreBottomPanel scoreBottomPanel;
    public PersonalCenterBottomPanel personalCenterBottomPanel;
	public KuaisupaijuPanel kuaisupaijuPanel;

    public ScoreDetailTopPanel scoreDetailTopPanel;
    public TheGamePaiRecordTopPanel theGamePaiRecordTopPanel;
    public TheGamePaiTopPanel theGamePaiTopPanel;
    public AboutOurTopPanel aboutOurTopPanel;
//    public BlindPhoneTopPanel blindPhoneTopPanel;
    public FriendDetailTopPanel friendDetailTopPanel;
    public FriendTopPanel friendTopPanel;
    public SettingTopPanel settingTopPanel;
    public ServicesTopPanel servicesTopPanel;
    public MyDataTopPanel myDataTopPanel;
    public ShopGoldTopPanel shopGoldTopPanel;
    public ShopDiamondTopPanel shopDiamondTopPanel;
    public SignatureTopPanel signatureTopPanel;
    public NameTopPanel nameTopPanel;
    public PersonalInfoTopPanel personalInfoTopPanel;
    public MyPaiPuTopPanel myPaiPuTopPanel;
    public AddFriendTopPanel addFriendTopPanel;
    public AddFriendInfoTopPanel addFriendInfoTopPanel;
    public NoticeListContentTopPanel noticeListContentTopPanel;
    public NoticeContentTopPanel noticeContentTopPanel;
    public MyMsgTopPanel myMsgTopPanel;
    public PaiMsgTopPanel paiMsgTopPanel;
    public AgreementTopPanel agreementTopPanel;

    public CreateGamePopup createGamePopup;
    public SelectPhotoPopup selectPhotoPopup;
    public SelectSexPopup selectSexPopup;
    public OddsPopup oddsPopup;
    public SelectPayPopup selectPayPopup;

    public RectTransform containerBottom;
    public RectTransform containerTop;
    

    public Transform containerPopup;

    public PlaneManager planeManager;

    private Toggle[] bottomToggleGroup;

    private static HallManager singleton;
    public static HallManager GetSingleton()
    {
        return singleton;
    }

    private void Awake()
    {
        singleton = this;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        containerBottom = transform.Find("ContainerBottom").GetComponent<RectTransform>();
        containerTop = transform.Find("ContainerTop").GetComponent<RectTransform>();
        containerPopup = transform.Find("ContainerPopup");

        hallBottomPanel = containerBottom.Find("HallBottomPanel").GetComponent<HallBottomPanel>();
        noticeListBottomPanel = containerBottom.Find("NoticeListBottomPanel").GetComponent<NoticeListBottomPanel>();
        personalCenterBottomPanel = containerBottom.Find("PeronalCenterBottomPanel").GetComponent<PersonalCenterBottomPanel>();
		kuaisupaijuPanel = containerBottom.Find("kuaisupaijuPanel").GetComponent<KuaisupaijuPanel>();

		scoreBottomPanel = containerTop.Find("ScoreBottomPanel").GetComponent<ScoreBottomPanel>();
        scoreDetailTopPanel = containerTop.Find("ScoreDetailTopPanel").GetComponent<ScoreDetailTopPanel>();
        theGamePaiRecordTopPanel = containerTop.Find("TheGamePaiRecordTopPanel").GetComponent<TheGamePaiRecordTopPanel>();
        theGamePaiTopPanel = containerTop.Find("TheGamePaiTopPanel").GetComponent<TheGamePaiTopPanel>();
        aboutOurTopPanel = containerTop.Find("AboutOurTopPanel").GetComponent<AboutOurTopPanel>();
        //blindPhoneTopPanel = containerTop.Find("BlindPhoneTopPanel").GetComponent<BlindPhoneTopPanel>();
        friendDetailTopPanel = containerTop.Find("FriendDetailTopPanel").GetComponent<FriendDetailTopPanel>();
        friendTopPanel = containerTop.Find("FriendTopPanel").GetComponent<FriendTopPanel>();
        settingTopPanel = containerTop.Find("SettingTopPanel").GetComponent<SettingTopPanel>();
        servicesTopPanel = containerTop.Find("ServicesTopPanel").GetComponent<ServicesTopPanel>();
        myDataTopPanel = containerTop.Find("MyDataTopPanel").GetComponent<MyDataTopPanel>();
        shopGoldTopPanel = containerTop.Find("ShopGoldTopPanel").GetComponent<ShopGoldTopPanel>();
        shopDiamondTopPanel = containerTop.Find("ShopDiamondTopPanel").GetComponent<ShopDiamondTopPanel>();
        signatureTopPanel = containerTop.Find("SignatureTopPanel").GetComponent<SignatureTopPanel>();
        nameTopPanel = containerTop.Find("NameTopPanel").GetComponent<NameTopPanel>();
        personalInfoTopPanel = containerTop.Find("PersonalInfoTopPanel").GetComponent<PersonalInfoTopPanel>();
        myPaiPuTopPanel = containerTop.Find("MyPaiPuTopPanel").GetComponent<MyPaiPuTopPanel>();
        addFriendTopPanel = containerTop.Find("AddFriendTopPanel").GetComponent<AddFriendTopPanel>();
        addFriendInfoTopPanel = containerTop.Find("AddFriendInfoTopPanel").GetComponent<AddFriendInfoTopPanel>();
        noticeListContentTopPanel = containerTop.Find("NoticeListContentTopPanel").GetComponent<NoticeListContentTopPanel>();
        noticeContentTopPanel = containerTop.Find("NoticeContentTopPanel").GetComponent<NoticeContentTopPanel>();
        myMsgTopPanel = containerTop.Find("MyMsgTopPanel").GetComponent<MyMsgTopPanel>();
        paiMsgTopPanel = containerTop.Find("PaiMsgTopPanel").GetComponent<PaiMsgTopPanel>();
        agreementTopPanel = containerTop.Find("AgreementTopPanel").GetComponent<AgreementTopPanel>();

        createGamePopup = containerPopup.Find("CreateGamePopup").GetComponent<CreateGamePopup>();
        selectPhotoPopup = containerTop.Find("SelectPhotoPopup").GetComponent<SelectPhotoPopup>();
        selectSexPopup = containerTop.Find("SelectSexPopup").GetComponent<SelectSexPopup>();
        oddsPopup = containerPopup.Find("OddsPopup").GetComponent<OddsPopup>();
        selectPayPopup = containerPopup.Find("SelectPayPopup").GetComponent<SelectPayPopup>();

        planeManager = GetComponent<PlaneManager>();
        planeManager.Init(containerBottom, containerTop);
        planeManager.movePosition = 2f;
        planeManager.topPlaneMoveTime = 0.4f;
        planeManager.sidePlaneMoveTime = 0.4f;

        bottomToggleGroup = transform.Find("BottomToggleGroup").GetComponentsInChildren<Toggle>();


        //设置默认开关
        if (PlayerPrefs.HasKey("isMusic"))
        {
            StaticData.isMusic = PlayerPrefs.GetInt("isMusic") == 1 ? true : false;
        }
        if (PlayerPrefs.HasKey("isVibrate"))
        {
            StaticData.isVibrate = PlayerPrefs.GetInt("isVibrate") == 1 ? true : false;
        }
        if (PlayerPrefs.HasKey("isInform"))
        {
            StaticData.isinform = PlayerPrefs.GetInt("isInform") == 1 ? true : false;
        }
        Waitting.getInstance().Hide();
        //开始时候获取一次上传头像的地址
        NetMngr.GetSingleton().Send(InterfaceMain.RequestUpDataUrl, new object[] {  });

		NetMngr.GetSingleton().Send(InterfaceMain.GetUpdatePar, new object[] { "4" });
    }

    void Start()
    {
       
        planeManager.ShowBottomPlane(hallBottomPanel);

        noticeListBottomPanel.gameObject.SetActive(false);
		hallBottomPanel.gameObject.SetActive (false);
        personalCenterBottomPanel.gameObject.SetActive(false);
		ClubManager.GetSingleton().clubListPanel.gameObject.SetActive(false);

		scoreBottomPanel.gameObject.SetActive(false);
        scoreDetailTopPanel.gameObject.SetActive(false);
        theGamePaiRecordTopPanel.gameObject.SetActive(false);
        theGamePaiTopPanel.gameObject.SetActive(false);
        aboutOurTopPanel.gameObject.SetActive(false);
//        blindPhoneTopPanel.gameObject.SetActive(false);
        friendDetailTopPanel.gameObject.SetActive(false);
        friendTopPanel.gameObject.SetActive(false);
        settingTopPanel.gameObject.SetActive(false);
        servicesTopPanel.gameObject.SetActive(false);
        myDataTopPanel.gameObject.SetActive(false);
        shopGoldTopPanel.gameObject.SetActive(false);
        shopDiamondTopPanel.gameObject.SetActive(false);
        signatureTopPanel.gameObject.SetActive(false);
        nameTopPanel.gameObject.SetActive(false);
        personalInfoTopPanel.gameObject.SetActive(false);
        myPaiPuTopPanel.gameObject.SetActive(false);
        addFriendTopPanel.gameObject.SetActive(false);
        addFriendInfoTopPanel.gameObject.SetActive(false);
        myMsgTopPanel.gameObject.SetActive(false);
        paiMsgTopPanel.gameObject.SetActive(false);
        agreementTopPanel.gameObject.SetActive(false);

        createGamePopup.gameObject.SetActive(false);
        selectPhotoPopup.gameObject.SetActive(false);
        selectSexPopup.gameObject.SetActive(false);
        oddsPopup.gameObject.SetActive(false);
        selectPayPopup.gameObject.SetActive(false);
        PopupCommon.GetSingleton().gameObject.SetActive(false);

        bottomToggleGroup[0].onValueChanged.AddListener(delegate{
            if (bottomToggleGroup[0].isOn)
            {
				planeManager.ShowBottomPlane(hallBottomPanel);
				hallBottomPanel.GetGameInfo();
                //createGamePopup.ShowView();
            }
        });
        bottomToggleGroup[1].onValueChanged.AddListener(delegate {
            if (bottomToggleGroup[1].isOn)
            {
                TouchMove.Instance().RemoveFunction();
                // planeManager.ShowBottomPlane(ClubManager.GetSingleton().clubListPanel);
                ClubManager.GetSingleton().clubListPanel.gameObject.SetActive(true);
                ClubManager.GetSingleton().clubPanel.gameObject.SetActive(false);
				ClubManager.GetSingleton().myClubPanel.gameObject.SetActive(false);
                ClubManager.GetSingleton().clubListPanel.transform.parent.SetAsLastSibling();             
				ClubManager.GetSingleton().clubListPanel.GetClubList();
              
            }
        });
        bottomToggleGroup[2].onValueChanged.AddListener(delegate {
            if (bottomToggleGroup[2].isOn)
            {
				planeManager.ShowBottomPlane(kuaisupaijuPanel);
            }
        });
        bottomToggleGroup[3].onValueChanged.AddListener(delegate {
            if (bottomToggleGroup[3].isOn)
            {
				planeManager.ShowBottomPlane(noticeListBottomPanel);
            }
        });
        bottomToggleGroup[4].onValueChanged.AddListener(delegate {
            if (bottomToggleGroup[4].isOn)
            {
                planeManager.ShowBottomPlane(personalCenterBottomPanel);
            }
        });
        if (StaticData.isGameOverShowPanel != "")
        {
            scoreDetailTopPanel.id = StaticData.isGameOverShowPanel;
            planeManager.AddTopPlane(scoreDetailTopPanel);
        }

        //判断是否在俱乐部中
        if (StaticData.clubId != "") {
            TouchMove.Instance().RemoveFunction();
            ClubManager.GetSingleton().clubPanel.clubId = StaticData.clubId;

            ClubManager.GetSingleton().clubPanel.clubName.text = StaticData.clubName;

            ClubManager.GetSingleton().clubPanel.GongGaoTog.isOn = false;
            ClubManager.GetSingleton().clubPanel.MatchTog.isOn = true;
            ClubManager.GetSingleton().clubPanel.RecordTog.isOn = false;
            ClubManager.GetSingleton().clubPanel.toggleIndex = 2;
            NetMngr.GetSingleton().Send(InterfaceClub.GetClubMatch, new object[] { StaticData.clubId, 1, 100 });
            if (StaticData.isHost == 1 || StaticData.isHost == 2)
            {
                ClubManager.GetSingleton().clubPanel.createGongGaoBtn.gameObject.SetActive(true);
                ClubManager.GetSingleton().clubPanel.createMatchBtn.gameObject.SetActive(true);

            }
            else
            {
                ClubManager.GetSingleton().clubPanel.createGongGaoBtn.gameObject.SetActive(false);
                ClubManager.GetSingleton().clubPanel.createMatchBtn.gameObject.SetActive(false);

            }
            ClubManager.GetSingleton().clubPanel.gameObject.SetActive(true);
            ClubManager.GetSingleton().clubListPanel.transform.parent.SetAsLastSibling();
            StaticData.clubId = "";
        }
    }

    void Update()
    {

    }

    [DllImport("__Internal")]
    private static extern void IOS_OpenCamera();
    [DllImport("__Internal")]
    private static extern void IOS_OpenAlbum();


    public int OpenFromType;//1个人信息2创建俱乐部3修改俱乐部信息
    public string upUrl;
    public string upName;

    public void OpenCamera(string url, string name, int otype)
    {
        OpenFromType = otype;
        upUrl = url;
        upName = name;
#if UNITY_ANDROID
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject current = jc.GetStatic<AndroidJavaObject>("currentActivity");
        current.Call("Takephoto");
#elif UNITY_IPHONE
        IOS_OpenCamera();
#endif
    }

    public void OpenAlbum(string url, string name, int otype)
    {
        OpenFromType = otype;
        upUrl = url;
        upName = name;
#if UNITY_ANDROID
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject current = jc.GetStatic<AndroidJavaObject>("currentActivity");
        current.Call("OpenGallery");
#elif UNITY_IPHONE
        IOS_OpenAlbum();
#endif
    }

    void Message(string filenName)
    {
        string filePath = Application.persistentDataPath + "/" + filenName;
        var temp = ReadLocalFile(filePath);
        Texture2D tex = new Texture2D(64, 64, TextureFormat.RGB24, false);
        tex.LoadImage(temp);
        if (OpenFromType == 1)
        {
            var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
            HallManager.GetSingleton().personalInfoTopPanel.SetIcon(sprite);
            StartCoroutine(SendTexture(0, "image", temp));
        }
        else if (OpenFromType == 2)
        {
            ClubManager.GetSingleton().clubCreateTopPanel.OnImageLoad(tex);
        }
        else if (OpenFromType == 3)
        {
            ClubManager.GetSingleton().clubEditTopPanel.OnImageLoad(tex);
        }


    }

    void AndroidMessage(string imgPath)
    {
        var temp = ReadLocalFile(imgPath);
        Texture2D tex = new Texture2D(64, 64, TextureFormat.RGB24, false);
        tex.LoadImage(temp);
        if (OpenFromType == 1)
        {
            var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
            HallManager.GetSingleton().personalInfoTopPanel.SetIcon(sprite);
            StartCoroutine(SendTexture(0, "image", temp));
        }
        else if (OpenFromType == 2)
        {
            ClubManager.GetSingleton().clubCreateTopPanel.OnImageLoad(tex);
        }
        else if (OpenFromType == 3)
        {
            ClubManager.GetSingleton().clubEditTopPanel.OnImageLoad(tex);
        }
    }

    IEnumerator SendTexture(int type, string fileName, byte[] b)
    {
        WWWForm form = new WWWForm();
        form.AddBinaryData(fileName, b, upName, "image/png");

        UnityWebRequest webRequest = UnityWebRequest.Post(upUrl, form);
        webRequest.timeout = 30;
        yield return webRequest.Send();
        if (webRequest.error != null)
        {
            Debug.Log(webRequest.error);
            PopupCommon.GetSingleton().ShowView("上传失败");
            if (OpenFromType == 1)
            {
                HallManager.GetSingleton().planeManager.RemoveSidePlane();
            }
            yield return null;
        }
        else
        {
            upUrl = webRequest.downloadHandler.text;
            NetMngr.GetSingleton().Send(InterfaceMain.UpdateHead, new object[] { upUrl });
            if (OpenFromType == 1)
            {
                HallManager.GetSingleton().planeManager.RemoveSidePlane();
            }
            yield return null;
        }
    }

    public byte[] ReadLocalFile(string filePath)
    {
        var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        fs.Seek(0, SeekOrigin.Begin);
        var binary = new byte[fs.Length];
        fs.Read(binary, 0, binary.Length);
        fs.Close();
        return binary;
    }


}
