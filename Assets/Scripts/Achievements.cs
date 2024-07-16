using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Achivements
{
    private string name;
    private int id;
    private bool completed;
    private string description;
    private Sprite image;

    public Achivements(string name, int id, bool completed, string description, Sprite image) {
        this.name = name;
        this.id = id;
        this.completed = completed;
        this.description = description;
        this.image = image;
    }

    public void SetName(string name) {
        this.name = name;
    }

    public string getName() {
        return name;
    }

    public void SetId(int id) {
        this.id = id;
    }

    public int getId() {
        return id;
    }

    public void SetCompleted(bool completed) {
        this.completed = completed;
    }

    public bool getCompleted() {
        return completed;
    }

    public void SetDescription(string description) {
        this.description = description;
    }

    public string getDescription() {
        return description;
    }

    public void SetImage(Sprite image) {
        this.image = image;
    }

    public Sprite getImage() {
        return image;
    }

    public override string ToString() {
        return "Name: " + name + " | ID: " + id + " | Completed: " + completed; 
    }

}
