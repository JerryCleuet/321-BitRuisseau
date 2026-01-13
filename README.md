# Projet 321-BitRuisseau

## Description

Ce projet a pour objectif de mettre en place une **communication en temps réel via le protocole MQTT**.  
Il permet à plusieurs utilisateurs de :

- **Envoyer des messages** sur un **topic MQTT précis**
- **Recevoir les messages** publiés par les autres utilisateurs
- **Afficher les messages** dans une liste
- **Afficher l’émetteur du message**

Le projet est développé avec **Visual Studio 2022** et versionné sur **GitHub**.

---

## Fonctionnalités

- Connexion à un **broker MQTT** (Celui fournit par l'ETML)
- Publication de messages sur un **topic commun** (Dans ce cas, **powercher/bitruisseau**)
- Abonnement à ce topic pour recevoir les messages
- Affichage en temps réel :
  - du nom des expéditeurs dans une liste
- Interface simple et lisible
- MediaPlayer fonctionnel permettant de choisir son dossier de fichiers audio

---

## Technologies utilisées

- **Langage** : C#
- **IDE** : Visual Studio 2022
- **Protocole** : MQTT
- **Broker MQTT** : (ex. Mosquitto, HiveMQ, etc.)
- **Versioning** : Git / GitHub

---

## Installation et configuration

### 1. Prérequis

- Visual Studio 2022
- Un broker MQTT fonctionnel

---

### 2️. Cloner le projet

```bash
git clone https://github.com/JerryCleuet/321-BitRuisseau
```
