using Pastel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePOO_Bourse.Models
{
    public class PorteFeuille
    {
        //ATTRIBUTS--------------------------------------------------------------------------------
        #region Attributs

        #endregion
        //CONSTRUCTEURS----------------------------------------------------------------------------
        #region Constructeurs
        public PorteFeuille(Personne gestionnairePortefeuille, decimal capital)
        {
            GestionnairePortefeuille = gestionnairePortefeuille;
            CapitalDepart = capital;
            Capital = CapitalDepart;
            ValeurTotaleActions = 0;
            TheoricalCapital = capital;
            ListeActions = new List<ActionOrdinaire>();
        }

        #endregion
        //PROPRIETES-------------------------------------------------------------------------------
        #region Proprietes

        public Personne GestionnairePortefeuille { get; set; }

        public List<ActionOrdinaire> ListeActions { get; set; }

        public decimal CapitalDepart { get; set; }

        public decimal Capital { get; set; }

        public decimal ValeurTotaleActions { get; set; }

        public decimal TheoricalCapital { get; set; }

        public decimal BeneficePerte { get; set; }

        #endregion
        //METHODES---------------------------------------------------------------------------------
        #region Methodes
        public void Acheter(Bourse b)
        {
            Console.WriteLine("ACHAT D'ACTION------------------------------------------------");

            string symboleAction = "";
            int quantite = 0;
            string s_quantite = "";

            Console.Write("Actions à acheter [SYMBOL]: ");

            string saisie = Console.ReadLine();
            int indexS = saisie.IndexOf(":");

            symboleAction = saisie.Substring(indexS + 1).Trim();

            Console.Write("Quantite à acheter: ");

            saisie = Console.ReadLine();
            quantite = int.Parse(saisie.Substring(indexS + 1).Trim());

            Console.WriteLine("");

            List<ActionOrdinaire> actionsAchetee = b.ActionsOrdinaires.Where(a => a.SymboleAction == symboleAction).Take(quantite).ToList();

            decimal coutAchat = new decimal();

            if (actionsAchetee.Count < quantite)
            {
                Console.WriteLine("Nombres d'action indisponible");
                Console.ReadKey();
            }
            else
            {
                foreach (ActionOrdinaire action in actionsAchetee)
                {
                    coutAchat += action.PrixAction;
                }

                if (coutAchat <= Capital)
                {
                    foreach (ActionOrdinaire action in actionsAchetee)
                    {
                        b.ActionsOrdinaires.Remove(action);
                        this.ListeActions.Add(action);

                        Capital -= action.PrixAction;
                    }
                }
                else
                {
                    Console.WriteLine("Capital insuffisant");
                    Console.ReadKey();
                }
                
            }
        }

        public void Vendre(Bourse b)
        {
            Console.WriteLine("VENTE D'ACTION------------------------------------------------");

            string symboleAction = "";
            int quantite = 0;
            string s_quantite = "";

            Console.Write("Actions à vendre [SYMBOL]: ");

            string saisie = Console.ReadLine();
            int indexS = saisie.IndexOf(":");

            symboleAction = saisie.Substring(indexS + 1).Trim();

            Console.Write("Quantite à vendre: ");

            saisie = Console.ReadLine();
            quantite = int.Parse(saisie.Substring(indexS + 1).Trim());

            Console.WriteLine("");

            List<ActionOrdinaire> actionsVendue = ListeActions.Where(a => a.SymboleAction == symboleAction).Take(quantite).ToList();

            if (actionsVendue.Count < quantite)
            {
                Console.WriteLine("Impossible de vendre autant d'actions, veuillez réessayer");
            }
            else
            {
                foreach (ActionOrdinaire action in actionsVendue)
                {
                    b.ActionsOrdinaires.Add(action);
                    this.ListeActions.Remove(action);

                    Capital += action.PrixAction;
                }
            }
        }

        public void SetValeurTotaleActions()
        {
            ValeurTotaleActions = 0;

            foreach (ActionOrdinaire ao in ListeActions)
            {
                ValeurTotaleActions += ao.PrixAction;
            }
        }

        public void SetTheoricalCapital()
        {
            SetValeurTotaleActions();
            TheoricalCapital = 0;

            TheoricalCapital = Capital + ValeurTotaleActions;
            BeneficePerte = TheoricalCapital - CapitalDepart;

        }

        public void AfficherPortefeuille()
        {
            List<string> actions = new List<string>();
            int nbAction = 0;

            SetTheoricalCapital();

            string s_BeneficePerte = "";

            if (BeneficePerte >= 0)
            {
                s_BeneficePerte = string.Format("+{0:0.00}", BeneficePerte).Pastel("#00FF00");
            }
            else
            {
                s_BeneficePerte = string.Format("{0:0.00}", BeneficePerte).Pastel("#e00014");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"PORTE FEUILLE-------------------------------------------------\n");
            sb.Append($"Capital depart      : {CapitalDepart.ToString("0.00").PadRight(8)} $\n");
            sb.Append($"Capital             : {Capital.ToString("0.00").PadRight(8)} $\n");
            sb.Append($"Valeur actions      : {ValeurTotaleActions.ToString("0.00").PadRight(8)} $\n");
            sb.Append($"Valeur portefeuille : {TheoricalCapital.ToString("0.00").PadRight(8)} $\n");
            sb.Append($"Bénéfice/Perte      : {s_BeneficePerte.PadRight(7)} $\n");
            sb.Append($"\n");
            sb.Append($"ACTIONS-------------------------------------------------------\n");

            List<ActionOrdinaire> list = ListeActions.DistinctBy(a => a.NomAction).ToList();

            foreach (ActionOrdinaire action in list)
            {
                decimal tempVariationAction = action.VariationAction * 100;

                string stringVariationAction = "";

                if (tempVariationAction >= 0)
                {
                    stringVariationAction = string.Format("+{0:0.00} %", tempVariationAction).Pastel("#00FF00");
                }
                else
                {
                    stringVariationAction = string.Format("{0:0.00} %", tempVariationAction).Pastel("#e00014");
                }

                nbAction = ListeActions.Where(a => a.NomAction == action.NomAction).Count();
                sb.Append($"{action.NomAction.PadRight(25)} - {action.SymboleAction.PadRight(5)} - {action.PrixAction.ToString("0.00").PadRight(8)} - {stringVariationAction.PadRight(7)} - {nbAction.ToString().PadRight(2)}\n");
            }

            Console.WriteLine(sb);

        }

        #endregion
        //METHODES QUI DECLENCHE UN EVENEMENT------------------------------------------------------
        #region Methodes evenements

        #endregion
        //SURCHARGE OPERATEUR----------------------------------------------------------------------
        #region Surcharges operateurs

        #endregion
    }
}
