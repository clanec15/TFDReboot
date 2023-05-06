using UnityEngine;
using Random = UnityEngine.Random;

public class ComputerSpecs : MonoBehaviour
{
    public string GPU, CPU, extension;
    public int RAMQuantity,BaudRate;
    public float StorageQuantity,datatransferrate;

    public string[] files, extensions, GPUs, CPUs;
    public int[] RAMsettings, BaudRatesFirst;
    public float[] StorageSettings;

    public bool ismobile, ishostile, alreadyhacked;

    public Material defaultMat;

    void randomextensiongenerator()
    {
        extensions = new string[] {".PeX", ".psf", ".cpb", ".txt", ".bin"};
        extension = extensions[Random.Range(0, extensions.Length)];
    }
    void Start()
    {
        GameObject.FindGameObjectWithTag("StatusLED").GetComponent<MeshRenderer>().material = defaultMat;

        
        GPUs = new string[] {"Rvidia HTX980", "Rvidia HTX1060", "Rvidia HTX 1070 Ti", "Rvidia HTX Atlas X", "Rvidia Tesla X200"};
        CPUs = new string[] {"Hintel Festel L6900", "Hintel y3 12200T", "Hintel y5 12400F", "Hintel y7 12700KF", "Hintel Argon 1390P", "EMD Praeminis 300U", "EMD Highzen 3 5500", "EMD Highzen 3 5500", "EMD Highzen 5 5700", "EMD Highzen 7 5900XD", "Emd Layi 7543"};
        RAMsettings = new int[] {8, 16, 32, 64, 128};
        StorageSettings = new float[] {0.5f, 1.0f, 2.0f, 4.0f, 8.0f, 16.0f, 32.0f};
        BaudRatesFirst = new int[] {110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200, 128000, 256000};

        GPU = GPUs[Random.Range(0, GPUs.Length)];
        CPU = CPUs[Random.Range(0, CPUs.Length)];
        RAMQuantity = RAMsettings[Random.Range(0,RAMsettings.Length)];
        StorageQuantity = StorageSettings[Random.Range(0,StorageSettings.Length)];
        BaudRate = BaudRatesFirst[Random.Range(0,BaudRatesFirst.Length)];

        datatransferrate = BaudRate/100;

        ismobile = Random.value > 0.5f;
        alreadyhacked = false;

        if(ismobile){
            ishostile = Random.value > 0.5f;
        }
        

        var allchars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";
        var length = 5;
        var randomChars = new char[length];
        int filescount = 50;
        int createdfiles = 0;

        files = new string[50];


        while (createdfiles < filescount){
            for(var i = 0; i < length; i++){
                randomChars[i] = allchars[Random.Range(0,allchars.Length)];    
            }

            randomextensiongenerator();

            files[createdfiles] = new string(randomChars) + extension;
            createdfiles += 1;
        }
    }
}
