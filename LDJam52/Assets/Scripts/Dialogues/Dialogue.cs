using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public Image image;

    public GameObject inputField;

    private int input = 2;

    private int index;

    private bool cont;

    private Color initCol;

    public GameObject player;
    public GameObject UICanvas;
    public GameObject InventoryCanvas;
    public GameObject MoneyCanvas;
    public GameObject GeneralUI;

    public List<AudioClip> clips = new List<AudioClip>();

    AudioSource source;

    public bool playOnAwake = false;

    bool Talk;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        inputField.GetComponent<TMP_InputField>().onEndEdit.AddListener(delegate { EndInput(inputField.GetComponent<TMP_InputField>()); });

        initCol = image.color;
        image.color = Color.black;

        source = GetComponent<AudioSource>();
        source.volume = 0.7f;

        inputField.SetActive(false);
        StartDialogue();
    }

    void OnStepDialogue()
    {
        TryPlaySound();

        if (index > 1)
        {
            image.color = initCol;
        }

        if (index == input)
        {
            inputField.SetActive(true);
            if (cont)
            {
                inputField.SetActive(false);
                NextLine();
            }
        }
        else
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    void EndInput(TMP_InputField inputField)
    {
        if (inputField.text.Length > 0)
        {
            Debug.Log("Text has been entered");
            cont = true;
        }
        else if (inputField.text.Length == 0)
        {
            Debug.Log("Main Input Empty");
            cont = false;
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            player.SetActive(true);
            UICanvas.SetActive(true);
            InventoryCanvas.SetActive(true);
            MoneyCanvas.SetActive(true);
            GeneralUI.SetActive(true);
            GameManager.Instance.gameState = GameState.Default;
            gameObject.SetActive(false);
        }
    }

    void TryPlaySound()
    {
        if (playOnAwake && Talk)
        {
            RandomPhrase();
        }
        else
        {
            Talk = true;
        }
    }

    public void RandomPhrase()
    {
        if (source.isPlaying)
        {
            source.Stop();
        }
        int index = Random.Range(0, clips.Count);
        source.PlayOneShot(clips[index]);
    }
}
