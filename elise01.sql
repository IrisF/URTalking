-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Erstellungszeit: 29. Sep 2015 um 22:37
-- Server Version: 5.5.32
-- PHP-Version: 5.4.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Datenbank: `elise01`
--
CREATE DATABASE IF NOT EXISTS `elise01` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `elise01`;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `buzz_words`
--

CREATE TABLE IF NOT EXISTS `buzz_words` (
  `id_buzz` int(11) NOT NULL AUTO_INCREMENT,
  `buzz_word` varchar(255) NOT NULL,
  `to_table` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_buzz`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Daten für Tabelle `buzz_words`
--

INSERT INTO `buzz_words` (`id_buzz`, `buzz_word`, `to_table`) VALUES
(1, 'wo', 'location'),
(2, 'wer', 'person');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `location`
--

CREATE TABLE IF NOT EXISTS `location` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `frage` longtext,
  `antwort` longtext,
  `type` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=14 ;

--
-- Daten für Tabelle `location`
--

INSERT INTO `location` (`id`, `frage`, `antwort`, `type`) VALUES
(1, 'Wo ist die Mensa?', 'Die Mensa ist gegenüber des Busterminals über die Treppen bei der Unterführung zu erreichen.', 'text'),
(2, 'Wo kann ich mich informieren, wann und wo die Klausuren stattfinden?', 'Den Klausurenplan findest du zu gegebenem Zeitpunkt im I:IMSK Forum unter "Mittelungen der Lehrstühle": http://www-app.uni-regensburg.de/Fakultaeten/SLK/iw/forum/index.php\n', 'text'),
(3, 'Wo finde ich alte Klausuren?', 'Eine Sammlung von Altklausuren wurde auf der Seite SIM zusammengetragen: http://www.uni-regensburg.de/universitaet/sim/klausuren/index.html\n', 'text'),
(4, 'Wo finde ich Unterlagen zu den Kursen?', 'Die Unterlagen kansnt du auf der Elearning-Plattform "GRIPS" finden: https://elearning.uni-regensburg.de/\n', 'text'),
(5, 'Wo liegen die Schwerpunkte des Studiums?', 'Anhand der Anzahl an Leistungspunkte ist das Modul Informationssysteme, Informationretrieval sowie das Projektmodul als Schwerpunkt einzustufen.\r\n\r\n', 'text'),
(6, 'Wo kann ich mich informieren, wann und wo die Klausuren stattfinden?', 'http://www-app.uni-regensburg.de/Fakultaeten/SLK/iw/forum/index.php', 'link'),
(7, 'Wo finde ich alte Klausuren?', 'http://www.uni-regensburg.de/universitaet/sim/klausuren/index.html\r\n', 'link'),
(8, 'Wo finde ich Unterlagen zu den Kursen?', 'https://elearning.uni-regensburg.de/\r\n', 'link'),
(9, 'Wo kann ich bei Fragen Ansprechpartner finden?', 'Dein Ansprechpartner für Fragen zu deinem Studium ist Frau Vogl. Sie ist die Sekretäring des Lehrstuhls für Informationswissenschaft. Gerne hilft sie dir bei deinen Fragen weiter: Renate.Vogl@ur.de \r\n\r\n', 'text'),
(10, 'Wo finde ich Informationen zur Stundenplangestaltung?', 'Auf den Seiten des Lehrstuhl für Informationswissenschaft findest du einen exemplarischen Studienverlauf: http://www.uni-regensburg.de/sprache-literatur-kultur/informationswissenschaft/fuer-studieninteressierte/bachelor/index.html\r\n', 'text'),
(11, 'Wo finde ich Informationen zur Stundenplangestaltung?', 'http://www.uni-regensburg.de/sprache-literatur-kultur/informationswissenschaft/fuer-studieninteressierte/bachelor/index.html\r\n', 'link'),
(12, 'Wo finde ich Notenspiegel?', 'Einen offiziellen Notenspiegel kannst du dir im Prüfungsamt abholen. Bitte vergiss dafür deinen Studenten- sowie Personalausweis nicht!', 'text'),
(13, 'Wo finde ich Mensa-card?', 'Die Mensa-Card erhältst du im Mensakartenbüro, gegenüber des Busterminals, beim Treppenaufgang zur Mensa.', 'text');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `person`
--

CREATE TABLE IF NOT EXISTS `person` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `frage` longtext,
  `antwort` longtext,
  `type` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Daten für Tabelle `person`
--

INSERT INTO `person` (`id`, `frage`, `antwort`, `type`) VALUES
(1, 'wer ist zuständig für den Kurs UR-Talking\r\n', 'Herr Jürgen Reischer und Frau Hanna Knäusl', 'text'),
(2, 'wer ist prof wolff', 'dinge', 'text');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `unknown`
--

CREATE TABLE IF NOT EXISTS `unknown` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `question` longtext NOT NULL,
  `answer` longtext NOT NULL,
  `type` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=51 ;

--
-- Daten für Tabelle `unknown`
--

INSERT INTO `unknown` (`id`, `question`, `answer`, `type`) VALUES
(1, 'Wie sehen meine Berufsaussichten bei diesem Studiengang aus? ', 'Vorab ist zu sagen, dass die beruflichen Möglichkeiten immer abhängig von deiner Wahl des Studiengangs und der aktuellen Marktlage sind.Informationswissenschaftler können Informationssysteme entwerfen, betreiben und evaluieren. Sie setzen dazu Methoden aus dem Software-Engineering und der empirischen Sozialforschung angemessen ein. Informationswissenschaftler finden Beschäftigung in IT-Unternehmen und –Abteilungen, in der Unternehmensberatung und im Bereich der neuen Medien. ', 'text'),
(2, 'Wie hoch ist der NC Informationswissenschaft überhaupt? ', 'Derzeit ist der Studiengang Informationswissenschaft nicht zulassungsbeschränkt. ', 'text'),
(3, 'Wie lange beträgt die Regelstudienzeit? ', 'Die Dauer des Studiums richtet sich nach dem individuellen Studienverlauf. Die Regelstudienzeit, d.h. die Zeit, in der das vorgesehene Studienprogramm idealerweise absolviert werden kann, beträgt 6 Semester. Die tatsächliche Studiendauer kann hiervon abweichen. Sie wird begrenzt durch die Prüfungsfristen, die in der Prüfungsordnung geregelt ist. ', 'text'),
(4, 'Wie lange dauern die Semesterferien? ', 'Das ist nicht pauschal zu beantworten. Die vorlesungsfreie Zeit beträgt grob 2 Monate. Bedenke jedoch, dass in dieser Zeit häufig noch Prüfungen stattfinden. ', 'text'),
(5, 'Wie finde ich in der ersten Woche meine Räume? ', 'Die Räumlichkeit zu den jeweiligen Kursen kann man aus dem LSF entnehmen. Die genaue Lage der Räume kannst du hier entnhemen: http://www.uni-regensburg.de/kontakt/lageplan/index.html ', 'text'),
(6, 'Wie lange geht das Wintersemester? ', 'Das Wintersemester geht immer bis zum 31. März. ', 'text'),
(7, 'Wie bekomme ich einen Sportausweis? ', 'Einen Sportausweis kannst du dir selbst auf deinen Studentenkarte buchen. Hierfür musst du mindesten 15 Euro Guthaben auf dieser haben und einen Validierungsautomat aufsuchen. Ein solcher steht beispielsweise im Vorraum der Mensa. ', 'text'),
(8, 'Wie funktioniert das Punktesystem d. Bachelors? ', 'Für jeden Kurs bekommst du eine gewisse Anzahl an Punkte, die den Arbeitsaufwand der Kurses repräsentieren sollen. ', 'text'),
(9, 'Wie Zeitaufwendig ist der Studiengang? ', 'Der Aufwand des Studiums ist stets von der Lernfähigkeit und Lernbereitschaft eines Studenten abhängig. Der Lernaufwand für einen speziellen Kurs ist durch die Leistungspunkte ersichtlich. ', 'text'),
(10, 'Wie lange dauert eine Prüfung? ', 'Das ist von Kurs zu Kurs unterschiedlich. Die meisten Klausuren dauern 60 oder 90 Minuten. ', 'text'),
(11, 'Wie meldet man sich für das nächste Semester zurück (im allgemeinen)? ', 'Die Rückmeldung erfolgt automatisch durch die Überweisnung des Semesterbeitrag. ', 'text'),
(12, 'Prüfungen anerkennen lassen andere Studiengänge', 'Wenn diese Kurse eine fachliche Anerkennung berechtigen, also inhaltlich ähnlich sind, benötigst du eine Anerkennung durch den jeweiligen Lehrstuhlinhaber bzw. den Kursverantwortlichen. Die Einbuchung nimmt dann das Prüfungsamt vor. Andernfalls kannst du bereits erbrachte Leistungen aus einem abgebrochenem Studium in den freien Wahlbereich einbringen. ', 'text'),
(13, 'Wie ist die Durchfallquote in den verschiedenen Studiengängen? ', 'Für die aktuelle Durchfaller- bzw. Studienabbrecherquote solltest du dich direkt bei den jeweiligen Sekretariaten der Lehrstühle melden. ', 'text'),
(14, 'Wie oft kann man eine Prüfung wiederholen? ', 'Du hast für jede Prüfung drei Versuche. ', 'text'),
(15, 'Wie schreibe ich mich für Veranstaltungen ein? ', 'Die Anmeldung erfolgt über das LSF im Anmeldezeitrum. Wann dieser ist kannst du direkt aus der jeweilige Kursbeschreibung entnehmen: https://lsf.uni-regensburg.de/ ', 'text'),
(16, 'Welche Voraussetzungen / Interessen sollte man für Informationswissenschaften mitbringen ? ', 'Informationswissenschaft setzt keine Vorkenntnisse (wie Programmierkenntnisse, Praktikum o.ä.) voraus. Dennoch ist ein Interesse an mathematischen Grundlagen und Programmieren während des Studiums für einen erfolgreichen Abschluss wünschenswert.', 'text'),
(17, '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!', 'Der Bachelorstudiengang der Informationswissenschaft setzt keine Vorkenntnisse (wie Programmierkenntnisse, Praktikum o.ä.) voraus. Dennoch ist ein Interesse an mathematischen Grundlagen und Programmieren während des Studiums für einen erfolgreichen Abschluss wünschenswert. ', 'text'),
(18, 'Welche Berufsfelder existieren nach dem Studium? ', 'Tätigkeitsfelder, die sich dir nach dem Studium Informationswissenschaft eröffnen gehen zum Beispiel in Richtung Informations- und Wissensmanagement, E-Commerce und E-Learning, Design und Evaluation von Bedienkonzepten für Computer und Smartphones und das Pflegen und Konzipieren von Informationsarchitekturen.', 'text'),
(19, '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!', 'Als Informationswissenschaftler stehen dir viele Türen offen. Beschäftigungsmöglichkeiten bieten sich zum Beispiel in der Automobilindustrie, in mittelständischen Unternehmen, in Banken und Versicherungen, in der IT-/Softwareindustrie und auch in der Web-/Medienbranche. ', 'text'),
(20, 'Welche VL sind für das erste Semester sinnvoll? ', 'Auf den Seiten des Lehrstuhl für Informationswissenschaft findest du einen exemplarischen Studienverlauf: http://www.uni-regensburg.de/sprache-literatur-kultur/informationswissenschaft/fuer-studieninteressierte/bachelor/index.html ', 'text'),
(21, 'Welche Voraussetzungen sollte ich mitbringen? ', 'Eigenschaften für die Informationswissenschaft sind Analytisches Denken und Interesse an den Möglichkeiten und Folgen der Informationstechnik. ', 'text'),
(22, 'Welche Programmiersprachen lernen wir später noch? ', 'Das hängt von deinen Vorlieben ab. Im Modul ''Software Engineering'' kannst du Java oder C# belegen. Je nach Interesse kannst du deine Fähigkeiten noch in einem Android-Projekt vertiefen. Auch vom Rechenzentrum werden einige Programmierkurse für dein Wahlbereich angeboten. ', 'text'),
(23, 'Welches 2.Hauptfach o. 2.Nebenfächer ergänzen sich besonders mit der Informationswissenschaft? ', 'Allgemein gesagt sind natürlich alle Kombinationen, die möglich sind auch geeignet. Es ist deine Entscheidung, ob du die Informationswissenschaft mit einem ähnlichen Fach, wie z.B Medieninformatik oder Wirtschaftsinformatik ergänzen willst, oder dich durch Philosophie oder Bewegungswissenschaften in einem ganz anderen Bereich weiterbilden möchtest. Beides hat seine Vorteile, die du für dich abwägen musst. ', 'text'),
(24, 'Welche möglichen Kurse stehen mir zur Vervollständigung meines Wahlbereichs zur Verfügung? ', 'In den freien Wahlbereich können prinzipiell alle Leistungen eingebracht werden. Daneben gibt es noch den fachinternen Wahlbereich, der z.B. mit Zusatzpunkten durch Übungen oder Programmierkurse des Rechenzetrums gefüllt werden kann. ', 'text'),
(25, 'Welche Kurse werden einem für das erste Semester empfohlen? ', 'Auf den Seiten des Lehrstuhl für Informationswissenschaft findest du einen exemplarischen Studienverlauf: http://www.uni-regensburg.de/sprache-literatur-kultur/informationswissenschaft/fuer-studieninteressierte/bachelor/index.html ', 'text'),
(26, 'Welche Themenbereiche werden im Studiengang informationswissenschaft behandelt? ', 'Die Themenbereiche kannst du beispielsweise auf den Seiten des Lehrstuhl entnehmen: http://www.uni-regensburg.de/sprache-literatur-kultur/informationswissenschaft/fuer-studieninteressierte/bachelor/index.html ', 'text'),
(27, 'Welche Voraussetzungen benötige ich, um das Studium abzuschließen? ', 'Für den Abschluss des Studium musst du die geforderte Anzahl an Leistungspunkten, inklusive der Bachelorarbeit erbracht haben. ', 'text'),
(28, 'Welche Veranstaltungen wurden zur Gesamtnote gezählt? ', 'Diese Informationen inklusive der Gewichtung der Kurse kannst du der Modulbeschreibung entnehmen: http://www.uni-regensburg.de/sprache-literatur-kultur/informationswissenschaft/fuer-studieninteressierte/bachelor/index.html ', 'text'),
(29, 'Was sind geeignete Kombinationsmöglichkeiten? ', 'Allgemein gesagt sind natürlich alle Kombinationen, die möglich sind auch geeignet. Es ist deine Entscheidung, ob du die Informationswissenschaft mit einem ähnlichen Fach, wie z.B Medieninformatik oder Wirtschaftsinformatik ergänzen willst, oder dich durch Philosophie oder Bewegungswissenschaften in einem ganz anderen Bereich weiterbilden möchtest. Beides hat seine Vorteile, die du für dich abwägen musst. ', 'text'),
(30, 'Was ist der Unterschied zwischen Dozent und Professor? ', 'Dozent: Ein Dozent ist eine Person, die an Hochschulen und Bildungsinstituten des Tertiär- oder Quartärbereichs unterrichtet bzw. lehrt. Professor: Professor oder Professorin ist in der Regel die Amts- und Berufsbezeichnung des Inhabers einer Professur. ', 'text'),
(31, 'Ich habe keine Ahnung, was soll ich in der Abschlussarbeit schreiben? ', 'Melde dich einfach mal bei den Lehrstühlen der Informationswissenschaft. Diese haben immer Vorschläge für eine Bachelorarbeit parat, sind aber auch offen für eigene Ideen. ', 'text'),
(32, 'Ist bei diesen Studiengänge Auslandssemester möglich? ', 'Allen Studierenden wird dringend empfohlen, einen mehrmonatigen bzw. einjährigen Studienaufenthalt im Ausland zu verbringen. Im Gegensatz zu einer weit verbreiteten Meinung bedeutet das Jahr im Ausland keinen Zeitverlust – auch nicht im Hinblick auf die Regelstudienzeit. Für den Auslandsaufenthalt kann auf Antrag Urlaub gewährt werden. Der günstigste Zeitpunkt für einen Auslandsaufenthalt ist nach Abschluss der Basismodule. Zu erwähnen ist außerdem die großzügige Anerkennungspraxis an der Universität Regensburg für die im Ausland erbrachten Leistungsnachweise ', 'text'),
(33, 'Kann man nachträglich vom 2ten Hauptfach auf 2 Nebenfächer wechseln? ', 'Es ist grundsätzlich möglich das aktuelle Fach während des Studiums zu wechseln, dies gilt bezüglich der Fächerkombination, als auch dem Studiengang selbst. ', 'text'),
(34, 'Gibt es Kurse, die ich bis zu einem bestimmten Semester bestanden haben muss? ', 'Diese Regelungen entnimmst du bitte der Prüfungsordnung auf den Seiten des Lehrstuhl für Informationswissenschaft: http://www.uni-regensburg.de/sprache-literatur-kultur/informationswissenschaft/fuer-studieninteressierte/bachelor/index.html ', 'text'),
(35, 'Brauche ich bis zu einem bestimmten Semester eine Mindestanzahl von ECTS? ', 'Diese Regelungen entnimmst du bitte der Prüfungsordnung auf den Seiten des Lehrstuhl für Informationswissenschaft: http://www.uni-regensburg.de/sprache-literatur-kultur/informationswissenschaft/fuer-studieninteressierte/bachelor/index.html ', 'text'),
(36, 'Wieviel Überhang Semester gibt es? ', 'Diese Regelungen entnimmst du bitte der Prüfungsordnung auf den Seiten des Lehrstuhl für Informationswissenschaft: http://www.uni-regensburg.de/sprache-literatur-kultur/informationswissenschaft/fuer-studieninteressierte/bachelor/index.html ', 'text'),
(37, 'An wann kann man sich für die Kurse anmelden? ', 'Diese information findest du in der jeweiligen Kursbeschreibung im LSF. In der Regel beginnt die Anmeldephase gegen Ende der vorlesungsfreien Zeit. ', 'text'),
(38, 'Sollte ich für die Programmierung/ Mathe im Vorfeld  vorbereiten? ', 'Nötig ist das nicht, die Kurse setzen kein Vorwissen voraus und fangen bei null an. Hilfreich ist es natürlich, wenn du dich schonmal in die Materie einließt. ', 'text'),
(39, 'Bauen spätere Veranstaltungen auf die anfangs erworbenen Lerninhalte auf? ', 'Ja, wenn dies der Fall ist, ist es in der Kursbeschreibung im LSF hinterlegt. Beispielsweise baut das Vertiefungsseminar Information Retrieval auf dem Grundkurs Information Retrieval auf. ', 'text'),
(40, 'Gibt es einen Studienrichtplan der einem hilft die Fächer sinnvoll zu belegen bzw in einer sinnvollen Reihenfolge? ', 'Auf den Seiten des Lehrstuhl für Informationswissenschaft findest du einen exemplarischen Studienverlauf: http://www.uni-regensburg.de/sprache-literatur-kultur/informationswissenschaft/fuer-studieninteressierte/bachelor/index.html ', 'text'),
(41, 'Kann ich ein Freisemester nehmen? ', 'Ein Freisemester ist grundsätzlich nicht möglich. Du kannst jedoch für ein Praktikum oder Auslandssemster ein Urlaubssemster einlegen. Auch im Krankheitsfall ist dies möglich. ', 'text'),
(42, 'Muss man in den Semesterferien anwesend sein? ', 'Grundsätzlich nicht. Es gibt jedoch Kurse, die in den Ferien stattfinden. ', 'text'),
(43, 'Gibt es Prüfungen in den Semesterferien? ', 'Ja, der Großteil der Klausuren findet in der vorlesungsfreien Zeit statt. ', 'text'),
(44, 'Kann ich Englischkurse oder andere Sprachkurse als Wahlbereich nehmen? ', 'Ja, diese kannst du problemlos im freien Wahlbereich einbringen. ', 'text'),
(45, 'Mit welchen anderen Studienfächern gibt es Überschneidungen? ', 'Vereinzelt gibt es Überschneidungen mit der Wirtschaftsinformatik und der Medieninformatik. Dies lässt sich bei fachähnlichen Fächern leider nicht vermeiden. ', 'text'),
(46, 'Darf man eine Prüfung zur Notenverbesserung wiederholen? ', 'Nein, eine bereits bestandene Klausur kann nicht wiederholt werden. ', 'text'),
(47, 'Die Informationswissenschaft stellt sich ja auf der Webseite sehr theoretisch dar, welche Kurse gibt es in denen die Praxisanwendung im Vordergrund steht? ', 'Nachdem die Grundlagen verinnerlihct sind, wird in den Vertiefungsseminaren sehr praxisnah gearbeitet, anhand von Experimenten und Praxisprojekten. ', 'text'),
(48, 'Muss das Modul nur im Ganzen oder alle einzelne Teile bestanden werden? ', 'Alle Teile der Module müssen bestanden werden. Für jeden Kurs hast du drei Versuche. ', 'text'),
(49, 'In welcher Reihenfolge sollten die Kurse besucht werden? ', 'Auf den Seiten des Lehrstuhl für Informationswissenschaft findest du einen exemplarischen Studienverlauf: http://www.uni-regensburg.de/sprache-literatur-kultur/informationswissenschaft/fuer-studieninteressierte/bachelor/index.html ', 'text'),
(50, 'Zu welcher Fakultät gehört Informationswissenschaft? ', 'Die Informationswissenschaft ist Teil der Fakultät Sprach-, Literatur- und Kulturwissenschaften.', 'text');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
