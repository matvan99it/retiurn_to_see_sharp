# retiurn_to_see_sharp
C# exercises to restart from where i stopeed

Gli esercizi sono suddivisi in **5 moduli tematici**, ciascuno con sfide di livello medio/alto e obiettivi bonus per migliorare le tue competenze.

---

## 🧩 Modulo 1 – OOP Avanzata

### 🧱 Esercizio 1: Sistema di noleggio veicoli
Crea un’app console che gestisce un sistema di noleggio auto:
- `Veicolo` (classe base) con proprietà come `Targa`, `Modello`, `PrezzoGiornaliero`.
- Sottoclassi: `Auto`, `Moto`, `Furgone`, ciascuna con proprietà specifiche.
- Interfaccia `INoleggiabile` con metodi `Noleggia()` e `Restituisci()`.
- Usa polimorfismo per stampare resoconti diversi a seconda del tipo di veicolo.
- Aggiungi una **classe GestoreNoleggi** che tiene traccia dei veicoli disponibili/noleggiati e calcola il totale incassato.

**🎯 Bonus:** implementa un sistema di **serializzazione JSON** per salvare e caricare i dati.

---

### 🧱 Esercizio 2: Gestione dipendenti con ereditarietà e interfacce
Crea un sistema per gestire un’azienda:
- Classe astratta `Dipendente` con proprietà comuni e metodo `CalcolaStipendio()`.
- Derivate: `Impiegato`, `Manager`, `Tecnico`.
- Aggiungi un’interfaccia `IPremiabile` con metodo `CalcolaPremio()`.
- Il manager riceve un bonus in base ai risultati del team.

**🎯 Bonus:** usa `List<Dipendente>` e LINQ per calcolare lo stipendio medio e il totale dei premi.

---

## ⚙️ Modulo 2 – LINQ e Collezioni

### 💡 Esercizio 3: Analisi di dati con LINQ
Dato un elenco di ordini (`Order` con `Cliente`, `Importo`, `Data`, `Categoria`):
- Trova i 3 clienti che spendono di più.
- Raggruppa per categoria e calcola la media degli importi.
- Filtra gli ordini dell’ultimo mese e ordina per data decrescente.

**🎯 Bonus:** scrivi una query LINQ “fluente” e una “query expression” che producono lo stesso risultato.

---

### 💡 Esercizio 4: Estensioni personalizzate
Crea una **classe statica di estensioni** che aggiunge funzionalità alle collezioni:
- Metodo `ToPrettyString()` che formatta gli oggetti in tabella.
- Metodo `Median()` per calcolare la mediana di una lista di numeri.
- Metodo `Chunk(int size)` per dividere una lista in sotto-liste di lunghezza fissa.

**🎯 Bonus:** usa `yield return` per rendere `Chunk()` lazily evaluated.

---

## ⚡ Modulo 3 – Async / Await

### 🌐 Esercizio 5: Download parallelo di dati
Simula il download di file da URL:
- Usa `HttpClient` con `async/await`.
- Mostra l’avanzamento dei download.
- Limita il numero di download concorrenti (usa `SemaphoreSlim`).

**🎯 Bonus:** implementa un “retry” automatico se un download fallisce.

---

## 🧠 Modulo 4 – Generics e Delegati

### 🧰 Esercizio 6: Repository generico
Crea una classe generica `Repository<T>` con operazioni CRUD:
- `Add(T item)`, `Remove(Predicate<T>)`, `Find(Func<T,bool>)`, `GetAll()`.
- Limita `T` a tipi che implementano un’interfaccia `IEntity` con `Id`.

**🎯 Bonus:** rendi il repository persistente tramite serializzazione JSON o XML.

---

### 🧰 Esercizio 7: Eventi e delegati
Simula un **sistema di sensori**:
- Classe `Sensore` con evento `OnMisuraRicevuta`.
- Classe `Monitor` che si iscrive e reagisce alle misure.
- Usa `EventHandler<T>` e `Action<T>` per gestire notifiche.

**🎯 Bonus:** implementa una pipeline di trasformazioni con **delegati compositi**.

---

## 🧩 Modulo 5 – Design Pattern

### 🏗️ Esercizio 8: Factory + Singleton
Implementa una **factory di notifiche**:
- Tipi di notifiche: `Email`, `SMS`, `Push`.
- `NotificationFactory` restituisce il tipo corretto in base a una stringa.
- Aggiungi un `Logger` come Singleton per tracciare ogni notifica inviata.

---

### 🏗️ Esercizio 9: Observer Pattern
Realizza un mini sistema di borsa:
- `Stock` notifica i suoi osservatori (`Investor`) quando il prezzo cambia.
- Ogni investor decide se “comprare” o “vendere”.
- Usa `IObservable<T>` e `IObserver<T>` oppure un’implementazione custom.

---

### 🏗️ Esercizio 10: Command Pattern
Crea un sistema di **undo/redo** per un editor di testo semplice:
- Comandi: `AddText`, `RemoveText`, `ReplaceText`.
- Ogni comando deve sapere come **eseguire** e **annullare** l’azione.
- Gestisci una stack per undo e redo.

---

## 🏁 Prossimi Passi
1. Segui la **roadmap settimanale** (in arrivo).
2. Lavora sugli esercizi in ordine crescente di complessità.
3. Consulta le **soluzioni passo passo** (in arrivo) per confrontare la tua implementazione.

---
