# Game Summary
This Game is called Tower of the Apes. It is inspired by a game called Icy Towers. The aim of the game is to get to the top of the level however you will be faced by faster moving platforms as you progress up the platforms.


# Developer Diary
### Aaron Hannon – G00347352

## Sep 27, 2019:
I just setup the project ready to begin and pushed it up to git hub. I did this because Github sometimes has problems with some of the long filenames that unity creates and I wanted to add them the .gitignore.
## Sep 30, 2019: 
I updated the project to unity to match the version on my desktop. I also set up  a sample level with default sprites to begin developing the game mechanics. I started with the player movement. Simple left, right and jump. Then I created a script that allowed the camera to follow the player. After that I added acceleration and deceleration the player so it felt like the player was gliding.
## Oct 1, 2019:
Added Platform prefab and implementation that allows the player to jump higher the faster his velocity is.
## Oct 2, 2019:
I created a script that generates platforms for the player to jump onto. The are “Platformer” platforms which allows the player to jump up through the bottom of them and collide with the top. I have all the platforms being generated randomly between the two side walls and they are all added to the parent container.
## Oct 3, 2019:
Today I created a script that destroys the platforms after a certain amount of time, needs some more balancing though. Also I fixed the player being able to clip through the walls. Debug.Logging the highest platform that the player gets to so now I just have to display it in the scene and save it to a file. I made the platforms move. They move faster as you progress up the platforms.
## Nov 11-13, 2019:
I added a double jump and began work on the UI. I wanted the camera to be in one scene and for it to rotate around the scene based on what UI element you clicked. I contacted the designer to confirm that this was okay and he said it was. I also requested some game graphics from him. 
## Nov 14, 2019:
Today we all had to show a level in the game. My developer did not show up so I currently don’t know how it is going. My Designer seemed happy with everything. I asked if I could remove some things like power-ups and he was fine with it. I also asked could I make some graphics for the game because the ones they sent me were very low res and were not even transparent.
## Dec 5, 2019:
Today I added music and a volume slider. I had some issues with this though because I was following this tutorial (https://www.youtube.com/watch?v=xNHSGMKtlv4) and the OnValueChange() of the slider would not allow me to create a dynamic float it would just give me a normal one and set it to 0. I just had to get the sliders volume manually and not through OnValueChange().
## Dec 7, 2019:
The player can now go to the scores screen. I tried storing the highscore data a JSON however I faced a lot of problems with this and it was not parsing it properly so I decided to stick with a simple txt file the that every like is a username and his highscore.
## Dec 8, 2019:
I changed the graphics of the volume slider and began researching how to sort a list based on a property of an object.( https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object) I found this post and it worked perfectly 
List<Order> SortedList = objListOrder.OrderByDecending(o=>o.highscore).ToList();
This line sorted the entire list based on the highscore.
## Dec 9-11, 2019:
Over the past few days all I have been doing is making things look as nice as possible with the supplied graphics and some that I made myself. Tweaks to all the menus and I have the highscores displaying and a user can enter their name if the lose of win to see if they have made it into the leaderboards.
I build it to Windows / UWP however there is one KNOWN BUG where on the windows build the scores do not display because unity does not build the assets folder with it and it breaks my File Handler….
Highscores works perfectly if you run it through Unity itself.

