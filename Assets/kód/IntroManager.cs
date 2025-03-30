using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroManager : MonoBehaviour
{
    public TextMeshProUGUI introText;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("HasSeenIntro", 0) == 1)
        {
            SceneManager.LoadScene("MainMenuScene");
        }
        else
        {
            PlayerPrefs.SetInt("HasSeenIntro", 1);
            PlayerPrefs.Save();
            introText.text = "Krev. Popel. Křik umírajících. To byl svět, jaký jste znali.\n\n" +
                "Po staletích nekonečné války mezi vašimi národy se nebe roztrhlo a hlas, starý jako samotný čas, prolomil ticho bojišť. " +
                "Bůh, jehož jméno se liší v jazycích každé rasy, rozhodl, že chaos už nebude déle tolerován. Ne přímým zásahem. Ne mírem. Ale hrou.\n\n" +
                "„Chcete moc? Chcete přežít? Tak hrajte.“\n\n" +
                "Čtyři frakce – lidé, trpaslíci, elfové a orkové – byly vytrženy ze svých zpustošených zemí a vhozeny do nového světa. " +
                "Tři lodě na národ, žádná cesta zpět. Žádné staré říše, jen syrová země čekající na svého vládce.\n\n" +
                "Tento ostrov, posvátný a prokletý zároveň, je rozdělen na čtyři biomy:\n\n" +
                "Temné lesy, kde stíny šeptají varování a kořeny se plazí jako hadí těla.\n" +
                "Ledové hory, kde jediný chybný krok znamená smrt v propasti.\n" +
                "Jedovaté bažiny, kde i vzduch skrývá neviditelné nepřátele.\n" +
                "Rozlehlé savany, kde dravci číhají na ty, kteří si myslí, že vidí vše.\n\n" +
                "Každá oblast má svá pravidla, své nebezpečí, své odměny. " +
                "Bůh vytvořil zákony této hry: zóny, kde smrt je jen krokem zpět, ale i místa, kde jediná chyba znamená definitivní konec. Vše záleží na tom, kam se odvážíte vstoupit.\n\n" +
                "Ale něco je špatně.\n\n" +
                "Hluboko v srdci ostrova leží něco, co ani Bůh neplánoval. Peklo prorazilo bariéru reality. " +
                "Démoni, bytosti mimo tuto hru, se vplížili do světa smrtelníků. Nehrají podle pravidel. Neusilují o vítězství. Loví.\n\n" +
                "A vy?\n\n" +
                "Jste jen pěšáci na šachovnici božské hry. Nebo se z vás stane něco víc?\n\n" +
                "Vstupte do světa, kde jediná jistota je boj. Kde smrt není konec, ale možná jen začátek něčeho horšího.";
        }
    }

    public void SkipIntro()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}