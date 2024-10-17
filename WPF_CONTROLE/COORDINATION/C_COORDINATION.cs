using System.Collections.Generic;
using System.Windows;
using WPF_CONTROLE.ABSTRACTION;
using WPF_CONTROLE.NOTIFIABLE;

namespace WPF_CONTROLE.COORDINATION
{
  internal class C_COORDINATION : C_NOTIFIABLE
  {
    C_DATA La_Data;

    private List<C_EQUIPE> _Ma_Liste_Equipes;
    public List<C_EQUIPE> Ma_Liste_Equipes {
      get { return _Ma_Liste_Equipes; }
      set { _Ma_Liste_Equipes = value; Signale_Changement(); }
    }

    private C_EQUIPE _Equipe_Selectionnee;
    public C_EQUIPE Equipe_Selectionnee {
      get { return _Equipe_Selectionnee; }
      set { _Equipe_Selectionnee = value; Signale_Changement(); }
    }

    private List<C_SPORTIF> _Ma_Liste_Sportifs;
    public List<C_SPORTIF> Ma_Liste_Sportifs {
      get { return _Ma_Liste_Sportifs; }
      set { _Ma_Liste_Sportifs = value; Signale_Changement(); }
    }

    private C_SPORTIF _Sportif_Selectionnee;
    public C_SPORTIF Sportif_Selectionnee {
      get { return _Sportif_Selectionnee; }
      set { _Sportif_Selectionnee = value; Signale_Changement(); }
    }

    private List<C_SPORTIF> _Ma_Liste_All_Sportifs;
    public List<C_SPORTIF> Ma_Liste_All_Sportifs {
      get { return _Ma_Liste_All_Sportifs; }
      set { _Ma_Liste_All_Sportifs = value; Signale_Changement(); }
    }

    private C_SPORTIF _All_Sportif_Selectionnee;
    public C_SPORTIF All_Sportif_Selectionnee {
      get { return _All_Sportif_Selectionnee; }
      set { _All_Sportif_Selectionnee = value; Signale_Changement(); }
    }

    public C_COORDINATION()
    {
      La_Data = new C_DATA();
      Refresh_All();
    }
    
    internal void Refresh_All()
    {
      Ma_Liste_Equipes = La_Data.Get_All_Equipes();
      Ma_Liste_All_Sportifs = La_Data.Get_All_Sportifs();
    }

    internal void Charge_Liste_Sportifs_Pour_Equipe_Selectionnee()
    {
      if (Equipe_Selectionnee != null) {
        Ma_Liste_Sportifs = La_Data.Get_Sportifs_By_Equipe(Equipe_Selectionnee);
      }
    }

    internal void Supprime_Equipe()
    {
      La_Data.Supprime_Equipe(Equipe_Selectionnee);
      Refresh_All();
    }

    internal void Ajoute_Equipe(string P_Nom)
    {
      La_Data.Ajoute_Equipe(P_Nom);
      Refresh_All();
    }

    internal void Desinscrit_Sportif()
    {
      La_Data.Desinscrit_Sportif(Sportif_Selectionnee);
      Refresh_All();
    }

    internal void Inscrit_Sportif()
    {
      if (Ma_Liste_Sportifs.Count < 32) {
        La_Data.Inscrit_Sportif(All_Sportif_Selectionnee, Equipe_Selectionnee);
        Refresh_All();
      } else {
        MessageBox.Show("Equipe Complète !", "ERREUR", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }

    internal void Supprime_Sportif()
    {
      La_Data.Supprime_Sportif(All_Sportif_Selectionnee);
      Refresh_All();
    }

    internal void Ajoute_Sportif(string P_Nom, string P_Num)
    {
      La_Data.Ajoute_Sportif(P_Nom, P_Num);
      Refresh_All();
    }
  }
}