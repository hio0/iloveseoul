using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpisodeManager : MonoBehaviour
{
    public Division targetdivision;
    public Episode episode;

    [SerializeField] GameObject talkP;

    public Sprite[] sprites;
    public string[] texts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTalk(Division div)
    {
        targetdivision = div;
        episode = targetdivision.episodes[targetdivision.episodeCount];

        talkP.SetActive(true);
    }

    void Correct()
    {
        targetdivision.hogamdo += targetdivision.hogamdo / 2;
        MoneyManager.Money.moneyRise += targetdivision.hogamdo;
    }

    void LittleMiss()
    {
        targetdivision.hogamdo -= targetdivision.hogamdo / 5;
        MoneyManager.Money.moneyRise += targetdivision.hogamdo;
    }

    void BigMiss()
    {
        targetdivision.hogamdo -= targetdivision.hogamdo / 3;
        MoneyManager.Money.moneyRise += targetdivision.hogamdo;
    }

    void EpisodeHappyEnd()
    {
        targetdivision.hogamdo *= 3;
        MoneyManager.Money.moneyRise += targetdivision.hogamdo;

        targetdivision.episodeCount++;
    }
}
