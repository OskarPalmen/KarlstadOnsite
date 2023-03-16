using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 25;
    public bool creatingSection = false;
    public int secNum;

    private List<GameObject> spawnedSections = new List<GameObject>(); // store references to spawned sections

    // Update is called once per frame
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 3);
        GameObject newSection = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        spawnedSections.Add(newSection); // add reference to spawned section to the list
        zPos += 25;
        yield return new WaitForSeconds(1);
        creatingSection = false;

        // destroy clones one at a time more quickly
        float delayTime = 3f; // decrease the delay time
        for (int i = 0; i < spawnedSections.Count; i++)
        {
            yield return new WaitForSeconds(delayTime); // wait for a shorter time before destroying the next clone
            Destroy(spawnedSections[i]);
        }
    }
}
