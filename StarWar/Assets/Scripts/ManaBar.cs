using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private GameObject[] _mana = default;
    private int manaCompteur;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NbrMana(int nMana)
    {
        manaCompteur = nMana - 1;

    }
    public void GerardLaflaque()
    {
        Debug.Log(manaCompteur);
        _mana[manaCompteur].SetActive(false);

        manaCompteur--;
    }

    public void ajoutMana()
    {
        manaCompteur++;
        _mana[manaCompteur].SetActive(true);
    }
}
