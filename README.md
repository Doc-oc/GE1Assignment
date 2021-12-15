# Asteroid Shooter

Name: Dylan O'Connor

Student Number: C18444694

Class Group: TU857 / DT211C

# Description of the project

My project is an endless runner action game. This mean that it is a game with a linear design that has no end. My game has a space theme, so you are playing as a spaceship shooting asteroids that come your way. The further you move in the game the asteroids speed will slowly increase and at some point more than one asteroid spawns at the same time. You gain points by staying alive and by shooting the asteroids.

# Instructions for use
You will be presented with a menu before you begin. There is only 1 option which is to play, Once you hit play the game will begin. You can move the spaceship using WASD or using the arrow keys. Each key has the same amount of speed. To shoot an on coming asteroid you can tap the space key that will fire a bullet towards the asteroid. You can press the R key to restart the game, this will not bring you to the home screen. Code snippet of player Movement here.

# How it work

The Aim of the game is to shoot or avoid as many asteroids as possible. Once the game starts the spaceship will spawn along with one asteroid slowly coming towards you. The game starts off easy so that the user can get use to it. 
So lets start with the scoring system. Using a Coroutine in C# i added that Every 2 seconds that you stay alive +10 will be added to your score. If you shoot an asteroid you will get another +10. To encourage the user to move forward I have also added +10 once you press down the UpArrow key, Otherwise the user would just move side to side.
```C#

    void Start(){
        //StartCoroutine to add score every 2 seconds
        StartCoroutine(ScoreUpdate());

        //If target object is not attached to Score, Find it
        target = FindObjectOfType<Target>();
    }

    //Function to calculate hitting a target
    public void TargetScore(){
        score.text = (scoreText += 10).ToString();
    }

    //Function to calculate moving forward
    public void MoveScore(){
        score.text = (scoreText += 10).ToString();
    }

    //Coroutine
    IEnumerator ScoreUpdate()
    {
        //Wait two seconds
        yield return new WaitForSeconds(2);
        score.text = (scoreText += 10).ToString(); //adding 10 to score every 2 seconds
      
```

# List of classes/assets in the project and whether made yourself or modified or if its from a source, please give the reference

| Class/asset | Source |
|-----------|-----------|
| MyClass.cs | Self written |
| MyClass1.cs | Modified from [reference]() |
| MyClass2.cs | From [reference]() |

# References

# What I am most proud of in the assignment

# Proposal submitted earlier can go here:

## This is how to markdown text:

This is *emphasis*

This is a bulleted list

- Item
- Item

This is a numbered list

1. Item
1. Item

This is a [hyperlink](http://bryanduggan.org)

# Headings
## Headings
#### Headings
##### Headings

This is code:

```Java
public void render()
{
	ui.noFill();
	ui.stroke(255);
	ui.rect(x, y, width, height);
	ui.textAlign(PApplet.CENTER, PApplet.CENTER);
	ui.text(text, x + width * 0.5f, y + height * 0.5f);
}
```

So is this without specifying the language:

```
public void render()
{
	ui.noFill();
	ui.stroke(255);
	ui.rect(x, y, width, height);
	ui.textAlign(PApplet.CENTER, PApplet.CENTER);
	ui.text(text, x + width * 0.5f, y + height * 0.5f);
}
```

This is an image using a relative URL:

![An image](images/p8.png)

This is an image using an absolute URL:

![A different image](https://bryanduggandotorg.files.wordpress.com/2019/02/infinite-forms-00045.png?w=595&h=&zoom=2)

This is a youtube video:

[![YouTube](http://img.youtube.com/vi/J2kHSSFA4NU/0.jpg)](https://www.youtube.com/watch?v=J2kHSSFA4NU)

This is a table:

| Heading 1 | Heading 2 |
|-----------|-----------|
|Some stuff | Some more stuff in this column |
|Some stuff | Some more stuff in this column |
|Some stuff | Some more stuff in this column |
|Some stuff | Some more stuff in this column |

