using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteMenu : MonoBehaviour
{
    public GameObject Center; 
    public GameObject EmoteBubblePrefab;
    public IKAnimationDatabank iKAnimationDataBase;
    public PlayersManager playersManager;
    private int SelectionIndex = -1;
    private Dictionary<int, Transform> SpawnOrderDictionary = new Dictionary<int, Transform>();
    private Camera camera;
    private List<EmoteBubbleButton> currentEmotes = new List<EmoteBubbleButton>();
    private EmoteBubbleButton selectedEmote;

    public void Init()
    {
        EmoteButtonSpawn[] spawnPoints = GetComponentsInChildren<EmoteButtonSpawn>();
        foreach(EmoteButtonSpawn emoteButtonSpawn in spawnPoints)
        {
            SpawnOrderDictionary.Add(emoteButtonSpawn.spawnOrder, emoteButtonSpawn.transform);
        }
        Center.SetActive(false);
        camera = Camera.main;
    }

    public void OpenEmoteMenu(EmotionManager emotionManager)
    {
        if(Center.activeSelf) return;

        var emotes = emotionManager.GetCurrentMoodEmotes();
        for(int i = 0; i< emotes.Count; i++)
        {

            GameObject button = Instantiate(EmoteBubblePrefab, SpawnOrderDictionary[i+1].transform);
            button.transform.localPosition = Vector3.zero;
            EmoteBubbleButton emoteBubble = button.GetComponent<EmoteBubbleButton>();
            emoteBubble.SetUp(emotes[i]);
            currentEmotes.Add(emoteBubble);
        }
        Center.SetActive(true);
    }

    public void CloseEmoteMenu()
    {
        if(!Center.activeSelf) return;
        if(selectedEmote)
        {
            Play();
        }
        foreach(var button in currentEmotes)
        {
            Destroy(button.transform.gameObject);
        }
        currentEmotes.Clear();
        selectedEmote = null;
        Center.SetActive(false);
    }

    private void Play()
    {
        IKAnimation animation = iKAnimationDataBase.GetAnimation(selectedEmote.id);
        playersManager.GetActivePlayer().iKAnimationManager.PlayEmote(animation);
    }

    public void Run(Transform headAnchor)
    {
        if(!Center.activeSelf) return; 
        Vector3 destination = camera.WorldToScreenPoint(headAnchor.position);
        Center.transform.position = destination; 

        if(!IsMovingRS())
        {
            foreach(var emote in currentEmotes)
            {
                emote.Normal();
            }
            return;
        } 
       
        Vector3 direction = new Vector3(Input.GetAxis("RS_Horizontal"), Input.GetAxis("RS_Vertical"),0);
        Vector3 inputPoint = camera.WorldToScreenPoint(headAnchor.position + (direction * .5f));

        Debug.DrawLine(headAnchor.position, headAnchor.position + (direction * .5f), Color.red, 1);

        GameObject ui = UIManager.Instance.GetUiObject(inputPoint);
        if(ui && ui.tag == Consts.TAG_EMOTE_BUTTON)
        {
            selectedEmote = ui.GetComponent<EmoteBubbleButton>();
        }
       
        if(selectedEmote && !selectedEmote.IsHovered())
        {
            foreach(var emote in currentEmotes)
            {
                if(emote != selectedEmote)
                {
                    emote.Normal();
                }
                else
                {
                    emote.Hover();
                }
            }
        }
    }

    public bool IsMovingRS()
    {
        return (Input.GetAxis("RS_Horizontal") != 0 || Input.GetAxis("RS_Vertical") != 0);
    }
}
