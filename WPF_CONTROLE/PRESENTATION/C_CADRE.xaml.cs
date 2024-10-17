using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_CONTROLE.COORDINATION;

namespace WPF_CONTROLE
{
  /// <summary>
  /// Logique d'interaction pour MainWindow.xaml
  /// </summary>

  public partial class C_CADRE : Window
  {
    C_COORDINATION La_Coordination;
    public C_CADRE()
    {
      try {
        La_Coordination = new C_COORDINATION();
        InitializeComponent();
        DataContext = La_Coordination;
      }
      catch (Exception P_Erreur) {
        MessageBox.Show(P_Erreur.Message, "ERREUR !", MessageBoxButton.OK, MessageBoxImage.Error);
        Close();
      }
    }

    private void LSTB_Equipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (LSTB_Equipes.SelectedItems != null) {
        BTN_Supprimer_Equipe.IsEnabled = true;
        if (LSTB_All_Sportifs.SelectedItems != null) {
          BTN_Inscrit_Sportif.IsEnabled = true;
        }
        La_Coordination.Charge_Liste_Sportifs_Pour_Equipe_Selectionnee();
      } else {
        BTN_Supprimer_Equipe.IsEnabled = false;
        BTN_Inscrit_Sportif.IsEnabled = false;
        LSTB_Equipes = null;
      }
    }

    private void LSTB_Sportifs_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (LSTB_Sportifs.SelectedItems != null) {
        BTN_Desinscrire_Sportif.IsEnabled = true;
      } else {
        BTN_Desinscrire_Sportif.IsEnabled = false;
      }
    }

    private void LSTB_All_Sportifs_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (LSTB_All_Sportifs.SelectedItems != null) {
        BTN_Supprime_Sportif.IsEnabled = true;
        if (LSTB_Equipes.SelectedItems != null) {
          BTN_Inscrit_Sportif.IsEnabled = true;
        }
      } else {
        BTN_Supprime_Sportif.IsEnabled = false;
        BTN_Inscrit_Sportif.IsEnabled = false;
      }
    }

    private void BTN_Supprimer_Equipe_Click(object sender, RoutedEventArgs e)
    {
      La_Coordination.Supprime_Equipe();
      BTN_Supprimer_Equipe.IsEnabled = false;
    }

    private void BTN_Ajoute_Equipe_Click(object sender, RoutedEventArgs e)
    {
      La_Coordination.Ajoute_Equipe(TXTB_Equipe_A_Ajouter.Text);
      TXTB_Equipe_A_Ajouter.Text = null;
      BTN_Ajoute_Equipe.IsEnabled = false;
    }

    private void TXTB_Equipe_A_Ajouter_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (TXTB_Equipe_A_Ajouter.Text != null) {
        BTN_Ajoute_Equipe.IsEnabled = true;
      }
    }

    private void BTN_Desinscrire_Sportif_Click(object sender, RoutedEventArgs e)
    {
      La_Coordination.Desinscrit_Sportif();
      BTN_Supprime_Sportif.IsEnabled = false;
    }

    private void BTN_Inscrit_Sportif_Click(object sender, RoutedEventArgs e)
    {
      La_Coordination.Inscrit_Sportif();
      BTN_Supprime_Sportif.IsEnabled = false;
    }

    private void BTN_Supprime_Sportif_Click(object sender, RoutedEventArgs e)
    {
      La_Coordination.Supprime_Sportif();
      BTN_Supprime_Sportif.IsEnabled = false;
    }

    private void BTN_Ajoute_Sportif_Click(object sender, RoutedEventArgs e)
    {
      La_Coordination.Ajoute_Sportif(TXTB_Nom_Sportif_A_Ajouter.Text, TXTB_Num_Sportif_A_Ajouter.Text);
      TXTB_Num_Sportif_A_Ajouter.Text = null;
      TXTB_Nom_Sportif_A_Ajouter.Text = null;
      BTN_Ajoute_Sportif.IsEnabled = false;
    }

    private void TXTB_Nom_Sportif_A_Ajouter_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (TXTB_Num_Sportif_A_Ajouter.Text != null && TXTB_Nom_Sportif_A_Ajouter.Text != null) {
        BTN_Ajoute_Sportif.IsEnabled = true;
      }
    }

    private void TXTB_Num_Sportif_A_Ajouter_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (TXTB_Num_Sportif_A_Ajouter.Text != null && TXTB_Nom_Sportif_A_Ajouter.Text != null) {
        BTN_Ajoute_Sportif.IsEnabled = true;
      }
    }
  }
}
