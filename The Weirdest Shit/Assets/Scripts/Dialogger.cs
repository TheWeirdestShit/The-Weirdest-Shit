using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct InteractionStep {
	public string Prompt;
	public string[] Responses;

	public float wait;
}


public class Dialogger : MonoBehaviour {

	public AudioClip[] ac;
	public PopSequencer sequencer;

	AudioSource asource;

	public Text promptText;
	public Button[] responseButtons;

	int current = -1;

	float time;
	bool showing;
	bool switched;

	public List<InteractionStep> Interactions;

	// Use this for initialization
	void Start () {
		asource = GetComponent<AudioSource>();
		foreach (Button butt in responseButtons) {
			butt.onClick.AddListener(Press);
		}
		Press();
	}

	public void Press(){
		showing = false;
		sequencer.popped = false;
		if (current+1<Interactions.Count)
			StartCoroutine(StepAndDisplayAfter(Interactions[current+1].wait));
	}



	void NextStep(){
		current++;
		if (current<Interactions.Count){
			InteractionStep istep = Interactions[current];
			promptText.text = istep.Prompt;
			int m = Mathf.Min(istep.Responses.Length, responseButtons.Length);
			for (int i = 0; i<m; i++){
				responseButtons[i].gameObject.SetActive(true);
				Text text = responseButtons[i].GetComponentInChildren<Text>();
				if (text!=null){
					text.text = istep.Responses[i];
				}
			}
			for (int i = m; i<responseButtons.Length;i++){
				responseButtons[i].gameObject.SetActive(false);
			}
		}
	}

	IEnumerator StepAndDisplayAfter(float seconds){
		yield return new WaitForSeconds(seconds);
		NextStep();
		sequencer.popped = true;
		if (asource!=null && ac.Length>0){
			asource.clip = ac.pickRandom();
			asource.Play();
		}
	}
	
}
