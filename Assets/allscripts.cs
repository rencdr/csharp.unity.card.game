using UnityEngine;
using UnityEngine.UI;

public enum HandSign
{
	Air,
	Water,
	Fire,
	Earth
}

public class RockPaperScissorsGame : MonoBehaviour
{
	public Button airButton;
	public Button waterButton;
	public Button fireButton;
	public Button earthButton;

	public Text resultText;
	public Image computerChoiceImage;

	public Sprite airSprite;
	public Sprite waterSprite;
	public Sprite fireSprite;
	public Sprite earthSprite;


	private HandSign playerChoice;
	private HandSign computerChoice;

	private void Start()
	{
		airButton.onClick.AddListener(() => ChooseHandSign(HandSign.Air));
		waterButton.onClick.AddListener(() => ChooseHandSign(HandSign.Water));
		fireButton.onClick.AddListener(() => ChooseHandSign(HandSign.Fire));
		earthButton.onClick.AddListener(() => ChooseHandSign(HandSign.Earth));
		

	}

	private void ChooseHandSign(HandSign choice)
	{
		playerChoice = choice;
		PlayGame();
	}

	private void PlayGame()
	{
		// Bilgisayarýn rastgele bir seçim yapmasýný saðlar
		computerChoice = GetRandomHandSign();

		// Bilgisayarýn seçimini ekrana sprite olarak gösterir
		ShowComputerChoiceSprite(computerChoice);

		// Sonucu kontrol etmek ve ekrana yazdýrmak için gerekli kodu buraya ekleyin
		DetermineWinner();
	}

	private HandSign GetRandomHandSign()
	{
		// Rastgele bir el iþareti seçer
		int randomIndex = Random.Range(0, 4);

		if (randomIndex == 0)
			return HandSign.Air;
		else if (randomIndex == 1)
			return HandSign.Water;
		else if (randomIndex == 2)
			return HandSign.Earth;
		else
			return HandSign.Fire;
	}

	private void ShowComputerChoiceSprite(HandSign handSign)
	{
		Sprite sprite = null;

		if (handSign == HandSign.Air)
			sprite = airSprite;
		else if (handSign == HandSign.Water)
			sprite = waterSprite;
		else if (handSign == HandSign.Earth)
			sprite = earthSprite;
		else if (handSign == HandSign.Fire)
			sprite = fireSprite;

		computerChoiceImage.sprite = sprite;
	}

	private void DetermineWinner()
	{
		string result = "";

		if (playerChoice == computerChoice)
		{
			result = "DRAW";
		}
		else if (
			(playerChoice == HandSign.Air && computerChoice == HandSign.Water) ||
			(playerChoice == HandSign.Water && computerChoice == HandSign.Earth) ||
			(playerChoice == HandSign.Earth && computerChoice == HandSign.Fire) ||
			(playerChoice == HandSign.Fire && computerChoice == HandSign.Air)
		)
		{
			result = "WIN";
		}
		else
		{
			result = "LOSE";
		}

		resultText.text = result;
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Quit();
		}
	}

	private void Quit()
	{

        Application.Quit();

	}
}
