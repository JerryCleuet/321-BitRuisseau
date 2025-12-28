## 24.11.25

- Clone: OK
- Journal: KO: je ne sais pas lequel regarder: Excel ou gitjournal ? Supprimez-en un
  - Intégrez le gitjournal en copie, pas en submodule, ça crée des problèmes (voir avec Eliott)
- Projet: OK
- User story: KO. Pas de tests d'acceptance. Ajoutez-les, ainsi que les maquettes dans vos US
- Git : OK
- Implémentation: J'imagine que ça fonctionne chez vous, mais pas chez moi: crash sur "var medias = Directory.GetFiles(mediaPath);".

- Global: Pas au niveau attendu

## 80%

- Réalisation du player standalone:
  - L'application crashe si je sélectionne un dossier qui ne contient pas de musique
  - Vous avez de belles maquettes, mais elles ne semblent pas vous avoir servi puisque le résultat ne leur ressemble pas du tout. C'est donc du temps qui a été gaspillé, dommage.
- Réalisation du player connecté:
  - Il n'y a aucune analyse fonctionnelle de la partie connectée
  - Il y a du code pour la découverte -> à finaliser lors du challenge
- Qualité du code:
  - Choix des identificateurs: changez Form1 / Form2 en de vrai noms
  - Usage abusif de `var`
  - Certains commentaires sont en anglais, d'autres en français -> à uniformiser
- Maîtrise technique:
  - Form2.cs:58 code dépendant de l'environnement de dev -> à supprimer
  - J'aimerais que vous m'expliquiez ce qui se passe en MQTTService.cs:42
- Autonomie: OK
- Livraison: pas de notification
- Journal de travail: OK
- Git: OK

- En résumé:
  - Vous avez fourni un travail conséquent (2h40 selon votre journal) pour une analyse dont on ne retrouve rien dans le produit final. C'est dommage, ce temps a été perdu.
  - Votre projet Github semble être à l'abandon. Selon lui, vous n'avez encore rien accompli, ce qui n'est pas vrai.
  - Bugs à corriger, qualité à améliorer
  - Faire une release finale impeccable
