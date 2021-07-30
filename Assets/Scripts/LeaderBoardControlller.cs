using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardController : MonoBehaviour {
    public string uid;
    public string score;

    public LeaderBoardController() {
    }

    public LeaderBoardController(string uid, string score) {
        this.uid = uid;
        this.score = score;
    }

    public Dictionary<string, string> ToDictionary() {
        Dictionary<string, string> result = new Dictionary<string, string>();
        result["uid"] = uid;
        result["score"] = score;

        return result;
    }
}
