using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseAdvisor
{
    public class AdvisorEngine
    {

        // récupération des inputs utilisateur dans l'interface
        // gestion de l'advisor avec timer :
        // - push d'erreurs ponctuelles via méthodes
        // - tips et astuces pour l'utilisation de l'interface
        // - activation du tutoriel
        // - indications de corrections lexicales pour languageTool
        // tous les visiteurs doivent pouvoir remplacer dans la liste d'instructions une instruction standard par une instruction Error


        // - - - SCHEMA LOGIQUE - - -
        // Envoi de l'objet error à l'advisorEngine par l'un des visiteurs
        // Vérification par le FinalCheck de la présence de l'erreur dans la liste d'instructions finale
        // Traitement de l'erreur suivant le type et extraction des données de l'erreur
        // Mise en forme des données de l'erreur suivant le type
        // Mise à jour de l'Advisor
    }
}
