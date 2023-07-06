using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePOO_Bourse.Models
{
    public class Actualiseur
    {
        //ATTRIBUTS--------------------------------------------------------------------------------
        #region Attributs

        #endregion
        //CONSTRUCTEURS----------------------------------------------------------------------------
        #region Constructeurs
        public Actualiseur()
        {
            ActionsOrdinaires = new List<ActionOrdinaire>();
            NouvellesValeurs = new Dictionary<string, decimal>();
        }

        #endregion
        //PROPRIETES-------------------------------------------------------------------------------
        #region Proprietes
        public List<ActionOrdinaire> ActionsOrdinaires { get; set; }

        public Dictionary<string, decimal> NouvellesValeurs { get; set; }


        #endregion
        //METHODES---------------------------------------------------------------------------------
        #region Methodes

        public void ActualiserActions()
        {
            foreach (ActionOrdinaire a in ActionsOrdinaires)
            {
                if (!NouvellesValeurs.ContainsKey(a.NomAction))
                {
                    NouvellesValeurs.Add(a.NomAction, a.PrixAction);
                }
            }

            foreach (string na in NouvellesValeurs.Keys)
            {
                decimal prixActuel = NouvellesValeurs[na];

                int r_pourcentage = 0;
                int r_signe = 0;

                Random randomPourcentage = new Random();
                Random randomSigne = new Random();

                r_pourcentage = randomPourcentage.Next(31);
                r_signe = randomSigne.Next(3) == 0 ? -1 : 1; 

                //signe = (decimal)((randomSigne.Next() * 2) - 1);

                decimal nouveauPrix = prixActuel + ((decimal)r_signe * (decimal)r_pourcentage/1000 * prixActuel);

                NouvellesValeurs[na] = nouveauPrix;
            }

            foreach (ActionOrdinaire a in ActionsOrdinaires)
            {
                decimal nouveauPrix = NouvellesValeurs.GetValueOrDefault(a.NomAction);

                decimal variationPrix = (nouveauPrix - a.PrixAction) / a.PrixAction;

                a.PrixAction = nouveauPrix;

                a.VariationAction = variationPrix;
            }

        }

        public void AjouterAction(List<ActionOrdinaire> actionBourses, List<ActionOrdinaire> actionPorteFeuille)
        {
            foreach (ActionOrdinaire ab in actionBourses)
            {
                ActionsOrdinaires.Add(ab);
            }

            foreach (ActionOrdinaire ap in actionPorteFeuille)
            {
                ActionsOrdinaires.Add(ap);
            }
        }

        #endregion

        //EVENEMENTS-------------------------------------------------------------------------------(2)
        #region Evenements
       

        //DECLENCHEUR D'EVENEMENTS-----------------------------------------------------------------(3)
        
        #endregion

        //SURCHARGE OPERATEUR----------------------------------------------------------------------
        #region Surcharges operateurs

        #endregion
    }
}
