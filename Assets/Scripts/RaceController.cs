using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceController : MonoBehaviour {

    public enum weather {
        Sun,
        Rain,
        Storm,
        Snow,
        Wind
    }

    public List<SnailRacer> racers;
    public GameObject snailPrefab;
    public weather currentWeather;
    public string[] nameList;

    void Start() {
        nameList = new string[85] {
            "ChefBoyardee",
            "HotGirlBummer",
            "TurtleJuice",
            "LactoseTheIntolerant",
            "SweetPoison",
            "ACollectionOfCells",
            "Avocadorable",
            "FrostedCupcake",
            "DownInSmoke",
            "FluffyCookie",
            "HangingWithMyGnomies",
            "KentuckyCriedFricken",
            "Idrinkchocolatemilk",
            "JuiceBoxJam",
            "CourtesyFlush",
            "MyExGirlfriend ",
            "SaltyScissors",
            "ItchyAndScratchy",
            "ADistraction",
            "ReginaPhalange",
            "ChiliConCarne",
            "TongueBerry",
            "YellowSnowman",
            "SewerSquirrel",
            "Churros4Eva",
            "FizzySodas",
            "CuteAsDucks",
            "CowabungaDude",
            "BillNyeTheRussianSpy",
            "BuhBuhBacon",
            "ChinChillin",
            "FedoraTheExplorer",
            "TestNamePleaseIgnore",
            "Kokonuts",
            "ManEatsPants",
            "Kissiz",
            "FlowerHoof",
            "DrunkBetch",
            "ImageNotUploaded",
            "MissPiggysDimples",
            "KarenYesKaren",
            "OpraWindFury",
            "Baabarella",
            "TyraSpanks",
            "Dexter",
            "DiscoThunder",
            "FistWizard",
            "KittyCowBear",
            "Avenged",
            "FartNRoses",
            "HitNRun",
            "JunkyardDog",
            "NachoCheeseFries",
            "HappyKilling",
            "CobraBite",
            "SpongeBobsPineapple",
            "TheMilkyWeigh",
            "IBlameJordan",
            "Blackout",
            "BettyBoopsBoop",
            "FrankenGin",
            "KillSwitch",
            "OwlPacino",
            "TequilaSunrise",
            "CrashTest",
            "StormCowz ",
            "Schmoople",
            "MorganFreemanButNot",
            "101WaysToMeetYourMaker",
            "ChopChop",
            "NotInsync",
            "DonWorryItsGonBOK",
            "Blister",
            "WakeAwake",
            "PaniniHead",
            "BloodFire",
            "LiquidDeath",
            "OmnipotentBeing",
            "BananaHammock",
            "UnicornHorn",
            "WhosURBuddha",
            "HoneyLemon",
            "LoveNPoprocks",
            "DrFeelGood ",
            "Anonymouse"
        };

        racers = new List<SnailRacer>();
    }


    void Update() {
    }

    public void CreateSnails() {
        GameObject btn = GameObject.Find("btnStartRace");
        btn.GetComponent<CanvasGroup>().alpha = 0;
        btn.GetComponent<CanvasGroup>().interactable = false;
        btn.GetComponent<CanvasGroup>().blocksRaycasts = false;
        int names = 0;
        for (int i = 0; i < 10; i++) {
            racers.Add(new SnailRacer("Snail " + i.ToString()));
            GameObject newSnail = Instantiate(snailPrefab, new Vector3(GameObject.Find(i.ToString()).transform.position.x, 1.434019f, -3.728f), Quaternion.identity);
            newSnail.name = racers[i].Name;
            newSnail.GetComponent<SnailMovement>().speed = racers[i].sunSpeed * 0.1f;
            newSnail.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color32((byte)racers[i].bodyColourR, (byte)racers[i].bodyColourG, (byte)racers[i].bodyColourB, 255));
            newSnail.GetComponentInChildren<TextMesh>().text = nameList[names];
            names++;
        }
        InvokeRepeating("ChangeWeather", 0, 5);
    }

    public void ChangeWeather() {
        int randWeatherChange = Random.Range(0, 5);
        switch (randWeatherChange) {
            case 0:
                currentWeather = weather.Rain;
                for (int i = 0; i < 10; i++) {
                    GameObject.Find(racers[i].Name).GetComponent<SnailMovement>().speed = racers[i].rainSpeed;
                }
                    break;
            case 1:
                currentWeather = weather.Snow;
                for (int i = 0; i < 10; i++) {
                    GameObject.Find(racers[i].Name).GetComponent<SnailMovement>().speed = racers[i].snowSpeed;
                }
                break;
            case 2:
                currentWeather = weather.Storm;
                for (int i = 0; i < 10; i++) {
                    GameObject.Find(racers[i].Name).GetComponent<SnailMovement>().speed = racers[i].stormSpeed;
                }
                break;
            case 3:
                currentWeather = weather.Sun;
                for (int i = 0; i < 10; i++) {
                    GameObject.Find(racers[i].Name).GetComponent<SnailMovement>().speed = racers[i].sunSpeed;
                }
                break;
            case 4:
                currentWeather = weather.Wind;
                for (int i = 0; i < 10; i++) {
                    GameObject.Find(racers[i].Name).GetComponent<SnailMovement>().speed = racers[i].windSpeed;
                }
                break;
            default:
                currentWeather = weather.Sun;
                for (int i = 0; i < 10; i++) {
                    GameObject.Find(racers[i].Name).GetComponent<SnailMovement>().speed = racers[i].sunSpeed;
                }
                break;
        }
    }

}
