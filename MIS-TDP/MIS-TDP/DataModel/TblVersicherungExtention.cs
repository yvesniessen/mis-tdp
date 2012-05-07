using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;


public partial class TblVersicherung
{
    public override bool Equals(object obj)
    {
        TblVersicherung other = obj as TblVersicherung;

        if (other == null)
            return false;

        if (!this._VersicherungNr.Equals(other._VersicherungNr))
            return false;

        if (!this._Name.Equals(other._Name))
            return false;

        return true;
    }

    public override int GetHashCode()
    {
        return this._VersicherungNr;
    }
}
