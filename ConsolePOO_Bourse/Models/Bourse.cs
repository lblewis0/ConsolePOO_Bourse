using Pastel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePOO_Bourse.Models
{
    public class Bourse
    {
        //ATTRIBUTS--------------------------------------------------------------------------------
        #region Attributs
        private int _id = 1;

        #endregion
        //CONSTRUCTEURS----------------------------------------------------------------------------
        #region Constructeurs
        public Bourse()
        {
            ActionsOrdinaires = new List<ActionOrdinaire>();
        }

        #endregion
        //PROPRIETES-------------------------------------------------------------------------------
        #region Proprietes
        public List <ActionOrdinaire> ActionsOrdinaires { get; set; }

        public int Id { get { return _id; } set { _id = value;} }


        #endregion
        //METHODES---------------------------------------------------------------------------------
        #region Methodes

        public void AfficherListeActions()
        {
            List<string> actions = new List<string>();
            int nbAction = 0;
            int indexAction = 0;
            int longueurNomAction = 30;

            StringBuilder sb = new StringBuilder();
            sb.Append($"BOURSE--------------------------------------------------------\n");

            List<ActionOrdinaire> list = ActionsOrdinaires.DistinctBy(a => a.NomAction).ToList();

            foreach (ActionOrdinaire action in  list)
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

                nbAction = ActionsOrdinaires.Where(a => a.NomAction == action.NomAction).Count();
                sb.Append($"{action.NomAction.PadRight(25)} - {action.SymboleAction.PadRight(5)} - {action.PrixAction.ToString("0.00").PadRight(8)} - {stringVariationAction.PadRight(7)} - {nbAction.ToString().PadRight(2)}\n");
            }

            Console.WriteLine(sb);   
        }

        public void ajouterAction(ActionOrdinaire a)
        {
            _id += 1;
            a.NbAction += 1;
            ActionsOrdinaires.Add(a);
        }

        #endregion

        //EVENEMENTS-------------------------------------------------------------------------------(2)
        #region Evenements
        //Crée un événement du type de délégué déclaré dans le namespace
        //public event PassageEnNegatifDelegate PassageEnNegatifEvent;
        //public event Action<Bourse> AjoutActionEvent;

        //DECLENCHEUR D'EVENEMENTS-----------------------------------------------------------------(3)
        //public void RaiseAjoutActionEvent()
        //{
        //    //Déclanche les méthodes inclues dans le délégué
        //    //Les méthodes seront abonnées dans banque
        //    AjoutActionEvent?.Invoke(this);
        //}

        //public void Abonement(ActionOrdinaire a)
        //{
        //    this.AjoutActionEvent += AjoutActionAction(a);
        //}
        #endregion

        //SURCHARGE OPERATEUR----------------------------------------------------------------------
        #region Surcharges operateurs

        #endregion
    }
}
