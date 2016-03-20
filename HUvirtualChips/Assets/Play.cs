using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Play : MonoBehaviour {

	public int PlayerOneStack;
	public int PlayerTwoStack;
	public int PlayerOneBet;
	public int PlayerTwoBet;
	public int PlayerOneMinbet;
	public int PlayerTwoMinbet;
	public int PlayerOneCall;
	public int PlayerTwoCall;
	public int Pot;
	public int PlayerOneRemaining;
	public int PlayerTwoRemaining;
	public int DifferenceOne;
	public int DifferenceTwo;
	public int DifferenceMinbetOne;
	public int DifferenceMinbetTwo;
	public int TotalChips;

	public int SB;
	public int BB;

	public float blindtimer;

	public bool CallPressed;
	public bool Blinds;
	public bool CheckOne;
	public bool CheckTwo;

	public Slider PlayerOneSlider;
	public Slider PlayerTwoSlider;

	public Image FlopOne;
	public Image FlopTwo;
	public Image FlopThree;
	public Image Turn;
	public Image River;

	public Text PlayerOneStackText;
	public Text PlayerTwoStackText;
	public Text PlayerOneBetText;
	public Text PlayerTwoBetText;
	public Text PlayerOneCallText;
	public Text PlayerTwoCallText;
	public Text PotText;
	public Text PlayerOneSliderValue;
	public Text PlayerTwoSliderValue;
	public Text BlindLevelTimer;

	// Use this for initialization
	void Start () {
		CallPressed = false;
		Blinds = true;
		CheckOne = false;
		CheckTwo = false;
		blindtimer = 300.0f;
		PlayerOneStack = 2000;
		PlayerTwoStack = 2000;
		Pot = 0;
		PlayerOneSlider.value = 0f;
		PlayerTwoSlider.value = 0f;
		SB = 25;
		BB = 50;
		if (Blinds == true) {
			PlayerOneBet = SB;
			PlayerTwoBet = BB;}
		if (Blinds == false) {
			PlayerOneBet = BB;
			PlayerTwoBet = SB;}
		PlayerOneRemaining = 2000 - PlayerOneBet;
		PlayerTwoRemaining = 2000 - PlayerTwoBet;
		PlayerOneStack = PlayerOneRemaining;
		PlayerTwoStack = PlayerTwoRemaining;

		FlopOne.enabled = false;
		FlopTwo.enabled = false;
		FlopThree.enabled = false;
		Turn.enabled = false;
		River.enabled = false;

		PlayerOneStackText.text = "Stack: $" + PlayerOneStack;
		PlayerTwoStackText.text = "Stack: $" + PlayerTwoStack;
		PotText.text = "$" + Pot;
	}
	
	// Update is called once per frame
	void Update () {
	

		PlayerOneBetText.text = "Bet: $" + PlayerOneBet;
		PlayerTwoBetText.text = "Bet: $" + PlayerTwoBet;
		PlayerOneCallText.text = "Call: $" + (PlayerTwoBet - PlayerOneBet);
		PlayerTwoCallText.text = "Call: $" + (PlayerOneBet - PlayerTwoBet);
		PotText.text = "$" + Pot;
		PlayerOneSlider.maxValue = PlayerOneStack;
		PlayerTwoSlider.maxValue = PlayerTwoStack;

		DifferenceMinbetOne = PlayerTwoBet - PlayerOneBet;
		PlayerOneSlider.minValue = PlayerTwoBet + DifferenceMinbetOne;
		if (FlopThree.enabled == false && PlayerTwoBet <= BB)
			PlayerOneSlider.minValue = BB * 2;
		if (FlopThree.enabled == true && PlayerTwoBet == 0) {
			PlayerOneSlider.minValue = BB;
			PlayerOneCallText.text = "Check";
		}
		DifferenceMinbetTwo = PlayerOneBet - PlayerTwoBet;
		PlayerTwoSlider.minValue = PlayerOneBet + DifferenceMinbetTwo;
		if (FlopThree.enabled == false && PlayerOneBet <= BB)
			PlayerTwoSlider.minValue = BB * 2;
		if (FlopThree.enabled == true && PlayerOneBet == 0) {
			PlayerTwoSlider.minValue = BB;
			PlayerTwoCallText.text = "Check";
		}
		if (CheckOne && CheckTwo) {
			CardButton ();
			CheckOne = false;
			CheckTwo = false;
		}
		if (CallPressed) {
			PlayerOneSlider.value = BB;
			PlayerTwoSlider.value = BB;
			CallPressed = false;
		}

		blindtimer -= Time.deltaTime;

		if (blindtimer > 240.0f)
			BlindLevelTimer.text = "Next level in: 5min";
		if (blindtimer > 180.0f && blindtimer < 239.9f)
			BlindLevelTimer.text = "Next level in: 4min";
		if (blindtimer > 120.0f && blindtimer < 179.9f)
			BlindLevelTimer.text = "Next level in: 3min";
		if (blindtimer > 60.0f && blindtimer < 119.9f)
			BlindLevelTimer.text = "Next level in: 2min";
		if (blindtimer > 30.0f && blindtimer < 60.0f)
			BlindLevelTimer.text = "Next level in: 1min";
		if (blindtimer < 29.9f)
			BlindLevelTimer.text = "Next level in: < 30 sec";
		if (blindtimer < 0.0f) {
			BlindLevels ();
			blindtimer = 300.0f;
		}
		
		if (SB == 1000) {
			blindtimer = 0.0f;
			BlindLevelTimer.text = "Max Level";
		}
		if (PlayerOneBet == 0 && PlayerTwoBet == 0) {
			PlayerOneSliderValue.text = "Bet: $" + (int)PlayerOneSlider.value;
			PlayerTwoSliderValue.text = "Bet: $" + (int)PlayerTwoSlider.value;
		}
		if (PlayerOneBet > 0 || PlayerTwoBet > 0) {
			PlayerOneSliderValue.text = "Raise to: $" + (int)PlayerOneSlider.value;
			PlayerTwoSliderValue.text = "Raise to: $" + (int)PlayerTwoSlider.value;
		}
			TotalChips = PlayerOneStack + PlayerTwoStack + PlayerOneBet + PlayerTwoBet + Pot;
	}

	public void BlindLevels (){
		if(SB == 900){
			SB = 1000;
			BB = SB * 2;}
		if(SB == 800){
			SB = 900;
			BB = SB * 2;}
		if(SB == 700){
			SB = 800;
			BB = SB * 2;}
		if(SB == 600){
			SB = 700;
			BB = SB * 2;}
		if(SB == 500){
			SB = 600;
			BB = SB * 2;}
		if(SB == 450){
			SB = 500;
			BB = SB * 2;}
		if(SB == 400){
			SB = 450;
			BB = SB * 2;}
		if(SB == 350){
			SB = 400;
			BB = SB * 2;}
		if(SB == 300){
			SB = 350;
			BB = SB * 2;}
		if(SB == 250){
			SB = 300;
			BB = SB * 2;}
		if(SB == 200){
			SB = 250;
			BB = SB * 2;}
		if(SB == 150){
			SB = 200;
			BB = SB * 2;}
		if(SB == 100){
			SB = 150;
			BB = SB * 2;}
		if(SB == 75){
			SB = 100;
			BB = SB * 2;}
		if(SB == 50){
			SB = 75;
			BB = SB * 2;}
		if(SB == 25){
			SB = 50;
			BB = SB * 2;}
	}
		
	public void RaiseButtonOne (){
		if (PlayerOneStack > 0 && PlayerTwoBet == 0) {
			CheckTwo = false;
			PlayerOneBet = (int)PlayerOneSlider.value;
			PlayerOneRemaining = PlayerOneStack - (int)PlayerOneSlider.value;
			PlayerOneStack = PlayerOneRemaining;
			PlayerOneStackText.text = "Stack: $" + PlayerOneRemaining;
			PlayerOneBetText.text = "Bet: $" + PlayerOneBet;
		}
		if (PlayerOneStack > 0 && PlayerTwoBet > 0) {
			print ("PlayerOneBet =" + PlayerOneBet);
			DifferenceOne = (int)PlayerOneSlider.value - PlayerOneBet;
			print ("DifferenceOne =" + DifferenceOne);
			PlayerOneBet = (int)PlayerOneSlider.value;
			PlayerOneRemaining = PlayerOneStack - DifferenceOne;
			PlayerOneStack = PlayerOneRemaining;
			PlayerOneStackText.text = "Stack: $" + PlayerOneRemaining;
			PlayerOneBetText.text = "Bet: $" + PlayerOneBet;
		}
	}
	public void RaiseButtonTwo (){
		if (PlayerTwoStack > 0 && PlayerOneBet == 0) {
			CheckOne = false;
			PlayerTwoBet = (int)PlayerTwoSlider.value;
			PlayerTwoRemaining = PlayerTwoStack - (int)PlayerTwoSlider.value;
			PlayerTwoStack = PlayerTwoRemaining;
			PlayerTwoStackText.text = "Stack: $" + PlayerTwoRemaining;
			PlayerTwoBetText.text = "Bet: $" + PlayerTwoBet;
		}
		if (PlayerTwoStack > 0 && PlayerOneBet > 0) {
			print ("PlayerTwoBet =" + PlayerTwoBet);
			DifferenceTwo = (int)PlayerTwoSlider.value - PlayerTwoBet;
			print ("DifferenceTwo =" + DifferenceTwo);
			PlayerTwoBet = (int)PlayerTwoSlider.value;
			PlayerTwoRemaining = PlayerTwoStack - DifferenceTwo;
			PlayerTwoStack = PlayerTwoRemaining;
			PlayerTwoStackText.text = "Stack: $" + PlayerTwoRemaining;
			PlayerTwoBetText.text = "Bet: $" + PlayerTwoBet;
		}
	}
	public void CardButton () {
		Pot = PlayerOneBet + PlayerTwoBet + Pot;
		PotText.text = "$" + Pot;
		PlayerOneBet = 0;
		PlayerTwoBet = 0;
	if (PlayerOneSlider.value > BB) {
		PlayerOneSlider.value = PlayerOneBet;
		print ("PlayerOneSliderValue =" + PlayerOneSlider.value);}
	if (PlayerTwoSlider.value > BB) {
		PlayerTwoSlider.value = PlayerTwoBet;
		print ("PLayerTwoSliderValue =" + PlayerTwoSlider.value);}
	if (Turn.enabled == true)
		River.enabled = true;
	if (FlopOne.enabled == true)
		Turn.enabled = true;
		FlopOne.enabled = true;
		FlopTwo.enabled = true;
		FlopThree.enabled = true;
	}
	public void WinPotOne (){
		PlayerOneStack = PlayerOneRemaining + Pot + PlayerOneBet + PlayerTwoBet;
		if (Blinds == false) {
			PlayerOneBet = SB;
			PlayerTwoBet = BB;
			StackUpdate ();
			Blinds = true;
			} else {
			PlayerOneBet = BB;
			PlayerTwoBet = SB;
			StackUpdate ();
			Blinds = false;}
		PlayerOneStackText.text = "Stack: $" + PlayerOneStack;
		Pot = 0;
		PlayerOneSlider.value = BB;
		PlayerTwoSlider.value = BB;
		FlopOne.enabled = false;
		FlopTwo.enabled = false;
		FlopThree.enabled = false;
		Turn.enabled = false;
		River.enabled = false;
		CheckOne = false;
		CallPressed = true;
	}
	public void WinPotTwo (){
		PlayerTwoStack = PlayerTwoRemaining + Pot + PlayerOneBet + PlayerTwoBet;
		if (Blinds == false) {
			PlayerOneBet = SB;
			PlayerTwoBet = BB;
			StackUpdate ();
			Blinds = true;
		} else {
			PlayerOneBet = BB;
			PlayerTwoBet = SB;
			StackUpdate ();
			Blinds = false;}
		PlayerTwoStackText.text = "Stack: $" + PlayerTwoStack;
		Pot = 0;
		PlayerOneSlider.value = BB;
		PlayerTwoSlider.value = BB;
		FlopOne.enabled = false;
		FlopTwo.enabled = false;
		FlopThree.enabled = false;
		Turn.enabled = false;
		River.enabled = false;
		CheckTwo = false;
		CallPressed = true;
	}
	public void FoldPlayerOne (){
		WinPotTwo ();
		FlopOne.enabled = false;
		FlopTwo.enabled = false;
		FlopThree.enabled = false;
		Turn.enabled = false;
		River.enabled = false;
		CallPressed = true;
	}
	public void FoldPlayerTwo (){
		WinPotOne ();
		FlopOne.enabled = false;
		FlopTwo.enabled = false;
		FlopThree.enabled = false;
		Turn.enabled = false;
		River.enabled = false;
		CallPressed = true;
	}
	public void CallPlayerOne (){
		if (PlayerTwoBet == 0)
			CheckOne = true;
		if (PlayerOneBet < PlayerTwoBet){
			DifferenceOne = PlayerTwoBet - PlayerOneBet;
			PlayerOneBet = PlayerTwoBet;
			PlayerOneRemaining = PlayerOneStack - DifferenceOne;
			PlayerOneStack = PlayerOneRemaining;
			PlayerOneStackText.text = "Stack: $" + PlayerOneStack;
			CardButton ();
			CheckOne = false;
			CallPressed = true;
		}
	}
	public void CallPlayerTwo (){
		if (PlayerOneBet == 0)
			CheckTwo = true;
		if (PlayerTwoBet < PlayerOneBet) {
			DifferenceTwo = PlayerOneBet - PlayerTwoBet;
			PlayerTwoBet = PlayerOneBet;
			PlayerTwoRemaining = PlayerTwoStack - DifferenceTwo;
			PlayerTwoStack = PlayerTwoRemaining;
			PlayerTwoStackText.text = "Stack: $" + PlayerTwoStack;
			CardButton ();
			CheckTwo = false;
			CallPressed = true;
		}
	}
	public void StackUpdate (){
		PlayerOneRemaining = PlayerOneStack - PlayerOneBet;
		PlayerTwoRemaining = PlayerTwoStack - PlayerTwoBet;
		PlayerOneStack = PlayerOneRemaining;
		PlayerTwoStack = PlayerTwoRemaining;
	}
}
