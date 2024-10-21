using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

public class MyClubPanel : BasePlane {

    public Button backBtn;
	public Transform myClubContent;
	public GameObject tip;

    void Awake() {
		backBtn= transform.Find("ToggleGroup/Back/Share").GetComponent<Button>();
        myClubContent = transform.Find("Scroll View/Viewport/Content");
		tip = transform.Find("tip").gameObject;

		backBtn.onClick.AddListener(()=> {
			ClubManager.GetSingleton().myClubPanel.gameObject.SetActive(false);
        });

		gameObject.SetActive(false);
    }

	public void FreshList()
	{

		ClearList (myClubContent);
		ArrayList List = ClubManager.GetSingleton().clubListPanel.myList;
		if (List.Count == 0)
		{
			tip.SetActive(true);
			return;
		}
		tip.SetActive(false);
		for (int i = 0; i < List.Count; i++)
		{
			Hashtable ht = List[i] as Hashtable;
			GameObject obj = Instantiate(Resources.Load("Club/ClubItem/ClubItem")) as GameObject;
			var listv = obj.GetComponent<ClubItem>();
			listv.transform.SetParent(myClubContent) ;
			listv.transform.localScale = new Vector2(1, 1);

			//赋值
			listv.SetInfo( ht["url"].ToString(), ht["clubName"].ToString(), ht["memberCount"].ToString(), ht["deskCount"].ToString(), ht["tag"].ToString(), ht["clubId"].ToString(), ht["isHost"].ToString());

		}
	}

	private void ClearList(Transform parent)
	{
		int childCount = parent.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Destroy(parent.GetChild(i).gameObject);
		}
	}


    void Start()
    {
		
    }

    void Update()
    {

    }

    public override void OnAddComplete()
    {
		
    }

    public override void OnAddStart()
    {

    }

    public override void OnRemoveComplete()
    {

    }

    public override void OnRemoveStart()
    {

    }


}
