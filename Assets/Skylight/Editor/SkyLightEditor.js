@CustomEditor(ZFSkylight)

class SkyLightEditor extends Editor {

	function OnInspectorGUI() {
	
		EditorGUILayout.Space();	
			
		if (GUILayout.Button ("Open Wizard") ) {
	
			SkyLightWizard.ShowWindow(this);
	
		}

		EditorGUILayout.Space();

	}

}

