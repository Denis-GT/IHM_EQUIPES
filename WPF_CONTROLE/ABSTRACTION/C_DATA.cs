using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CONTROLE.ABSTRACTION
{
  internal class C_DATA
  {
    ABSTRACTION.C_BASE La_Base = new ABSTRACTION.C_BASE();

    List<C_EQUIPE> Les_Equipes;
    List<C_SPORTIF> Les_Sportifs;

    public C_DATA()
    {
      Refresh_All();
    }

    public void Refresh_All()
    {
      Les_Equipes = La_Base.Les_Equipes.ToList();
      Les_Sportifs = La_Base.Les_Sportifs.ToList();
    }

    public List<C_EQUIPE> Get_All_Equipes()
    {
      return Les_Equipes;
    }

    public List<C_SPORTIF> Get_All_Sportifs()
    {
      return Les_Sportifs;
    }

    public List<C_SPORTIF> Get_Sportifs_By_Equipe(C_EQUIPE P_Equipe)
    {
      List<C_SPORTIF> Sportifs_Trouvee = new List<C_SPORTIF>();
      foreach (var Sportif in Les_Sportifs) {
        if (Sportif.Equipe_Id == P_Equipe.Id) {
          Sportifs_Trouvee.Add(Sportif);
        }
      }
      return Sportifs_Trouvee;
    }

    public void Supprime_Equipe(C_EQUIPE P_Equipe)
    {
      La_Base.Les_Equipes.Remove(P_Equipe);
      La_Base.SaveChanges();
      Refresh_All();
    }

    public void Ajoute_Equipe(string P_Equipe)
    {
      C_EQUIPE Equipe_Ajoutee = new C_EQUIPE() { Nom = P_Equipe };
      La_Base.Les_Equipes.Add(Equipe_Ajoutee);
      La_Base.SaveChanges();
      Refresh_All();
    }

    public void Desinscrit_Sportif(C_SPORTIF P_Sportif)
    {
      P_Sportif.Equipe_Id = null;
      La_Base.SaveChanges();
      Refresh_All();
    }

    public void Inscrit_Sportif(C_SPORTIF P_Sportif, C_EQUIPE P_Equipe)
    {
      P_Sportif.Equipe_Id = P_Equipe.Id;
      La_Base.SaveChanges();
      Refresh_All();
    }

    public void Supprime_Sportif(C_SPORTIF P_Sportif)
    {
      La_Base.Les_Sportifs.Remove(P_Sportif);
      La_Base.SaveChanges();
      Refresh_All();
    }

    public void Ajoute_Sportif(string P_Nom, string P_Num)
    {
      C_SPORTIF Sportif_A_Ajouter = new C_SPORTIF() {  Nom = P_Nom.ToUpper(), NumAdherent = P_Num };
      La_Base.Les_Sportifs.Add(Sportif_A_Ajouter);
      La_Base.SaveChanges();
      Refresh_All();
    }
  }
}
