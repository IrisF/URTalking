# URTalking

Fehlerbehebung: - Tritt ein Fehler("Fehlt ein Assemblerverweis?") bezüglich der Bibliotheken "SimpleString", "SynonymsDictionary", oder "AnswerTypeDetector" auf muss das Projekt
				  der jeweiligen Bibliothek in Visual Studio geladen und erstellt werden. Danach sollte sich im Ordner "bin/Debug" eine .dll mit selbigem Name enthalten sein. Diese
				  muss nun in das Verzeichnis packages/NLP Ordner des Projekts UR_Talking kopiert werden.

Datenbank: - Um das Projekt vollständig testen zu können muss zu Beginn eine SQL-Datenbank z.B. via Xampp erstellt und das File "elise01.sql" geladen werden. Anschließend müssen in der Klasse
			 "MySqlConnection.cs" die Instanzvariablen "uid" und "password" angepasst werden. 

Models: -Der letzte Schritt ist das Anpassen der Model Pfade in der Klasse "NLP.cs". Beispiel Models liegen im Ordner "Models" im Projekt UR_Talking


Bei Fragen/Unklarheiten einfach melden...