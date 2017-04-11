using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public enum TimeClock {Twelve, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Eleven}

public class DayAndNight : MonoBehaviour
{
    public TimeClock timeOfDay;

    public float sec;
    public int min;
    public int hour;
    public int timeSpeedUp;

    public bool am;

    private int hourDisplay;

    public Text timeDisplay;

    public Image panel;

    public Color dayColor;
    public Color nightColor;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        sec += Time.deltaTime * timeSpeedUp;

        if(am)
        {
            panel.color = Color.Lerp(dayColor, nightColor, (Time.time * timeSpeedUp)/ 43200);
            //panel.color = dayColor;   
            timeDisplay.color = Color.black;
        }
        if (!am)
        {
            panel.color = Color.Lerp(dayColor, nightColor, Mathf.PingPong(Time.time, 2));
            //panel.color = nightColor;
            timeDisplay.color = Color.white;
        }

        HoursOfDay();
    }

    public void HoursOfDay()
        {

        if (sec >= 60)
        {
            min += 1;
            sec = 0;
        }

        if (min >= 60)
        {
            hour += 1;
            min = 0;
        }

        if (hour >= 12)
        {
            am = !am;
            hour = 0;
        }

        timeDisplay.text = hourDisplay +" : 0  " + min;
        if(min >= 10)
        {
            timeDisplay.text = hourDisplay + " : " + min;
        }
        switch (hour)
             {
                case 0:
                timeOfDay = TimeClock.Twelve;
                hourDisplay = 12; 
                break;

            case 1:
                timeOfDay = TimeClock.One;
                hourDisplay = 1;
                break;

            case 2:
                timeOfDay = TimeClock.Two;
                hourDisplay = 2;
                break;

            case 3:
                timeOfDay = TimeClock.Three;
                hourDisplay = 3;
                break;

            case 4:
                timeOfDay = TimeClock.Four;
                hourDisplay = 4;
                break;

            case 5:
                timeOfDay = TimeClock.Five;
                hourDisplay = 5;
                break;

            case 6:
                timeOfDay = TimeClock.Six;
                hourDisplay = 6;
                break;

            case 7:
                timeOfDay = TimeClock.Seven;
                hourDisplay = 7;
                break;

            case 8:
                timeOfDay = TimeClock.Eight;
                hourDisplay = 8;
                break;

            case 9:
                timeOfDay = TimeClock.Nine;
                hourDisplay = 9;
                break;

            case 10:
                timeOfDay = TimeClock.Ten;
                hourDisplay = 10;
                break;

            case 11:
                timeOfDay = TimeClock.Eleven;
                hourDisplay = 11;
                break;

            default:

                timeOfDay = TimeClock.Twelve;
                break;

          }        
        }
}
