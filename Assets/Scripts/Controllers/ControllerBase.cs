using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBase : MonoBehaviour
{
    
    public float moveSpeed;
    
    protected CharacterBase character;

    protected GameManager gameManager;
    
    // Start is called before the first frame update
    protected void Start()
    {
        character = GetComponent<CharacterBase>();
        gameManager = GameObject.Find("_Managers").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
