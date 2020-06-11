namespace AlgoDat_praktikum
{
    public class Treap : ServiceBinTree
    {
        // Data
        // Bereits in der ServiceBinTree-Klasse definiert
        // Achtung: beim 'insert' darauf achten ein TreapElement zu erstellen
        //
        // Die Element-Klasse erbt von der TreeElement-Klasse; Methoden muessen wenn noetig ueberschrieben werden.

        // Search
        // Die 'richtige' search-fkt soll nur bool zurueck geben.
        // Da es fuer andere anwendungen praktisch ist mehr rueckgabewerte zu haben lieber 2 search fkt
        // Hier: Nur auswertung des rueckgabewerts der anderen search-Funktion [In BinSearchTree.cs: Zeile 5ff]
        // Andere search-Fkt: Gibt struct zurueck, die in der service Klasse definiert ist. [Habe ich rekursiv geloest -> Siehe TreeElement.cs Z.31ff]

        // Insert
        // Iterative Lsg in der Hauptklasse [BinSearchTree Z.15ff]

        // Delete
        // Iterative Lsg in der Hauptklasse [BinSearchTree Z. 39ff]

        // Print
        // -> Bereits in der ServiceBinTree-Klasse erstellt;
        // Der Ausgabe-Algorithmus (der in ServiceBinTree aufgerufen wird) ist Teil der TreapElement-Klasse (rekusriv geloest) [TreeElement.cs Z16ff]

        // Allgemein:
        // Die meisten Algorithmen koennen in Pseudo-Code-Form in den Aufzeichnungen der VL gefunden werden!
    }
}