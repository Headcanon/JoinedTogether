using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject dedMenu;

    private PointManager pm;
    private SoundMaster sm;

    private void Start()
    {
        pm = GetComponent<PointManager>();
        sm = FindObjectOfType<SoundMaster>();
    }

    private bool ded;
    public void Die()
    {
        if (!ded)
        {
            ded = true;

            pm.playing = false;

            sm.PlayDamage();

            dedMenu.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            Restart();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
