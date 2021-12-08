using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Need this for calling UI scripts
using UnityEngine.SceneManagement;
                                                                         ///////////////////////// gamescene 0, menu scene 1

public class MenuManager : MonoBehaviour {

    [SerializeField] Transform MenuPanel; //Will assign our panel to this variable so we can enable/disable it
    [SerializeField] Transform InstructionPanel;
    [SerializeField] Transform SettingPanel;
    [SerializeField] Transform HighScorePanel;        // create panels
    [SerializeField] Text namefield;       // player name
    [SerializeField] Text[] nameTexts;     
    [SerializeField] Text[] scoreTexts;      //text[] for high scores         
    [SerializeField] Slider Volume;    
    [SerializeField] Text VolumeValue;
    [SerializeField] Dropdown Difficulty;
    
    const int easy = 0;
    const int hard = 1 ;
    const int medium = 2;    //assign difficulty value
	
	bool isPaused;     // pause?
	
	void Start(){
		setFalse();   // set all paneels off beside the main menu
		if(MainManager.level >= MainManager.maxLevel){
			HighScore();
		}
		else{
			Back();
		}
		MainManager.score = 0;
		MainManager.level = 1;
	}
	
	public void StartGame(){
		if(namefield.text == ""){
			MainManager.playername = "Unknown";// set default name 	if the player doesnt enter a name
		}
		else{
			MainManager.playername = namefield.text;//assign the string as persistent d	ata for play name
		}
		SceneManager.LoadScene(1);
			
		
	}// StartGame()
	
	public void Setting(){
		getVolume();
		getDifficulty();
		MenuPanel.gameObject.SetActive(false); 
		InstructionPanel.gameObject.SetActive(false); 
		SettingPanel.gameObject.SetActive(true);                // only setting panel is active
		HighScorePanel.gameObject.SetActive(false); 
		
	}
	
	public void Back(){
		MenuPanel.gameObject.SetActive(true); 
		InstructionPanel.gameObject.SetActive(false); 
		SettingPanel.gameObject.SetActive(false);                // only main menu panel is active
		HighScorePanel.gameObject.SetActive(false); 
		
	}
	
	public void HighScore(){
		MenuPanel.gameObject.SetActive(false); 
		InstructionPanel.gameObject.SetActive(false); 
		SettingPanel.gameObject.SetActive(false);                // only high score  panel is active
		HighScorePanel.gameObject.SetActive(true); 
		
	}
	public void setFalse(){
		MenuPanel.gameObject.SetActive(false); 
		InstructionPanel.gameObject.SetActive(false); 
		SettingPanel.gameObject.SetActive(false);                // all off
		HighScorePanel.gameObject.SetActive(false); 
		
	}
	
	public void getVolume(){
		Volume.value = MainManager.volume;
		VolumeValue.text = (Volume.value*100).ToString("0.0")+"%";
	}
	public void saveVolume(){
		MainManager.volume = Volume.value;
		VolumeValue.text = (Volume.value*100).ToString("0.0")+"%";
	}
	public void saveDifficulty(){
		MainManager.difficulty = Difficulty.value;
		
	}
	public void getDifficulty(){
		Difficulty.value = MainManager.difficulty;
	}
	public void DeleteScores(){
		for(int i =0; i< MainManager.numOfHighScore; i++){
			PlayerPrefs.DeleteKey(MainManager.NameKey +i);
			PlayerPrefs.DeleteKey(MainManager.scoreKey +i);
		}
	}
	public void ViewHighScores(){
		for(int i =0; i< MainManager.numOfHighScore; i++){
			nameTexts[i].text = PlayerPrefs.GetString(MainManager.NameKey +i).ToString();
			scoreTexts[i].text = PlayerPrefs.GetFloat(MainManager.scoreKey+i).ToString();
		}
	}
}