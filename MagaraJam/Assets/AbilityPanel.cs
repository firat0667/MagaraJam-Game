using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPanel : MonoBehaviour
{
    [SerializeField] GameObject LevelUpPanel;
    [SerializeField] Transform[] augment_positions;
    [SerializeField] GameObject[] Augments;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0)){
            openPanel();

        }
        else if (Input.GetKeyDown(KeyCode.Escape)){
            ClosePanel();
        }
    }

    public void openPanel()
    {
        Time.timeScale = 0;
       
        LevelUpPanel.SetActive(true);
        idenitfyAugments();
    }
    public void ClosePanel()
    {
        Time.timeScale = 1;
        LevelUpPanel.SetActive(false);
    }
    void idenitfyAugments()
    {
        int a0 = Random.Range(0, Augments.Length);
        int a1 = Random.Range(0, Augments.Length);
       
        GameObject augment0 = Instantiate(Augments[a0], augment_positions[0]);
        GameObject augment1 = Instantiate(Augments[a1], augment_positions[1]);
        
    }
}
