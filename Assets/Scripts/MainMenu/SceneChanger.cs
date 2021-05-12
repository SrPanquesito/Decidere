using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public void Scene1(){
        SceneManager.LoadScene("Escena de Prueba - Panque");
    }
}
