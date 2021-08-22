using UnityEngine ; 
using System.Collections ;

public class ReceiveAndOpenDoor : MonoBehaviour {

	public GameObject Win ;

	public override void HighEnergy()
	{
		Win.SetActive(true) ;
	}
}