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


public partial class TblFabrikat
{
    public override bool Equals(object obj)
    {
        TblFabrikat other = obj as TblFabrikat;

        if (other == null)
            return false;

        if (!this._ID.Equals(other._ID))
            return false;

        if (!this._Bezeichnung.Equals(other._Bezeichnung))
            return false;

        return true;
    }

    public override int GetHashCode()
    {
        return this._ID;
    }
}
