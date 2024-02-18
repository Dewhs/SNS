# SNS (système de Surveillance de Niveau Sonore) - [XAMARIN] Application mobile

## But du projet

SNS est un projet de fin d'études (BTS) qui a pour but de surveiller, et signaler via une colonne de LED (Vert, Orange, Rouge), si le niveau sonore dans une pièce est trop élevé (exmple d'utilisation : cantine scolaire).
La définition des seuils est faite par les utilisateurs authorisés via les interfaces mises à disposition (Interface web ou application mobile).

## Fonctionnement global du système

SNS est composé d'un dbmètre connecté à une raspberry pi qui gère la colonne de LED en fonction des seuils défini, et envoie les données sur un serveur web qui centralise toutes les données du système. Ces données sont ensuite accessibles via une interface web ainsi que via une application mobile.

Voici un shéma simplifié des parties du système nous concernant:

![shéma simplifié système SNS - Application mobile](https://imgur.com/1DYvJ7l.png)

## Autres parties du système

- [Interface web](https://github.com/Zzerkow/Sound_Level_Monitoring_Advanced_Technicians_Certificate_End_Year_Project)
- [Service web](https://github.com/lelinguine/supervision-services)
