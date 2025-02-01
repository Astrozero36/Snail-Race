using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailRacer {

    public string Name { get; set; }
    public float Stamina { get; set; }
    public float Intelligence { get; set; }
    public float rainSpeed { get; set; }
    public float sunSpeed { get; set; }
    public float snowSpeed { get; set; }
    public float stormSpeed { get; set; }
    public float windSpeed { get; set; }
    public int bodyColourR { get; set; }
    public int bodyColourG { get; set; }
    public int bodyColourB { get; set; }
    public string genome { get; set; }

    public SnailRacer(string _name) {
        Name = _name;
        Stamina = Random.Range(1, 100);
        Intelligence = Random.Range(1, 100);
        rainSpeed = Random.Range(1.0f, 5.0f);
        sunSpeed = Random.Range(1.0f, 5.0f);
        snowSpeed = Random.Range(1.0f, 5.0f);
        stormSpeed = Random.Range(1.0f, 5.0f);
        windSpeed = Random.Range(1.0f, 5.0f);
        bodyColourR = Random.Range(0, 255);
        bodyColourG = Random.Range(0, 255);
        bodyColourB = Random.Range(0, 255);
    }

}
