using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class SSAScript : MonoBehaviour
{
    public float totalsize, hardrivesize;
    public int Neededtries,tries, BaudRateGuess;
    public string[] detectedfiles;
    public int[] baudrates;
    public InputField SerialPort, baudRate;
    public Toggle SerCrackModule, HardProbeModule, HarrietHandModule, BedoinFilesModule, TwoB58Module, MorpheusModule, TyphonModule;
    public Button StartButton, CancelButton,ExitButton;
    public Text ConsoleOutput;
    public bool SerCrackModuleEnabled, HardProbeEnabled, HarrietHandEnabled, BedoinFilesEnabled, TwoB58Enabled, MorpheusEnabled, TyphonEnabled, ResetConsole, isitrobot, isithostile, hacked;
    public GameObject NearComputer, StatusLED, hardrive;
    public Material OnLight, OffLight, SuspendLight;
    public MeshRenderer LEDMaterial;

    List<int> index;
    List<string> namefile;
    List<float> size;

    //public Dictionary<int, file> HardDriveDictionary;

    void BaudRateGuesser()
    {
        baudrates = new int[] {110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200, 128000, 256000};
        BaudRateGuess = baudrates[Random.Range(0, 13)];
    }

    void Awake()
    {
        SerCrackModule.onValueChanged.AddListener(delegate { SerCrackModuleEnabled = !SerCrackModuleEnabled;});
        HardProbeModule.onValueChanged.AddListener(delegate { HardProbeEnabled = !HardProbeEnabled;});
        HarrietHandModule.onValueChanged.AddListener(delegate { HarrietHandEnabled = !HarrietHandEnabled;});
        BedoinFilesModule.onValueChanged.AddListener(delegate { BedoinFilesEnabled = !BedoinFilesEnabled;});
        TwoB58Module.onValueChanged.AddListener(delegate { TwoB58Enabled = !TwoB58Enabled;});
        MorpheusModule.onValueChanged.AddListener(delegate { MorpheusEnabled = !MorpheusEnabled;});
        TyphonModule.onValueChanged.AddListener(delegate { TyphonEnabled = !TyphonEnabled;});
        StartButton.onClick.AddListener(delegate { StartCoroutine("HackingProcedure");});
        CancelButton.onClick.AddListener(delegate { ResetConsole = !ResetConsole;});
        ExitButton.onClick.AddListener(delegate { Exit(); });

        index = new List<int>();
        namefile = new List<string>();
        size = new List<float>();
    }

    void Start()
    {

        NearComputer = GameObject.FindGameObjectWithTag("ComputerTest");
        StatusLED = GameObject.FindGameObjectWithTag("StatusLED");
        hardrive = GameObject.FindGameObjectWithTag("MainComputer");
        hardrivesize = hardrive.GetComponent<HardDriveScript>().HardDriveCapacity;
        LEDMaterial = StatusLED.GetComponent<MeshRenderer>();
        isitrobot = NearComputer.GetComponent<ComputerSpecs>().ismobile;
        isithostile = NearComputer.GetComponent<ComputerSpecs>().ishostile;
        hacked = NearComputer.GetComponent<ComputerSpecs>().alreadyhacked;
        detectedfiles = NearComputer.GetComponent<ComputerSpecs>().files;
        LEDMaterial.material = OnLight;
    }

    void Exit()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }

    IEnumerator HackingProcedure()
    {
        if(NearComputer.GetComponent<ComputerSpecs>().BaudRate.ToString() != baudRate.text){

            BaudRateGuesser();
            ConsoleOutput.text = "<color=red>[!]</color> Bad Baud Rate or none given, trying to guess. \n    Using: " + Convert.ToString(BaudRateGuess) + "\n";
            
            yield return new WaitForSeconds(2);
            ConsoleOutput.text = "";

            yield return StartCoroutine("BadBaudRate");
            if(ResetConsole){
                ResetConsole = !ResetConsole;
                yield break;
            }
        }
        
        if(SerCrackModuleEnabled){
            yield return StartCoroutine("SerCrackMod");
        }


        if(HardProbeEnabled){
            yield return StartCoroutine("HardProbeMod");
        }


        if(HarrietHandEnabled){
            yield return StartCoroutine("HarrietHandMod");

        }


        if(BedoinFilesEnabled){
            yield return StartCoroutine("BedoinFilesMod");
        }


        if(TwoB58Enabled){
            yield return StartCoroutine("TwoB58Mod");
        }


        if(MorpheusEnabled){
            yield return StartCoroutine("MorpheusMod");
        }


        yield return null;
    }

    IEnumerator SerCrackMod()
    {
        if(hacked){
            ConsoleOutput.text = "<color=yellow>[*]</color> Machine Already Hacked!, logging in...";
            yield return new WaitForSeconds(5);
            yield break;
        }

        ConsoleOutput.text = "";
        //my dumb femboy brain cant work rn, heading to bed [11:53PM 8/3/22]
        bool cleanconsole;
        int[] possibletries;
        int possibletriesaccess = 0;
        cleanconsole = true;
        Neededtries = Random.Range(80, 200);

        possibletries = new int[] {13, 26, 39, 52, 65, 78, 91, 104, 117, 130, 143, 156, 169, 182, 192, 206};
        tries = 0;
        
        while (tries <= Neededtries){
            cleanconsole = true;
            ConsoleOutput.text +="<color=red>[!]</color> SerCrack Try No. "+ tries + " on " + SerialPort.text + " unsuccesful!\n";
            yield return new WaitForSeconds(1);
            

            if(tries == possibletries[possibletriesaccess] && cleanconsole == true){
                ConsoleOutput.text = "";
                cleanconsole = false;
                possibletriesaccess += 1;
            }


            tries += 1;
            
        }
        ConsoleOutput.text = "<color=green>[✓]</color> SerCrack Try No." + tries + " on " + SerialPort.text + " Succesful with \nPassword (idk), Logging In...";
        ConsoleOutput.text = ConsoleOutput.text + "\n<color=yellow>[*]</color> Logged In!";
        hacked = !hacked;
        yield return new WaitForSeconds(5);
        ConsoleOutput.text = "";
        tries = 0;


    }

    IEnumerator HardProbeMod()
    {
        if(hacked == false){
            ConsoleOutput.text = "<color=red>[!]</color> Login Required!";
            yield return new WaitForSeconds(2);
            yield break;
        }


        //This shit sucks, but im running on bad 5 hours of sleep and this is what i could come up with [11:45AM 8/5/2022]
        ConsoleOutput.text = "HardProbe Starting...";
        yield return new WaitForSeconds (5);
        ConsoleOutput.text += "\nHardware Detected!, Displaying\n";
        yield return new WaitForSeconds (5);
        ConsoleOutput.text += "CPU: " + NearComputer.GetComponent<ComputerSpecs>().CPU + "\n";
        ConsoleOutput.text += "GPU: " + NearComputer.GetComponent<ComputerSpecs>().GPU + "\n";
        ConsoleOutput.text += "Available RAM: " + NearComputer.GetComponent<ComputerSpecs>().RAMQuantity + "GB" +"\n";
        ConsoleOutput.text += "Available Storage: " + NearComputer.GetComponent<ComputerSpecs>().StorageQuantity + "TB" + "\n";
        ConsoleOutput.text += "Probing Finished";

        yield return new WaitForSeconds(10);
        ConsoleOutput.text = "";


    }

    IEnumerator HarrietHandMod()
    {
        if(hacked == false){
            ConsoleOutput.text = "<color=red>[!]</color> Login Required!";
            yield break;
        }


        //very proud of this shit ngl [12:53AM 8/6/2022]
        ConsoleOutput.text = "Starting Corutine...";

        if(isitrobot && isithostile){
            ConsoleOutput.text = "[*] Starting 0x" +  Convert.ToString(Random.Range(400, 900)) + " payload...";
            yield return new WaitForSeconds(5);

            ConsoleOutput.text += "\n Sending...";

            if(Random.value > 0.5f){
                ConsoleOutput.text += "\nPayload Succesful!, Machine Liberated!";
                isithostile = false;
            }

            else{
                ConsoleOutput.text += "\nPayload Failed!";
            }

        }

        else if(!isithostile){
            ConsoleOutput.text += "\nMachine Already Friendly!";
        }

        else if(!isitrobot){
            ConsoleOutput.text += "\nNot a movable machine! (Aka Computer/Server)";
        }

        yield return new WaitForSeconds(5);
    }

    IEnumerator BedoinFilesMod()
    {
        if(hacked == false){
            ConsoleOutput.text = "<color=red>[!]</color> Login Required!";
            yield break;
        }


        //My brain is mush again, brb in 8 hours [1:12AM 8/7/22]
        ConsoleOutput.text = "Extracting Useful Files...";
        ConsoleOutput.text += "\nFound " + Convert.ToString(detectedfiles.Length) + " Files";
        ConsoleOutput.text += "\nSaving to hard drive...";
        int i;
        i = 0;


        foreach(string filename in detectedfiles)
        {
            
            if(size.Sum() <= hardrivesize){
                size.Add(Random.Range(0.000488281f, 0.0009765625f));
                namefile.Add(detectedfiles[i]);
                
                i++;
            }
            
        }

        yield return new WaitForSeconds(5);

        totalsize = size.Sum();
        

        ConsoleOutput.text += "\nSaved " + String.Format("{0:0.##}",totalsize*1024)+ " MiB of data";
        hardrivesize -= totalsize;
        ConsoleOutput.text += "\nFree space available after transaction: " + Convert.ToString(hardrivesize) + " GiB";

        yield return new WaitForSeconds(5);

    }

    IEnumerator TwoB58Mod()
    {
        if(hacked == false){
            ConsoleOutput.text = "<color=red>[!]</color> Login Required!";
            yield break;
        }


        ConsoleOutput.text = "Sending Payload 0x" + Random.Range(635, 4095).ToString("X") + "...\n";
        if(Random.value > 0.5f){
            ConsoleOutput.text += "Payload Succesful!, Turning off...";
            yield return new WaitForSeconds(3);
            LEDMaterial.material = OffLight;
        }

        else{
            ConsoleOutput.text += "Payload Failed...";
        }

        yield return new WaitForSeconds(5);

    }

    IEnumerator MorpheusMod()
    {
        if(hacked == false){
            ConsoleOutput.text = "<color=red>[!]</color> Login Required!";
            yield break;
        }

        ConsoleOutput.text = "Sending Payload 0x" + Random.Range(635, 4095).ToString("X") + "...\n";
        if(Random.value > 0.5f){
            ConsoleOutput.text += "Payload Succesful!, Suspending...";
            yield return new WaitForSeconds(3);
            LEDMaterial.material = SuspendLight;
        }

        else{
            ConsoleOutput.text += "Payload Failed...";
        }

        yield return new WaitForSeconds(5);
    }

    IEnumerator BadBaudRate()
    {
        int repetitions = 20;
        int errors = 0;
        var allchars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890!|@·#$~%&¬/{([)]=}?\'¿¡¸ºª`^+*'-";
        var length = 50;

        var randomChars = new char[length];

        while (errors < repetitions){

            for(var i = 0; i < length; i++){
                randomChars[i] = allchars[Random.Range(0,allchars.Length)];
            }

            ConsoleOutput.text += new string(randomChars) + "\n";
            errors += 1;

            yield return new WaitForSeconds(1);

            if (ResetConsole){
                break;
            }
        }



        yield return null;
    }
    

}
