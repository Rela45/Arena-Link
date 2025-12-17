# Game-Project-Arena-Link

# ARENA LINK

**Multiplayer Arena Game (Unity + C#) con Editor Tools e Backend Live Ops**

---

## 1. Overview

Arena Link è un mini-gioco multiplayer online (2–8 giocatori) sviluppato in Unity con C#, progettato come **progetto portfolio professionale**.

Il focus non è sul contenuto artistico, ma su:

* architettura del codice
* networking multiplayer
* integrazione backend
* strumenti per il team (Editor Tools)

Questo progetto dimostra competenze richieste per ruoli **Gameplay Programmer**, **Multiplayer Programmer** e **Tools Programmer**.

---

## 2. Tech Stack

### Core

* Unity LTS (URP)
* C# (.NET / Unity API)

### Multiplayer

* Photon Fusion *(server authoritative)*

### Backend

* PlayFab

  * Authentication
  * Player Data
  * Leaderboards
  * Telemetry

### Tooling

* Unity Editor scripting
* ScriptableObjects
* Git + GitHub
* GitHub Actions (CI/CD)

---

## 3. Gameplay Design

### Genere

Top-down multiplayer arena action

### Meccaniche

* Movimento
* Dash con cooldown
* Attacco base
* Abilità secondaria
* Sistema vita e respawn
* Punteggio

### Match

* 2–8 giocatori
* Mappe piccole
* Durata 3–5 minuti
* Win condition basata su punteggio

---

## 4. Multiplayer Architecture

### Modello

* Server authoritative
* Sincronizzazione dello stato dei player
* Event-driven gameplay events

### Sistemi implementati

* Lobby & matchmaking
* Ready system
* Match state machine
* Player disconnection handling

---

## 5. Backend Integration (PlayFab)

### Funzionalità

* Login anonimo / email
* Player profile
* Statistiche persistenti
* Leaderboard globale
* Match telemetry

---

## 6. Editor Tools

### Arena Level Editor

Custom Unity Editor Window per:

* Creazione mappe
* Posizionamento spawn point
* Ostacoli e pickup
* Salvataggio in ScriptableObject

### Match Config Tool

Inspector personalizzato per:

* Durata match
* Win condition
* Cooldown abilità
* Spawn rate

---

## 7. Code Architecture

### Design Principles

* Separation of Concerns
* Modularità
* Event-based communication
* Data-driven design (ScriptableObjects)

### Folder Structure

```
Assets/
 ├── Scripts/
 │   ├── Core/
 │   ├── Gameplay/
 │   ├── Multiplayer/
 │   ├── Backend/
 │   ├── UI/
 │   ├── Tools/
 │   └── Utils/
 ├── ScriptableObjects/
 ├── Prefabs/
 ├── Scenes/
 └── Art/
```

---

## 8. Key Classes

### Core

* GameManager
* MatchStateMachine
* ServiceLocator

### Gameplay

* PlayerController
* AbilitySystem
* HealthComponent

### Multiplayer

* NetworkPlayer
* NetworkMatchManager
* LobbyManager

### Backend

* PlayFabAuthService
* PlayerDataService
* LeaderboardService

### Tools

* ArenaEditorWindow
* ArenaData
* MatchConfigEditor

---

## 9. Performance & Quality

* Object pooling
* Riduzione GC allocations
* Unity Profiler utilizzato
* Frame rate stabile

---

## 10. Builds

* Windows Standalone
* Android APK

---

## 11. Demo

* 🎥 Video demo (2–3 minuti)
* 🎮 Build giocabile

*(link da aggiungere)*

---

## 12. What This Project Demonstrates

* Uso professionale di Unity e C#
* Multiplayer networking
* Backend live-service
* Tool development
* Architettura scalabile
* Pipeline reale di sviluppo

---

## 13. Future Improvements

* Bot AI
* Ranked matchmaking
* Replay system
* ECS/DOTS experimentation

---

## Author

Sviluppato come progetto portfolio professionale.
