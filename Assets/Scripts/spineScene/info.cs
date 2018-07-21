using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class info : MonoBehaviour {


	//asta-i cel mai prost cod pe care l-am scris anu asta
	//by far
	public struct informatii {
	
		public string title;
		public string info;

	};
	public informatii[] data;
	public Text currentTitle, currentInfo;
	public Dropdown dropdown;
	public Image im;

	// Use this for initialization
	void Start () {

		data = new informatii[3];

		//literally hardcodam ca n-am chef

		data [0].title = "Lordoza";
		data [0].info = "Lordoza este o deviatie a coloanei vertebrale, in plan sagital cu convexitatea anterioara, prin accentuarea curburilor fiziologice. In regiunea lombara bazinul prezinta o anteversie accentuata tinzand spre orizontalizare. Abdomenul este proeminent, iar membrele inferioare sunt intinse din genunchi sau in hiperextensie. Cu timpul hiperlordoza va avea repercursiuni asupra apofizelor spinoase la care se vor produce leziuni de uzura. \n\n Printre cauzele hiperlordozei enumeram si stationarea la verticala un timp indelungat, actiune ce duce la scurtarea muschilor spinali, ei fiind muschii care lordozeaza si nu greutatea corpului. De asemenea mobilitatea redusa in miscarea de abductie a membrelor: 45 de grade pentru atriculatia coxo-femurala si 90 de grade pentru articulatia scapulo-humerala, iar depasirea acestor limite se face prin lordozare.";

		data [1].title = "Cifoza";
		data [1].info = "Cifoza este o rotunjire a spatelui. Unele rotunjiri sunt normale, dar termenul de cifoza se refera, de obicei, la o rotunjire exagerata a spatelui. Cifoza poate sa apara la orice varsta, insa este mai frecventa la femeile in varsta.\n\nCifoza legata de varsta apare adesea dupa ce osteoporoza slabeste oasele vertebrale pana la punctul in care acestea se sparg si se comprima. Alte tipuri de cifoza sunt observate la sugari sau adolescenti, din cauza malformatiei coloanei vertebrale sau a incovoierii oaselor vertebrale in timp.\n\nDesi coloana vertebrala toracica ar trebui sa aiba o cifoza naturala intre 20 si 45 de grade, anomaliile posturale sau structurale pot determina o curba care se afla in afara acestui interval normal. In timp ce termenul medical pentru o curba care este mai mare decat normala (mai mult de 50 de grade) este de fapt \"hipercifoza\", termenul \"cifoza\" este folosit in mod obisnuit de medici pentru a se referi la starea clinica a curburii excesive a coloanei vertebrale toracice, un spate superior rotunjit.";		

		data [2].title = "Scolioza";
		data [2].info = "Scolioza este o deformare permanenta a coloanei vertebrale, legata de o torsiune a vertebrelor una fata de cealalta, in cele trei planuri ale spatiului (sus-jos, dreapta-stanga, fata-spate). Apare mai ales in copilarie si adolescenta, dar poate aparea si la varsta adulta. Aceasta conditie este uneori consecinta unei alte maladii sau malformatii. \n\nAceasta deviere a coloanei vertebrale este legata de o rotatie a vertebrelor una fata de cealalta. In cazul acestei afectiuni, coloana vertebrala prezinta o rasucire. Curburile sale naturale, inainte si inapoi, sunt modificate. Scolioza este o boala frecventa in Romania, de fapt, tara noastra fiind pe locul 1 in randul tarilor europene, din acest punct de vedere.\n\n Scolioza este o afectiune care determina curbarea coloanei vertebrale laterale. Poate afecta orice parte a acesteia, dar cele mai frecvente regiuni sunt zona toracica (scolioza toracica) si partea inferioara a spatelui (scolioza lombara). In cele mai multe cazuri, motivele de schimbare a formei nu sunt cunoscute, dar in altele paralizia cerebrala, distrofia musculara si spina bifida sunt factori in dezvoltarea scoliozelor.1";
		togglePic ();
	}

	public void setInfo ()
	{
		int index = dropdown.value;
		currentTitle.text = data [index].title;
		currentInfo.text = data [index].info;
	}

	public void togglePic()
	{
		if (im.enabled == false)
			im.enabled = true;
		else
			im.enabled = false;
	}
	public void backtomenu()
	{
		SceneManager.LoadScene ("menu");
	}
}
