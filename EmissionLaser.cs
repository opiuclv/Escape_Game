using UnityEngine ; 
using System.Collections ;

public class EmissionLaser : MonoBehaviour {

	// 開關控制是否發射雷射
	public bool Enable ;
	// 雷射發射點
	public GameObject pointer ;
	public float thickness = 0.002f ;
	Transform previousContact = null ;

	void Start() 
	{
		// 建立雷射發射點
		pointer = GameObject.CreatePrimitive(PrimitiveType.Cube) ;
		pointer.transform.parent = this.transform ;
		pointer.transform.localScale = new Vector3(thickness, thickness, 100f) ;
		pointer.transform.localPosition = new Vector3(0f, 0f, 50f) ;
		pointer.transform.rotation = new Quaternion(0, 0, 0, 0) ;

		// 刪除雷射發射器的碰撞
		BoxCollider collider = pointer.GameComponent<BoxCollider>() ;
		GameObject.Destroy(collider) ;

		if(Enable)
		{
			pointer.SetAction(true) ;
		}
		else 
		{
			pointer.SetAction(false) ;
		}

	}

	// 開始發射雷射(設定初始值)
	public void StartEmission() 
	{
		pointer.SetAction(true) ;
		Enable = true ;
	}

	public void EndEmission() 
	{
		pointer.SetAction(false) ;
		Enable = false ;
		// 目前是有下一個傳遞物體，如果有將停止發射雷射事件傳遞給他
		if( previousContact != null ) 
		{ // 有東西
			ReceiveLaser r = previousContact.GameComponent<ReceiveLaser>() ;
			if( r != null ) 
			{
				r.PointerOut() ;
			}
			previousContact = null ;
		}
	}

	void Update() 
	{
		// 根據Enable來判斷是否發射雷射
		if ( !Enable ) 
		{
			return ;
		}
		Ray raycast = new Ray(transform.position, transform.forward) ;
		RaycastHit hit ;
		bool bHit = Physics.Raycast(raycast, out hit) ;

		float dist = 100f ;
		// 擊中物體並且不等於目前擊中物體，如果援物體不為空則觸發PointerOut
		if ( bHit && previousContact != hit.transform ) 
		{
			ReceiveLaser r ;
			if ( previousContact != null ) {
				r = previousContact.GameComponent<ReceiveLaser>() ;
				if ( r != null ) 
				{
					r.PointerOut() ;
				}
			}

			previousContact = hit.transform ;
			r = previousContact.GameComponent<ReceiveLaser>() ;
			if ( r != null ) 
			{
				r.PointerIn() ;
			}
		} 
		// 如果沒有擊中物體，並且原有擊中物體，則觸發原有物體的PointerOut事件
		// 並將previousContact清空
		if ( !bHit ) 
		{
			if ( previousContact != null ) 
			{
				ReceiveLaser r = previousContact.GameComponent<ReceiveLaser>() ;
				if ( r != null ) 
				{
					r.PointerOut() ;
				}
				previousContact = null ;
			}
		}
		if ( bHit && hit.distance < 100f ) 
		{
			dist = hit.distance ;
		}
		pointer.transform.localScale = new Vector3( thickness, thickness, dist) ;
		pointer.transform.localPosition = new Vector3( 0f, 0f, dist / 2f ) ; 
	}
}









