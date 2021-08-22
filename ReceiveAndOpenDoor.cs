using UnityEngine ; 
using System.Collections ;

public class ReceiveAndOpenDoor : MonoBehaviour {
	public Transform[] Doors ; // 座標
	bool HasEnergy = false ;

	void FixedUpdate()
	{
		if ( HasEnergy )
		{
			foreach( Transform tr in Doors )
			{
				tr.position = Vector3.Lerp( tr.position, new Vector3(tr.
				position.x, -10, tr.position.z, Time.fixedDeltaTime ) ) ;
			}
		}
	}

	public override void HighEnergy()
	{
		HasEnergy = true ;
	}
}