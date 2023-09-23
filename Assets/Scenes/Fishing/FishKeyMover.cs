using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishKeyMover : MonoBehaviour
{
    private static int numberOfKeys = 10;
    public int keyCounter = 0;
    private GameObject[] fishKeys = new GameObject[numberOfKeys];
    private Vector3[] fishKeyLocations = new [] {
    new Vector3(4.92000008f,0.103000164f,4.01400042f),
    new Vector3(5.07999992f,0.103000164f,4.01400042f),
    new Vector3(5.23999977f,0.103000164f,4.01400042f),
    new Vector3(5.39999962f,0.103000164f,4.01400042f),
    new Vector3(5.55999994f,0.103000164f,4.01400042f),
    new Vector3(5.55999994f,-0.0499999598f,4.36000013f),
    new Vector3(5.39999962f,-0.0499999598f,4.36000013f),
    new Vector3(5.23999977f,-0.0499999598f,4.36000013f),
    new Vector3(5.07999992f,-0.0499999598f,4.36000013f),
    new Vector3(4.92000008f,-0.0500000007f,4.36000013f),
    new Vector3(4.76000008f,0.103000164f,4.01400042f)
    };
    private GameObject Key;
    public bool FishingActive = true;

    void Start()
    {
        var goodFish = 0.40f;
        var badFish = 0.40f;

       for (int i = 0; i < numberOfKeys; i++){
        Key = GameObject.Find("FishKey" + i.ToString());
        fishKeys[i] = Key;
        for (int j = 1; j < 4; j++){
            if(Random.value < goodFish){
                fishKeys[i].transform.GetChild(j).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if(Random.value < badFish){
                fishKeys[i].transform.GetChild(j).gameObject.transform.GetChild(2).gameObject.SetActive(true);
            }
            else{
                fishKeys[i].transform.GetChild(j).gameObject.SetActive(true);
            }
        }
        
       }
       fishKeys[0].transform.position = fishKeyLocations[0];
       fishKeys[1].transform.position = fishKeyLocations[1];
       fishKeys[2].transform.position = fishKeyLocations[2];
       fishKeys[3].transform.position = fishKeyLocations[3];
       fishKeys[4].transform.position = fishKeyLocations[4];
       fishKeys[5].transform.position = fishKeyLocations[5];
       fishKeys[6].transform.position = fishKeyLocations[6];
       fishKeys[7].transform.position = fishKeyLocations[7];
       fishKeys[8].transform.position = fishKeyLocations[8];
       fishKeys[9].transform.position = fishKeyLocations[9];
    }
    /*
    void Update()
    {
        while(FishingActive == true){
            StartCoroutine(FishKeyMove());
            FishingActive = false;
        }
    }

    public IEnumerator FishKeyMove(){
        fishKeys[0].transform.position = fishKeyLocations[10];
        keyCounter++;
        yield return new WaitForSeconds(1f);
        fishKeys[1].transform.position = fishKeyLocations[0];
        keyCounter++;
        yield return new WaitForSeconds(1f);
        fishKeys[2].transform.position = fishKeyLocations[1];
        keyCounter++;
        yield return new WaitForSeconds(1f);
        fishKeys[3].transform.position = fishKeyLocations[2];
        keyCounter++;
        yield return new WaitForSeconds(1f);
        fishKeys[4].transform.position = fishKeyLocations[3];
        keyCounter++;
        yield return new WaitForSeconds(1f);
        fishKeys[5].transform.position = fishKeyLocations[4];
        keyCounter++;
        yield return new WaitForSeconds(1f);
        fishKeys[6].transform.position = fishKeyLocations[5];
        keyCounter++;
        yield return new WaitForSeconds(1f);
        fishKeys[7].transform.position = fishKeyLocations[6];
        keyCounter++;
        yield return new WaitForSeconds(1f);
        fishKeys[8].transform.position = fishKeyLocations[7];
        keyCounter++;
        yield return new WaitForSeconds(1f);
        fishKeys[9].transform.position = fishKeyLocations[8];
        keyCounter++;
        yield return new WaitForSeconds(1f);
        if (keyCounter == 10){
            FishingActive = true;
            keyCounter = 0;
            Debug.Log("happen");
        }
        else{
            Debug.Log("how did this happen");
        }
    }
    */
}
