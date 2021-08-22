using UnityEngine ; 
using System.Collections ;

public class ReceiveLaser : MonoBehaviour 
{
	// 參考計數
	int ReferenceCount = 0 ;
	// 用於初始化
	void Start() ;
	// 有雷射擊中
	public void PointerIn() 
	{
		ReferenceCount ++ ;
		if ( ReferenceCount > 0 ) 
		{
			HighEnergy() ;
		}
	}
	// 雷射離開
	public void PointerOut() 
	{
		ReferenceCount -- ;
		if ( ReferenceCount <= 0 ) 
		{
			LowEnergy() ;
		}

	}

	// 這裏以下都沒直接寫做啥事，而是以virtual標記並且另外使用子類別來實現
	// 進入低能量狀態
	public virtual void LowEnergy() ;
	// 進入高能量狀態
	public virtual void HighEnergy() ;

}