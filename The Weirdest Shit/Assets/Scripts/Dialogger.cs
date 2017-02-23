using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct InteractionStep {
	public string Prompt;
	public string[] Responses;

}

public class Dialogger : MonoBehaviour {

	public Text promptText;
	public Button[] responseButtons;

	int current = -1;

	public List<InteractionStep> Interactions;

	// Use this for initialization
	void Start () {
		foreach (Button butt in responseButtons) {
			butt.onClick.AddListener(NextStep);
		}
		NextStep();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NextStep(){
		current++;
		if (current<Interactions.Count){
			InteractionStep istep = Interactions[current];
			promptText.text = istep.Prompt;
			int m = Mathf.Min(istep.Responses.Length, responseButtons.Length);
			for (int i = 0; i<m; i++){
				responseButtons[i].enabled = true;
				Text text = responseButtons[i].GetComponentInChildren<Text>();
				if (text!=null){
					text.text = istep.Responses[i];
				}
			}
			for (int i = m; i<responseButtons.Length;i++){
				responseButtons[i].enabled = false;
			}
		}
	}
}
