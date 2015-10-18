
class SkyLightWizard extends EditorWindow {

	static var preview : Texture2D;
	static var header : Texture2D;
	static var skyEditor : SkyLightEditor;
	static var LM : boolean = false;
	static var tempTime : float;
	
	private var iblModes : String[] = ["hemisphere", "sphere"];
	private var wrapModes : String[] = ["mirror", "fit"];
				
	@MenuItem ("GameObject/Create Other/ZF Skylight", false, 20) 

    static function CreateLight() {
	
		var nl : GameObject = new GameObject ("ZF Skylight");
		nl.AddComponent(ZFSkylight);
		Selection.activeGameObject = nl;

    }
	
    static function ShowWindow(SkyEditor : SkyLightEditor) {
	
		skyEditor = SkyEditor;
		var window : SkyLightWizard = CreateInstance(SkyLightWizard);
		window.minSize = Vector2 (520,600);
		window.maxSize = Vector2 (520,600);
		window.ShowUtility();
	
    }	
 
    function OnGUI() {
		
		if (Lightmapping.isRunning && !LM) {
		
			LM = true;
			tempTime = EditorApplication.timeSinceStartup;
		
		}
		else if (!Lightmapping.isRunning && LM) {
		
			LM = false;
			Debug.Log ("Bake with selected skylight finished in " + (EditorApplication.timeSinceStartup-tempTime) + " seconds.");
		
		}
		
		header = AssetDatabase.LoadAssetAtPath("Assets/Skylight/Images/header.png", Texture2D);
		GUILayout.Label (header);

		if (!preview)
			preview = AssetDatabase.LoadAssetAtPath("Assets/Skylight/Images/ibl.png", Texture2D);
	
		if (Selection.activeGameObject && Selection.activeGameObject == skyEditor.target.gameObject) {
		
			var sky = Selection.activeGameObject.GetComponent(ZFSkylight);		
			EditorGUILayout.Space();	
			GUILayout.Label ("Intensity");
			sky.intensity = EditorGUILayout.Slider(sky.intensity, 0.0, 10.0);
			EditorGUILayout.Space();	
			GUILayout.Label ("Quality");
			sky.quality = EditorGUILayout.Slider(sky.quality, 1, 10);
			EditorGUILayout.Space();	
			GUILayout.Label ("Sky color");
			sky.color = EditorGUILayout.ColorField(sky.color);
			
			if (sky.ibl) {
			
				EditorGUI.DrawPreviewTexture(Rect(4,237,512,192),sky.ibl, null, ScaleMode.StretchToFill,0);
						
			}
			else {
			
				EditorGUI.DrawPreviewTexture(Rect(4,237,512,192),preview, null, ScaleMode.StretchToFill,0);
			
			}
			
			EditorGUILayout.Space();	
			GUILayout.Label ("Sky image");
			sky.ibl = EditorGUI.ObjectField(Rect(4,237,70,70),"",sky.ibl, Texture2D, true);
		
			if (sky.ibl) {
			
				GUI.Label (Rect(4,338,567,20),"Sun offset");
				sky.offset = EditorGUI.Slider(Rect(4,324,567,20), sky.offset, 0.0, 1.0);

			}
			//
			sky.iblModes_id = EditorGUI.Popup(Rect(10,405,100,20), sky.iblModes_id, iblModes);
					
		}
			
		if (LM) {
		
			if (GUI.Button(Rect(40,480,440,30), "Cancel baking") ) {
			
				Lightmapping.Cancel();

			}	
			
		}
		else {
			
			if (GUI.Button(Rect(40,440,440,30), "Bake scene") ) {
			
				SkyLightBase.Bake(skyEditor.target.gameObject, sky.iblModes_id);

			}		

			if (GUI.Button(Rect(40,480,440,30), "Bake selected") ) {
			
				SkyLightBase.BakeSelected(skyEditor.target.gameObject, sky.iblModes_id);

			}		
		
		}

		if (GUI.Button(Rect(40,520,440,30), "Select current skylight") ) {
		
			Selection.activeGameObject = skyEditor.target.gameObject;
		
		}

		if (GUI.Button(Rect(40,560,440,30), "Close wizard") ) {
		
			this.Close();
		
		}

		Repaint();
		
    }
	
}