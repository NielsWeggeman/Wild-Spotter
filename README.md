# Soccer Star VR
Simple VR Game built for Intern Challenge

*---- Welcome to... Wild Spotter! ----*

Deze VR-game is gemaakt voor een 'intern' opdract, om mijn ervaring in Unity tot dusver
te laten zien. Het is een minigame die is gebouwd om kinderen af te leiden en hen te 
helpen ontspannen wanneer ze een pijnlijke of enge procedure ondergaan in het ziekenhuis.

Wild Spotter teleporteert de speler naar een gezellige camping met warme kleuren,
schattige dieren en gezellige vibes. Door gebruik te maken van 'Gaze detection',
kan de speler gewoon rondkijken en punten scoren door alle dieren in het wild in 
de scene te spotten - zonder daarvoor hun handen of de rest van hun lichaam te bewegen.

Dit is geschikt voor in ziekenhuissituaties waar het kind relatief stil moeten zitten 
tijdens de procedure, en daarom hun handen niet kunnen gebruiken.

Deze game is ontworpen om te worden gespeeld op de Oculus Quest 2

*---- N.B. Opstart instructies ----*

Download de 'Wild Spotter - Hand In Version.apk' en installeer deze op Quest 2 om het 
spel te spelen.

Let op: een controller is vereist om het spel te starten, maar wordt niet in het spel 
gebruikt. In plaats daarvan gebruikt de game 'gaze detection'. Een fout in de set-up
zorgt er echter voor dat de menuknoppen alleen kunnen worden geactiveerd door voor een 
seconde of twee naar de rand van de knop te 'staren' (deze vertraging is opzettelijk). 
Zodra de game je 'teleporteert' van de menupagina naar een scène met daglicht, heb je 
het spel gestart en ben je klaar om dieren te gaan spotten. Genieten van!

![alt text](https://github.com/NielsWeggeman/Wild-Spotter/blob/main/Menu%20view.jpg)
![alt text](https://github.com/NielsWeggeman/Wild-Spotter/blob/main/Game%20view%201.jpg)
![alt text](https://github.com/NielsWeggeman/Wild-Spotter/blob/main/Game%20view%202.jpg)


*---- Mogelijkheden tot verbetering ----*

Deze app is binnen twee dagen gebouwd. Als ik hier meer tijd aan zou besteden, zou ik
aan de volgende dingen werken:

- Beperking van het gezichtsveld, zodat kinderen effectief alleen vooruit willlen kijken,
  in plaats van om zich heen.
- Veel meer dieren toevoegen en deze meer sporadisch te laten verschijnen, zodat het spel 
  langer leuk blijft.
- De hierna genoemde bugs oplossen.
- Geluidseffecten toevoegen die aan geven dat een dier op het punt staat te voorschijn te komen.
- Een geluidseffect toevoegen dat aangeeft dat er het dier waar op dit moment naar wordt gekeken
  al was gevonden.
- 'Post processing' toevoegen om de verlichting te verbeteren.
- Informatie toevoegen over welke dieren je hebt gespot, zodat je meer over deze dieren kan leren.
  

*---- Bekende Bugs ----*

Niet alle bugs konden binnen de termijn van twee dagen goed worden verwijderd. 
Er zijn een paar bugs al bekend:

- De cursor op de menupagina is niet erg duidelijk zichtbaar. Dit komt door de belichtingsinstellingen
  en omdat ik het materiaal niet kon laten licht geven.
- De knop bij startmenu kan alleen worden geactiveerd door naar de rand van de knop te staren.
- De zittende vogel kan per ongeluk worden geteleporteerd zodat deze recht voor je neus komt te staan. 
  Dit probleem verdwijnt wanneer het spel opnieuw wordt opgestart.
- De terugknop in het spel werkt niet meer. Waarschijnlijk heb ik per ongeluk iets in de 
  editor-instelling gewijzigd.
- Heel af en toe worden de verlichtingsinstellingen niet goed geladen, waardoor de menuscène er erg 
  donker uitziet en de gamescène er erg raar uitziet. Dit kan wederom worden opgelost door simpelweg de 
  app opnieuw op te starten.
- De laatste 'bug' (de schaatsenrijder op de rivier) telt ook als een dier, maar kan erg moeilijk te 
  vinden zijn ;p. Die zou ik voor een groter dier moeten vervangen.

*---- IP ----*

Ik heb gratis middelen uit de unity assetstore gebruikt om de scènes te bouwen.
Dit project zou niet mogelijk zijn geweest zonder de modellen van:
- 'Free Low Poly Nature Forest' door 'Pure Poly'
- 'Low Poly Free Vegetation Kit' door 'Proxy Games'
- 'Low Poly Wind' door 'Nicrom'
- 'POLY - Lite Survival Collection' door 'ANIMPIC STUDIO'
- 'Procedural Fire' door 'Hovl Studio'
- 'Simple Low Poly Nature Pack' door 'NeutronCat' and
- 'Simplistic Low Poly Nature' door 'Acorn Bringer'

Evenals met de gratis audiosamples van:
- 'Nature Essentials' door 'Nox_sound'
- 'Nature Sound FX' door 'lumino'
- 'Nature Sound Pack' door 'Goumain Antoine' and
- 'ROMANTIC CINE JAZZ PIANO VOL.2' door 'Beaver Sound'

En de volgende youtube-tutorials:
- "Unity VR Tutorial - Button Gaze Timer Interaction" door 'Xlaughts'
  https://www.youtube.com/watch?v=zdNBZsJdg9c
- "VR Gaze Interaction in Unity" door Tomaz Saraiva
  https://www.youtube.com/watch?v=8p4erfeWatA
- "Simple Gaze Cursor in Unity" tutorial door Adam Kelly van 'Immersive Limit'
  https://www.immersivelimit.com/tutorials/simple-gaze-cursor-in-unity
- "Unity VR Development for Oculus Quest: Main Menu" door 'Realary'
  https://www.youtube.com/watch?v=Xhz7cW5dbyY&t=73s
- "How to update UI (user interface) text game object component via script in
  2D Unity game?" door 'Alexander Zotov'
  https://www.youtube.com/watch?v=45U3PhmUSuI
- en "Path Creator (free unity tool)" door 'Sebastian Lague'
  https://www.youtube.com/watch?v=saAQNRSYU9k
  
