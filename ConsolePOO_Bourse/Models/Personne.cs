using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePOO_Bourse.Models
{
    public class Personne : Proprietaire
    {
        //ATTRIBUTS--------------------------------------------------------------------------------
        #region Attributs

        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;

        #endregion

        //CONSTRUCTEURS----------------------------------------------------------------------------
        #region Constructeurs
        public Personne(string firstName, string lastName, string r_birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            string[] bDay = r_birthDate.Split('-');
            BirthDate = new DateTime(int.Parse(bDay[2]), int.Parse(bDay[1]), int.Parse(bDay[0]));
        }
        #endregion

        //PROPRIETES-------------------------------------------------------------------------------
        #region Proprietes

        public string FirstName
        {
            get { return _firstName; }
            private set
            {
                if (value.Trim() == "")
                {
                    return;
                }
                _firstName = value.Trim();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            private set
            {
                if (value.Trim() == "")
                {
                    return;
                }
                _lastName = value.Trim();
            }
        }

        public DateTime BirthDate { get; private set; }

        public List<ActionOrdinaire> Actions { get; set; }

        #endregion

        //METHODES---------------------------------------------------------------------------------
        #region Methodes
        public override string ToString()
        {
            return $"--------------- Person -------------\n" +
                   $"Prenom: {FirstName}\n" +
                   $"Nom: {LastName}\n" +
                   $"Date de naissance: {BirthDate}\n";
        }
        #endregion

        //SURCHARGE OPERATEUR----------------------------------------------------------------------
        #region Surcharges operateurs
        public static bool operator ==(Personne p1, Personne p2)
        {
            return p1.FirstName == p2.FirstName && p1.LastName == p2.LastName && p1.BirthDate == p2.BirthDate;
        }

        public static bool operator !=(Personne p1, Personne p2)
        {
            //retourne l'inverse de l'operateur ==
            //Donc si l'égalité précédente renvoit faux parce que pas égal == est faux
            //Renvoie vraie dans cette surcharge != est vraie
            return !(p1 == p2);
        }
        #endregion
    }
}
