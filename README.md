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
So lets start with the scoring system. Using a Coroutine in C# I added that Every 2 seconds that you stay alive +10 will be added to your score. If you shoot an asteroid you will get another +10. To encourage the user to move forward I have also added +10 to be added to your score once you press down the UpArrow key, Otherwise the user would just move side to side. I added a highscore so that the user has something to beat everytime they play.
```C#
    void Start(){
        highscoreText = PlayerPrefs.GetInt(highscoreKey, 0); 
        highscore.text = "Highscore: " + highscoreText;   
        //If target object is not attached to Score, Find it
        target = FindObjectOfType<Target>();
    }

    void Update(){
        //adding highscore
        if (highscoreText < scoreText) {
            //Puts score into the highscore key
            PlayerPrefs.SetInt(highscoreKey, scoreText);
            //Saves the keys
            PlayerPrefs.Save();
        }
    }

    //Function to calculate hitting a target
    public void TargetScore(){
        score.text = (scoreText = scoreText + 10).ToString();
    }

    //Function to calculate moving forward
    public void MoveScore(){
        score.text = (scoreText = scoreText + 10).ToString();
    }

    //Coroutine
    IEnumerator ScoreUpdate()
    {
        //Wait two seconds
        yield return new WaitForSeconds(2);
        score.text = (scoreText = scoreText + 10).ToString(); //adding 10 to score every 2 seconds
    }
```
Asteroids have a health of 20. When the user shoots them with the spaceship they lose a health of -10. So it takes 3 shots to destroy an asteroid. The spaceship will send out a raycast that will then spawn a line renderer once it hits an object. This line renderer is the bullettrail effect so the user can see the bullet hitting the asteroid. The spaceship has a crosshair so that you can use it to aim at the asteroid. Asteroids spawn in 3 random locations across the terrian. They always have the same y value but the x and z vary. Asteroids have a script attached to them that moves them towards the the player at a certain speed. That speed will slowly increase once another one has spawned. This is aimed to make the game slightly more difficult as you progress. Once the player gets too a new hundred two targets will spawn
Heres a code snippet of how the raycast was made
```C#
void Shoot(){
        //Declaring Raycast
        RaycastHit hit;

        //Sending a raycast in the direction of spaceship at a certain range
        if(Physics.Raycast(fpsGun.transform.position, fpsGun.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

            //Setting the target as the hit component
            Target target = hit.transform.GetComponent<Target>();

            //If we have hit a target take damage
            if(target != null){
                target.TakeDamage(damage);
            }

            //Spawning Trail
            SpawnVoidTrail(hit.point);
        }
    }

```
For sound I have space rps game themed music which plays all throughout the game in a loop. I also have a gun shooting effect that you can here once you press the space key.

To give the game the endless runner effect I needed to create an infinite road. To do this I had to use a empty game object that contains 3 road prefabs. These 3 road prefab will spawn once the game begins. When the player progresses and moves onto the next road , the previous road will be destroyed and another road prefab will be added on. This means we are recycling roads and destroying the old ones so it doesnt take up alot of memory in run time. There is two empty game objects with bix colliders either side of the road so that the user can not vary from the road, this is set so the user has to stay within the boundaries.
Code snippet of creating a road
```C#
 // Update is called once per frame
    void Update()
    {
        //If player is at a certain point spawn another road, give the endless runner effect
        if(playerTransform.position.z -35>zSpawn-(numOfRoads*roadLength)){
            SpawnRoad(Random.Range(0, roadPrefabs.Length));
            DeleteRoad();
        }
    }

    public void SpawnRoad(int roadIndex){
        //Create new game object (road) based on the z position of previous
        GameObject gObj = Instantiate(roadPrefabs[roadIndex], transform.forward * zSpawn, transform.rotation );
        activeRoad.Add(gObj);
        zSpawn += roadLength;
    }

    //Deleting put of scene Roads
    private void DeleteRoad(){
        Destroy(activeRoad[0]);
        activeRoad.RemoveAt(0);
    }
```
Screenshot of Before Game Menu:
<img width="869" alt="Screenshot 2021-12-15 at 11 28 46" src="https://user-images.githubusercontent.com/61470071/146178683-787ec575-e258-4cc9-8b8f-a780ce0ad786.png">

Screenshot of Player in Game:

<img width="869" alt="Screenshot 2021-12-15 at 11 28 09" src="https://user-images.githubusercontent.com/61470071/146178678-8aa69b29-42df-49ff-ad6a-dbb5ed53a8fd.png">

While in game the user can also press the letter "R" to restart the game.

# List of classes/assets in the project and whether made yourself or modified or if its from a source, please give the reference

| Class/asset | Source |
|-----------|-----------|
| CameriaController.cs | Self written |
| GunController.cs | Modified from [Brackeys YT Channel](https://www.youtube.com/channel/UCYbK_tjZ2OrIZFBvU6CCMiA) |
| ObstacleController.cs | Self written |
| PlayerController.cs | Self written |
| RoadManager.cs | Modified from [Youtube](https://www.youtube.com/watch?v=6Y0U8GHiuBA)|
| Score.cs | Self Written using Lecture notes|
| RoadManager.cs | Modified from [Youtube](https://www.youtube.com/watch?v=6Y0U8GHiuBA)|
| Target.cs | Modified from [Unity Docs](https://docs.unity3d.com/Manual/index.html)|
| TargetSpawn.cs |Self Written|
| Spaceship Asset |Self Written|
| Target (Asteroid) |Self Written, Material From Asset store|
| Roads |Self Written|

# References

[Unity Docs](https://docs.unity3d.com/Manual/index.html)
[Bryan Duggan](https://github.com/skooter500/GE1-2021-2022)
[Brackeys](https://www.youtube.com/channel/UCYbK_tjZ2OrIZFBvU6CCMiA)

[Youtube Video Of Assignment](https://youtu.be/NE22EogG1zw)

# What I am most proud of in the assignment

I am quite proud of the whole assignment. I learned so much in a short space of time by just doing the assignment. I am now more familiar with how game physics work and can now relate what I have been doing on this assignment to real world games. Such as Raycasts and how they work, as they would be used in most fps shooter games. So I am proud of the fact that I was able to get a raycast working in my game.

# Proposal submitted earlier can go here:

I am creating a endless runner game similar to subway surfers or Temple run , where there will be a world and obstacles and barriers will present themselves to 
the user as they play. The game will get progessivily harder as the player progresses.
