using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameUIManager : MonoBehaviour {

    public static GameUIManager _instance;
    public Transform playerHeadTrans;
    public Transform backGameTrans;
    public Button backGamebtn;
    public Transform roomNumSitActivePlayerTrans;
    public Transform mineButtomSeatTrans;// 底部自己UI
    public Transform dichizhuma;
    public Transform dichizhuma_ani_destination;
    public Transform loadingTransfrom;
    public MyController _myController;
    public myjifeipai _mjifenpai;
    public Controlbtns controlbtns;
    public PopupTopleftPanel ptopleftpanel;

    public RectTransform containerBottom;
    public RectTransform containerTop;

    public PlaneManager planeManager;

    public ManagerSetPopup managerSetPopup;
    public PlayerManageListPopup playerManageListPopup;
    public PlayerManagePopup playerManagePopup;
    public PlayerInfoPopup playerInfoPopup;
    public MatchInfoPopup matchInfoPopup;
	public GameSharePopup gameSharePopup;

	public PaiMsgTopPanel paiMsgTopPanel;
    public NowRecordPanel nowRecordPanel;
    public GameReviewPanel gameReviewPanel;
    public InsurancePanel insurancePanel;
    public OtherPanel otherPanel;
    public InsuranceRulePopup insuranceRulePopup;
    public CardTypeIntroducePopup cardTypeIntroducePopup;
    public RoomSetPopup roomSetPopup;
    public GameObject shopInGame;
    public GuessHandPopup guessHandPopup;
    public GuessRecordPanel guessRecordPanel;
    public InsuranceInfo insuranceInfoPopup;
    public PopupReplay popupReplay;
    public SelectPayPopup selectPayPopup;
    public RotateLight rlight;

    public Button guessButton;

    public Button btndashang; 
    public Text textdashang;
    Button btnBgClose;
	public Text chouma;//房间筹码
	public Text time;//房间剩余时间
	public Text club;//房间名字
	public Text playerName;//ID
    private Text insurance;//保险

	public string strplayercount;

    private Text Dici;//底池
    private Text dichizhumaText;//底池筹码

    private Text delayMoney;
    private Text paiXing;//牌型

    public Transform DairuTime;
    public Text dairuTimetext;
    public float timer = 200;
    public float timerConst = 180;
    public bool isStart = false;
    Bianchi[] mbianchi;

	private Button selectBtn;
	public SelectPanel selectPanel;

	public int gameType;
	public Image gameTypeImage;

    bool isTuoGuan;
    public static GameUIManager GetSingleton()
    {
        return _instance;
    }


    private void Awake()
    {
        if (_instance == null)
            _instance = this;
       
        backGameTrans = transform.Find("outofGame");
        backGamebtn = backGameTrans.Find("back").GetComponent<Button>();
        backGamebtn.onClick.AddListener(()=> {
            if(!isTuoGuan)
                 NetMngr.GetSingleton().Send(InterfaceGame.DesktopPlayerReturnRequest,new object[] { });
            else
                NetMngr.GetSingleton().Send(InterfaceGame.tuoGuan, new object[] { false });
        });
        btndashang = transform.Find("dashang").GetComponent<Button>();
        btndashang.gameObject.SetActive(false);
        btndashang.onClick.AddListener(delegate {
            NetMngr.GetSingleton().Send(InterfaceGame.showLeftCardsM,new object[] { });
            btndashang.gameObject.SetActive(false);
        });
        textdashang= transform.Find("dashang/Text").GetComponent<Text>();
        rlight = transform.Find("Light").GetComponent<RotateLight>();
        backGameTrans.gameObject.SetActive(false);
        containerBottom = transform.Find("ContainerBottom").GetComponent<RectTransform>();
        containerTop = transform.Find("ContainerTop").GetComponent<RectTransform>();
        planeManager = GetComponent<PlaneManager>();
        planeManager.Init(containerBottom, containerTop);
        planeManager.movePosition = 2f;
        planeManager.topPlaneMoveTime = 0.4f;
        planeManager.sidePlaneMoveTime = 0.4f;
        nowRecordPanel = containerTop.Find("NowRecordPanel").GetComponent<NowRecordPanel>();
        gameReviewPanel = containerTop.Find("GameReviewPanel").GetComponent<GameReviewPanel>();
        insurancePanel = transform.Find("InsurancePanel").GetComponent<InsurancePanel>();
        otherPanel = containerTop.Find("OtherPanel").GetComponent<OtherPanel>();
        insuranceRulePopup= transform.Find("InsuranceRulePopup").GetComponent<InsuranceRulePopup>();
        cardTypeIntroducePopup =transform.Find("CardTypeIntroducePopup").GetComponent<CardTypeIntroducePopup>();
        roomSetPopup= transform.Find("RoomSetPopup").GetComponent<RoomSetPopup>();
        shopInGame = transform.Find("ShopInGame").gameObject;
        guessHandPopup = transform.Find("GuessHandPopup").GetComponent<GuessHandPopup>();
        guessRecordPanel= transform.Find("GuessRecordPanel").GetComponent<GuessRecordPanel>();
        selectPayPopup = transform.Find("SelectPayPopup").GetComponent<SelectPayPopup>();
        guessButton = transform.Find("Controlbtns/guessBtn").GetComponent<Button>();

        loadingTransfrom = transform.Find("Loading");
        playerHeadTrans = transform.Find("playerHead");
        mineButtomSeatTrans = playerHeadTrans.Find("0");
        btnBgClose = transform.Find("bg1").GetComponent<Button>();
      
        _myController = transform.Find("mycontrol").GetComponent<MyController>();
        controlbtns = transform.Find("Controlbtns").GetComponent<Controlbtns>();
        ptopleftpanel = transform.Find("LeftTopPopupup").GetComponent<PopupTopleftPanel>();
        managerSetPopup = transform.Find("ManagerSetPopup").GetComponent<ManagerSetPopup>();
        playerManageListPopup = transform.Find("PlayerManageListPopup").GetComponent<PlayerManageListPopup>();
        playerManagePopup = transform.Find("PlayerManagePopup").GetComponent<PlayerManagePopup>();
        playerInfoPopup = transform.Find("PlayerInfoPopup").GetComponent<PlayerInfoPopup>();
        matchInfoPopup = transform.Find("MatchInfoPopup").GetComponent<MatchInfoPopup>();
		gameSharePopup = transform.Find("GameSharePopup").GetComponent<GameSharePopup>();
		paiMsgTopPanel = transform.Find("PaiMsgTopPanel").GetComponent<PaiMsgTopPanel>();
        insuranceInfoPopup = transform.Find("InsuranceInfo").GetComponent<InsuranceInfo>();
        insuranceInfoPopup.gameObject.SetActive(false);
        managerSetPopup.gameObject.SetActive(false);
        playerManageListPopup.gameObject.SetActive(false);
        playerManagePopup.gameObject.SetActive(false);
        playerInfoPopup.gameObject.SetActive(false);
        matchInfoPopup.gameObject.SetActive(false);
        selectPayPopup.gameObject.SetActive(false);
		gameSharePopup.gameObject.SetActive (false);
		paiMsgTopPanel.gameObject.SetActive (false);
        shopInGame.gameObject.transform.GetChild(1).gameObject.SetActive(true);

        ptopleftpanel.gameObject.SetActive(false);
        chouma = transform.Find("BgInfo/BG/Chouma/Text").GetComponent<Text>();
        time = transform.Find("BgInfo/BG/Time/Text").GetComponent<Text>();
        club = transform.Find("BgInfo/Club").GetComponent<Text>();
        playerName = transform.Find("BgInfo/Name").GetComponent<Text>();
        insurance = transform.Find("BgInfo/Insurance").GetComponent<Text>();
        Dici = transform.Find("Dichi/count").GetComponent<Text>();
        delayMoney = transform.Find("mycontrol/myturn/Text").GetComponent<Text>();
        paiXing = transform.Find("Paixing").GetComponent<Text>();
        paiXing.gameObject.SetActive(false);
        dichizhuma = transform.Find("Dichi/dichizhuma");
        dichizhuma_ani_destination = dichizhuma.Find("value");
        dichizhumaText = dichizhuma.Find("value").GetComponent<Text>();
        _mjifenpai = transform.Find("jifeipai").GetComponent<myjifeipai>();
        DairuTime = transform.Find("DaiRuTime");
        dairuTimetext = DairuTime.transform.Find("Text").GetComponent<Text>();
        DairuTime.gameObject.SetActive(false);
        _mjifenpai.gameObject.SetActive(false);
        Dici.gameObject.SetActive(false);
        dichizhuma.gameObject.SetActive(false);
        nowRecordPanel.gameObject.SetActive(false);
        shopInGame.gameObject.SetActive(false);
        otherPanel.gameObject.SetActive(false);
        btnBgClose.onClick.AddListener(() => {
            if (ptopleftpanel.gameObject.activeInHierarchy)
                ptopleftpanel.gameObject.SetActive(false);
            if (_myController.addtransfrom.gameObject.activeInHierarchy)
            {
                _myController.setAddCancel();
            }
        });
        popupReplay = transform.Find("PopupReplay").GetComponent<PopupReplay>();
        popupReplay.gameObject.SetActive(false);
        // Test 
        // roomNumSitActivePlayerTrans = playerHeadTrans.Find("9Persion");
        guessButton.onClick.AddListener(() => {
            guessHandPopup.gameObject.SetActive(true);
            // GameUIManager.GetSingleton().guessRecordPanel.gameObject.SetActive(true);
            TouchMove.Instance().isRun = false;
        });

		//cheat
		selectBtn = transform.Find("SelectButton").GetComponent<Button>();
		selectBtn.onClick.AddListener(()=> {
			NetMngr.GetSingleton().Send(InterfaceGame.SelectCard, new object[] { });
		});

		selectPanel = transform.Find("SelectPanel").GetComponent<SelectPanel>();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

		gameTypeImage = transform.Find("bg/Image").GetComponent<Image>();
    }
    void Start() {
        mbianchi = transform.Find("Dichi").GetComponentsInChildren<Bianchi>();
        for (int j = 0; j < mbianchi.Length; j++)
        {
         //   Debug.Log(mbianchi[j].gameObject.name + "===");
            mbianchi[j].hideGo();
        }
        if (StaticData.isReplay)
        {
            Waitting.getInstance().Hide();
            popupReplay.gameObject.SetActive(true);
            return;
        }
        Waitting.getInstance().Show();
        NetMngr.GetSingleton().Send(InterfaceGame.sendtotal, new object[]{});
        TouchMove.Instance().AddFunction(TouchMove.ActionType.Right, LeftPanel);
        TouchMove.Instance().AddFunction(TouchMove.ActionType.Left, RightPanel);
        ShowBar.statusBarState = ShowBar.States.Hidden;

        
    }
    public  void hideBianchi()
    {
        for (int j = 0; j < mbianchi.Length; j++)
        {
          //  Debug.Log(mbianchi[j].gameObject.name+"===");
            mbianchi[j].hideGo();
        }
    }
	void Update () {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            //StartCoroutine(showTimeOnDesk("5"));
            NetMngr.GetSingleton().Send(InterfaceGame.getGameReview,new object[] { "5444" });
        }
        if (isStart)
        {
            timer -= Time.deltaTime;
            dairuTimetext.text = ((int)timer).ToString();
            if (timer<=0)
            {
                isStart = false;
                timer = 180;
            }
        }
    }
    //  b  是否等待授权
    public void WaitForAccess(Hashtable h,bool b)
    {
        if (h["netID"].ToString() == "") return;
        int temp = GameManager.GetSingleton().netTolocal(int.Parse(h["netID"].ToString()));
        if(b)
        roomNumSitActivePlayerTrans.GetChild(temp).GetComponent<PlayInfo>().KeepWaitForAccess();
        else
        {
            roomNumSitActivePlayerTrans.GetChild(temp).GetComponent<PlayInfo>().BackToAccess();
        }
    }
    // 其他玩家授权状态
    public void OthersWaitForAccessState(Hashtable h)
    {
        if (h.Contains("netID"))
        {
            if (h["netID"].ToString() == "") return;
            int temp = GameManager.GetSingleton().netTolocal(int.Parse(h["netID"].ToString()));
            string type = h["type"].ToString();
            if (type == "0")// 等待授权
                roomNumSitActivePlayerTrans.GetChild(temp).GetComponent<PlayInfo>().KeepWaitForAccess();
            else
            {
                roomNumSitActivePlayerTrans.GetChild(temp).GetComponent<PlayInfo>().BackToAccess();
            }
        }
       
    }
    //8-7 显示还原头像
    public void RecoerHeadImage(int temp)
    {
        roomNumSitActivePlayerTrans.GetChild(temp).GetComponent<PlayInfo>().setHeadDark(false);
    }
    public void showBianchi(Hashtable h)
    {
        Debug.Log("Fuck.................................=========");
        ArrayList al = h["potCoin"] as ArrayList;
        this.hideBianchi();
        for(int i = 0; i < al.Count; i++)
        {
            mbianchi[i].showMsg(al[i].ToString());
        }
    }
    public void showDashang(string msg)
    {
        btndashang.gameObject.SetActive(true);
        textdashang.text = msg;
    }
    public void LeftPanel()
    {
        planeManager.AddSidePlane(nowRecordPanel, containerTop, SidePlaneDirection.LEFT, 508);
    }
    public void RightPanel()
    {
       // planeManager.AddSidePlane(otherPanel, containerTop, SidePlaneDirection.RIGHT, 174);
    }
    public void setPaixingText(string s)
    {
        paiXing.gameObject.SetActive(true);
        paiXing.text = s;
    }
    public void gameStartResetData()
    {
        Dici.gameObject.SetActive(false);
        dichizhuma.gameObject.SetActive(false);
        btndashang.gameObject.SetActive(false);
        paiXing.gameObject.SetActive(false);
        SetDelayMoney(orignDelayMoney);
    }
    public void setMyCardsType(Hashtable h)
    {

    }
    public void RoomOwnerclickStartBtn()
    {
        _myController.setTips(false);
    }
    public void GameStart(Hashtable h)
    {
        GameManager.GetSingleton().isGetGonggongPai = false;
        Paicontrol.GetInstance().MfaPai(h);
    }
    /// <summary>
    /// 设置桌布信息
    /// </summary>
    /// <param name="data"></param>
    public void SetBgInfo(Hashtable data)
    {
    }
    /// <summary>
    /// 设置底池
    /// </summary>
    /// <param name="data"></param>
    public void SetDichi(Hashtable data)
    {
        //Debug.Log(data["potCoin"].ToString()+"===");
        Dici.gameObject.SetActive(true);
        Dici.text = "底池:"+data["potCoin"].ToString();
        GameManager.GetSingleton().gameDichi = int.Parse(data["potCoin"].ToString());
        // 6-26 需求
       // this.setZhuamaDichi();
    }
    public void set627Dici(Hashtable h)
    {
        dichizhuma.gameObject.SetActive(true);
        dichizhumaText.text = h["money"].ToString();
    }
    public void setZhuamaDichi()
    {
        dichizhuma.gameObject.SetActive(true);
        dichizhumaText.text = Dici.text.Split(':')[1];
    }
    public void setDelayTime(Hashtable h)
    {
        SetDelayMoney(h["delayMoney"].ToString());
        _myController.AddDelayTime(int.Parse(h["time"].ToString()));
    }
    public void SetDelayMoney(string value)
    {
        delayMoney.text = value;
    }
    
    public void setPlayinfo(int i,Hashtable h)
    {
        Debug.Log("设置头像");
        roomNumSitActivePlayerTrans.GetChild(i).gameObject.SetActive(true);
        roomNumSitActivePlayerTrans.GetChild(i).GetComponent<PlayInfo>().setPlayinfo(h);
    }
    public void setAlreadySeatPlayinfo(int i, string h)
    {
        roomNumSitActivePlayerTrans.GetChild(i).GetComponent<PlayInfo>().setAlreadySeatPlayinfo(h);
    }
    public void setAlreadySeatPlayinfoPai(int i, string h)
    {
		if (i == GameManager.GetSingleton().myNetID)
            return;
        Paicontrol.GetInstance().PlayerAlreadyOnDeskFapai(roomNumSitActivePlayerTrans.GetChild(i));
    }
    // 某人延长时间
    public void SomeOneAddTime(Hashtable hh)
    {
        int temp = GameManager.GetSingleton().netTolocal(int.Parse(hh["netID"].ToString()));
        float time = float.Parse(hh["time"].ToString());
        roomNumSitActivePlayerTrans.GetChild(temp).GetComponent<PlayInfo>().Daojishi_Start(time);
    }


    public void ResetAllPlayerInfo()
    {
        for(int j=0;j< roomNumSitActivePlayerTrans.childCount; j++)
        {
            roomNumSitActivePlayerTrans.GetChild(j).GetComponent<PlayInfo>().RestUIPlayer();
        }
    }
    public void setAllSeatEmpty()
    {
        for(int i=0;i< roomNumSitActivePlayerTrans.childCount; i++)
        {
            roomNumSitActivePlayerTrans.GetChild(i).GetComponent<PlayInfo>().oneLeaveSeat();
            roomNumSitActivePlayerTrans.GetChild(i).GetComponent<PlayInfo>().OneGameStartResetUI(false);
            Paicontrol.GetInstance().RecoveryPersonPai(roomNumSitActivePlayerTrans.GetChild(i));
        }
    }
    //某人离开（站起围观）除我之外
    public void setOneSeatEmpty(int i, Hashtable h=null)
    {
        // 如果我是观战，仍然需要显示“入座”
        if (StaticData.isGuanzhan)
            roomNumSitActivePlayerTrans.GetChild(i).GetComponent<PlayInfo>().oneLeaveSeat();
        //  我是入座玩家，直接隐藏位置即可
        else
            roomNumSitActivePlayerTrans.GetChild(i).GetComponent<PlayInfo>().gameObject.SetActive(false);
        // 清空牌
        Paicontrol.GetInstance().RecoveryPersonPai(roomNumSitActivePlayerTrans.GetChild(i));
        roomNumSitActivePlayerTrans.GetChild(i).GetComponent<PlayInfo>().OneGameStartResetUI(false);
    }
    // 玩家暂离(托管处理方式类似)
    public void setOneSeatKeey(int i, int h)
    {
        isTuoGuan = false;
		if (i == GameManager.GetSingleton().myNetID && !StaticData.isGuanzhan)
        {
            // 自己显示“返回”按钮
            backGameTrans.gameObject.SetActive(true);
        }
        // 显示倒计时
        roomNumSitActivePlayerTrans.GetChild(i).GetComponent<PlayInfo>().KeepSeat(h);
    }
    public void BackToSeat(int i)
    {
		if (i == GameManager.GetSingleton().myNetID && !StaticData.isGuanzhan)
        {
            // 自己显示“返回”按钮
            backGameTrans.gameObject.SetActive(false);
        }
        roomNumSitActivePlayerTrans.GetChild(i).GetComponent<PlayInfo>().BackToSeat();
    }
    public void TuoGuan(int i,bool b)
    {
        isTuoGuan = true;
		if (i == GameManager.GetSingleton().myNetID && !StaticData.isGuanzhan)
        {
            // 自己显示“返回”按钮
            backGameTrans.gameObject.SetActive(b);
           // GameUIManager.GetSingleton()._myController.ResetUIButton();
        }
        //else
        //{
        //    backGameTrans.gameObject.SetActive(false);
        //}
        // 托管
        roomNumSitActivePlayerTrans.GetChild(i).GetComponent<PlayInfo>().setTuoGuan(b);
    }
    public  void  setZhuanginfo(int i)
    {
        for(int j=0;j< roomNumSitActivePlayerTrans.childCount; j++)
        {
            if(i==j)
                roomNumSitActivePlayerTrans.GetChild(j).GetComponent<PlayInfo>().setZhuangInfo(true);
            else
                roomNumSitActivePlayerTrans.GetChild(j).GetComponent<PlayInfo>().setZhuangInfo(false);
        }
    }
    public void hideAllSeatHeadImg()
    {
        for (int j = 0; j < roomNumSitActivePlayerTrans.childCount; j++)
        {
            roomNumSitActivePlayerTrans.GetChild(j).gameObject.SetActive(false);
        }
    }
    // rinfo
    string orignDelayMoney = "";
    public void setRoomInfo(Hashtable data)
    {
        gameType = int.Parse(data["gameType"].ToString());
        if (gameType == 2)
        {
            insuranceRulePopup = transform.Find("InsuranceRulePopup2").GetComponent<InsuranceRulePopup>();
        }
        else
        {
            insuranceRulePopup = transform.Find("InsuranceRulePopup").GetComponent<InsuranceRulePopup>();
        }
        gameTypeImage.sprite = Resources.Load<Sprite> ("img/gametype_" + gameType.ToString());

		Paicontrol.GetInstance ().setMyArea (gameType);

        if (data.Contains("delayMoney"))
        {
            orignDelayMoney = data["delayMoney"].ToString();
            SetDelayMoney(data["delayMoney"].ToString());
        }
		strplayercount = data ["roomPlaycount"].ToString ();
        roomNumSitActivePlayerTrans = playerHeadTrans.Find(data["roomPlaycount"].ToString()+"Persion");
        for(int i=0;i< playerHeadTrans.childCount; i++)
        {
            if (i == (int.Parse(data["roomPlaycount"].ToString()) - 2))
            {
                playerHeadTrans.GetChild(i).gameObject.SetActive(true);
            }else
                playerHeadTrans.GetChild(i).gameObject.SetActive(false);
        }
        for(int j = 0; j < roomNumSitActivePlayerTrans.childCount; j++)
        {
            rlight.vectorss.Add(roomNumSitActivePlayerTrans.GetChild(j));
        }
        chouma.text = GameManager.GetSingleton().roomXiaoMang+"/"+GameManager.GetSingleton().roomDaMang;
        int temp = int.Parse(data["time"].ToString());
        float h = Mathf.FloorToInt(temp / 3600f);
        float m = Mathf.FloorToInt(temp / 60f - h * 60f);
        float s = Mathf.FloorToInt(temp - m * 60f - h * 3600f);
        time.text = h.ToString("00") + ":" + m.ToString("00") + ":" + s.ToString("00");
        club.text = "[" + data["roomName"].ToString() + "]";


		if (data ["clubName"].ToString () == "") {
			//显示分享按钮
			controlbtns.share.gameObject.SetActive(true);
			controlbtns.msg.gameObject.SetActive(false);
			playerName.text = "(" + data ["roomId"].ToString () + ")";
		} else {
			//显示消息按钮
			controlbtns.share.gameObject.SetActive(false);
			controlbtns.msg.gameObject.SetActive(true);
			playerName.text = "(" + data["clubName"].ToString() + ")";
		}
        insurance.text = data["isInsurance"].ToString() == "1" ? "保险:开启" : "保险:关闭";
        if(cor!=null)
        StopCoroutine(cor);
        bool bDaojishi = data["roomState"].ToString() == "0" ? false : true;
        cor = StartCoroutine(showTimeOnDesk(data["time"].ToString(), bDaojishi));
        Debug.Log("cor..."+ data["showBtnOrTips"].ToString());
        switch (data["showBtnOrTips"].ToString())
        {
            case "0":
                _myController.startGameShow(true);
                _myController.setTips(false);
                break;
            case "1":
                _myController.startGameShow(false);
                _myController.setTips(true);
                break;
            case "2":
                _myController.startGameShow(false);
                _myController.setTips(false);
                break;
        }
    }
    Coroutine cor;
    public void setNewTime(Hashtable data)
    {
        if (data.Contains("delayTime"))
            GameManager.GetSingleton().everyDelayTime = int.Parse(data["delayTime"].ToString());

        if(cor != null)
            StopCoroutine(cor);

        bool bDaojishi = data["roomState"].ToString() == "0" ? false : true;
        cor = StartCoroutine(showTimeOnDesk(data["time"].ToString(), bDaojishi));
    }
    IEnumerator showTimeOnDesk(string time1, bool bDaojishi)
    {
        int temo = int.Parse(time1);
        if (!bDaojishi)
        {
            float h = Mathf.FloorToInt(temo / 3600f);
            float m = Mathf.FloorToInt(temo / 60f - h * 60f);
            float s = Mathf.FloorToInt(temo - m * 60f - h * 3600f);

            time.text = h.ToString("00") + ":" + m.ToString("00") + ":" + s.ToString("00");
        }
        else
        {
            while (temo > 0)
            {
                yield return new WaitForSeconds(1);
                temo--;
                float h = Mathf.FloorToInt(temo / 3600f);
                float m = Mathf.FloorToInt(temo / 60f - h * 60f);
                float s = Mathf.FloorToInt(temo - m * 60f - h * 3600f);

                time.text = h.ToString("00") + ":" + m.ToString("00") + ":" + s.ToString("00");
            }
        }

       
    }
    public void HideBtnAndTips()
    {
        _myController.startGameShow(false);
        _myController.setTips(false);
        
    }
    public void loadImageFromURL(string url, Image headImg)
    {
        StartCoroutine(url,headImg);
    }
    public void OnSomeOneTurn(Hashtable h)
    {

    }
    public void someOneMaiPai(Hashtable h) // netid
    {
        int netid = int.Parse(h["netid"].ToString());
        int localid = GameManager.GetSingleton().netTolocal(netid);
        PlayInfo pinfo = roomNumSitActivePlayerTrans.GetChild(localid).GetComponent<PlayInfo>();
        pinfo.showOperaModel("maipai");
    }
    // 某人下注（我操作的时候，别人“弃牌”也推给我！！！这个时候不能隐藏操作界面）
    public void somneOneXiaZhu(Hashtable h) {
        string coin = h["leftMoney"].ToString();
        string zhunma = h["zhuma"].ToString();
        int netid = int.Parse(h["netID"].ToString());
        string tempmode = h["opratorMode"].ToString();
        int localid = GameManager.GetSingleton().netTolocal(netid);
        if (!StaticData.isGuanzhan)
        {
			if (netid == GameManager.GetSingleton().myNetID)
            {
				GameUIManager.GetSingleton().roomNumSitActivePlayerTrans.GetChild(localid).GetComponent<PlayInfo>().showHeadImage(true);
                GameManager.GetSingleton().myDeskLeftmoney = int.Parse(coin);
                _myController.mytrunTransform.gameObject.SetActive(false);
                _myController.nomytrunTransform.gameObject.SetActive(false);
                _myController.startRunTime = false;
                // 我弃牌
                //    if (tempmode == "0")
                //    {
                //        _myController.mytrunTransform.gameObject.SetActive(false);
                //        _myController.nomytrunTransform.gameObject.SetActive(false);
                //    }
            }
        }
        if (h.Contains("isGameOver"))
        {
            if (h["isGameOver"].ToString() == "1")
            {
                _myController.mytrunTransform.gameObject.SetActive(false);
                _myController.nomytrunTransform.gameObject.SetActive(false);
            }
        }
    
        PlayInfo pinfo = roomNumSitActivePlayerTrans.GetChild(localid).GetComponent<PlayInfo>();
        pinfo.setLeftMoney(coin);
        pinfo.SetNewChouma(zhunma);
        pinfo.Daojishi_Stop();

        // 我（其他人）弃牌动画
        if (tempmode == "0")
        {
            string tem = h["isQiPaiAndShowPai"].ToString();
            Paicontrol.GetInstance().QiPaiAni(localid, tem);
            // 头像设置灰色
            pinfo.setHeadDark();
            SoundManager.GetSingleton().PlaySound("Audio/qipai");
            pinfo.SetNewChouma("");
        }
        if (h.Contains("dizhu"))
           Dici.text = h["dizhu"].ToString();
        if (h["zhuatou"].ToString() == "1")
        {
            pinfo.showZhuaTou();
        }
        pinfo.showOperaModel(tempmode);
        // "金币飞"动画
        if (tempmode!="0" && tempmode !="3")
        Paicontrol.GetInstance().XiaZhuAni(pinfo);
        if (tempmode == "4")
        {
            SoundManager.GetSingleton().PlaySound("Audio/allin");
            pinfo.setAllin(true);
        }
        // 
        switch (tempmode)
        {
            // jiazhu
            case "1": SoundManager.GetSingleton().PlaySound("Audio/jiazhu"); break;
            // genzhu
            case "2": SoundManager.GetSingleton().PlaySound("Audio/genzhu"); break;
            // qianzhu
            case "5": SoundManager.GetSingleton().PlaySound("Audio/qianzhu"); break;
            case "6": SoundManager.GetSingleton().PlaySound("Audio/daxiaomang"); break;
        }
           
    }
    IEnumerator LoadImage(string url,Image headImg)
    {
        if (url != "")
        {
            WWW www = new WWW(url);
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
            }
            headImg.overrideSprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero);
        }
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }

	public void onSelectCard(Hashtable h)
	{

		if (!h.ContainsKey ("state"))
			return;

		if (h ["state"].ToString () == "1") {
			selectPanel.gameObject.SetActive (true);
			//几张牌
			int count = int.Parse (h ["impose"].ToString());
			//剩余牌显示
			selectPanel.showCards (count, h ["cards"].ToString());

		} else {
			selectPanel.gameObject.SetActive (false);
		}
	}
}
