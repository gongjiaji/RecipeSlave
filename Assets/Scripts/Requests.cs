using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requests{
    public string name;
    public string id;
    public string description;
    public string[] rewards;

    public Requests(string[] content, string[] rewards) {
        name = content[0];
        id = content[1];
        description = content[2];
        this.rewards = rewards;
    }
}
