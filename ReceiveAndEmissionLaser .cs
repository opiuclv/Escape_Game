using UnityEngine ; 
using System.Collections ;

public class ReceiveAndEmissionLaser : MonoBehaviour {
	public EmissionLaser[] EmissionLasers ;

	//	這裡override繼承了前面用vitual標注的函式

	public override void HighEnergy() 
	{
		foreach ( EmissionLaser EmissionLaser in EmissionLasers )
		{
			EmissionLaser.StartEmission() ;
		}
	}

	public override void LowEnergy() 
	{
		foreach ( EmissionLaser EmissionLaser in EmissionLasers )
		{
			EmissionLaser.EndEmission() ;
		}
	}

}