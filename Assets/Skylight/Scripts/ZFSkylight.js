
#pragma strict

var generateLights : boolean = false;
var intensity : float = 0.5;
var quality : int = 1;
var color : Color = new Color (0.82,0.9,1.0,1.0);
var ibl : Texture2D;
var offset : float = 0.0;
var iblModes_id : int;
// var wrapModes_id : int;

function OnDrawGizmos() {

	#if UNITY_EDITOR

	Gizmos.DrawIcon(transform.position, "skylight");

	if (Selection.activeGameObject == this.gameObject) {

		Gizmos.color = Color.yellow;
		var distance : float = Vector3.Distance(transform.position, GetComponent.<Camera>().current.transform.position); 
		var direction : Vector3 = transform.TransformDirection (Vector3.forward) * distance * 0.1;
		Gizmos.DrawRay (transform.position, direction);
		Gizmos.DrawRay (transform.position+Vector3(0,distance * 0.012,0), direction);
		Gizmos.DrawRay (transform.position+Vector3(0,-distance * 0.012,0), direction);

	}

	if (transform.localEulerAngles.x != 0 && transform.localEulerAngles.z != 0) {
	
		transform.localEulerAngles.x = 0;
		transform.localEulerAngles.z = 0;
	 
	 }

	#endif

}