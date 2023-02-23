using giocoGladiatore;
using System.Data;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using static giocoGladiatore.Gladiatore;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;

//prendere frasi da file

string path = "C:/Users/39351/source/repos/giocoGladiatore/giocoGladiatore/FrasiMalvagi.xml";

        // Create an instance of the XmlSerializer.
        XmlSerializer serializer = new XmlSerializer(typeof(root));

        // Declare an object variable of the type to be deserialized.
        root frase;



        
        using (FileStream reader = new FileStream(path, FileMode.Open))
        {
            // Call the Deserialize method to restore the object's state.
            frase = (root)serializer.Deserialize(reader);
        }


List<string> frasiMalvagi = new List<string>();
List<string> frasiBuoni = new List<string>();


for(int i=0; i < frase.rows.Length; i++){
    if(!frase.rows[i].IsEvil){
        frasiBuoni.Add(frase.rows[i].phrase);

    }else{
        frasiMalvagi.Add(frase.rows[i].phrase);
    }
}



player gladiatore1=new Gladiatore();
player gladiatore2=new Gladiatore();


for (int i=0;i < 2;i++)
{

    Console.WriteLine("Scegli la classe del tuto guerriero:");
    Console.WriteLine("1: Gladiatore - Abilità speciale: attacco potenziato (33% success rate)");
    Console.WriteLine("2: Guerriero Persiano - Abilità speciale: ipnotizzazione");
    Console.WriteLine("3: Ladro - Abilità speciale: sciva gli attacchi (33% success rate)");

    string choice = Console.ReadLine();
    Console.WriteLine("Inserisci il nome del primo giocatore:");
    string nome = Console.ReadLine();


    bool invalido = false;


    bool isMalvagio = false;

    do
    {
        Console.Write("Scrivi");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(" SI ");
        Console.ResetColor();
        Console.Write("se il tuo personaggio e malagio, scrivi");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(" NO ");
        Console.ResetColor();
        Console.Write("se il tuo personaggio non e malvagio\n");
        string malvagioS = Console.ReadLine();

        if (malvagioS == "si")
        {
            isMalvagio = true;
            invalido = true;
        }
        else if (malvagioS == "no")
        {
            isMalvagio = false;
            invalido = true;
        }
        else
        {
            Console.WriteLine("input non valido");
        }

    } while (!invalido);

    bool ok = true;
    do
    {
        switch (choice)
        {
            case "1":
                if(i==1){
                    Gladiatore gl2 = new Gladiatore(nome, 100, 20, 15, isMalvagio);
                    gladiatore2 = gl2;
                    break;
                }
                Gladiatore gl1 = new Gladiatore(nome, 100, 20, 15, isMalvagio);
                gladiatore1=gl1;
                break;
            case "2":
                if (i == 1)
                {
                    GuerrieroPersiano gl2 = new GuerrieroPersiano(nome, 100, 20, 15, isMalvagio);
                    gladiatore2 = gl2;
                    break;
                }
                GuerrieroPersiano gl4 = new GuerrieroPersiano(nome, 100, 20, 15, isMalvagio);
                gladiatore1 = gl4;
                break;
            case "3":
                if (i == 1)
                {
                    Ladro gl2 = new Ladro(nome, 100, 20, 15, isMalvagio);
                    gladiatore2 = gl2;
                    break;
                }
                Ladro gl3 = new Ladro(nome, 100, 20, 15, isMalvagio);
                gladiatore1 = gl3;
                break;
            default:
                ok = false;
                break;
        }
    } while (!ok);
}



using (StreamWriter sw = File.AppendText("C:\\Users\\39351\\source\\repos\\giocoGladiatore\\giocoGladiatore\\combatLog.txt"))
{
    sw.WriteLine(System.DateTime.Now);

    sw.Close();
}

bool turno = true;
bool running = true;
while (running)
{
    player gladiatoreAttutale; //player turno attuale
    player gladiatoreAvversario;

    Console.WriteLine("");
    Console.WriteLine("");

    //cambio turno giocatori
    if (turno)
    {
        gladiatoreAttutale = gladiatore1;
        gladiatoreAvversario = gladiatore2;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(gladiatore1);
        Console.ResetColor();

    }else
    {
        gladiatoreAttutale = gladiatore2;
        gladiatoreAvversario=gladiatore1;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(gladiatore2);
        Console.ResetColor();
    }

    //scelta tipo di attacco
    Console.WriteLine("");
    Console.WriteLine(gladiatoreAttutale.attacks());
    Console.WriteLine("");
    string input = Console.ReadLine();
    Console.WriteLine("");


    if (input == "q" || input == "Q") running = false;
    gladiatoreAttutale.chooseAttack(input, gladiatoreAvversario);



    //se uno dei due gladiatori muore:
    if (gladiatoreAvversario.Hp <= 0)
    {
        
        Console.WriteLine("");
        Console.WriteLine("");
        Console.ForegroundColor=ConsoleColor.Green;
        Console.WriteLine(gladiatoreAttutale.Nome + " VINCE!!!");
        Console.ResetColor();
        
        if (gladiatoreAttutale.Malvagio){
        Random rand = new Random();
            Console.WriteLine("----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\t\t"+frasiMalvagi[rand.Next(0,frasiBuoni.Count())]);
            Console.ResetColor();
            Console.WriteLine("----------------------------------------------------");
        }
        else{
            Random rand = new Random();
            Console.WriteLine("----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t"+frasiBuoni[rand.Next(0,frasiMalvagi.Count())]);
            Console.ResetColor();
            Console.WriteLine("----------------------------------------------------");
        }

        
        //si ferma il game loop
        running =false;
    }
    

    if (turno)
    {
        
        turno = false;
    }else
    {
        
        turno = true;   
    }

}