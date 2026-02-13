using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunction : MonoBehaviour
{
    public void Weapon()
    {
        SceneManager.LoadScene("Weapon", LoadSceneMode.Additive);
    }
    public void Secondary()
    {
        SceneManager.LoadScene("Secondary", LoadSceneMode.Additive);
    }
    public void Consumables()
    {
        SceneManager.LoadScene("Consumables", LoadSceneMode.Additive);
    }
    public void Helmet()
    {
        SceneManager.LoadScene("Helmet", LoadSceneMode.Additive);
    }
    public void Armor()
    {
        SceneManager.LoadScene("Armor", LoadSceneMode.Additive);
    }
    public void Greaves()
    {
        SceneManager.LoadScene("Greaves", LoadSceneMode.Additive);
    }
    public void Exit()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
