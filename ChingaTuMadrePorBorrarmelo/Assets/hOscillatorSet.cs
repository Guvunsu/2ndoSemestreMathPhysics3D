using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hOscillatorSet : MonoBehaviour
{
    public GameObject hOcillatorPrefab;
    public int hOscillatorNum;
    void Start()
    {
        for (int i = 0; i < hOscillatorNum; i++)
        {
            GameObject hOscilltor = Instantiate(hOcillatorPrefab, transform.Find("Chain"));
            hOscilltor.GetComponent<HarmonicOscilator>().lenght = 1;
            hOscilltor.GetComponent<HarmonicOscilator>().amplitud = 0.5f;
            hOscilltor.GetComponent<HarmonicOscilator>().frequency = 2;

            float phase = i * 2 * Mathf.PI / hOscillatorNum;
            hOscilltor.GetComponent<HarmonicOscilator>().phase = phase;
            hOscilltor.transform.localPosition = new Vector3(i, 0, 0);
        }
        for (int i = 0; i < hOscillatorNum; i++)
            for (int j = 0; j < hOscillatorNum; j++)
            {
                GameObject hOscillator = Instantiate(hOcillatorPrefab, transform.Find("Membrane"));
                hOscillator.GetComponent<HarmonicOscilator>().lenght = 1;
                hOscillator.GetComponent<HarmonicOscilator>().amplitud = 0.5f;
                hOscillator.GetComponent<HarmonicOscilator>().frequency = 2;

                float phase = (i + j) * 2 * Mathf.PI / hOscillatorNum;
                hOscillator.GetComponent<HarmonicOscilator>().phase = phase;
                hOscillator.transform.localPosition = new Vector3(i, 0, j);
            }

        transform.Find("Chain").gameObject.SetActive(false);
        transform.Find("Membrane").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
