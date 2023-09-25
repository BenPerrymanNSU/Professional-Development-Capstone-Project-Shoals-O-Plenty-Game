using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishKeyMover : MonoBehaviour
{
    private static int numberOfKeys = 10;
    private GameObject[] fishKeys = new GameObject[numberOfKeys];
    public Vector3[] fishKeyLocations = new [] {
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
    public float goodFish = 0.50f;
    public int countGoodFish = 0;
    public float badFish = 0.50f;
    public int countBadFish = 0;
    public int minimumGoodFish = 10;
    public bool minimumGoodFishCleared = false;

    public void placeFishTokens()
    {
        Debug.Log("Started");
       for (int i = 0; i < numberOfKeys; i++){
            Key = GameObject.Find("FishKey" + i.ToString());
            fishKeys[i] = Key;
            var randSlot = Random.Range(1, 4);
            //Debug.Log("Slot: " + randSlot);
            for (int j = 1; j < 4; j++){
                if(j == randSlot && minimumGoodFish > 0 && minimumGoodFishCleared == false){
                    fishKeys[i].transform.GetChild(j).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    fishKeys[i].transform.GetChild(j).gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).GetComponent<Collider>().enabled = true;
                    fishKeys[i].transform.GetChild(j).gameObject.transform.GetChild(2).gameObject.SetActive(false);
                    minimumGoodFish--;
                    countGoodFish++;
                    Debug.Log("Did a Min " + j +" " + minimumGoodFish);
                    minimumGoodFishCleared = true;
                }
                else if(Random.value <= goodFish){
                    fishKeys[i].transform.GetChild(j).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    fishKeys[i].transform.GetChild(j).gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).GetComponent<Collider>().enabled = true;
                    fishKeys[i].transform.GetChild(j).gameObject.transform.GetChild(2).gameObject.SetActive(false);
                    countGoodFish++;
                }
                else if(Random.value <= badFish){
                    fishKeys[i].transform.GetChild(j).gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    fishKeys[i].transform.GetChild(j).gameObject.transform.GetChild(2).gameObject.transform.GetChild(6).GetComponent<Collider>().enabled = true;
                    fishKeys[i].transform.GetChild(j).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    countBadFish++;
                }
                else{
                    fishKeys[i].transform.GetChild(j).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    fishKeys[i].transform.GetChild(j).gameObject.transform.GetChild(2).gameObject.SetActive(false);
                }
            }
            minimumGoodFishCleared = false;
       }
       /*
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
       */
       Debug.Log("Good: " + countGoodFish);
       Debug.Log("Bad: " + countBadFish);
    }
}
