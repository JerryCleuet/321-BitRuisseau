## Analyse fonctionnelle

Dans le cadre de mon projet, j'ai réalisé une analyse fonctionnelle permettant de mieux séparer les parties à développer / mettre en place. Dans ce document, on peut retrouver une explication sur la réalisation des User Stories ainsi que voir l'ensemble des maquettes crées et si elles ont été pertinentes / ou non.

### User Stories

Toutes mes User Stories se trouvent dans le [projet GitHub](https://github.com/users/JerryCleuet/projects/6) de mon repository [321-BitRuisseau](https://github.com/JerryCleuet/321-BitRuisseau).
J'ai réalisé chaque User Story de la manière suivante :

- Tout d'abord, sélectionner une fonctionnalité ou une tâche clé du projet
- La définir avec le modèle "En tant que, je veux, dans le but de"
- Lui assigner des tests unitaires précis et atomiques
- Finalement, déplacer cette User Story dans les colonnes du Kanban de GitHub Project au cours du projet (Ce point a été un peu mis de côté par faute d'attention)

### Maquettes

J'ai réalisé les maquettes de mon application avec l'outil Figma, très utile pour créer des modèles précis et agréables au regard. La plupart d'entre elles étaient surévaluées par rapport au travail demandé/rendu, et même parfois un peu incorrectes à cause d'erreurs de compréhension de ma part face au projet en général.

## La liste des maquettes

![Liste médiathèques](maquettes/Liste-mediatheques.png)

Quand j'ai réalisé cette maquette, je pensais qu'il fallait en fait créer des médiathèques remplies de médias et les publier aux autres. Je n'ai donc pas ce résultat, mais une liste des Mediacenter représentant toute personne sur le réseau MQTT qui a correctement configuré ses messages et qui envoie sur le bon topic.

## La liste des médias disponibles

![Liste medias](maquettes/Liste-medias.png)

Dans mon application, la liste des médias s'affiche un peu différemment, mais dans l'ensemble l'idée reste la même. On ne peut cependant pas effectuer le CRUD sur les médias dans mon application finale, et l'affichage est légèrement différent.

## Ajouter un média à une médiathèque

![Ajouter media](maquettes/Ajouter-media.png)

Cette maquette a été un peu futile au final : le second but de ce projet n'était pas d'ajouter des médias à des médiathèques, mais bien de sélectionner un dossier de médias, les afficher et les lire.

## Confirmer la suppresion d'un élément

![Confirm suppression](maquettes/Confirm-suppression.png)

## Modifier la description d'un média

![Modif media](maquettes/Modif-media.png)

Même remarque, les opérations CRUD sur les médias n'étaient pas le vrai but de ce projet.

### Constat

Lors de ce projet, beaucoup de points ont été simplifés pour mettre l'accent sur le but réel : pouvoir échanger des messages sur un topic précis avec MQTT et pouvoir réagir à ces messages. Presque tout ce qui touche au CRUD (surtout POST, DELETE et PUT), ce n'était pas vraiment le but principal.
