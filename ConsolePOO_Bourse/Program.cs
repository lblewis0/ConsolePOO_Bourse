//Je veux générer une bourse avec une liste d'actions disponibles à la vente
//Avec mon porte-feuille je veux pouvoir acheter vendre ces actions
//VERSION THREAD 1.1

using ConsolePOO_Bourse.Models;
using ConsolePOO_Bourse.Utils;
using System.Text;

class Program
{
    static Bourse bourse = new Bourse();
    static Personne personne = new Personne("Louis", "Boeckmans", "02-04-1995");
    static PorteFeuille portefeuille = new PorteFeuille(personne, 10000);
    static bool stillDo = true;
    static StringBuilder sb = new StringBuilder();
    static Actualiseur actBourse = new Actualiseur();
    static Timer timer;

    static void Main(string[] args)
    {
        #region Création des entreprises cotes en bourse
        Entreprise ent1 = new Entreprise("Apple Inc");
        Entreprise ent2 = new Entreprise("Microsoft Corporation");
        Entreprise ent3 = new Entreprise("Amazon Inc");
        Entreprise ent4 = new Entreprise("Google Inc");
        Entreprise ent5 = new Entreprise("Facebook");
        #endregion

        #region Création des actions dans bourse
        for (int i = 0; i < 10; i++)
        {
            ActionOrdinaire action = new ActionOrdinaire(ent1, bourse.Id, "Apple Inc", "AAPL", 100, 150.25M);
            bourse.ajouterAction(action);
        }

        for (int i = 0; i < 10; i++)
        {
            ActionOrdinaire action = new ActionOrdinaire(ent2, bourse.Id, "Microsoft Corporation", "MSFT", 100, 290.85M);
            bourse.ajouterAction(action);
        }

        for (int i = 0; i < 10; i++)
        {
            ActionOrdinaire action = new ActionOrdinaire(ent3, bourse.Id, "Amazon Inc", "AMZN", 100, 3450.2M);
            bourse.ajouterAction(action);
        }

        for (int i = 0; i < 10; i++)
        {
            ActionOrdinaire action = new ActionOrdinaire(ent4, bourse.Id, "Google Inc", "GOOGL", 100, 2550.75M);
            bourse.ajouterAction(action);
        }

        for (int i = 0; i < 10; i++)
        {
            ActionOrdinaire action = new ActionOrdinaire(ent5, bourse.Id, "Facebook", "FB", 100, 355.4M);
            bourse.ajouterAction(action);
        }
        #endregion

        timer = new Timer(ActualiserActions, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        BouclePrincipale();

        timer.Dispose();

    }

    static void BouclePrincipale()
    {
        do
        {
            int choix = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("                      ");

            switch (choix)
            {
                case 0:
                    lock (bourse)
                    {
                        lock (portefeuille)
                        {
                            portefeuille.Acheter(bourse);
                        }
                    }
                    break;
                case 1:
                    lock (bourse)
                    {
                        lock (portefeuille)
                        {
                            portefeuille.Vendre(bourse);
                        }
                    }
                    break;
                case 2:
                    break;
                case 3:
                    stillDo = false;
                    break;
                default:
                    break;

            }

            //Thread.Sleep(5000);

        } while (stillDo && !Console.KeyAvailable);

        Console.ReadKey(true);
    }

    static void ActualiserActions(object state)
    {
        lock (bourse)
        {
            lock (portefeuille)
            {
                actBourse.ActionsOrdinaires.Clear();
                actBourse.NouvellesValeurs.Clear();
                actBourse.AjouterAction(bourse.ActionsOrdinaires, portefeuille.ListeActions);
                actBourse.ActualiserActions();

                Console.Clear();
                bourse.AfficherListeActions();
                portefeuille.AfficherPortefeuille();

                sb.Clear();
                foreach (TypeAction a in Enum.GetValues<TypeAction>())
                {
                    sb.AppendLine($"{(int)a + 1} {a.ToString()}");
                }

                Console.WriteLine("PROGRAMME-----------------------------------------------------");
                Console.WriteLine(sb);
                Console.WriteLine("CHOIX PROGRAMME-----------------------------------------------");

            }
        }
    }

}



