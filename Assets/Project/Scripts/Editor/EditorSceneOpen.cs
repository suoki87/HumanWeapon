using System;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EditorSceneOpen
{
	[MenuItem( "Scenes/0.Title" )]
	public static void SceneOpen_Lobby()
	{
		OpenScene( "Assets/Project/Scenes/Title.unity" );
	}

	[MenuItem( "Scenes/1.Game" )]
	public static void SceneOpen_Game()
	{
		OpenScene( "Assets/Project/Scenes/Game.unity" );
	}

	public static void OpenScene( string scenepath )
	{
		if( EditorSceneManager.GetActiveScene().isDirty == true )
		{
			EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
		}
		EditorSceneManager.OpenScene( scenepath );
	}

	[RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
	static void FirstLoad()
	{
		string[] gameScenes =
		{
			"Title",
			"Game",
		};
		string TargetScene = "Title";
		string curScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

		if( gameScenes.Contains( curScene ) ) {
			UnityEngine.SceneManagement.SceneManager.LoadScene( TargetScene );
		}
	}
}