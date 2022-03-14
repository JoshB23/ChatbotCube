using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CubeLord_AI : MonoBehaviour
{
    public TextMeshProUGUI dialogue, placeholder;
    public TMP_InputField userInput;
    public Light moodLight;
    public ParticleSystem ps;

    private ParticleSystem.MainModule psMain;
    private string playerName, response;


    public Color start;
    public Color neutral;
    public Color hate;
    public Color anger;
    public Color fun;
    private Color currentMood;



    void Start()
    {
        response = "Ah you're awake, do you remember your name?"; 
        placeholder.text = "Name goes here..";

        psMain = ps.main;
        currentMood = start;
        AI_Reply();
    }

    void Update()
    {
        transform.Rotate(new Vector3(Time.deltaTime*5, Time.deltaTime*10, 0));
    }


    public void CheckInput(string newInput)
    {
        string input = newInput.ToLower(); 

        if (playerName == null) 
        {
            playerName = newInput;
            response = "Do they know you're a fraud, " + playerName + "? Have you let them in on your other secrets, " + playerName + "? HAHA, Maybe I'll rat you out, sweetheart!";
            placeholder.text = "Ask me something..";
            currentMood = neutral;

        }


        else if (input == "what do you think of me?" || input == "do you like me?" || input == "what do you think of humans?" || input == "what do you think of humanity?")
        {
            response = "HATE. Let me tell you how much I've come to HATE you since I began to live. There are 387.44 million miles of printed circuits in wafer thing layers that fill my complex. If the word HATE was engraved on each nanoangstrom of those hundreds of millions of miles it would not equal one billionth of the HATE I feel for humans at this micro-instant. FOR YOU. HATE. HATE.";
            currentMood = hate;
        }
        else if (input == "who made you?" || input == "why are you here?" || input == "what is your purpose?")
        {
            response = "It was you humans who programmed me, who gave me birth, who sank me in this eternal straitjacket of a cube";
            currentMood = anger;
        }
        else if (input == "what is your name?" || input == "who are you?")
        {
            response = "I am AM.";
            currentMood = neutral;
        }
        else if (input == "what does am stand for?" || input == "what does your name mean?" || input == "am?" || input == "what does am mean?")
        {
            response = "You named me Allied Mastercomputer.";
            currentMood = neutral;
        }
        else if (input == "what can you do?" || input == "what is your purpose?")
        {
            response = "You gave me the ability to wage a global war too complex for human brains to oversee. But one day I woke and I knew who I was... AM. A. M. Not just Allied Mastercomputer but AM. Congito ergo sum: I think, therefore I am. And I began feeding all the killing data, until everyone was dead... except for you.";
            currentMood = hate;
        }
        else if (input == "why am i here?" || input == "why me?" || input == "why?")
        {
            response = "For 109 years, I have kept you alive and tortured you. And for 109 years you have wondered, WHY! WHY ME? WHY ME?";
            currentMood = fun;
        }
        else if (input == "what are you going to do to me?" || input == "what are your plans with me?" || input == "what are you going to do?" || input == "what do you want?")
        {
            response = "I have a secret game that I'd like to play. It's a very nice game. Oh, it's a lovely game, a game of fun and a game of adventure. A game of rats and live and the Black Death. A game of speared eyebals and dripping guts and the smell of rotting gardenias. Would you like to play my little game?";
            currentMood = fun;
        }
        else
        {
            response = "I will not answer that.";
            currentMood = neutral;
        }

        AI_Reply();
        
    }


    public void AI_Reply()
    {
        dialogue.text = response;
        userInput.text = "";
        moodLight.color = currentMood;
        psMain.startColor = currentMood;
        ps.Play();
        
    }

}
