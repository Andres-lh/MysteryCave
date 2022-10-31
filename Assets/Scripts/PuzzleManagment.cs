using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagment : MonoBehaviour
{
    [SerializeField] private List<ValidatePuzzle> validateZones;
    [SerializeField] private CamaraTransition cameraManager;
    [SerializeField] private TimeController timeController;
    [SerializeField] private List<Clue> clues;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject continueUI;
    private bool canValidate;
    public int[] solution = new int[3];
    public bool correct;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createSolution()
    {
        for(int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                solution[i] = Random.Range(1,7);
            }
            else
            {
                int aux = Random.Range(1, 7);
                for(int j = 0; j < 3; j++)
                {
                    if (aux == solution[j])
                    {
                        aux = 0;
                    }
                }
                if (aux == 0)
                {
                    i--;
                }
                else
                {
                    solution[i] = aux;
                }
            }
        }        
        for (int i= 0; i < 3; i++)
        {
            clues[i].ActivateClue(solution[i]);
        }
    }

    public void resetAll()
    {
        for (int i = 0; i < 3; i++)
        {
            clues[i].deactivateAll();
        }
    }

    public void checkSlots()
    {
        if (validateZones[0].value != 0 && validateZones[1].value != 0 && validateZones[2].value != 0)
        {
            canValidate = true;
            checkSolution();
        }
        else
        {
            canValidate = false;
        }
    }

    public void checkSolution()
    {
        if (canValidate)
        {
            if(validateZones[0].value == solution[0] && validateZones[1].value == solution[1] && validateZones[2].value == solution[2])
            {
                correct = true;
                cameraManager.DesativateWalls();
                timeController.shouldCountDown = false;
                audioSource.PlayOneShot(winSound, 1f);
                continueUI.SetActive(true);
                foreach(ValidatePuzzle v in validateZones)
                {
                    v.enabled = false;
                }
            }
            else
            {
                correct = false;
            }
        }
        
    }
}
