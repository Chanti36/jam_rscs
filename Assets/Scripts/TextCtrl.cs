using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCtrl : MonoBehaviour
{
    [SerializeField] private Text text;

	int i_charIndex = 0;
	int i_phraseIndex = 0;

    float f_charTimer;
    float f_phraseTimer;
    float f_charDelay;
    float f_phraseDelay;

    string [] dialogue = {  "introoooooooooooooooooooo",
                            "jashdjash akjsdh asjkdha jsdh akjsbfheuofaho uouhasjdh asjkcnasjkbckjsjba djkbass kjdb akjsbdakj b",
                            "enddddddddddddddddddddddd" };

    bool b_ondialogue;
    bool [] b_shake = {false, true, false};

    Vector3 textPos;
    [SerializeField] private float shakeIntensity;

	void Start()
    {
        textPos = text.rectTransform.position;

        i_charIndex = 0;
        i_phraseIndex = 0;

        f_charDelay = 0.1f;
        f_phraseDelay = 2.0f;

        text.text = "";
		b_ondialogue = true;
	}

    public void StartDialogue(string[] newDialogue, bool[] shake)
    {
        dialogue = newDialogue;
        b_shake = shake;

		i_charIndex = 0;
		i_phraseIndex = 0;

		f_charDelay = 0.1f;
		f_phraseDelay = 2.0f;

		text.text = "";
		b_ondialogue = true;
	}

	void Update()
    {
        if (!b_ondialogue)
            return ;

        //CHAR
        if (i_charIndex < dialogue[i_phraseIndex].Length)
        {
            f_charTimer += Time.deltaTime;
            if (f_charTimer > f_charDelay)
            {
                text.text += dialogue[i_phraseIndex][i_charIndex];
                f_charTimer = 0;
                i_charIndex++;

                if (b_shake[i_phraseIndex])
                    text.rectTransform.position = textPos + new Vector3(Random.Range(-shakeIntensity, shakeIntensity), 
                                                                        Random.Range(-shakeIntensity, shakeIntensity));
            }
            return;
        }
        text.rectTransform.position = textPos;

        //PHRASE
        f_phraseTimer += Time.deltaTime;

        if ( f_phraseTimer > f_phraseDelay)
        {
            text.text = "";
            if (i_phraseIndex < dialogue.Length - 1)
            {
                f_phraseTimer = 0;
                i_charIndex = 0;
                i_phraseIndex++;
            }
            else
            {
                b_ondialogue = false;
            }
        }                
    }
}
