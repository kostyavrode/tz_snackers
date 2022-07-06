using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPartController : MonoBehaviour
{
    [SerializeField] private PlayerPart partPrefab;
    [SerializeField] private int partsLength;
    public List<GameObject> playerParts = new List<GameObject>();

    private void Start()
    {
        AddPlayerPart(partsLength);
    }
    public void AddPlayerPart(int count)
    {
        for (int i = 0; i < count - 1; i++)
        {
            GameObject newObj=Instantiate(partPrefab.gameObject, PlayerPartPosition(), Quaternion.identity, this.transform);
            playerParts.Add(newObj);
            ScaleChanger.NiceScaleChanging(newObj,0.5f);

        }
    }
    public void MultiplyPlayerPart(int count)
    {
        int temp = playerParts.Count * count - playerParts.Count;
        for (int i = 0; i < temp - 1; i++)
        {
            GameObject newObj=Instantiate(partPrefab.gameObject, PlayerPartPosition(), Quaternion.identity, this.transform);
            playerParts.Add(newObj);
        }
    }
    public void MinusPlayerPart(int count)
    {
        int temp = playerParts.Count-count;
        for (int i = 0; i < count; i++)
        {
            if (playerParts.Count > 0)
            {
                GameObject affectObject = playerParts[i].gameObject;
                playerParts.Remove(playerParts[i]);
                Destroy(affectObject);
            }
        }
    }
    public void RemovePart(GameObject playerPart)
    {
        Debug.Log("sgf");
        if (playerPart.TryGetComponent(out PlayerPart part))
            playerParts.Remove(playerPart);
        ScaleChanger.NiceScaleDecrease(playerPart);
        
    }
    private Vector3 PlayerPartPosition()
    {
        Vector3 pos = Random.insideUnitSphere*2f;
        pos.y = 0f;
        Vector3 newPos = transform.position + pos;
        return newPos;
    }
}
