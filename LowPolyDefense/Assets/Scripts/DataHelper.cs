using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DataHelper : MonoBehaviour {

    public static DataHelper instance;

    public Canvas currentCanvas;
    public GameObject dataNotification;
    public GameObject dataNotificationResponse;
    public EventSystem eventSystem;
    private Transform currentNotification;

    public float widthPercent, heightPercent, xPositionsPercent;

    private void Awake()
	{
        instance = this;
	}
		
	private void Start()
	{
	
	}

	private void Update()
	{
	
	}

    public void ShowData(string data)
    {
        GameObject newDataNotificaiton = Instantiate(dataNotification, currentCanvas.transform) as GameObject;
        newDataNotificaiton.GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width * widthPercent, Screen.height * heightPercent);
        newDataNotificaiton.GetComponent<RectTransform>().position = new Vector3(Screen.width * 0.5f * xPositionsPercent, currentCanvas.transform.position.y, currentCanvas.transform.position.z);
        newDataNotificaiton.GetComponent<RectTransform>().localScale = Vector3.one;
        newDataNotificaiton.GetComponentInChildren<Text>().text = data;
        currentNotification = newDataNotificaiton.transform;
    }

    public void ShowDataWithResponse(string data, Action comfirmAction, Action cancelAction)
    {
        GameObject newDataNotificationResponse = Instantiate(dataNotificationResponse, currentCanvas.transform) as GameObject;
        newDataNotificationResponse.GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width * widthPercent, Screen.height * heightPercent);
        newDataNotificationResponse.GetComponent<RectTransform>().position = new Vector3(Screen.width * 0.5f * xPositionsPercent, currentCanvas.transform.position.y, currentCanvas.transform.position.z);
        newDataNotificationResponse.GetComponent<RectTransform>().localScale = Vector3.one;
        newDataNotificationResponse.GetComponentInChildren<Text>().text = data;
        GameObject acceptButton = newDataNotificationResponse.transform.GetChild(0).gameObject;
        GameObject cancelButton = newDataNotificationResponse.transform.GetChild(1).gameObject;

        currentNotification = newDataNotificationResponse.transform;

        StartCoroutine(CheckForResponse(acceptButton, cancelButton, comfirmAction, cancelAction));
    }

    private IEnumerator CheckForResponse(GameObject acceptButton, GameObject cancelButton, Action comfirmAction, Action cancelAction)
    {
        while (eventSystem.currentSelectedGameObject != acceptButton && eventSystem.currentSelectedGameObject != cancelButton)
        {
            Debug.Log(eventSystem.currentSelectedGameObject);
            yield return new WaitForSeconds(0.1f);
        }

        if (eventSystem.currentSelectedGameObject == acceptButton)
        {
            if (comfirmAction != null)
            {
                comfirmAction.Invoke();
            }
            else
            {
                Debug.Log("Trying to close from comfirm button");
            }
        }
        if (eventSystem.currentSelectedGameObject == cancelButton)
        {
            if (cancelAction != null)
            {
                cancelAction.Invoke();
            }
            else
            {
                Debug.Log("Trying to close from cancel button");
            }
        }
        yield break;
    }

    public void CloseCurrentData()
    {
        Destroy(currentNotification);
    }

}