using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuGUI : MonoBehaviour
{
    // Start is called before the first frame update


   public void loadGame1()
    {
        SceneManager.LoadScene("ecena1");
    }
    public void loadGame2()
    {
        SceneManager.LoadScene("ecena2");
    }
    public void loadGame3()
    {
        SceneManager.LoadScene("ecena3");
    }
}
