# Bachelorprojekt | Unity 

Dieses Projekt stellt einen integralen Teil meines Bachelorprojekts dar.
Hier wurde das [3D-Modell](https://github.com/dsteige1/bachelorarbeit_blender) der Speyerer Domkrypta, welches ich mit Blender erstellt habe, interaktiv aufbereitet.

## Aufbau und Funktionen
### Generell
 - Ziel war es, das fertige 3D-Modell nun erfahrbar zu machen
 - Dazu wurde das [fbx-Modell](https://github.com/dsteige1/bachelorarbeit_unity/tree/master/Assets/Models) in sechs Teilen – Mittelteil, Süd-/ und Nordflügel, Chrokrypta, Vorkrypta und Gruft – importiert, um etwas flexibler zu sein und bei Anpassungen nicht immer das ganze Modell neu importieren zu müssen
 - Die fbx-Dateien wurden dabei immer direkt in den Assets-Ordner exportiert, da Unity eine Art Delta-Import unterstützt. So musste ich, wenn ich eine Teil wiederholt importiert habe, nicht alle Texturen und Komponenten neu zuordnen
- Parallel dazu wurden die Texturen in Blender _gebaked_, nach Unity importiert und als [Materialien](https://github.com/dsteige1/bachelorarbeit_unity/tree/master/Assets/Materials)  angelegt


### Skripte
- CameraMouse.cs
	- Dieses Skript entstammt einem [Tutorial](https://www.youtube.com/watch?v=blO039OzUZc) von Holistic3d und dient der Rotation/Steuerung der Kamera
	- Dabei werden die Koordinaten des Cursors auf einem 2D-Vektor _(Vector2)_ gespeichert und durch die _Mathf.Lerp()_-Funktion interpoliert und weicher gemacht
	- Dann werden die Vektoren der transform-Komponente der Kamera (Bewegung auf der y-Achse -> vertikale Bewegung) und des Parent-Objekts, dem Player (x-Achse -> horizontale Achse) zugeordnet
- CharacterControl.cs
	- Auch dieses Skript entstammt dem [Tutorial](https://www.youtube.com/watch?v=blO039OzUZc) von Holistic3d und dient der Bewegung des Players
	- Als erstes wird der Cursor im Viewport _gelocked_, damit er nicht aus dem Fenster herausfahren kann
	- Dann werden die Inputs der Pfeiltasten, bzw. W, A, S und D-Taste erfasst _(Input.GetAxis("Vertical"))_ und _Input.GetAxis("Horizontal")_ und an die transform-Komponente des Players übergeben
	- Zusätzlich wird überprüft, ob der Player noch über einem bestimmten y-Wert liegt. So kann abgefangen werden, falls man 'von der Welt fällt'
	- Zuletzt wird implementiert, dass man den Cursor via Space-Taste wieder freigeben und auch wieder sperren kann. Dies ist wichtig, damit man mit den Objekten interagieren kann und die Click-Trigger funktionieren.
- JS_Connector.cs
	- Dieses Skript importiert über DllImport Funktionen, welche im späteren Built als JavaScript ausgeführt werden
	- Diese Funktion kann dann ausgeführt werden
	- In meinem Fall wird die Funktion _SendObjName()_ ausgeführt und der Objektname des zugehörigen Objekts _(this)_ übergeben
	- Die Funktion wird durch einen _PointerClick_-Trigger auf Objekte gerufen
- MaterialChanger.cs
	- Dieses Script implementiert die Funktion, durch die bei einem _PointerEnter_ auf Objekte der _Smoothness_-Parameter der Material-Komponente verändert wird
	- Dazu wird zunächst der original-Wert gespeichert
	- Dann wird in einem Loop der Wert jedes Materials des Objekts auf 1 (100%) gesetzt
	- Bei einem _PointerExit_-Event werden alle Materialien wieder zurückgesetzt
- MenuScript.cs
	- In diesem Skript sind die Funktionen des Menüs zu finden
	1. Die Funktion, mit der man durch den _SceneManager_ in die nächste Szene springt
	2. Die externe JavaScript-Funktion, die zur Anleitung verankert
- MiniMap.cs
	- Dieses Skript entstammt einem Tutorial von [Brackeys](https://www.youtube.com/watch?v=28JTTXqMvOU) und steuert die Kamera, welche auf die Minimap projiziert wird
	- Dazu wird die Position und die Rotation der y-Achse des Players auf an die MiniMapCamera übertragen
	- Das Objekt Player muss dazu der Variable _player_ zugewiesen werden
- Rotator.cs
	- Hiermit werden die Informations-Icons durch die _transforms.Rotate()_-Methode rotiert
## Interoperabilität
- Um die Interoperabilität zwischen dem C#-basierten Unity-Projekt und der webbasierten Web-Gl JavaScript-Anwendung zu gewährleisten, musste ich eine JavaScript-Bibliothek als Plugin anlegen: [Assets/Plugins/myLib.jslib](https://github.com/dsteige1/bachelorarbeit_unity/blob/master/Assets/Plugins/myLib.jslib) 
- Diese hält die Funktionen bereit, welche nach dem DllImport über C#-Funktionen aufgerufen werden können (siehe [JS_Connector.cs](https://github.com/dsteige1/bachelorarbeit_unity/blob/master/Assets/Scripts/JS_Connector.cs))
- Die Funktionen aus dieser Bibliothek funktionieren wie normale JavaScript-Funktionen
	- _SendObjName_ ruft ich die externe _getObjInfo()_-Funktion auf und übergibt den Objektnamen – mit einem _Pointer_Stringify_, da sonst nur der int-Wert des Pointers übergeben werde würde
	- _TutAnchor_ ruft die Funktion _jumpToTutorial()_ auf, durch die das html-Dokument zur Anleitung springt (gesteuert durch die WebGl-App)
## Performance
- Die Performance hat zunächst nach dem Build große Probleme dargestellt. Man konnte kaum die App laden, ohne dass die Lüftung des Computers lautstark anging, daher habe ich folgende Maßnahmen getroffen:
	- Static Batching:
		- Alle Objekte, die mit _static batching_ getaggt sind, werden zusammengefasst und als ein Mesh gerendert
		- Dies reduziert die _draw calls_ erheblich
	![Static batching](https://github.com/dsteige1/bachelorarbeit_unity/blob/master/doc_imgs/batching.png =250x)
	-	Ausschalten, dass die Applikation auch im Hintergrund läuft
		-	Dadurch lädt die Seite später schneller, da die App dann nur performt, wenn sie im Fokus ist
	- Ausschalten der Exceptions Supports
		- Der Unity-Dokumentation nach hat dies auch positive Auswirungen auf die Performance

#### Erstellt mit der Unity-Version: 2019.2.12f1