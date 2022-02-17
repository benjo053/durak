using System;

namespace Calculator;

class Taschenrechner
{
    private string eingabe;
    private string bearbeitung;

    public Taschenrechner()
    {
        eingabe = "";
        bearbeitung = "";
    }

    public Taschenrechner(string s)
    {
        eingabe = new String(s);
        bearbeitung = new String(s);
    }

    public void SetEingabe(string s)
    {
        eingabe = new String(s);
        bearbeitung = new String(s);
    }

    public string GetAnfrage()
    {
        return eingabe;
    }

    public int GetErgebnis()
    {
        return LeseAusdruck();
    }

    public char PeekZeichen()
    {
        if (bearbeitung.Length == 0) return '\\';
        while (bearbeitung[0] == ' ') { LeseZeichen(); }
        return bearbeitung[0];
    }

    public char LeseZeichen()
    {
        if (bearbeitung.Length == 0) return '\\';
        char current = bearbeitung[0];
        bearbeitung = bearbeitung[1..];
        return current;
    }

    public int LeseZahl()
    {
        int zahl = LeseZeichen() - '0';
        while (Char.IsDigit(PeekZeichen()))
        {
            zahl *= 10;
            zahl += (LeseZeichen() - '0');
        }
        return zahl;
    }

    public int LeseAusdruck()
    {
        char c = PeekZeichen();
        int erg;
        if (c == '+')
        {
            LeseZeichen();
            erg = LeseSummand();
        }
        else if (c == '-')
        {
            LeseZeichen();
            erg = -LeseSummand();
        }
        else
        {
            erg = LeseSummand();
        }
        do
        {
            c = PeekZeichen();
            if (c == '+')
            {
                LeseZeichen();
                erg += LeseSummand();
            }
            else if (c == '-')
            {
                LeseZeichen();
                erg -= LeseSummand();
            }
        } while ((c == '+') || (c == '-'));
        return erg;
    }

    public int LeseSummand()
    {
        int erg = LeseFaktor();
        char c;
        do
        {
            c = PeekZeichen();
            if (c == '*')
            {
                LeseZeichen();
                erg *= LeseSummand();
            }
            else if (c == '/')
            {
                LeseZeichen();
                erg /= LeseSummand();
            }
        } while ((c == '*') | (c == '/'));
        return erg;
    }

    public int LeseFaktor()
    {
        char c = PeekZeichen();
        int erg;
        if (c == '(')
        {
            LeseZeichen();
            erg = LeseAusdruck();
            c = LeseZeichen();
            if (c != ')')
            {
                throw new ArgumentException("FEHLER: ')' erwartet!");
            }
        }
        else
        {
            erg = LeseZahl();
        }
        return erg;
    }
}

