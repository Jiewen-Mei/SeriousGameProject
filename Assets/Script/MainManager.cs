using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainManager : MonoBehaviour
{
	
	public static MainManager Instance;   //use as condiiton for one instance only
	public static string playername = "Unknown";
	public const int numOfHighScore = 5;  
	public const string NameKey = "HSName";
	public const string scoreKey = "HScore";
	public static float volume = 1f;  
	public static float score = 0f;
	public static float level = 1f;
	public static float maxLevel = 3f;
	public static int difficulty = 0;
	
	
	public void Awake(){
		if(Instance != null){
			Destroy(gameObject);
			return;
		}
		
		Instance = this;
		DontDestroyOnLoad(gameObject);      // only initial copy
	}
	
	public static void SaveScore(){
		for( int i = 0; i < numOfHighScore; i++){
			string currentNameKey = NameKey + i;
			string currentScoreKey = scoreKey + i;
			
			if(PlayerPrefs.HasKey(currentScoreKey)){
				float currentScore = PlayerPrefs.GetFloat(currentScoreKey);
				if(score > currentScore){
					float tempScore = currentScore;
					string tempName = PlayerPrefs.GetString(currentNameKey);
					PlayerPrefs.SetString(currentNameKey, playername);
					PlayerPrefs.SetFloat(currentScoreKey, score);
					score = tempScore;
					playername = tempName; 
				}
			}
			else {
				PlayerPrefs.SetString(currentNameKey,playername);
				PlayerPrefs.SetFloat(currentScoreKey, score);
				return;
			}
		}
	}
   
}
