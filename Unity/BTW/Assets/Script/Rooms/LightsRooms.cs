using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.Universal;
using Random = System.Random;

public class LightsRooms : MonoBehaviour
{
    public string[] colours;
    private Random rand = new Random();
    public List<string> seq1, seq2, playerTry;
    public Light2D L1Ug, L1Db, L1Ly, L1Rr, L2Ug, L2Db, L2Ly, L2Rr;
    public GameObject start, but1, but2, but3, but4;
    public bool started,done;
    public int correct ;
    public GameObject door;
    
    
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        done = false;
        colours = new []{"blue", "yellow", "red", "green"};
        for (int i = 0; i < 4; i++)
        {
            seq1.Add(colours[rand.Next(0,4)]);
        }
        for (int i = 0; i < 8; i++)
        {
            seq2.Add(colours[rand.Next(0,4)]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        bool rightGuess = true;
        if (done)
        {
            if (correct == 0)
            {
                if (seq1.Count == playerTry.Count)
                {
                    for (int i = 0; i < playerTry.Count; i++)
                    {
                        if (seq1[i] != playerTry[i])
                            rightGuess = false;
                    }
                }
                else
                    rightGuess = false;

                if (rightGuess)
                {
                    correct++;
                    playerTry = new List<string>();
                    started = false;
                    done = false;
                }
                else
                {
                    started = false;
                    playerTry = new List<string>();
                    done = false;
                    rightGuess = true;
                }
            }
            else if (correct == 1)
            {
                if (seq2.Count == playerTry.Count)
                {
                    for (int i = 0; i < playerTry.Count; i++)
                    {
                        if (seq2[i] != playerTry[i])
                            rightGuess = false;
                    }
                }
                else
                    rightGuess = false;

                if (rightGuess)
                {
                    correct++;
                    playerTry = new List<string>();
                    started = false;
                    done = false;
                    door.SetActive(false);
                }
                else
                {
                    started = false;
                    playerTry = new List<string>();
                    done = false;
                }
            }
        }
    }

    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.IsTouching(start.GetComponent<Collider2D>()) && !started)
        {
            started = true;
            StartCoroutine(PlayColours());
        }
        else if (started)
        {
            if (col.IsTouching(but1.GetComponent<Collider2D>()))
            {
                playerTry.Add("red");
                Debug.Log("red");
            }
            else if (col.IsTouching(but2.GetComponent<Collider2D>()))
            {
                playerTry.Add("yellow");
                Debug.Log("yellow");
            }
            else if (col.IsTouching(but3.GetComponent<Collider2D>()))
            {
                playerTry.Add("blue");
                Debug.Log("blue");
            }
            else if (col.IsTouching(but4.GetComponent<Collider2D>()))
            {
                playerTry.Add("green");
                Debug.Log("green");
            }
            else if (col.IsTouching(start.GetComponent<Collider2D>()))
                done = true;
        }
    }

    IEnumerator PlayColours()
    {
        if (correct == 0)
        {
            foreach (var c in seq1)
            {
                if (c == "green")
                {
                    Debug.Log("green");
                    L1Ug.intensity = 1;
                    yield return new WaitForSeconds(1);
                    L1Ug.intensity = 0;
                    yield return new WaitForSeconds((float) 0.3);
                }
                else if (c == "blue")
                {
                    Debug.Log("blue");
                    L1Db.intensity = 1;
                    yield return new WaitForSeconds(1);
                    L1Db.intensity = 0;
                    yield return new WaitForSeconds((float) 0.3);
                }
                else if (c == "yellow")
                {
                    Debug.Log("yellow");
                    L1Ly.intensity = 1;
                    yield return new WaitForSeconds(1);
                    L1Ly.intensity = 0;
                    yield return new WaitForSeconds((float) 0.3);
                }
                else if (c == "red")
                {
                    Debug.Log("red");
                    L1Rr.intensity = 1;
                    yield return new WaitForSeconds(1);
                    L1Rr.intensity = 0;
                    yield return new WaitForSeconds((float) 0.3);
                }
            }
            yield return new WaitForSeconds(5);
        }
        else if (correct == 1)
        {
            foreach (var c in seq2)
            {
                if (c == "green")
                {
                    L2Ug.intensity = 1;
                    yield return new WaitForSeconds((float) 0.7);
                    L2Ug.intensity = 0;
                    yield return new WaitForSeconds((float) 0.3);
                }
                else if (c == "blue")
                {
                    L2Db.intensity = 1;
                    yield return new WaitForSeconds((float) 0.7);
                    L2Db.intensity = 0;
                    yield return new WaitForSeconds((float) 0.3);
                }
                else if (c == "yellow")
                {
                    L2Ly.intensity = 1;
                    yield return new WaitForSeconds((float) 0.7);
                    L2Ly.intensity = 0;
                    yield return new WaitForSeconds((float) 0.3);
                }
                else if (c == "red")
                {
                    L2Rr.intensity = 1;
                    yield return new WaitForSeconds((float) 0.7);
                    L2Rr.intensity = 0;
                    yield return new WaitForSeconds((float) 0.3);
                }
                
            }
            yield return new WaitForSeconds(4);
        }
        else if (correct == 2)
        {
            L2Ug.intensity = 1;
            L2Db.intensity = 1;
            L2Ly.intensity = 1;
            L2Rr.intensity = 1;
            yield return new WaitForSeconds(1);
            L2Ug.intensity = 0;
            L2Db.intensity = 0;
            L2Ly.intensity = 0;
            L2Rr.intensity = 0;
            yield return new WaitForSeconds(1);
            L2Ug.intensity = 1;
            L2Db.intensity = 1;
            L2Ly.intensity = 1;
            L2Rr.intensity = 1;
            yield return new WaitForSeconds(1);
            L2Ug.intensity = 0;
            L2Db.intensity = 0;
            L2Ly.intensity = 0;
            L2Rr.intensity = 0;
            yield return new WaitForSeconds(1);
            L2Ug.intensity = 1;
            L2Db.intensity = 1;
            L2Ly.intensity = 1;
            L2Rr.intensity = 1;
            yield return new WaitForSeconds(1);
            L2Ug.intensity = 0;
            L2Db.intensity = 0;
            L2Ly.intensity = 0;
            L2Rr.intensity = 0;
            
        }
    }
}
