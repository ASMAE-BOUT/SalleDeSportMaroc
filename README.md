MarocActive est une application web conçue pour gérer un centre sportif à Rabat, offrant une plateforme intuitive pour les utilisateurs souhaitant découvrir et s'inscrire à des cours collectifs, consulter les profils des coachs, et gérer leurs abonnements. L'objectif principal est de fournir une expérience utilisateur fluide et moderne, tout en permettant aux administrateurs de gérer facilement les cours et les coachs.

Fonctionnalités Principales
Barre de navigation : Présente sur toutes les pages, avec des liens vers "Accueil", "Abonnements", "Cours", "Coachs", "Contact", et "Espace Admin". Elle est responsive et se transforme en menu hamburger sur mobile.
Page d'accueil : Affiche un message de bienvenue ("Bienvenue à MarocActive ! Le centre sportif de référence à Rabat") avec un bouton orange "Voir nos abonnements". Une section "Pourquoi choisir MarocActive ?" met en avant des avantages comme "Équipements modernes", "Coachs certifiés", et "Cours variés".
Page des abonnements : Présente un tableau comparatif des abonnements (Mensuel à 250 MAD, Trimestriel à 700 MAD, Annuel à 2500 MAD) avec des boutons "S’abonner". Une section FAQ répond à des questions courantes.
Page des cours : Liste les cours disponibles (Yoga & Relaxation, CrossFit Intensif, Zumba Énergique) avec des descriptions et des points forts (programmes adaptés, suivi personnalisé, accès libre ou abonnement spécifique).
Page des coachs : Affiche les profils des coachs (Youssef El Amrani, Sara Bennani, Khalid Ouchen, Fatima Zahra Idrissi) sous forme de cartes avec photos circulaires, spécialités, et boutons "Détails". Une section "Témoignages" fictive est incluse.
Page de contact : Contient un formulaire de contact et une carte fictive centrée à Rabat pour les informations de localisation.
Espace Admin : Permet aux administrateurs de gérer les cours et les coachs (ajouter, modifier, supprimer).
Technologies Utilisées
Backend : ASP.NET Core (C#) avec \textit{CoursController} et \textit{CoachController} pour gérer les fonctionnalités.
Frontend : Bootstrap 5 pour une interface responsive et moderne.
Base de données : Non spécifiée dans cette version, mais conçue pour être compatible avec Entity Framework (par exemple, SQL Server).
Palette de couleurs : Noir (#000000) pour les titres et textes, orange (#FF9900) pour les boutons, et blanc pour les textes sur fond noir (comme le pied de page).
Installation et Exécution
Prérequis :
.NET SDK 6.0 ou supérieur.
Visual Studio 2022 (ou tout autre IDE compatible avec ASP.NET Core).
Navigateur moderne (Chrome, Firefox, etc.).
Étapes :
Clonez le dépôt :
bash

Copy
git clone [https://github.com/votre-utilisateur/MarocActive.git](https://github.com/ASMAE-BOUT/SalleDeSportMaroc.git)
Naviguez dans le dossier du projet :
bash

Copy
cd MarocActive
Restaurez les dépendances :
bash

Copy
dotnet restore
Lancez l’application :
bash

Copy
dotnet run
Accédez à l’application via https://localhost:5001 (ou le port configuré).
Configuration : Aucune base de données n’est configurée dans cette version. Les données (cours, coachs) sont statiques. Pour une version complète, configurez une base de données avec Entity Framework.
Contributions
Les contributions sont les bienvenues ! Si vous souhaitez contribuer :

Forkez le projet.
Créez une branche pour votre fonctionnalité (git checkout -b feature/nouvelle-fonctionnalite).
Soumettez une pull request avec une description claire de vos changements.
Perspectives d’Amélioration
Implémenter une base de données réelle pour stocker les cours, coachs, et abonnements.
Ajouter une fonctionnalité de réservation de séances d’essai gratuites.
Intégrer un système de paiement sécurisé via PayPal.
Améliorer l’interface avec des images pour les cours et des profils plus détaillés pour les coachs.
