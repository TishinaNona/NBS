﻿using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityToolbarExtender.Examples
{
	static class ToolbarStyles
	{
		public static readonly GUIStyle commandButtonStyle;

		static ToolbarStyles()
		{
			commandButtonStyle = new GUIStyle("Command")
			{
				fontSize = 16,
				alignment = TextAnchor.MiddleCenter,
				imagePosition = ImagePosition.ImageAbove,
				fontStyle = FontStyle.Bold
			};
		}
	}

	[InitializeOnLoad]
	public class SceneSwitchLeftButton
	{
		static SceneSwitchLeftButton()
		{
			ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
		}

		static void OnToolbarGUI()
		{
			GUILayout.FlexibleSpace();

			if(GUILayout.Button(new GUIContent("GO", "EntryPoint"), ToolbarStyles.commandButtonStyle))
			{
				//SceneHelper.OpenLastLaunchScene();
				SceneHelper.StartScene("EntryPoint");
			}
			if(GUILayout.Button(new GUIContent("1", "EntryPoint"), ToolbarStyles.commandButtonStyle))
			{
				//SceneHelper.OpenLastLaunchScene();
				SceneHelper.OpenScene("EntryPoint");
			}
			if(GUILayout.Button(new GUIContent("2", "MainMenu"), ToolbarStyles.commandButtonStyle))
			{
				//SceneHelper.OpenLastLaunchScene();
				SceneHelper.OpenScene("MainMenu");
			}
            if (GUILayout.Button(new GUIContent("3", "GameLobbyLvl_00"), ToolbarStyles.commandButtonStyle))
            {
                //SceneHelper.OpenLastLaunchScene();
                SceneHelper.OpenScene("GameLobbyLvl_00");
            }
            if (GUILayout.Button(new GUIContent("4", "GameScene_LvlOne"), ToolbarStyles.commandButtonStyle))
            {
                //SceneHelper.OpenLastLaunchScene();
                SceneHelper.OpenScene("GameScene_LvlOne");
            }
        }
	}
	

	static class SceneHelper
	{

		
		
		static string sceneToOpen;

		public static void StartScene(string sceneName)
		{
			if(EditorApplication.isPlaying)
			{
				EditorApplication.isPlaying = false;
			}
			sceneToOpen = sceneName;
			EditorApplication.update += OnUpdate;
		}
		public static void OpenScene(string sceneName)
		{
			string[] guids = AssetDatabase.FindAssets("t:scene " + sceneName, null);
			if (guids.Length == 0)
			{
				Debug.LogWarning("Couldn't find scene file");
			}
			else
			{
				string scenePath = AssetDatabase.GUIDToAssetPath(guids[0]);
				EditorSceneManager.OpenScene(scenePath);
			}
		}
		

		static void OnUpdate()
		{
			if (sceneToOpen == null ||
			    EditorApplication.isPlaying || EditorApplication.isPaused ||
			    EditorApplication.isCompiling || EditorApplication.isPlayingOrWillChangePlaymode)
			{
				return;
			}

			EditorApplication.update -= OnUpdate;

			if(EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
			{
				// need to get scene via search because the path to the scene
				// file contains the package version so it'll change over time
				string[] guids = AssetDatabase.FindAssets("t:scene " + sceneToOpen, null);
				if (guids.Length == 0)
				{
					Debug.LogWarning("Couldn't find scene file");
				}
				else
				{
					string scenePath = AssetDatabase.GUIDToAssetPath(guids[0]);
					EditorSceneManager.OpenScene(scenePath);
					EditorApplication.isPlaying = true;
				}
			}
			sceneToOpen = null;
		}


	}
}