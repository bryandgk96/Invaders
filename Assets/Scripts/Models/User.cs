using UnityEngine;
using UnityEngine.UIElements;

public class User : MonoBehaviour
{
    public string UserName;
    public string Score;
    

    public User()
    {
    }
    public User(string username, string _score)
    {
        this.UserName = username;
        this.Score = _score;
    }
}
