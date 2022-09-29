# Soccer Star VR
Simple VR Game built for Intern Challenge

*---- Welcome to... Wild Spotter! ----*

This VR game was built for an Intern challenge, to showcase
my experience in Unity thusfar. It is a mini game build to distract children
and help them relax when undergoing a painful or scary procedure in hospitals.

Wild Spotter teleports the player to a cosy campsite with bright colors,
cute animals and great vibes altogether. By utilising gaze detection,
the player can simply look around and score points by spotting all the
wild-life in the scene - without moving their hands or the rest of their body.

This is suited for in hospital situations where the child may
be required to sit relatively still during the procedure, and can therefore
not use their hands.

N.B. !! The game is designed to be played on Oculus Quest 2 !!

*---- N.B. Launch Instructions ----*

Download the 'Wild Spotter - Hand In Version.apk' and install it on Quest 2 to play the game!

Beware that a controller is required to start the game, but not used in the game.
Instead, the game uses gaze detection to be played. Some error in the set-up
makes that the Menu buttons can be fired only by 'gazing' at the surrounding
edge of the button, for a second or two (the delay is intentional). Once the
game 'teleports' you from the menu page to a 'daylight scene', you know you
launched the game and are now ready to play. Enjoy!

![alt text](https://github.com/NickMcWay/Wild-Spotter/blob/main/Menu%20view.jpg?raw=true)
![alt text](https://github.com/NickMcWay/Wild-Spotter/blob/main/Game%20view%201.jpg?raw=true)
![alt text](https://github.com/NickMcWay/Wild-Spotter/blob/main/Game%20view%202.jpg?raw=true)


*---- Further improvements ----*

This app was built within two days time. If I would spend more time on this
game, I would recommend:

- Limiting the field of view so kids only watch in front of them.
- Adding in much more animals.
- Making them appear more sporadically, so that the game stays fun for a longer
  period of time.
- Fixing the bugs.
- Adding sound effects to indicate that an animal is about to be visible.
- Adding a sound effect that indicates that an animal was already found.
- Adding post-processing to improve the lighting.
- Adding information about which animals you spotted, as well as educational
  information so that you can learn more about the animals.
  

*---- Known Bugs ----*

Not all bugs could properly be removed within the two-day timeframe.
There are a few bugs:

- The cursor on the menu page is not very clearly visible. This is due to the lighting settings and because I couldn't get it's material to be emissive.
- Button at start menu can only be activated by gazing at the edge of the button.
- Sitting bird can accidentally be teleported to right in front of you. This issue disappears when restarting the game.
- The back button does not work anymore. Likely, something within the editor setting was accidentally changed.
- Every once in a while, the lighting settings don't load properly, making the menu scene look very dark and the game scene look very weird. This can also
  be resolved by simply rebooting the app.
- The last bug (the water skitter on the river) also counts as an animal but may be very hard to find ;p. This should likely be a larger animal.



*---- IP ----*

I used free assets from the unity assetstore to build the scenes.
This project would not have been possible without the models from:
- 'Free Low Poly Nature Forest' by 'Pure Poly'
- 'Low Poly Free Vegetation Kit' by 'Proxy Games'
- 'Low Poly Wind' by 'Nicrom'
- 'POLY - Lite Survival Collection' by 'ANIMPIC STUDIO'
- 'Procedural Fire' by 'Hovl Studio'
- 'Simple Low Poly Nature Pack' by 'NeutronCat' and
- 'Simplistic Low Poly Nature' by 'Acorn Bringer'

As well as with the free audio samples from:
- 'Nature Essentials' by 'Nox_sound'
- 'Nature Sound FX' by 'lumino'
- 'Nature Sound Pack' by 'Goumain Antoine' and
- 'ROMANTIC CINE JAZZ PIANO VOL.2' by 'Beaver Sound'

And the following youtube tutorials:
- "Unity VR Tutorial - Button Gaze Timer Interaction" by 'Xlaughts'
  https://www.youtube.com/watch?v=zdNBZsJdg9c
- "VR Gaze Interaction in Unity" by Tomaz Saraiva
  https://www.youtube.com/watch?v=8p4erfeWatA
- "Simple Gaze Cursor in Unity" tutorial by Adam Kelly from 'Immersive Limit'
  https://www.immersivelimit.com/tutorials/simple-gaze-cursor-in-unity
- "Unity VR Development for Oculus Quest: Main Menu" by 'Realary'
  https://www.youtube.com/watch?v=Xhz7cW5dbyY&t=73s
- "How to update UI (user interface) text game object component via script in
  2D Unity game?" by 'Alexander Zotov'
  https://www.youtube.com/watch?v=45U3PhmUSuI
- and "Path Creator (free unity tool)" by 'Sebastian Lague'
  https://www.youtube.com/watch?v=saAQNRSYU9k
  
