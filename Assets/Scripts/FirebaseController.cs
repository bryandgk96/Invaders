using System.Collections.Generic;
using Firebase;

using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

// ReSharper disable All

public class FirebaseController : MonoBehaviour
{
    private DatabaseReference _databaseReference;
    [SerializeField] private InputField username;
    
    
    void Start()
    {
        _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SaveData(string user_ID)
    {
        User user = new User();
        
        user.UserName = username.text;
        user.Score = "0";
        string json = JsonUtility.ToJson(user);

        _databaseReference.Child("Users").Child(user_ID).SetRawJsonValueAsync(json).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Se añadio usuario satisfactoriamente");
                Debug.Log(user.UserName);
            }
            else
            {
                Debug.Log("No se añadio al usuario");
            }
        });
    }
    
    private void NuevoScore(string userId, string score) {
        
        string key = _databaseReference.Child("scores").Push().Key;
        LeaderBoardController entry = new LeaderBoardController(userId, score);
        Dictionary<string, string> entryValues = entry.ToDictionary();

        Dictionary<string, string> childUpdates = new Dictionary<string, string>();
        childUpdates["/scores/" + key] = entryValues.ToString();
        childUpdates["/user-scores/" + userId + "/" + key] = entryValues.ToString();

        //_databaseReference.UpdateChildrenAsync(childUpdates);
    }
    
    void Update()
    {
        
    }
}
