using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ClubInfoTopPanel : BasePlane
{
    public Button backBtn;
    public Button settingBtn;

	public Button exitBtn;
	public Button disBtn;

    public Transform infoContent;

    public CircleImage clubHead;
    public Text clubName;
    public Text clubId;
    public string clubIdString;
    public GameObject tag;
    public GameObject tag2;
    public GameObject tag3;

    public Text clubMemberCount;
    public Transform clubTagContent;

    public Text clubjianjie;
    public Text kefuWX;
    public string kefu;
    public Button copyBtn;

    public Transform memberHeadContent;
    public Text memberCount;
    public Button seeClubChengYuanBtn;

    public Button seeClubSettingBtn;

    public Button seeClubUpdateBtn;

	public Toggle seeSendCoinBtn;

	public Toggle seeSendDiamondBtn;

    public Button seeClubWelcomeBtn;

    public Button seeClubShareBtn;

    public Button seeClubMeberDiamonBtn;

    public Toggle clubRefuseMsg;

    public Toggle clubSelf;

    public Button delGongGaoBtn;
    //需要区分显示的内容
    public GameObject setting;
    public GameObject update;
    public GameObject welcome;
    public GameObject refuse;
    public GameObject self;
    public GameObject delgonggao;
    public GameObject sendCoin;
    public GameObject sendDiamond;
    public GameObject sendDiamondMeber;

	public GameObject sendCoinTip;
	public GameObject sendDiamondip;

	public Button sendCoinTipBtn;
	public Button sendDiamondipBtn;

	public GameObject clubdis;

	public bool initialSendCoin;
	public bool initialSendDiamond;


    public int isMine; //0-成员 1-群主 2-管理员

    public bool canSendCoin=false;
    public bool canSendDiamond = false;
    void Awake()
    {
        backBtn = transform.Find("ToggleGroup/Back/Share").GetComponent<Button>();
        settingBtn = transform.Find("ToggleGroup/SettingBtn").GetComponent<Button>();

        infoContent = transform.Find("Info/Viewport/Content");

        clubHead = infoContent.Find("ClubBG/ClubTitle/ClubHead/mask").GetComponent<CircleImage>();
        clubName = infoContent.Find("ClubBG/ClubTitle/ClubName").GetComponent<Text>();
        clubId = infoContent.Find("ClubBG/ClubTitle/ClubId").GetComponent<Text>();
        clubMemberCount = infoContent.Find("ClubBG/ClubTitle/ClubMemberCount").GetComponent<Text>();
        clubTagContent = infoContent.Find("ClubBG/ClubTitle/ClubTip/Scroll View/Viewport/Content");
        tag = clubTagContent.Find("tip").gameObject;
        tag2 = clubTagContent.Find("tip2").gameObject;
        tag3 = clubTagContent.Find("tip3").gameObject;



		clubjianjie = infoContent.Find("ClubBG/ClubTitle/Jieshao/JieshaoText").GetComponent<Text>();
		kefuWX = infoContent.Find("ClubBG/ClubFuWX/KeFuWX").GetComponent<Text>();
		copyBtn = infoContent.Find("ClubBG/ClubFuWX/copyBtn").GetComponent<Button>();

        memberHeadContent = infoContent.Find("ClubChengYuan/Scroll View/Viewport/Content");
        memberCount = infoContent.Find("ClubChengYuan/memberCount").GetComponent<Text>();
        seeClubChengYuanBtn = infoContent.Find("ClubChengYuan/moreBtn").GetComponent<Button>();

        seeClubSettingBtn = infoContent.Find("ClubSetting/moreBtn").GetComponent<Button>();

        seeClubUpdateBtn = infoContent.Find("ClubUpdate/moreBtn").GetComponent<Button>();

		seeSendCoinBtn = infoContent.Find("ClubSendCoin/Toggle").GetComponent<Toggle>();
		seeSendDiamondBtn = infoContent.Find("ClubSendDiamond/Toggle").GetComponent<Toggle>();

//		seeSendCoinBtn = infoContent.Find("ClubSendCoin/Toggle").GetComponent<Button>();
//        seeSendDiamondBtn = infoContent.Find("ClubSendDiamond/moreBtn").GetComponent<Button>();

        seeClubWelcomeBtn = infoContent.Find("ClubWelcome/moreBtn").GetComponent<Button>();

        seeClubShareBtn = infoContent.Find("ClubShare/moreBtn").GetComponent<Button>();

        seeClubMeberDiamonBtn = infoContent.Find("ClubSendMeberDiamond/moreBtn").GetComponent<Button>();

        clubRefuseMsg = infoContent.Find("ClubRefuseMsg/Toggle").GetComponent<Toggle>();

        clubSelf = infoContent.Find("ClubSelf/Toggle").GetComponent<Toggle>();

		delGongGaoBtn = infoContent.Find("ClubDelGongGao/moreBtn").GetComponent<Button>();

		exitBtn = infoContent.Find("Clubdis/exit").GetComponent<Button>();
		disBtn = infoContent.Find("Clubdis/dis").GetComponent<Button>();

		sendCoinTip = infoContent.Find("ClubSendCoin/Cointips").gameObject;
		sendDiamondip = infoContent.Find("ClubSendDiamond/Diamondtips").gameObject;

		sendCoinTipBtn = infoContent.Find("ClubSendCoin/Wenhao").GetComponent<Button>();
		sendDiamondipBtn = infoContent.Find("ClubSendCoin/Wenhao").GetComponent<Button>();


		sendCoinTipBtn.onClick.AddListener(() => {
			sendCoinTip.SetActive(true);
		});

		sendDiamondipBtn.onClick.AddListener(() => {
			sendDiamondip.SetActive(true);
		});

        //需要区分显示的内容
        setting = infoContent.Find("ClubSetting").gameObject;
        update = infoContent.Find("ClubUpdate").gameObject;
        welcome = infoContent.Find("ClubWelcome").gameObject;
        refuse = infoContent.Find("ClubRefuseMsg").gameObject;
        delgonggao = infoContent.Find("ClubDelGongGao").gameObject;
        sendCoin = infoContent.Find("ClubSendCoin").gameObject;
        sendDiamond = infoContent.Find("ClubSendDiamond").gameObject;
        sendDiamondMeber = infoContent.Find("ClubSendMeberDiamond").gameObject;
		clubdis = infoContent.Find("Clubdis").gameObject;
        self = infoContent.Find("ClubSelf").gameObject;

        backBtn.onClick.AddListener(() => {

			if (isMine==1||isMine==2)
			{
				if(seeSendCoinBtn.isOn != initialSendCoin)
				{
					if (seeSendCoinBtn.isOn)
					{
						NetMngr.GetSingleton().Send(InterfaceClub.SetSendCoin, new object[] { ClubManager.GetSingleton().clubPanel.clubId, "1" });

					}
					else
					{
						NetMngr.GetSingleton().Send(InterfaceClub.SetSendCoin, new object[] { ClubManager.GetSingleton().clubPanel.clubId, "0" });
					}
				}
				if(seeSendDiamondBtn.isOn != initialSendDiamond){
					if (seeSendDiamondBtn.isOn)
					{
						NetMngr.GetSingleton().Send(InterfaceClub.SetSendDiamond, new object[] { ClubManager.GetSingleton().clubPanel.clubId, "1" });

					}
					else
					{
						NetMngr.GetSingleton().Send(InterfaceClub.SetSendDiamond, new object[] { ClubManager.GetSingleton().clubPanel.clubId, "0" });
					}
				}


			}
            ClubManager.GetSingleton().planeManager.RemoveTopPlane();

        });

        copyBtn.onClick.AddListener(() => {
            UniClipboard.SetText(kefu);
            ClubManager.GetSingleton().commonPopup.ShowView("复制成功");
        });

        settingBtn.onClick.AddListener(() => {
            ClubManager.GetSingleton().dissClubPopup.ShowView();
        });

        seeClubChengYuanBtn.onClick.AddListener(() => {
            if (isMine==1||isMine==2)
            {
                ClubManager.GetSingleton().planeManager.AddTopPlane(ClubManager.GetSingleton().clubMemberTopPanel);
            }
            else
            {
                ClubManager.GetSingleton().clubMember2TopPanel.panelType = 1;
                ClubManager.GetSingleton().planeManager.AddTopPlane(ClubManager.GetSingleton().clubMember2TopPanel);

            }

        });

        seeClubSettingBtn.onClick.AddListener(() => {
            ClubManager.GetSingleton().planeManager.AddTopPlane(ClubManager.GetSingleton().setClubManagerTopPanel);
        });

        seeClubShareBtn.onClick.AddListener(() => {
            ClubManager.GetSingleton().planeManager.AddTopPlane(ClubManager.GetSingleton().erweimaPanel);
        });

        seeClubMeberDiamonBtn.onClick.AddListener(() =>
        {
            ClubManager.GetSingleton().planeManager.AddTopPlane(ClubManager.GetSingleton().sendMeberDiamondTopPanel);
        });

        seeClubUpdateBtn.onClick.AddListener(() => {
            ClubManager.GetSingleton().planeManager.AddTopPlane(ClubManager.GetSingleton().clubUpdateTopPanel);
        });

//        seeSendCoinBtn.onClick.AddListener(() => {
//            if (canSendCoin)
//            {
//                ClubManager.GetSingleton().sendCoinTopPanel.ChangeType(1);
//                ClubManager.GetSingleton().planeManager.AddTopPlane(ClubManager.GetSingleton().sendCoinTopPanel);
//            }
//            else
//            {
//                ClubManager.GetSingleton().commonPopup.ShowView("当前没有赠送金币权限");
//            }
//        });
//
//        seeSendDiamondBtn.onClick.AddListener(() => {
//            if (canSendDiamond)
//            {
//                ClubManager.GetSingleton().sendCoinTopPanel.ChangeType(2);
//                ClubManager.GetSingleton().planeManager.AddTopPlane(ClubManager.GetSingleton().sendCoinTopPanel);
//            }
//            else
//            {
//                ClubManager.GetSingleton().commonPopup.ShowView("当前没有赠送钻石权限");
//            }
//        });


        seeClubWelcomeBtn.onClick.AddListener(() => {
            ClubManager.GetSingleton().planeManager.AddTopPlane(ClubManager.GetSingleton().welcomeMemberTopPanel);
        });

        delGongGaoBtn.onClick.AddListener(() => {
            ClubManager.GetSingleton().commonPopup.ShowView("确定清除俱乐部公告？", null, true, () => {

                NetMngr.GetSingleton().Send(InterfaceClub.DelGongGao, new object[] { ClubManager.GetSingleton().clubPanel.clubId });

            });

        });

		exitBtn.onClick.AddListener(() => {
			ClubManager.GetSingleton().commonPopup.ShowView("确定退出俱乐部？", null, true, () => {

				NetMngr.GetSingleton().Send(InterfaceClub.QuitClub, new object[] { ClubManager.GetSingleton().clubPanel.clubId });

			});


		});


		disBtn.onClick.AddListener(()=> {
			ClubManager.GetSingleton().commonPopup.ShowView("确定解散俱乐部？",null,true,()=> {

				NetMngr.GetSingleton().Send(InterfaceClub.DissClub,new object[] {ClubManager.GetSingleton().clubPanel.clubId });

			});


		});



        clubRefuseMsg.onValueChanged.AddListener((bool b) => {
            int jujue, simi;
            jujue = clubRefuseMsg.isOn ? 1 : 0;
            simi = clubSelf.isOn ? 1 : 0;
            NetMngr.GetSingleton().Send(InterfaceClub.SetRefuseAndSelf, new object[] { ClubManager.GetSingleton().clubPanel.clubId, jujue, simi });

        });

        clubSelf.onValueChanged.AddListener((bool b) => {
            int jujue, simi;
            jujue = clubRefuseMsg.isOn ? 1 : 0;
            simi = clubSelf.isOn ? 1 : 0;
            NetMngr.GetSingleton().Send(InterfaceClub.SetRefuseAndSelf, new object[] { ClubManager.GetSingleton().clubPanel.clubId, jujue, simi });

        });

        gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
    public void SetInfo(Hashtable data) {
        GameTools.GetSingleton().GetTextureFromNet(data["url"].ToString(), GetSprtie);

        clubName.text = data["clubName"].ToString();
        clubId.text = "ID:" + data["clubId"].ToString();
        clubIdString = data["clubId"].ToString();
        clubMemberCount.text = data["memberCount"].ToString();

        memberCount.text = data["memberCount"].ToString().Split('/')[0] + "人";

        clubjianjie.text = data["clubJianJie"].ToString();
        kefuWX.text = "客服:" + data["clubkefu"].ToString();
        kefu = data["clubkefu"].ToString();

        clubRefuseMsg.isOn = data["isRefuseMessage"].ToString() == "1" ? true : false;
        clubSelf.isOn = data["isSelf"].ToString() == "1" ? true : false;

        string[] tags = data["tag"].ToString().Split('|');
        if (tags.Length < 3)
        {
            tag.gameObject.SetActive(false);
            tag2.gameObject.SetActive(false);
            tag3.gameObject.SetActive(false);
            if (tags.Length == 1)
            {
                tag.gameObject.SetActive(true);
                tag.transform.GetChild(0).GetComponent<Text>().text = tags[0];
            }
            if (tags.Length == 2)
            {
                tag.gameObject.SetActive(true);
                tag2.gameObject.SetActive(true);
                tag.transform.GetChild(0).GetComponent<Text>().text = tags[0];
                tag2.transform.GetChild(0).GetComponent<Text>().text = tags[1];
            }
        }
        else
        {
            tag.transform.GetChild(0).GetComponent<Text>().text = tags[0];
            tag2.transform.GetChild(0).GetComponent<Text>().text = tags[1];
            tag3.transform.GetChild(0).GetComponent<Text>().text = tags[2];
            tag.transform.GetChild(0).GetComponent<Text>().text = tags[0];
            tag2.transform.GetChild(0).GetComponent<Text>().text = tags[1];
            tag3.transform.GetChild(0).GetComponent<Text>().text = tags[2];
        }

        if (data["isMine"].ToString() == "1")
        {
            setting.SetActive(true);
            update.SetActive(true);
            welcome.SetActive(true);
            refuse.SetActive(true);
            delgonggao.SetActive(true);
            sendCoin.SetActive(true);
            sendDiamond.SetActive(true);
            self.SetActive(true);
            sendDiamondMeber.SetActive(true);
//			clubdis.SetActive(true);
			exitBtn.gameObject.SetActive(false);
			disBtn.gameObject.SetActive(true);

            isMine = 1;

        }
        else if (data["isMine"].ToString() == "2")
        {
            setting.SetActive(true);
            update.SetActive(true);
            welcome.SetActive(true);
            refuse.SetActive(true);
            delgonggao.SetActive(true);
            sendCoin.SetActive(true);
            sendDiamond.SetActive(true);
            self.SetActive(true);
            sendDiamondMeber.SetActive(true);
			exitBtn.gameObject.SetActive(true);
			disBtn.gameObject.SetActive(false);
            isMine = 2;

        }
        else
        {
            setting.SetActive(false);
            update.SetActive(false);
            welcome.SetActive(false);
            refuse.SetActive(false);
            delgonggao.SetActive(false);
            sendCoin.SetActive(false);
            sendDiamond.SetActive(false);
            self.SetActive(false);
            sendDiamondMeber.SetActive(false);
			exitBtn.gameObject.SetActive(true);
			disBtn.gameObject.SetActive(false);
            isMine = 0;
        }


        for (int i = 0; i < memberHeadContent.childCount; i++)
        {
            memberHeadContent.GetChild(i).gameObject.SetActive(false);

        }

        ArrayList List = data["clubMemberList"] as ArrayList;
        //Debug.LogWarning(List.Count);
        if (List == null)
        {
            Debug.Log("俱乐部没人");
            return;
        }


        for (int i = 0; i < List.Count; i++)
        {
            if (i > 7)
            {
                break;
            }

            Hashtable ht = List[i] as Hashtable;
            memberHeadContent.GetChild(i).gameObject.SetActive(true);
            GameTools.GetSingleton().GetTextureFromNet(ht["headUrl"].ToString(), memberHeadContent.GetChild(i).GetComponent<HeadItem>().GetHead);

        }
    }
    public Hashtable ht=new Hashtable();
    public void GetClubInfoCallBack(Hashtable data) {
        ht = data;
        ClubManager.GetSingleton().planeManager.AddTopPlane(ClubManager.GetSingleton().clubInfoTopPanel);
        
        SetInfo(ht);

    }

    public void GetSprtie(Sprite s) {
        clubHead.sprite = s;
    }
    

    public override void OnAddComplete()
    {
        SetInfo(ht);
    }

    public override void OnAddStart()
    {
        NetMngr.GetSingleton().Send(InterfaceClub.GetCoinContent, new object[] { ClubManager.GetSingleton().clubPanel.clubId });
        NetMngr.GetSingleton().Send(InterfaceClub.GetDiamondContent, new object[] { ClubManager.GetSingleton().clubPanel.clubId });
    }

	public void GetCoinContentCallBack(Hashtable data) {

		if (data["isSend"].ToString() == "1")
		{
			seeSendCoinBtn.isOn = true;
		}
		else
		{
			seeSendCoinBtn.isOn= false;
		}

		initialSendCoin = seeSendCoinBtn.isOn;

	}

	public void GetDiamondContentCallBack(Hashtable data)
	{

		if (data["isSend"].ToString() == "1")
		{
			seeSendDiamondBtn.isOn = true;
		}
		else
		{
			seeSendDiamondBtn.isOn = false;
		}

		initialSendDiamond = seeSendDiamondBtn.isOn;


	}

    public override void OnRemoveComplete()
    {

    }

    public override void OnRemoveStart()
    {
		ClubManager.GetSingleton().clubListPanel.GetClubList();
//        ClubManager.GetSingleton().clubPanel.GongGaoTog.isOn = true;
//        ClubManager.GetSingleton().clubPanel.toggleIndex = 1;
    }
}