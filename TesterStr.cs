using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TesterStr : MonoBehaviour
{
    [SerializeField] private Text text;
    private StringPolymorph m_stringPoly;
    private string m_testString;
    void Start()
    {
        m_stringPoly = new StringPolymorph(text);
        StartCoroutine(TestCorout());
    }

    private IEnumerator TestCorout()
    {
        System.Random rnd = new System.Random();
        var val = rnd.Next(100000, 999999);
        m_testString = val.ToString();
        
        yield return new WaitForSeconds(1f);

        while (true)
        {
            val = rnd.Next(0, 1234567);
            m_stringPoly.ChangeString(ref m_testString, val);
            yield return new WaitForSeconds(1f);
        }
    }
}
