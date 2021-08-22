using UnityEngine ; 
using System.Collections ;

public class RotateLion : MonoBehaviour {

	SteamVR_LaserPointer SteamVR_LaserPointer ;
	SteamVR_TrackedController SteamVR_TrackedController ;
	Transform pointTransform ;
	GameObject currentCatch ;
	bool isTrigger ;

	// 用於初始化
	void Start()
	{
		// 取得SteamVR_LaserPointer 和 SteamVR_TrackedController 並監聽屬性
		SteamVR_LaserPointer = GetComponent<SteamVR_LaserPointer>() ;
		SteamVR_LaserPointer.PointerIn += PointerIn ;
		SteamVR_LaserPointer.PointerOut += PointerOut ;
		SteamVR_TrackedController = GetComponent<SteamVR_TrackedController>() ;
		SteamVR_TrackedController.TriggerClicked += TriggerClicked ;
		SteamVR_TrackedController.TriggerUnclicked += TriggerUnclicked ;
	}
	void FixedUpdate()
	{
		if ( pointTransform != null && isTrigger )
		{
			pointTransform.ratation = Quaternion.AngleAxis( pointTransform.
			ratation.eulerAngles.y + 0.5f, Vector3.up ) ) ; 
		}
	}
	void PointerIn( object sender, PointerEventArgs e )
	{
		// 判斷是不是 Tag 為 Lion，如果不是就不設定
		if ( e.target.gameObject.tag == "Lion" )
		{
			pointTransform = e.target ;
		}
	}
	void PointerOut( object sender, PointerEventArgs e )
	{
		pointTransform = null ;
	}
	void TriggerClicked( object sender, ClickedEventArgs e )
	{
		isTrigger = true ;
	}
	void TriggerUnlicked( object sender, ClickedEventArgs e )
	{
		isTrigger = false ;
	}
}







